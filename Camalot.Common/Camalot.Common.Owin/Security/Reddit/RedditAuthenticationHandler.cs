using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Newtonsoft.Json.Linq;
using Camalot.Common.Extensions;
using Camalot.Common.Owin.Security.Reddit.Provider;

namespace Camalot.Common.Owin.Security.Reddit {
	internal class RedditAuthenticationHandler : AuthenticationHandler<RedditAuthenticationOptions> {
		private const string AccountUri = "https://oauth.reddit.com/api/v1/me.json";
		private const string AuthorizationUri = "https://ssl.reddit.com/api/v1/authorize";
		private const string Schema = "http://www.w3.org/2001/XMLSchema#string";
		private const string TokenUri = "https://ssl.reddit.com/api/v1/access_token";
		private readonly HttpClient _httpClient;
		private readonly ILogger _logger;

		private static String ReturnUri { get; set; }

		public RedditAuthenticationHandler ( HttpClient httpClient, ILogger logger ) {
			_httpClient = httpClient;
			_logger = logger;
		}

		protected override Task ApplyResponseChallengeAsync ( ) {
			_logger.WriteVerbose ( "ApplyResponseChallenge" );

			if ( Response.StatusCode != 401 ) {
				return Task.FromResult<object> ( null );
			}

			var challenge = Helper.LookupChallenge ( Options.AuthenticationType,
					Options.AuthenticationMode );

			if ( challenge == null ) return Task.FromResult<object> ( null );

			var requestPrefix = Request.Scheme + "://" + Request.Host;
			var currentQueryString = Request.QueryString;
			var currentUri = !currentQueryString.HasValue
					? requestPrefix + Request.PathBase + Request.Path
					: requestPrefix + Request.PathBase + Request.Path + "?" + currentQueryString.Value;

			var redirectUri = requestPrefix + Request.PathBase + Options.ReturnEndpointPath;

			var extra = challenge.Properties;
			if ( string.IsNullOrEmpty ( extra.RedirectUri ) ) {
				extra.RedirectUri = currentUri;
			}
			RedditAuthenticationHandler.ReturnUri = extra.RedirectUri;
			extra.RedirectUri = null;

			GenerateCorrelationId ( extra );
			var state = Options.StateDataFormat.Protect ( extra );
			var scopes = string.Join ( " ", Options.Scope );

			var authorizationEndpoint =
					string.Format (
							"{0}?client_id={1}&response_type=code&redirect_uri={2}&state={3}&scope={4}",
							AuthorizationUri,
							Uri.EscapeDataString ( Options.ClientId ),
							Uri.EscapeDataString ( redirectUri ),
							Uri.EscapeDataString ( state ),
							Uri.EscapeDataString(scopes));

			Response.StatusCode = 302;
			Response.Headers.Set ( "Location", authorizationEndpoint );
			return Task.FromResult<object> ( null );
		}

		protected override async Task<AuthenticationTicket> AuthenticateCoreAsync ( ) {
			_logger.WriteVerbose ( "AuthenticateCoreAsync" );

			AuthenticationProperties properties = null;
			try {
				string code = null;
				string state = null;

				var query = Request.Query;
				var values = query.GetValues ( "code" );
				if ( values != null && values.Count == 1 ) {
					code = values[0];
				}
				values = query.GetValues ( "state" );
				if ( values != null && values.Count == 1 ) {
					state = values[0];
				}

				properties = Options.StateDataFormat.Unprotect ( state );
				if ( properties == null ) {
					return null;
				}

				var redirectUri = string.Format ( "{0}://{1}{2}{3}",
						Request.Scheme, Request.Host, RequestPathBase, Options.ReturnEndpointPath );
				var scopes = string.Join ( " ", Options.Scope );

				var tokenRequestParameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("client_id", Options.ClientId),
                    new KeyValuePair<string, string>("client_secret", Options.ClientSecret),
                    new KeyValuePair<string, string>("redirect_uri", redirectUri),
										new KeyValuePair<string,string>("scope", scopes),
                };

				var requestContent = new FormUrlEncodedContent ( tokenRequestParameters );
				_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue ( "Basic", "{0}:{1}".With ( Options.ClientId, Options.ClientSecret ).ToBase64String ( ) );

				var response =
						await _httpClient.PostAsync ( TokenUri, requestContent, Request.CallCancelled );
				response.EnsureSuccessStatusCode ( );
				var oauthTokenResponse = await response.Content.ReadAsStringAsync ( );

				var oauth2Token = ParseTokenResponse ( oauthTokenResponse );

				var accessToken = oauth2Token["access_token"];

				if ( string.IsNullOrWhiteSpace ( accessToken ) ) {
					_logger.WriteWarning ( "Access token was not found" );
					return new AuthenticationTicket ( null, properties );
				}

				var testUri = AccountUri + "?access_token=" + Uri.EscapeDataString ( accessToken ) +
												 "&oauth_token=" + Options.ClientSecret + "&oauth_consumer_key=" + Options.ClientId;
				_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue ( "bearer", accessToken );
				var graphResponse = await _httpClient.GetAsync ( testUri, Request.CallCancelled );

				graphResponse.EnsureSuccessStatusCode ( );
				var accountString = await graphResponse.Content.ReadAsStringAsync ( );
				var accountInformation = JObject.Parse ( accountString );

				var context = new RedditAuthenticatedContext ( Context, accountInformation, accessToken );
				context.Identity = new ClaimsIdentity (
						new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, context.Id, Schema, Options.AuthenticationType),
                        new Claim(ClaimTypes.Name, context.Username, Schema, Options.AuthenticationType),

                        new Claim("urn:reddit:id", context.Id, Schema, Options.AuthenticationType),
                        new Claim("urn:reddit:name", context.Username, Schema, Options.AuthenticationType),
                    },
						Options.AuthenticationType,
						ClaimsIdentity.DefaultNameClaimType,
						ClaimsIdentity.DefaultRoleClaimType );

				await Options.Provider.Authenticated ( context );
				properties.RedirectUri = RedditAuthenticationHandler.ReturnUri;
				context.Properties = properties;

				return new AuthenticationTicket ( context.Identity, context.Properties );
			} catch ( Exception ex ) {
				_logger.WriteWarning ( "Authentication failed", ex );
				return new AuthenticationTicket ( null, properties );
			}
		}

		public override async Task<bool> InvokeAsync ( ) {
			_logger.WriteVerbose ( "InvokeAsync" );

			if ( Options.ReturnEndpointPath != null &&
					String.Equals ( Options.ReturnEndpointPath, Request.Path.Value, StringComparison.OrdinalIgnoreCase ) ) {
				return await InvokeReturnPathAsync ( );
			}
			return false;
		}

		public async Task<bool> InvokeReturnPathAsync ( ) {
			_logger.WriteVerbose ( "InvokeReturnPathAsync" );

			var model = await AuthenticateAsync ( );

			var context = new RedditReturnEndpointContext ( Context, model ) {
				SignInAsAuthenticationType = Options.SignInAsAuthenticationType,
				RedirectUri = model.Properties.RedirectUri
			};
			model.Properties.RedirectUri = null;

			await Options.Provider.ReturnEndpoint ( context );

			if ( context.SignInAsAuthenticationType != null && context.Identity != null ) {
				var signInIdentity = context.Identity;
				if (
						!string.Equals ( signInIdentity.AuthenticationType, context.SignInAsAuthenticationType,
								StringComparison.Ordinal ) ) {
					signInIdentity = new ClaimsIdentity ( signInIdentity.Claims, context.SignInAsAuthenticationType,
							signInIdentity.NameClaimType, signInIdentity.RoleClaimType );
				}
				Context.Authentication.SignIn ( context.Properties, signInIdentity );
			}

			if ( context.IsRequestCompleted || context.RedirectUri == null )
				return context.IsRequestCompleted;
			Response.Redirect ( context.RedirectUri );
			context.RequestCompleted ( );

			return context.IsRequestCompleted;
		}


		private IReadableStringCollection ParseTokenResponse ( String data ) {

			//"{\"access_token\": \"2RhkUOOInzZEWa3h8yxpyELoVQ8\", \"token_type\": \"bearer\", \"expires_in\": 3600, \"scope\": \"identity\"}"

			var obj = JObject.Parse ( data );
			
			var dict = new Dictionary<string, string[]> ( );
			var kvps = data.Split ( new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries );
			foreach ( var prop in obj.Properties() ) {
				dict.Add ( prop.Name, prop.Value.ToString().Split ( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries ) );
			}
			return new ReadableStringCollection ( dict );
		}
	}
}

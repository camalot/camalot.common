using System;
using System.Net.Http;
using Camalot.Common.Owin.Security.Github.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Owin;

namespace Camalot.Common.Owin.Security.Github {
	internal class GithubAuthenticationMiddleware : AuthenticationMiddleware<GithubAuthenticationOptions> {
		private readonly HttpClient _httpClient;
		private readonly ILogger _logger;

		public GithubAuthenticationMiddleware (
				OwinMiddleware next,
				IAppBuilder app,
				GithubAuthenticationOptions options )
			: base ( next, options ) {
			_logger = app.CreateLogger<GithubAuthenticationMiddleware> ( );

			if ( Options.Provider == null ) {
				Options.Provider = new GithubAuthenticationProvider ( );
			}

			if ( Options.StateDataFormat == null ) {
				var dataProtector = app.CreateDataProtector (
						typeof ( GithubAuthenticationMiddleware ).FullName,
						Options.AuthenticationType, "v1" );
				Options.StateDataFormat = new PropertiesDataFormat ( dataProtector );
			}

			_httpClient = new HttpClient ( ResolveHttpMessageHandler ( Options ) ) {
				Timeout = Options.BackchannelTimeout,
				MaxResponseContentBufferSize = 1024 * 1024 * 10
			};
		}

		protected override AuthenticationHandler<GithubAuthenticationOptions> CreateHandler ( ) {
			return new GithubAuthenticationHandler ( _httpClient, _logger );
		}

		private static HttpMessageHandler ResolveHttpMessageHandler ( GithubAuthenticationOptions options ) {
			var handler = options.BackchannelHttpHandler ?? new WebRequestHandler ( );

			if ( options.BackchannelCertificateValidator == null ) return handler;

			var webRequestHandler = handler as WebRequestHandler;
			if ( webRequestHandler == null ) {
				throw new InvalidOperationException ( "Validator Handler Mismatch" );
			}
			webRequestHandler.ServerCertificateValidationCallback = options.BackchannelCertificateValidator.Validate;

			return handler;
		}
	}
}

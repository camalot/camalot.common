using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Owin.Security.Reddit.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Owin;

namespace Camalot.Common.Owin.Security.Reddit {
	internal class RedditAuthenticationMiddleware : AuthenticationMiddleware<RedditAuthenticationOptions> {
		private readonly HttpClient _httpClient;
		private readonly ILogger _logger;

		public RedditAuthenticationMiddleware (
				OwinMiddleware next,
				IAppBuilder app,
				RedditAuthenticationOptions options )
			: base ( next, options ) {
			_logger = app.CreateLogger<RedditAuthenticationMiddleware> ( );

			if ( Options.Provider == null ) {
				Options.Provider = new RedditAuthenticationProvider ( );
			}

			if ( Options.StateDataFormat == null ) {
				var dataProtector = app.CreateDataProtector (
						typeof ( RedditAuthenticationMiddleware ).FullName,
						Options.AuthenticationType, "v1" );
				Options.StateDataFormat = new PropertiesDataFormat ( dataProtector );
			}

			_httpClient = new HttpClient ( ResolveHttpMessageHandler ( Options ) ) {
				Timeout = Options.BackchannelTimeout,
				MaxResponseContentBufferSize = 1024 * 1024 * 10
			};
		}

		protected override AuthenticationHandler<RedditAuthenticationOptions> CreateHandler ( ) {
			return new RedditAuthenticationHandler ( _httpClient, _logger );
		}

		private static HttpMessageHandler ResolveHttpMessageHandler ( RedditAuthenticationOptions options ) {
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

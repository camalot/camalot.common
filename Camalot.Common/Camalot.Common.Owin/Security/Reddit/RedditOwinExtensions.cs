using System;
using Microsoft.Owin.Security;
using Owin;

namespace Camalot.Common.Owin.Security.Reddit {
	public static class RedditOwinExtensions {
		public static IAppBuilder UseRedditAuthentication (
				this IAppBuilder app,
				RedditAuthenticationOptions options ) {
			if ( app == null ) {
				throw new ArgumentNullException ( "app" );
			}
			if ( options == null ) {
				throw new ArgumentNullException ( "options" );
			}

			app.Use ( typeof ( RedditAuthenticationMiddleware ), app, options );
			return app;
		}

		public static IAppBuilder UseRedditAuthentication (
				this IAppBuilder app,
				string clientId,
				string clientSecret ) {
			return UseRedditAuthentication (
			app,
			new RedditAuthenticationOptions {
				ClientSecret = clientSecret,
				ClientId = clientId,
				SignInAsAuthenticationType = app.GetDefaultSignInAsAuthenticationType ( ),
			} );
		}

	}
}

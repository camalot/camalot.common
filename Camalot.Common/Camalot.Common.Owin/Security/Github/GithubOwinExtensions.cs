using System;
using Microsoft.Owin.Security;
using Owin;

namespace Camalot.Common.Owin.Security.Github {
	public static class GithubOwinExtensions {
		public static IAppBuilder UseGithubAuthentication (
						this IAppBuilder app,
						GithubAuthenticationOptions options ) {
			if ( app == null ) {
				throw new ArgumentNullException ( "app" );
			}
			if ( options == null ) {
				throw new ArgumentNullException ( "options" );
			}

			app.Use ( typeof ( GithubAuthenticationMiddleware ), app, options );
			return app;
		}

		public static IAppBuilder UseGithubAuthentication (
				this IAppBuilder app,
				string clientId,
				string clientSecret ) {
					return UseGithubAuthentication (
					app,
					new GithubAuthenticationOptions {
						ClientId = clientId,
						ClientSecret = clientSecret,
						SignInAsAuthenticationType = app.GetDefaultSignInAsAuthenticationType ( ),
					} );
		}
	}
}

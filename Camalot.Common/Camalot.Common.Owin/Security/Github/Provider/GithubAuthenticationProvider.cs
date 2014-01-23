using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Owin.Security.Github.Provider {
	public class GithubAuthenticationProvider : IGithubAuthenticationProvider {
		public GithubAuthenticationProvider ( ) {
			OnAuthenticated = context => Task.FromResult<object> ( null );
			OnReturnEndpoint = context => Task.FromResult<object> ( null );
		}

		public Func<GithubAuthenticatedContext, Task> OnAuthenticated { get; set; }

		public Func<GithubReturnEndpointContext, Task> OnReturnEndpoint { get; set; }

		public virtual Task Authenticated ( GithubAuthenticatedContext context ) {
			return OnAuthenticated ( context );
		}

		public virtual Task ReturnEndpoint ( GithubReturnEndpointContext context ) {
			return OnReturnEndpoint ( context );
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Owin.Security.Reddit.Provider {
	public class RedditAuthenticationProvider : IRedditAuthenticationProvider {
		public RedditAuthenticationProvider ( ) {
			OnAuthenticated = context => Task.FromResult<object> ( null );
			OnReturnEndpoint = context => Task.FromResult<object> ( null );
		}

		public Func<RedditAuthenticatedContext, Task> OnAuthenticated { get; set; }

		public Func<RedditReturnEndpointContext, Task> OnReturnEndpoint { get; set; }

		public virtual Task Authenticated ( RedditAuthenticatedContext context ) {
			return OnAuthenticated ( context );
		}

		public virtual Task ReturnEndpoint ( RedditReturnEndpointContext context ) {
			return OnReturnEndpoint ( context );
		}
	}
}

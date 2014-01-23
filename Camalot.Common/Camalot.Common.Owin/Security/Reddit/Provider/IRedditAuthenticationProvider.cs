using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Owin.Security.Reddit.Provider {
	public interface IRedditAuthenticationProvider {
		Task Authenticated ( RedditAuthenticatedContext context );
		Task ReturnEndpoint ( RedditReturnEndpointContext context );

	}
}

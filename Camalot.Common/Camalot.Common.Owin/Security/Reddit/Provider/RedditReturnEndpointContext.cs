using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;

namespace Camalot.Common.Owin.Security.Reddit.Provider {
	public class RedditReturnEndpointContext : ReturnEndpointContext {
		public RedditReturnEndpointContext (
				IOwinContext context,
				AuthenticationTicket ticket )
			: base ( context, ticket ) {
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;

namespace Camalot.Common.Owin.Security.Github.Provider {
	public class GithubReturnEndpointContext : ReturnEndpointContext {
		public GithubReturnEndpointContext (
				IOwinContext context,
				AuthenticationTicket ticket)
			: base ( context, ticket ) {
		}
	}
}

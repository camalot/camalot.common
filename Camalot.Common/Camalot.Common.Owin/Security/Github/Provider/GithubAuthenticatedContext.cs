using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;

namespace Camalot.Common.Owin.Security.Github.Provider {
	public class GithubAuthenticatedContext : BaseContext {
		public GithubAuthenticatedContext ( IOwinContext context, JObject user, string accessToken )
			: base ( context ) {
			User = user;
			AccessToken = accessToken;
			Url = TryGetValue ( user, "html_url" );
			DisplayName = TryGetValue ( user, "name" );
			Id = TryGetValue ( user, "id" );
			Username = TryGetValue ( user, "login" );
			Blog = TryGetValue ( user, "email" );
			Bio = TryGetValue ( user, "bio" );
		}

		public JObject User { get; private set; }
		public String Username { get; private set; }
		public string AccessToken { get; private set; }
		public string Url { get; private set; }
		public string DisplayName { get; private set; }
		public string Id { get; private set; }
		public string AvatarUrl { get; private set; }
		public string GravatarId { get; private set; }

		public String Blog { get; private set; }
		public String Email { get; private set; }

		public String Bio { get; private set; }
		public ClaimsIdentity Identity { get; set; }
		public AuthenticationProperties Properties { get; set; }

		private static string TryGetValue ( IDictionary<string, JToken> user, string propertyName ) {
			JToken value;
			return user.TryGetValue ( propertyName, out value ) ? value.ToString ( ) : null;
		}
	}
}

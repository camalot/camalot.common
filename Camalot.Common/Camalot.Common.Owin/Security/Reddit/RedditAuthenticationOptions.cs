using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Owin.Security.Reddit.Provider;
using Microsoft.Owin.Security;

namespace Camalot.Common.Owin.Security.Reddit {
	public class RedditAuthenticationOptions : AuthenticationOptions {
		public const string Scheme = "Reddit";

		public RedditAuthenticationOptions ( )
			: base ( Scheme ) {
			Caption = Scheme;
			ReturnEndpointPath = "/signin-reddit";
			AuthenticationMode = AuthenticationMode.Passive;
			BackchannelTimeout = TimeSpan.FromSeconds ( 60 );
			Scope = new List<string> ( ) { "identity" };
		}

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public ICertificateValidator BackchannelCertificateValidator { get; set; }
		public TimeSpan BackchannelTimeout { get; set; }
		public HttpMessageHandler BackchannelHttpHandler { get; set; }

		public string Caption {
			get { return Description.Caption; }
			set { Description.Caption = value; }
		}

		public string ReturnEndpointPath { get; set; }

		public string SignInAsAuthenticationType { get; set; }

		public IRedditAuthenticationProvider Provider { get; set; }

		public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }

		public IList<string> Scope { get; private set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Owin.Security.Github.Provider;
using Microsoft.Owin.Security;

namespace Camalot.Common.Owin.Security.Github {
	public class GithubAuthenticationOptions : AuthenticationOptions {
		public const string Scheme = "Github";

		public GithubAuthenticationOptions ( )
			: base ( Scheme ) {
			Caption = Scheme;
			ReturnEndpointPath = "/signin-github";
			AuthenticationMode = AuthenticationMode.Passive;
			BackchannelTimeout = TimeSpan.FromSeconds ( 60 );
			Scope = new List<string> ( ) { "user:email"};
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

		public IGithubAuthenticationProvider Provider { get; set; }

		public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }

		public IList<string> Scope { get; private set; }
	}
}

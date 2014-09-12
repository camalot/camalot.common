using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Camalot.Common.Mvc.Extensions {
	public static partial class CamalotCommonMvcExtensions {
		/// <summary>
		/// Registers the robots.txt route.
		/// </summary>
		/// <param name="rc">The rc.</param>
		/// <returns></returns>
		/// <gist id="20c736abe3a6ec0016cb">Global.asax setup.</gist>
		/// <see cref="Camalot.Common.Mvc.Attributes.RobotsDisallowAttribute"/>
		/// <see cref="Camalot.Common.Mvc.Controllers.RobotsController"/>
		/// <see cref="Camalot.Common.Mvc.Configuration.RobotsRouteConfiguration"/>
		public static RouteCollection RegisterRobotsTxt(this RouteCollection rc) {
			Camalot.Common.Mvc.Configuration.RobotsRouteConfiguration.RegisterRoutes(rc);
			return rc;
		}


	}
}

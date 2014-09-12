using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mvc.Configuration {
	/// <summary>
	/// Registers the /robots.txt route
	/// </summary>
	/// <gist id="20c736abe3a6ec0016cb">Global.asax setup.</gist>
	/// <see cref="Camalot.Common.Mvc.Attributes.RobotsDisallowAttribute"/>
	/// <see cref="Camalot.Common.Mvc.Controllers.RobotsController"/>
	public class RobotsRouteConfiguration {
		/// <summary>
		/// Registers the routes.
		/// </summary>
		/// <param name="routes">The routes.</param>
		public static void RegisterRoutes(RouteCollection routes) {

			routes.MapRoute(
				name: "CamalotCommonMvcRobotsTxt",
				url: "robots.txt",
				defaults: new { controller = "Robots", action = "Index" },
				namespaces: new String[] { "Camalot.Common.Mvc.Controllers" }
			);
		}
	}
}

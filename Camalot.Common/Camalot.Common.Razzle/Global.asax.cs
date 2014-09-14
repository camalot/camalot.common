using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Razzle.Mvc.Configuration;

using Camalot.Common.Mvc.Extensions;
using Razzle.Mvc.Castle.Configuration;
namespace Camalot.Common.Razzle {
	public class MvcApplication : System.Web.HttpApplication {
		protected void Application_Start() {
			AreaRegistration.RegisterAllAreas();

			FiltersConfiguration.RegisterGlobalFilters(GlobalFilters.Filters);

			RouteTable.Routes.RegisterRobotsTxt();

			RouteConfiguration.RegisterRoutes(RouteTable.Routes);
			BundleConfiguration.RegisterBundles(BundleTable.Bundles);
		}
	}
}

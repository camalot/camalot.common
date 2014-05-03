using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Camalot.Common.Mvc.Extensions {
	public static partial class CamalotCommonMvcExtensions {
		/// <summary>
		/// Gets a UrlHelper for the Controller Context.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		public static UrlHelper Url ( this ControllerContext context ) {
			return new UrlHelper ( new RequestContext ( context.HttpContext, context.RouteData ) );
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// Causes all ajax request to not be cached by the browser.
	/// </summary>
	/// <gist id="a516e3b232ddd08de55b"></gist>
	public class AjaxNoCacheFilterAttribute : ActionFilterAttribute {

		/// <summary>
		/// Called by the ASP.NET MVC framework before the action result executes.
		/// </summary>
		/// <param name="filterContext">The filter context.</param>
		public override void OnResultExecuting(ResultExecutingContext filterContext) {
			if(filterContext.RequestContext.HttpContext.Request.IsAjaxRequest()) {
				var response = filterContext.HttpContext.Response;

				response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
				response.Cache.SetValidUntilExpires(false);
				response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
				response.Cache.SetCacheability(HttpCacheability.NoCache);
				response.Cache.SetNoStore();
				response.Headers.Add("Pragma", "no-cache");

			}
			base.OnResultExecuting(filterContext);
		}

	}
}

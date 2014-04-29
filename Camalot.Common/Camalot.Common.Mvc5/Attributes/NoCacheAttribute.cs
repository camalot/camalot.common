using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// Indicates that the request should never be cached by the browser.
	/// </summary>
	/// <gist id="e7a1052b19479b3334e5"></gist>
	[AttributeUsage ( AttributeTargets.Class | AttributeTargets.Method )]
	public class NoCacheAttribute : ActionFilterAttribute {
		/// <summary>
		/// Called by the ASP.NET MVC framework before the action result executes.
		/// </summary>
		/// <param name="filterContext">The filter context.</param>
		public override void OnResultExecuting ( ResultExecutingContext filterContext ) {
			var response = filterContext.HttpContext.Response;

			response.Cache.SetExpires ( DateTime.UtcNow.AddDays ( -1 ) );
			response.Cache.SetValidUntilExpires ( false );
			response.Cache.SetRevalidation ( HttpCacheRevalidation.AllCaches );
			response.Cache.SetCacheability ( HttpCacheability.NoCache );
			response.Cache.SetNoStore ( );
			response.Headers.Add ( "Pragma", "no-cache" );

			base.OnResultExecuting ( filterContext );
		}
	}
}

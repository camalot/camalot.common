using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// Requires an action/controller to be called only from the specified host
	/// </summary>
	/// <gist id="af91f34d5c3c0630cb07"></gist>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class RequireSourceHostAttribute : ActionFilterAttribute {
		/// <summary>
		/// Initializes a new instance of the <see cref="RequireSourceHostAttribute"/> class.
		/// </summary>
		/// <param name="hostNames">Name of the hosts to allow.</param>
		public RequireSourceHostAttribute(params string[] hostNames) {
			AllowedHostNames = hostNames.Require();
		}

		/// <summary>
		/// Gets or sets the name of the host.
		/// </summary>
		/// <value>
		/// The name of the host.
		/// </value>
		public string[] AllowedHostNames { get; set; }

		/// <summary>
		/// Called by the ASP.NET MVC framework before the action method executes.
		/// </summary>
		/// <param name="filterContext">The filter context.</param>
		/// <exception cref="System.Web.HttpException">404;File not found.</exception>
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			if(AllowedHostNames.Contains(filterContext.HttpContext.Request.Url.Host, StringComparer.InvariantCultureIgnoreCase)) {
				base.OnActionExecuting(filterContext);
			} else {
				throw new HttpException(404, "File not found.");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Camalot.Common.Mvc.Extensions;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// Indicates that the requests should be compressed using the methods accepted by the clients browser. (GZIP or DEFLATE)
	/// </summary>
	/// <seealso cref="http://www.gzip.org/zlib/rfc-gzip.html">GZIP</seealso>
	/// <seealso cref="http://www.gzip.org/zlib/rfc-deflate.html">DEFLATE</seealso>
	/// <gist id="388e21dd8e2fd378f00f"></gist>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	[AspNetHostingPermission ( SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal )]
	public class CompressAttribute : ActionFilterAttribute {
		/// <summary>
		/// Called by the ASP.NET MVC framework after the action result executes.
		/// </summary>
		/// <param name="filterContext">The filter context.</param>
		/// <ignore>true</ignore>
		public override void OnResultExecuted ( ResultExecutedContext filterContext ) {
			if ( filterContext.Exception == null || ( filterContext.Exception != null && filterContext.ExceptionHandled ) ) {
				filterContext.HttpContext.CompressResponse ( );
			}

			base.OnResultExecuted ( filterContext );
		}
	}
}

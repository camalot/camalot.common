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
	[AttributeUsage ( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false )]
	[AspNetHostingPermission ( SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal )]
	public class CompressAttribute : ActionFilterAttribute {
		public override void OnResultExecuted ( ResultExecutedContext filterContext ) {
			if ( filterContext.Exception == null || ( filterContext.Exception != null && filterContext.ExceptionHandled ) ) {
				filterContext.HttpContext.CompressResponse ( );
			}

			base.OnResultExecuted ( filterContext );
		}
	}
}

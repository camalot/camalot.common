using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mvc.Attributes {
	[AttributeUsage ( AttributeTargets.Method | AttributeTargets.Class )]
	public class AjaxOnlyAttribute : ActionMethodSelectorAttribute {
		public override bool IsValidForRequest ( ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo ) {
			return controllerContext.Require ( ).HttpContext.Request.IsAjaxRequest ( );
		}
	}
}

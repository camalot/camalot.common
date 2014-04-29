using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// Indicates that a method can only be called from an Ajax request.
	/// </summary>
	/// <gist id="8ae9de7976766ccaf7f3">Decorate your method or class with the AjaxOnly attribute and it will only be able to be called via ajax.</gist>
	[AttributeUsage ( AttributeTargets.Method | AttributeTargets.Class )]
	public class AjaxOnlyAttribute : ActionMethodSelectorAttribute {
		/// <summary>
		/// Determines whether the action method selection is valid for the specified controller context.
		/// </summary>
		/// <param name="controllerContext">The controller context.</param>
		/// <param name="methodInfo">Information about the action method.</param>
		/// <returns>
		/// true if the action method selection is valid for the specified controller context; otherwise, false.
		/// </returns>
		/// <ignore>true</ignore>
		public override bool IsValidForRequest ( ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo ) {
			return controllerContext.Require ( ).HttpContext.Request.IsAjaxRequest ( );
		}
	}
}

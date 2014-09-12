using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// Describes that the controller, area, or action should be not visited by a web crawler robot.
	/// </summary>
	/// <gist id="5eb2b71f8c503312ea8d">Disallow an entire Area Registration</gist>
	/// <gist id="dc6bff55bf8e3545cdd3">Disallow an entire Controller</gist>
	/// <gist id="67b52bc676b3f036d980">Disallow a specific Action within a Controller</gist>
	/// <gist id="56cfb749d29235fb61e1">Setup the web.config for handling the robots.txt requests.</gist>
	/// <gist id="20c736abe3a6ec0016cb">Global.asax setup.</gist>
	/// <see cref="Camalot.Common.Mvc.Controllers.RobotsController"/>
	/// <see cref="Camalot.Common.Mvc.Configuration.RobotsRouteConfiguration"/>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
	public class RobotsDisallowAttribute : Attribute {

		/// <summary>
		/// Gets or sets the area.
		/// </summary>
		/// <value>
		/// This helps get the area information when building the robots.txt.
		/// </value>
		/// <remarks>This can be left empty if the attribute is on an AreaRegistration.</remarks>
		public string Area { get; set; }


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// An attribute to specify that an enum should be ignored when looking at the enums via reflection. 
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumIgnoreAttribute : Attribute {
	}
}

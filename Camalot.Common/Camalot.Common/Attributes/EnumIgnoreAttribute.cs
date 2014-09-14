using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Attributes {
	/// <summary>
	/// An attribute to specify that an enum should be ignored when looking at the enums via reflection. 
	/// </summary>
	/// <gist id="754edf4379b8d4e57cd4" />
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumIgnoreAttribute : Attribute {
	}
}

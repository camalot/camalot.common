using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// An attribute to give an enum a display value
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumDisplayAttribute : Attribute {
		public EnumDisplayAttribute(string value) {
			Value = value.Require();
		}

		public string Value { get; set; }
	}
}

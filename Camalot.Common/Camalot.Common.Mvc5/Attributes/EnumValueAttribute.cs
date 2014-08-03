using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// An attribute that gives an enum a string value to use.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumValueAttribute : Attribute {
		public EnumValueAttribute(string value) {
			Value = value.Require();
		}

		public string Value { get; set; }
	}
}

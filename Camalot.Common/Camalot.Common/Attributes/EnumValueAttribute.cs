using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;

namespace Camalot.Common.Attributes {
	/// <summary>
	/// An attribute that gives an enum a string value to use.
	/// </summary>
	/// <gist id="754edf4379b8d4e57cd4" />
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumValueAttribute : Attribute {
		public EnumValueAttribute(string value) {
			Value = value.Require();
		}

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		public string Value { get; set; }
	}
}

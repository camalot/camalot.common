using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;
using Camalot.Common.Properties;

namespace Camalot.Common.Attributes {
	/// <summary>
	/// A helper attribute for defining configuration elements in the web config.
	/// </summary>
	/// <ignore>true</ignore>
	[AttributeUsage ( AttributeTargets.Class )]
	public class ConfigurationPathAttribute : Attribute {
		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationPathAttribute"/> class.
		/// </summary>
		/// <param name="path">The path.</param>
		public ConfigurationPathAttribute ( String path ) {
			Path = path.Require ( );
		}

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		/// <value>
		/// The path.
		/// </value>
		public String Path { get; set; }
	}
}

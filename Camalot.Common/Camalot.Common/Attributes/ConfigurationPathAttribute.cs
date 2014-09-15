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
	/// <gist id="6fc378fae7d7a51c58a1">Define the configuration</gist>
	/// <gist id="6214ba8cf5bc2eabeb45">Define the xml configuration in the app/web config file</gist>
	/// <gist id="eab0e87c8adf9548d41f">Load the configuration</gist>
	/// <see cref="Camalot.Common.Configuration.ConfigurationReader" />
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

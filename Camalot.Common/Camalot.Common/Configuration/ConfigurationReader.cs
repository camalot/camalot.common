using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Attributes;
using Camalot.Common.Extensions;

namespace Camalot.Common.Configuration {
	/// <summary>
	/// Gets a configuration object from the configuration context.
	/// </summary>
	/// <gist id="6fc378fae7d7a51c58a1">Define the configuration</gist>
	/// <gist id="6214ba8cf5bc2eabeb45">Define the xml configuration in the app/web config file</gist>
	/// <gist id="eab0e87c8adf9548d41f">Load the configuration</gist>
	/// <see cref="Camalot.Common.Attributes.ConfigurationPathAttribute" />
	public class ConfigurationReader : IConfigurationReader {
		/// <summary>
		/// Gets a configuration object from the configuration context.
		/// </summary>
		/// <typeparam name="T">The configuration object to get from the context.</typeparam>
		/// <returns></returns>
		/// <gist id="eab0e87c8adf9548d41f">Load the configuration</gist>
		/// <see cref="Camalot.Common.Attributes.ConfigurationPathAttribute" />
		public T Get<T>() {
			var path = typeof ( T ).GetCustomAttributeValue<ConfigurationPathAttribute, String> ( x => x.Path );
			return (T)ConfigurationManager.GetSection ( path );
		}
	}
}

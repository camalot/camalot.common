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
	public class ConfigurationReader : IConfigurationReader{
		/// <summary>
		/// Gets a configuration object from the configuration context.
		/// </summary>
		/// <typeparam name="T">The configuration object to get from the context.</typeparam>
		/// <returns></returns>
		public T Get<T>() {
			var path = typeof ( T ).GetCustomAttributeValue<ConfigurationPathAttribute, String> ( x => x.Path );
			return (T)ConfigurationManager.GetSection ( path );
		}
	}
}

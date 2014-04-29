using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Configuration {
	/// <summary>
	/// Gets a configuration object from the configuration context.
	/// </summary>
	public interface IConfigurationReader {
		/// <summary>
		/// Gets a configuration object from the configuration context.
		/// </summary>
		/// <typeparam name="T">The configuration object to get from the context.</typeparam>
		/// <returns></returns>
		T Get<T>();
	}
}

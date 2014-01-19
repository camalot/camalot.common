using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Attributes;
using Camalot.Common.Extensions;

namespace Camalot.Common.Configuration {
	public class ConfigurationReader {
		public T Get<T> ( ) {
			var path = typeof ( T ).GetCustomAttributeValue<ConfigurationPathAttribute, String> ( x => x.Path );
			return (T)ConfigurationManager.GetSection ( path );
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;
using Camalot.Common.Properties;

namespace Camalot.Common.Attributes {
	[AttributeUsage ( AttributeTargets.Class )]
	public class ConfigurationPathAttribute : Attribute {
		public ConfigurationPathAttribute ( String path ) {
			Path = path.Require ( );
		}

		public String Path { get; set; }
	}
}

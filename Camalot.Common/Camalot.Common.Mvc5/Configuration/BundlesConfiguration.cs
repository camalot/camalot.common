using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Camalot.Common.Attributes;
using System.Web.Optimization;

namespace Camalot.Common.Mvc.Configuration {
	[ConfigurationPath ( "camalot.common/bundles" )]
	[XmlRoot ( "bundles" )]
	public class BundlesConfiguration {
		public BundlesConfiguration ( ) {
			UseCdn = false;
			IgnoreList = new List<BundleIgnore> ( );
		}
		[XmlElement ( "scripts" )]
		public BundleGroup Scripts { get; set; }
		[XmlElement ( "styles" )]
		public BundleGroup Styles { get; set; }
		[XmlArray("ignores")]
		[XmlArrayItem("ignore")]
		public List<BundleIgnore> IgnoreList { get; set; }

		[XmlAttribute ( "useCdn" )]
		public bool UseCdn { get; set; }
		[XmlAttribute ( "enableOptimizations" )]
		public bool EnableOptimizations { get; set; }
	}

	public class BundleGroup {
		[XmlElement ( "bundle" )]
		public List<BundleGroupItem> Bundles { get; set; }
	}

	public class BundleGroupItem {
		public BundleGroupItem ( ) {
			Includes = new List<BundleItemInclude> ( );
		}
		[XmlAttribute ( "name" )]
		public String Name { get; set; }

		[XmlAttribute ( "cndFallbackExpression" )]
		public String CdnFallbackExpression { get; set; }
		[XmlAttribute ( "cdnPath" )]
		public String CdnPath { get; set; }

		[XmlElement ( "include" )]
		public List<BundleItemInclude> Includes { get; set; }
	}

	public class BundleItemInclude {
		[XmlAttribute ( "path" )]
		public String Path { get; set; }
	}

	public class BundleIgnore {
		[XmlAttribute("pattern")]
		public string Pattern { get; set; }
		[XmlAttribute ( "when" )]
		public OptimizationMode When { get; set; }
	}
}

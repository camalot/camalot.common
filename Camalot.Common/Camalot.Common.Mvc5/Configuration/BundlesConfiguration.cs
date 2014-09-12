using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Camalot.Common.Attributes;
using System.Web.Optimization;

namespace Camalot.Common.Mvc.Configuration {
	/// <summary>
	/// Represents the root bundle element
	/// </summary>
	/// <ignore>true</ignore>
	/// <ignore>true</ignore>
	[ConfigurationPath("camalot.common/bundles")]
	[XmlRoot ( "bundles" )]
	public class BundlesConfiguration {
		/// <summary>
		/// Initializes a new instance of the <see cref="BundlesConfiguration"/> class.
		/// </summary>
		public BundlesConfiguration ( ) {
			UseCdn = false;
			IgnoreList = new List<BundleIgnore> ( );
		}
		/// <summary>
		/// Gets or sets the scripts.
		/// </summary>
		/// <value>
		/// The scripts.
		/// </value>
		[XmlElement ( "scripts" )]
		public BundleGroup Scripts { get; set; }
		/// <summary>
		/// Gets or sets the styles.
		/// </summary>
		/// <value>
		/// The styles.
		/// </value>
		[XmlElement ( "styles" )]
		public BundleGroup Styles { get; set; }
		/// <summary>
		/// Gets or sets the ignore list.
		/// </summary>
		/// <value>
		/// The ignore list.
		/// </value>
		[XmlArray("ignores")]
		[XmlArrayItem("ignore")]
		public List<BundleIgnore> IgnoreList { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [use CDN].
		/// </summary>
		/// <value>
		///   <c>true</c> if [use CDN]; otherwise, <c>false</c>.
		/// </value>
		[XmlAttribute ( "useCdn" )]
		public bool UseCdn { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether [enable optimizations].
		/// </summary>
		/// <value>
		///   <c>true</c> if [enable optimizations]; otherwise, <c>false</c>.
		/// </value>
		[XmlAttribute ( "enableOptimizations" )]
		public bool EnableOptimizations { get; set; }
	}

	/// <summary>
	/// Represents a bundle group
	/// </summary>
	/// <ignore>true</ignore>
	public class BundleGroup {
		/// <summary>
		/// Gets or sets the bundles.
		/// </summary>
		/// <value>
		/// The bundles.
		/// </value>
		[XmlElement ( "bundle" )]
		public List<BundleGroupItem> Bundles { get; set; }
	}

	/// <summary>
	/// Represents a bundle group item
	/// </summary>
	/// <ignore>true</ignore>
	public class BundleGroupItem {
		/// <summary>
		/// Initializes a new instance of the <see cref="BundleGroupItem"/> class.
		/// </summary>
		public BundleGroupItem ( ) {
			Includes = new List<BundleItemInclude> ( );
		}
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		[XmlAttribute ( "name" )]
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the CDN fallback expression.
		/// </summary>
		/// <value>
		/// The CDN fallback expression.
		/// </value>
		[XmlAttribute ( "cndFallbackExpression" )]
		public String CdnFallbackExpression { get; set; }
		/// <summary>
		/// Gets or sets the CDN path.
		/// </summary>
		/// <value>
		/// The CDN path.
		/// </value>
		[XmlAttribute ( "cdnPath" )]
		public String CdnPath { get; set; }

		/// <summary>
		/// Gets or sets the includes.
		/// </summary>
		/// <value>
		/// The includes.
		/// </value>
		[XmlElement ( "include" )]
		public List<BundleItemInclude> Includes { get; set; }
	}

	/// <summary>
	/// Represents an included item in the bundle item
	/// </summary>
	/// <ignore>true</ignore>
	public class BundleItemInclude {
		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		/// <value>
		/// The path.
		/// </value>
		[XmlAttribute ( "path" )]
		public String Path { get; set; }
	}

	/// <summary>
	/// Represents and ignore pattern in the bundle
	/// </summary>
	/// <ignore>true</ignore>
	public class BundleIgnore {
		/// <summary>
		/// Gets or sets the pattern.
		/// </summary>
		/// <value>
		/// The pattern.
		/// </value>
		[XmlAttribute("pattern")]
		public string Pattern { get; set; }
		/// <summary>
		/// Gets or sets the when.
		/// </summary>
		/// <value>
		/// The when.
		/// </value>
		[XmlAttribute ( "when" )]
		public OptimizationMode When { get; set; }
	}
}

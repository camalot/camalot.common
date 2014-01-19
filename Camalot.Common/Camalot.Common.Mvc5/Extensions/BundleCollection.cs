using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;
using Camalot.Common.Configuration;
using Camalot.Common.Mvc.Configuration;
using MoreLinq;

namespace Camalot.Common.Mvc.Extensions {
	public static partial class CamalotCommonMvcExtensions {
		/// <summary>
		/// Loads bundle configuration from web configuration in &lt;camalot.common&gt; section
		/// </summary>
		/// <param name="bundles">The bundles.</param>
		public static void LoadFromWebConfiguration ( this BundleCollection bundles ) {
			var cr = new ConfigurationReader ( );
			var bConfig = cr.Get<BundlesConfiguration> ( );

			bundles.IgnoreList.Ignore ( "*.map", OptimizationMode.Always );

			BundleTable.EnableOptimizations = bConfig.EnableOptimizations;

			bConfig.IgnoreList.ForEach ( i => {
				bundles.IgnoreList.Ignore ( i.Pattern, i.When );
			} );

			bundles.UseCdn = bConfig.UseCdn;
			bConfig.Scripts.Bundles.ForEach ( b => {
				var bndl = new ScriptBundle ( b.Name );
				if ( !string.IsNullOrWhiteSpace ( b.CdnPath ) ) {
					bndl.CdnPath = b.CdnPath;
					bndl.CdnFallbackExpression = b.CdnFallbackExpression;
				}
				b.Includes.ForEach ( i => bndl.Include ( i.Path ) );
			} );

			bConfig.Styles.Bundles.ForEach ( b => {
				var bndl = new StyleBundle ( b.Name );
				if ( !string.IsNullOrWhiteSpace ( b.CdnPath ) ) {
					bndl.CdnPath = b.CdnPath;
				}
				b.Includes.ForEach ( i => bndl.Include ( i.Path ) );
				bundles.Add ( bndl );
			} );
		}
	}
}

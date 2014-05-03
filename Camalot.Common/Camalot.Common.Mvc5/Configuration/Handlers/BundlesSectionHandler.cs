using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mvc.Configuration.Handlers {
	/// <summary>
	/// The Web.Config handler for the bundles
	/// </summary>
	/// <gist id="f9dfc0b776191f1a728a"></gist>
	/// <seealso cref="M:Camalot.Common.Mvc.Extensions.CamalotCommonMvcExtensions.LoadFromWebConfiguration"/>
	public class BundlesSectionHandler : IConfigurationSectionHandler {
		/// <summary>
		/// Creates the bundle configuration from the configContext.
		/// </summary>
		/// <param name="parent">The parent.</param>
		/// <param name="configContext">The configuration context.</param>
		/// <param name="section">The section.</param>
		/// <returns></returns>
		/// <ignore>true</ignore>
		public BundlesConfiguration Create ( object parent, object configContext, XmlNode section ) {
			return section.CreateConfigurationInstanceFromConfigurationNode<BundlesConfiguration> ( );
		}

		#region IConfigurationSectionHandler Members

		/// <summary>
		/// Creates a configuration section handler.
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="configContext">Configuration context object.</param>
		/// <param name="section"></param>
		/// <returns>The created section handler object.</returns>
		object IConfigurationSectionHandler.Create ( object parent, object configContext, XmlNode section ) {
			return this.Create ( parent, configContext, (XmlElement)section );
		}

		#endregion
	}
}

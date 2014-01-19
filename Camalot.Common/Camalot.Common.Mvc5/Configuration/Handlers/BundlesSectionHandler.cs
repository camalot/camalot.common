using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mvc.Configuration.Handlers {
	public class BundlesSectionHandler : IConfigurationSectionHandler {
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

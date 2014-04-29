using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Camalot.Common.Site.Models.Documentation.Xml {
	public class Assembly {
		[XmlElement("name")]
		public string Name { get; set; }
	}
}
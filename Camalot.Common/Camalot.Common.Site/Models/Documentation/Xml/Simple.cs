using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Camalot.Common.Site.Models.Documentation.Xml {
	public class Simple {
		[XmlText]
		public string Value { get; set; }

		public override string ToString() {
			return Value;
		}
	}
}
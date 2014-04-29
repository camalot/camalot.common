using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Camalot.Common.Site.Models.Documentation {
	public class ClassModel {
		public ClassModel() {
			Methods = new List<MethodModel>();
		}
		public string Name { get; set; }
		public string Description { get; set; }
		public string Namespace { get; set; }
		public string Assembly { get; set; }
		public Xml.Member Documentation { get; set; }
		public string XmlName { get; set; }
		public bool Ignore { get { return Documentation != null && Documentation.Ignore; } }
		public IList<MethodModel> Methods {get;set;}
	}
}
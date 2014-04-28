using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Camalot.Common.Site.Models.Documentation {
	public class NamespaceModel {
		public NamespaceModel() {
			Classes = new List<ClassModel>();
			Namespaces = new List<NamespaceModel>();
		}
		public string Name { get; set; }
		public IList<NamespaceModel> Namespaces { get; set; }
		public IList<ClassModel> Classes { get; set; }
	}
}
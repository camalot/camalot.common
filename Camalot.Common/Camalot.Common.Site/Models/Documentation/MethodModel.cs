using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Camalot.Common.Extensions;
using Camalot.Common.Site.Extensions;
namespace Camalot.Common.Site.Models.Documentation {
	public class MethodModel {
		public MethodModel() {
			Parameters = new List<ParameterModel>();
			GenericParameters = new List<TypeModel>();
		}
		public string Name { get; set; }
		public Xml.Member Documentation { get; set; }
		public string XmlName { get; set; }
		public bool Ignore { get { return Documentation != null && Documentation.Ignore; } }

		public IList<ParameterModel> Parameters { get; set; }
		public IList<TypeModel> GenericParameters { get; set; }

		public Type ExtensionOf { get; set; }

		public override string ToString() {
			if(ExtensionOf == null) {
				return "{0}{2} ( {1} )".With(Name, String.Join(", ", Parameters.Select(p => p.ToString())), GenericParameters != null && GenericParameters.Count > 0 ? "<{0}>".With(String.Join(", ", GenericParameters.Select(g => g.ToString()))) : "");
			} else {
				return "{0}.{1}{3} ( {2} )".With(
					ExtensionOf.ToSafeFullName(),
					Name, 
					String.Join(", ", Parameters.Skip(1).Select(p => p.ToString())), 
					GenericParameters != null && GenericParameters.Count > 0 ? "<{0}>".With(String.Join(", ", GenericParameters.Select(g => g.ToString()))) : ""
				);
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Camalot.Common.Extensions;

namespace Camalot.Common.Site.Models.Documentation {
	public class MethodModel {
		public MethodModel() {
			Parameters = new List<ParameterModel>();
			GenericParameters = new List<TypeModel>();
		}
		public string Name { get; set; }
		public IList<ParameterModel> Parameters { get; set; }
		public IList<TypeModel> GenericParameters { get; set; }

		public override string ToString() {
			return "{0}{2} ( {1} )".With(Name, String.Join(", ", Parameters.Select(p => p.ToString())), GenericParameters != null && GenericParameters.Count > 0 ? "<{0}>".With(String.Join(", ", GenericParameters.Select(g => g.ToString()))) : "");
		}
	}
}
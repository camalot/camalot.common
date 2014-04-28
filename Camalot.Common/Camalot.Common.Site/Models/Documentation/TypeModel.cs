using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Camalot.Common.Extensions;
using Camalot.Common.Site.Extensions;

namespace Camalot.Common.Site.Models.Documentation {
	public class TypeModel {
		public Type BaseType { get; set; }
		public string Name { get; set; }
		public override string ToString() {
			return BaseType.ToSafeName();
		}
	}
}

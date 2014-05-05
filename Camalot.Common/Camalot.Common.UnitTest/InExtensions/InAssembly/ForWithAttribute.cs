using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InAssembly {
	[TestClass]
	public class ForWithAttribute {
		[TestMethod]
		public void WhenAssemblyHasTypesWithAttribute_MustReturnTypes() {
			var assembly = typeof(ConfigurationPathAttribute).Assembly;
			var types = assembly.WithAttribute<AttributeUsageAttribute>();
			Assert.IsTrue(types.Any(x => x == typeof(ConfigurationPathAttribute)));
		}

		[TestMethod]
		public void WhenAssemblyDoesNotJaveTypesWithAttribute_MustReturnEmpty() {
			var assembly = typeof(ConfigurationPathAttribute).Assembly;
			var types = assembly.WithAttribute<ConfigurationPathAttribute>();
			Assert.IsTrue(types.Count() == 0);
		}
	}
}

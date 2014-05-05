using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using Camalot.Common.Attributes;

namespace Camalot.Common.UnitTest.InExtensions.InAppDomain {
	[TestClass]
	public class ForWithAttribute {
		[TestMethod]
		public void WhenCurrentDomainHasTypesWithAttribute_MustReturnTypes() {
			var types = AppDomain.CurrentDomain.WithAttribute<AttributeUsageAttribute>();
			Assert.IsTrue(types.Any(x => x == typeof(ConfigurationPathAttribute)));
		}

		[TestMethod]
		public void WhenCurrentDomainDoesNotJaveTypesWithAttribute_MustReturnEmpty() {
			var types = AppDomain.CurrentDomain.WithAttribute<ConfigurationPathAttribute>();
			Assert.IsTrue(types.Count() == 0);
		}
	}
}

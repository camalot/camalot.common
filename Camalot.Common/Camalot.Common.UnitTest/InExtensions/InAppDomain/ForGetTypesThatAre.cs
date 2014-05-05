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
	public class ForGetTypesThatAre {
		[TestMethod]
		public void WhenCurrentDomainHasTypesThatExtendType_MustReturnTypes() {
			var types = AppDomain.CurrentDomain.GetTypesThatAre<Object>();
			Assert.IsTrue(types.Count() > 0);
		}

		[TestMethod]
		public void WhenCurrentDomainDoesNotTypesThatExtendType_MustReturnEmpty() {
			var types = AppDomain.CurrentDomain.GetTypesThatAre<ConfigurationPathAttribute>();
			Assert.IsTrue(types.Count() == 0);
		}
	}
}

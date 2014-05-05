using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using Camalot.Common.Attributes;

namespace Camalot.Common.UnitTest.InExtensions.InAssembly {
	[TestClass]
	public class ForGetTypesThatAre {
		[TestMethod]
		public void WhenAssemblyHasTypesThatExtendType_MustReturnTypes() {
			var assembly = typeof(ConfigurationPathAttribute).Assembly;
			var types = assembly.GetTypesThatAre<Object>();
			Assert.IsTrue(types.Count() > 0);
		}

		[TestMethod]
		public void WhenAssemblyDoesNotTypesThatExtendType_MustReturnEmpty() {
			var assembly = typeof(ConfigurationPathAttribute).Assembly;
			var types = assembly.GetTypesThatAre<ConfigurationPathAttribute>();
			Assert.IsTrue(types.Count() == 0);
		}
	}
}

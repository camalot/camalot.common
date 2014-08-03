using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InType {
	[TestClass]
	public class ForGetMethodsOfReturnType {
		[TestMethod]
		public void WhenTypeDoesNotHaveMethodsOfReturnType_MustReturnEmptyCollection() {
			var type = typeof(System.Environment);
			var result = type.GetMethodsOfReturnType<DateTime>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 0);
		}

		[TestMethod]
		public void WhenTypeDoesHaveMethodsOfReturnType_MustReturnCollection() {
			var type = typeof(System.Environment);
			var result = type.GetMethodsOfReturnType<bool>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 5);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;
using System.Reflection;

namespace Camalot.Common.UnitTest.InExtensions.InMethodInfo {
	[TestClass]
	public class ForGetCustomAttributeValue {

		public class TestClass {
			[System.ComponentModel.Description("description")]
			public void TestMethod1() { }

			public void TestMethod2() { }
		}

		[TestMethod]
		public void WhenMethodInfoDoesNotHaveAttribute_ReturnDefaultValue() {
			var method = typeof(TestClass).GetMethod("TestMethod2");

			var expected = default(string);
			var result = method.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void WhenMethodInfoHasAttribute_ReturnValue() {
			var expected = "description";
			var method = typeof(TestClass).GetMethod("TestMethod1");
			var result = method.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void WhenMethodInfoIsNull_MustThrowException() {
			var method = default(MethodInfo);
			try {
				var result = ((MethodInfo)null).GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			} catch(ArgumentNullException) {
				Assert.IsNull(method);
				return;
			}
			Assert.Fail("Expected exception did not occur.");
		}
	}
}

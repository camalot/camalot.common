using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;
using System.Reflection;

namespace Camalot.Common.UnitTest.InExtensions.InParameterInfo {
	[TestClass]
	public class ForGetCustomAttributeValue {

		public class TestClass {
			public void TestMethod1(
				[System.ComponentModel.Description("description")]
				int int1,
				int int2) { }
			public void TestMethod2(
				[System.ComponentModel.Description("description")]
				int int1,
				[System.ComponentModel.Description("description")]
				int int2
				) { }
			public void TestMethod3(
				int int1,
				int int2
				) { }
			public void TestMethod4() { }
		}

		[TestMethod]
		public void WhenMethodInfoDoesNotHaveAttribute_ReturnDefaultValue() {
			var method = typeof(TestClass).GetMethod("TestMethod3");
			var parameter = method.GetParameters().Single(m => m.Name == "int1");
			var expected = default(string);
			var result = parameter.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void WhenMethodInfoHasAttribute_ReturnValue() {
			var expected = "description";
			var method = typeof(TestClass).GetMethod("TestMethod2");
			var parameter = method.GetParameters().Single(m => m.Name == "int2");
			var result = parameter.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void WhenMethodInfoIsNull_MustThrowException() {
			var parameter = default(ParameterInfo);
			try {
				var result = parameter.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			} catch(ArgumentNullException) {
				Assert.IsNull(parameter);
				return;
			}
			Assert.Fail("Expected exception did not occur.");
		}
	}
}

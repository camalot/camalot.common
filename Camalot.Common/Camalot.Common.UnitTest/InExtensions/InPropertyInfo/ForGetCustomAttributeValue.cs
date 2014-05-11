using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;
using System.Reflection;

namespace Camalot.Common.UnitTest.InExtensions.InPropertyInfo {
	[TestClass]
	public class ForGetCustomAttributeValue {

		public class TestClass {
			[System.ComponentModel.Description("description")]
			public int Property1 { get; set; }
			public int Property2 { get; set; }
		}

		[TestMethod]
		public void WhenPropertyInfoDoesNotHaveAttribute_ReturnDefaultValue() {
			var method = typeof(TestClass).GetProperty("Property2");

			var expected = default(string);
			var result = method.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void WhenPropertyInfoHasAttribute_ReturnValue() {
			var expected = "description";
			var property = typeof(TestClass).GetProperty("Property1");
			var result = property.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void WhenPropertyInfoIsNull_MustThrowException() {
			var property = default(PropertyInfo);
			try {
				var result = property.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			} catch(ArgumentNullException) {
				Assert.IsNull(property);
				return;
			}
			Assert.Fail("Expected exception did not occur.");
		}
	}
}

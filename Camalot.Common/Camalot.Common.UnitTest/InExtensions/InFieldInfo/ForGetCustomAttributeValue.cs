using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;
using System.Reflection;

namespace Camalot.Common.UnitTest.InExtensions.InFieldInfo {
	[TestClass]
	public class ForGetCustomAttributeValue {

		public class TestClass {
			[System.ComponentModel.Description("My very own field")]
			public int SomeField = default(int);
			public string AnotherField = default(string);
		}

		[TestMethod]
		public void WhenFieldInfoDoesNotHaveAttribute_ReturnDefaultValue() {
			var field = typeof(TestClass).GetField("AnotherField");

			var expected = default(string);
			var result = field.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void WhenFieldInfoHasAttribute_ReturnValue() {
			var field = typeof(TestClass).GetField("SomeField");

			var expected = "My very own field";
			var result = field.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);

		}

		[TestMethod]
		public void WhenFieldInfoIsNull_MustThrowException() {
			var field = default(FieldInfo);
			try {
				field = typeof(TestClass).GetField("InvalidField");
				var result = field.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			} catch(ArgumentNullException) {
				Assert.IsNull(field);
				return;
			}
			Assert.Fail("Expected exception did not occur.");
		}
	}
}

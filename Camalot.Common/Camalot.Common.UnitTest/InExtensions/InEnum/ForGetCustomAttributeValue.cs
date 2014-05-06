using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InEnum {
	[TestClass]
	public class ForGetCustomAttributeValue {

		public enum TestEnum {
			[System.ComponentModel.Description("some text")]
			EnumValue1,
			EnumValue2
		}

		[TestMethod]
		public void WhenEnumDoesNotHaveAttribute_ReturnDefaultValue() {
			var result = TestEnum.EnumValue2.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(default(string),result);
		}

		[TestMethod]
		public void WhenEnumDoesHaveAttribute_ReturnValue() {
			var expected = "some text";
			var result = TestEnum.EnumValue1.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);
		}
	}
}

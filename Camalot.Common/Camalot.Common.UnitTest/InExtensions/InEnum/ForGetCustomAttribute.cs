using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InEnum {
	[TestClass]
	public class ForGetCustomAttribute {

		public enum TestEnum {
			[System.ComponentModel.Description("some text")]
			EnumValue1,
			EnumValue2
		}

		[TestMethod]
		public void WhenEnumDoesNotHaveAttribute_ReturnNull() {
			var result = TestEnum.EnumValue2.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNull(result);
		}

		[TestMethod]
		public void WhenEnumDoesHaveAttribute_ReturnAttribute() {
			var expected = "some text";
			var result = TestEnum.EnumValue1.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.AreEqual(expected, result.Description);
		}
	}
}

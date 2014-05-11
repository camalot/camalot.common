using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InType {
	[TestClass]
	public class ForGetCustomAttributeValue {
		[System.ComponentModel.Description("description")]
		public class TestClass {
		}

		[TestMethod]
		public void WhenTypeDoesNotHaveAttribute_MustReturnNull() {
			var type = typeof(TestClass);
			var result = type.GetCustomAttributeValue<ObsoleteAttribute, string>(x => x.Message);
			Assert.IsNull(result);
		}

		[TestMethod]
		public void WhenTypeDoesHaveAttribute_MustReturnValue() {
			var type = typeof(TestClass);
			var result = type.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			var expected = "description";
			Assert.IsNotNull(result);
			Assert.AreEqual<string>(expected, result);
		}

		[TestMethod]
		public void WhenTypeIsNull_MustReturnNull() {
			var type = (Type)null;
			var result = type.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.IsNull(result);
			Assert.IsNull(type);
		}
	}
}

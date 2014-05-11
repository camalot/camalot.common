using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;
using System.Reflection;

namespace Camalot.Common.UnitTest.InExtensions.InMemberInfo {
	[TestClass]
	public class ForGetCustomAttributeValue {

		public class TestClass {
			[System.ComponentModel.Description("My very own field")]
			public int SomeField = default(int);
			public string AnotherField = default(string);
		}

		[TestMethod]
		public void WhenMemberInfoDoesNotHaveAttribute_ReturnDefaultValue() {
			var field = typeof(TestClass).GetMember("AnotherField").First();

			var expected = default(string);
			var result = field.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void WhenMemberInfoHasAttribute_ReturnValue() {
			var field = typeof(TestClass).GetMember("SomeField").First();

			var expected = "My very own field";
			var result = field.GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			Assert.AreEqual(expected, result);

		}

		[TestMethod]
		public void WhenMemberInfoIsNull_MustThrowException() {
			var field = default(MemberInfo);
			try {
				var result = ((MemberInfo)null).GetCustomAttributeValue<System.ComponentModel.DescriptionAttribute, string>(x => x.Description);
			} catch(ArgumentNullException) {
				Assert.IsNull(field);
				return;
			}
			Assert.Fail("Expected exception did not occur.");
		}
	}
}

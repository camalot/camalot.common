using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InMemberInfo {
	[TestClass]
	public class ForHasAttribute {
		public class TestClass {
			[System.ComponentModel.Description("My very own field")]
			public int SomeField = default(int);
			[System.ComponentModel.Description("My very own field")]
			public string AnotherField = default(string);
		}

		public class NoAttributesTestClass {
			public int SomeField = default(int);
			public string AnotherField = default(string);
		}

		[TestMethod]
		public void WhenMemberHasAttribute_MustReturnTrue() {
			var field = typeof(TestClass).GetMember("SomeField").First();
			var result = field.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenMemberDoesNotHaveAttribute_MustReturnFalse() {
			var field = typeof(NoAttributesTestClass).GetMember("AnotherField").First();
			var result = field.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void WhenAllMembersHaveAttribute_MustReturnTrue() {
			var fields = typeof(TestClass).GetMembers();
			var result = fields.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenNoMembersHaveAttribute_MustReturnFalse() {
			var fields = typeof(NoAttributesTestClass).GetMembers();
			var result = fields.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InFieldInfo {
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
		public void WhenFieldHasAttribute_MustReturnTrue() {
			var field = typeof(TestClass).GetField("SomeField");
			var result = field.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenFieldDoesNotHaveAttribute_MustReturnFalse() {
			var field = typeof(NoAttributesTestClass).GetField("AnotherField");
			var result = field.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void WhenAllFieldsHaveAttribute_MustReturnTrue() {
			var fields = typeof(TestClass).GetFields();
			var result = fields.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenNoFieldsHaveAttribute_MustReturnFalse() {
			var fields = typeof(NoAttributesTestClass).GetFields();
			var result = fields.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}
	}
}

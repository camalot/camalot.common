using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using System.Reflection;

namespace Camalot.Common.UnitTest.InExtensions.InMethodInfo {
	[TestClass]
	public class ForHasAttribute {
		public class TestClass {
			[System.ComponentModel.Description("description")]
			public void TestMethod1() { }
			[System.ComponentModel.Description("description")]
			public void TestMethod2() { }
		}

		public class NoAttributesTestClass {
			public void TestMethod1() { }
			public void TestMethod2() { }
		}

		[TestMethod]
		public void WhenMethodHasAttribute_MustReturnTrue() {
			var method = typeof(TestClass).GetMethod("TestMethod1");
			var result = method.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenMethodDoesNotHaveAttribute_MustReturnFalse() {
			var method = typeof(NoAttributesTestClass).GetMethod("TestMethod2");
			var result = method.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void WhenAllMethodsHaveAttribute_MustReturnTrue() {
			var method = typeof(TestClass).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			var result = method.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenNoMethodsHaveAttribute_MustReturnFalse() {
			var fields = typeof(NoAttributesTestClass).GetMethods();
			var result = fields.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}
	}
}

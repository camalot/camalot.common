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
	public class ForWithAttribute {

		public class TestClass {
			[System.ComponentModel.Description("description")]
			public void TestMethod1() { }
			[System.ComponentModel.Description("description")]
			public void TestMethod2() { }
		}

		public class NoMethodsTestClass {

		}

		[TestMethod]
		public void WhenTypeHasMethodInfo_MustReturnCollectionOfMethodInfos() {
			var methods = typeof(TestClass).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
			var result = methods.WithAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 2);
		}

		[TestMethod]
		public void WhenTypeDoesNotHaveMethodInfo_MustReturnCollectionOfMethodInfos() {
			var methods = typeof(NoMethodsTestClass).GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
			var result = methods.WithAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 0);
		}
	}
}

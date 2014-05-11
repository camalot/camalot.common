using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using System.Reflection;

namespace Camalot.Common.UnitTest.InExtensions.InParameterInfo {
	[TestClass]
	public class ForWithAttribute {

		public class TestClass {
			public void TestMethod1(
				[System.ComponentModel.Description("description")]
				int int1,
				int int2) { }
			public void TestMethod2(
				[System.ComponentModel.Description("description")]
				int int1,
				[System.ComponentModel.Description("description")]
				int int2
				) { }
			public void TestMethod3(
				int int1,
				int int2
				) { }
			public void TestMethod4() { }
		}

		[TestMethod]
		public void WhenTypeHasMethodsWithParameterInfoWithAttribute_MustReturnCollectionOfParameterInfos() {
			var methods = typeof(TestClass).GetMethod("TestMethod1");
			var paramItems = methods.GetParameters();
			var result = paramItems.WithAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 1);
		}

		[TestMethod]
		public void WhenTypeDoesNotHaveMethodsWithParameterInfoWithAttribute_MustReturnCollectionOfParameterInfos() {
			var methods = typeof(TestClass).GetMethod("TestMethod3");
			var paramItems = methods.GetParameters();
			var result = paramItems.WithAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 0);
		}
	}
}

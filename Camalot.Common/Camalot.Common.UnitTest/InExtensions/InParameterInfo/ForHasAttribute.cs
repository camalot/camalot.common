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
	public class ForHasAttribute {
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
		public void WhenMethodParameterHasAttribute_MustReturnTrue() {
			var method = typeof(TestClass).GetMethod("TestMethod1");
			var param1 = method.GetParameters().Single( x => x.Name == "int1");
			var result = param1.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenMethodParameterDoesNotHaveAttribute_MustReturnFalse() {
			var method = typeof(TestClass).GetMethod("TestMethod1");
			var param1 = method.GetParameters().Single(x => x.Name == "int2");
			var result = param1.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void WhenAllMethodParametersHaveAttribute_MustReturnTrue() {
			var method = typeof(TestClass).GetMethod("TestMethod2");
			var paramItems = method.GetParameters();
			var result = paramItems.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenNoMethodParametersHaveAttribute_MustReturnFalse() {
			var method = typeof(TestClass).GetMethod("TestMethod3");
			var paramItems = method.GetParameters();
			var result = paramItems.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void WhenNoMethodHasNoParameters_MustReturnFalse() {
			var method = typeof(TestClass).GetMethod("TestMethod4");
			var paramItems = method.GetParameters();
			var result = paramItems.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}
	}
}

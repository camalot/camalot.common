using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using System.Reflection;

namespace Camalot.Common.UnitTest.InExtensions.InPropertyInfo {
	[TestClass]
	public class ForHasAttribute {
		public class TestClass {
			[System.ComponentModel.Description("description")]
			public int Property1 { get; set; }
			[System.ComponentModel.Description("description")]
			public int Property2 { get; set; }
		}

		public class TestClass2 {
			public int Property1 { get; set; }
			public int Property2 { get; set; }
		}

		[TestMethod]
		public void WhenPropertyHasAttribute_MustReturnTrue() {
			var method = typeof(TestClass).GetProperty("Property1");
			var result = method.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenPropertyDoesNotHaveAttribute_MustReturnFalse() {
			var method = typeof(TestClass2).GetProperty("Property2");
			var result = method.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void WhenAllPropertiesHaveAttribute_MustReturnTrue() {
			var properties = typeof(TestClass).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var result = properties.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenNoPropertiesHaveAttribute_MustReturnFalse() {
			var properties = typeof(TestClass2).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var result = properties.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}
	}
}

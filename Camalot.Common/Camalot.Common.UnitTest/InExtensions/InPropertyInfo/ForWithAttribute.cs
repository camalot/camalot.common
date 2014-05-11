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
	public class ForWithAttribute {

		public class TestClass {
			[System.ComponentModel.Description("description")]
			public int Property1 { get; set; }
			public int Property2 { get; set; }
		}

		public class TestClass2 {
			public int Property1 { get; set; }
			public int Property2 { get; set; }
		}

		[TestMethod]
		public void WhenTypeHasPropertiesWithAttribute_MustReturnCollectionOfPropertyInfos() {
			var properties = typeof(TestClass).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var result = properties.WithAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 1);
		}

		[TestMethod]
		public void WhenTypeDoesNotHavePropertiesWithAttribute_MustReturnCollectionOfPropertyInfos() {
			var properties = typeof(TestClass2).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var result = properties.WithAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 0);
		}
	}
}

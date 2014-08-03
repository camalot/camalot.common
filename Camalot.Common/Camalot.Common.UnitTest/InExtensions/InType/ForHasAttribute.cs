using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InType {
	[TestClass]
	public class ForHasAttribute {
		[System.ComponentModel.Description("description")]
		public class TestClass1 {
		}

		[System.ComponentModel.Description("description")]
		public class TestClass2 {
		}

		public class TestClass3 {
		}

		[TestMethod]
		public void WhenTypeHasAttribute_MustReturnTrue() {
			var type = typeof(TestClass1);
			var result = type.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenTypeDoesNotHaveAttribute_MustReturnFalse() {
			var type = typeof(TestClass3);
			var result = type.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void WhenAllTypessHaveAttribute_MustReturnTrue() {
			var types = new[] { typeof(TestClass1), typeof(TestClass2) };
			var result = types.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenNoTypessHaveAttribute_MustReturnFalse() {
			var types = new[] { typeof(TestClass3) };
			var result = types.HasAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsFalse(result);
		}
	}
}

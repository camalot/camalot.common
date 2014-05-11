using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InType {
	[TestClass]
	public class ForGetCustomAttribute {
		[TestMethod]
		public void WhenTypeIsNull_MustReturnNull() {
			var type = (Type)null;
			var result = type.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNull(type);
			Assert.IsNull(result);
		}

		[TestMethod]
		public void WhenTypeDoesNotHaveAttribute_MustReturnNull() {
			var type = this.GetType();
			Assert.IsNotNull(type);
			var result = type.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNull(result);
		}

		[TestMethod]
		public void WhenTypeDoesHaveAttribute_MustReturnAttribute() {
			var type = this.GetType();
			Assert.IsNotNull(type);
			var result = type.GetCustomAttribute<TestClassAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Is<TestClassAttribute>());
		}
	}
}

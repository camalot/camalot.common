using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InType {
	[TestClass]
	public class ForWithAttribute {
		[System.ComponentModel.Description("description")]
		public class TestClass1 {
		}
		public class TestClass2 {
		}

		[TestMethod]
		public void WhenTypesHaveAttribute_MustReturnCollectionOfTypes() {
			var types = new[] { typeof(TestClass1), typeof(TestClass2) };
			var result = types.WithAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.GetType().GetGenericArguments().First().Is<Type>());
			Assert.IsTrue(result.Count() == 1);
		}

		[TestMethod]
		public void WhenTypesDoesNotHaveAttribute_MustReturnEmptyCollectionOfTypes() {
			var types = new[] { typeof(TestClass1), typeof(TestClass2) };
			var result = types.WithAttribute<System.ComponentModel.DisplayNameAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.GetType().GetGenericArguments().First().Is<Type>());
			Assert.IsTrue(result.Count() == 0);
		}

		[TestMethod]
		public void WhenTypesIsNull_MustReturnNull () {
			var types = default(IEnumerable<Type>);
			var result = types.WithAttribute<System.ComponentModel.DisplayNameAttribute>();
			Assert.IsNull(types);
			Assert.IsNull(result);
		}
	}
}

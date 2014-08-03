using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InType {
	[TestClass]
	public class ForQualifiedName {
		[TestMethod]
		public void WhenTypeIsNotNull_MustReturnQualifiedName() {
			var type = typeof(string);
			var expected = "System.String, mscorlib";
			var result = type.QualifiedName();
			Assert.AreEqual<string>(expected, result);
		}

		[TestMethod]
		public void WhenTypeIsNull_MustThrowException() {
			try {
				var type = default(Type);
				Assert.IsNull(type);
				var result = type.QualifiedName();
				Assert.Fail("Should have thrown exception.");
			} catch(NullReferenceException) {
				return;
			}
			Assert.Fail("Expected exception did not occur");
		}
	}
}

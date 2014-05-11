using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InType {
	[TestClass]
	public class ForIsNullable {
		[TestMethod]
		public void WhenTypeIsNull_MustThrowException() {
			try {
				var type = (Type)null;
				var result = type.IsNullable();
			} catch(NullReferenceException) {
				return;
			}
			Assert.Fail("Expected exception did not occur.");
		}

		[TestMethod]
		public void WhenTypeIsNullable_MustReturnTrue() {
			var type = typeof(DateTime?);
			var result = type.IsNullable();
			Assert.IsNotNull(type);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenTypeIsNotNullable_MustReturnFalse() {
			var type = typeof(DateTime);
			var result = type.IsNullable();
			Assert.IsNotNull(type);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void WhenTypeIsNotGeneric_MustReturnFalse() {
			var type = typeof(IEnumerable<DateTime>);
			var result = type.IsNullable();
			Assert.IsNotNull(type);
			Assert.IsFalse(result);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InGuid {
	[TestClass]
	public class ForIsEmpty {
		[TestMethod]
		public void WhenGuidIsEmpty_MustReturnTrue() {
			var guid = Guid.Empty;
			var result = guid.IsEmpty();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenGuidIsEmptyFromCreateInstance_MustReturnTrue() {
			var guid = new Guid();
			var result = guid.IsEmpty();
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenGuidIsNotEmpty_MustReturnFalse() {
			var guid = Guid.NewGuid();
			var result = guid.IsEmpty();
			Assert.IsFalse(result);
		}
	}
}

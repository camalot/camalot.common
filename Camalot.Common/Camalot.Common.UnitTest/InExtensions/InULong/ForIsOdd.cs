using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InULong {
	[TestClass]
	public class ForIsOdd {
		[TestMethod]
		public void WhenValueIsOdd_MustReturnTrue() {
			var d = (ulong)41L;
			Assert.IsTrue(d.IsOdd());
		}
		[TestMethod]
		public void WhenValueIsEven_MustReturnFalse() {
			var d = (ulong)40L;
			Assert.IsFalse(d.IsOdd());
		}
	}
}

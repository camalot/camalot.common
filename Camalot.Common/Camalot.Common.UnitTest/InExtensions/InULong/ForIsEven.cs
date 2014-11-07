using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InULong {
	[TestClass]
	public class ForIsEven {
		[TestMethod]
		public void WhenValueIsEven_MustReturnTrue() {
			var f = (ulong)40L;
			Assert.IsTrue(f.IsEven());
		}
		[TestMethod]
		public void WhenValueIsOdd_MustReturnFalse() {
			var f = (ulong)41L;
			Assert.IsFalse(f.IsEven());
		}
	}
}

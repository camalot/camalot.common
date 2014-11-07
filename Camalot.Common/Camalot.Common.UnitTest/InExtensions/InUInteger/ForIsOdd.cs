using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InUInteger {
	[TestClass]
	public class ForIsOdd {
		[TestMethod]
		public void WhenValueIsOdd_MustReturnTrue() {
			var d = (uint)41;
			Assert.IsTrue(d.IsOdd());
		}
		[TestMethod]
		public void WhenValueIsEven_MustReturnFalse() {
			var d = (uint)40;
			Assert.IsFalse(d.IsOdd());
		}
	}
}

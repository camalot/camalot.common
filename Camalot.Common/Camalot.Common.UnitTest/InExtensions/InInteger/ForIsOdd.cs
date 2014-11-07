using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InInteger {
	[TestClass]
	public class ForIsOdd {
		[TestMethod]
		public void WhenValueIsOdd_MustReturnTrue() {
			var d = (int)41;
			Assert.IsTrue(d.IsOdd());
		}
		[TestMethod]
		public void WhenValueIsEven_MustReturnFalse() {
			var d = (int)40;
			Assert.IsFalse(d.IsOdd());
		}
	}
}

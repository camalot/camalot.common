using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InFloat {
	[TestClass]
	public class ForIsEven {
		[TestMethod]
		public void WhenValueIsEven_MustReturnTrue() {
			var f = 40f;
			Assert.IsTrue(f.IsEven());
		}
		[TestMethod]
		public void WhenValueIsOdd_MustReturnFalse() {
			var f = 41f;
			Assert.IsFalse(f.IsEven());
		}
	}
}

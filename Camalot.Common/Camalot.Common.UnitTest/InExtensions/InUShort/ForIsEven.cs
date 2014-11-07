using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InUShort {
	[TestClass]
	public class ForIsEven {
		[TestMethod]
		public void WhenValueIsEven_MustReturnTrue() {
			var f = (ushort)40;
			Assert.IsTrue(f.IsEven());
		}
		[TestMethod]
		public void WhenValueIsOdd_MustReturnFalse() {
			var f = (ushort)41;
			Assert.IsFalse(f.IsEven());
		}
	}
}

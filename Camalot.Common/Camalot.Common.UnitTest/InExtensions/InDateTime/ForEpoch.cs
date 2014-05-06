using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InDateTime {
	[TestClass]
	public class ForEpoch {
		[TestMethod]
		public void WhenDateTimeIsAnyThing_ReturnEpochDateTime() {
			var expected = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			var epoch = DateTime.Now.Epoch();
			Assert.AreEqual(expected, epoch);
		}
	}
}

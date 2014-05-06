using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InDateTime {
	[TestClass]
	public class ForRoundUp {
		[TestMethod]
		public void WhenDateTimeMinuteLower_ReturnRoundedUpDateTime() {
			var date = new DateTime(2012, 1, 1, 12, 10, 40);
			var expected = new DateTime(2012, 1, 1, 12, 15, 0);
			var rounded = date.RoundUp(new TimeSpan(0, 15, 0));
			Assert.AreEqual<DateTime>(expected, rounded);
		}

		[TestMethod]
		public void WhenDateTimeMinuteHigher_ReturnRoundedUpDateTime() {
			var date = new DateTime(2012, 1, 1, 12, 16, 40);
			var expected = new DateTime(2012, 1, 1, 12, 30, 0);
			var rounded = date.RoundUp(new TimeSpan(0, 15, 0));
			Assert.AreEqual<DateTime>(expected, rounded);
		}
	}
}

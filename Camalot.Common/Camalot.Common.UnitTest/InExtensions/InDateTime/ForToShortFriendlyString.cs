using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InDateTime {
	[TestClass]
	public class ForToShortFriendlyString {
		[TestMethod]
		public void WhenDateTimeIsSecondsAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddSeconds(-4);
			var message = date.ToShortFriendlyString();
			Assert.AreEqual<string>("now", message);
		}

		[TestMethod]
		public void WhenDateTimeIsMinutesAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddMinutes(-4);
			var message = date.ToShortFriendlyString();
			Assert.AreEqual<string>("4m", message);
		}

		[TestMethod]
		public void WhenDateTimeIsHoursAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddHours(-4);
			var message = date.ToShortFriendlyString();
			Assert.AreEqual<string>("4h", message);
		}

		[TestMethod]
		public void WhenDateTimeIsDaysAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-4);
			var message = date.ToShortFriendlyString();
			Assert.AreEqual<string>("4d", message);
		}

		[TestMethod]
		public void WhenDateTimeIsWeeksAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-14);
			var message = date.ToShortFriendlyString();
			Assert.AreEqual<string>("2w", message);
		}

		[TestMethod]
		public void WhenDateTimeIsMonthsAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-(4 * 31));
			var message = date.ToShortFriendlyString();
			Assert.AreEqual<string>("4M", message);
		}

		[TestMethod]
		public void WhenDateTimeIsYearsAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddYears(-4);
			var message = date.ToShortFriendlyString();
			Assert.AreEqual<string>("4y", message);
		}

	}
}

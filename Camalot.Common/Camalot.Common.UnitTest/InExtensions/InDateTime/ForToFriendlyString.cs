using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InDateTime {
	[TestClass]
	public class ForToFriendlyString {
		[TestMethod]
		public void WhenDateTimeIsSecondsAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddSeconds(-4);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("just now", message);
		}

		[TestMethod]
		public void WhenDateTimeIsMinutesAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddMinutes(-4);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("4 minutes ago", message);
		}

		[TestMethod]
		public void WhenDateTimeIsOneMinuteAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddMinutes(-1);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("a minute ago", message);
		}

		[TestMethod]
		public void WhenDateTimeIsHoursAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddHours(-4);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("4 hours ago", message);
		}

		[TestMethod]
		public void WhenDateTimeIsOneHourAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddHours(-1);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("an hour ago", message);
		}


		[TestMethod]
		public void WhenDateTimeIsDaysAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-4);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("4 days ago", message);
		}

		[TestMethod]
		public void WhenDateTimeIsOneDayAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-1);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("a day ago", message);
		}

		[TestMethod]
		public void WhenDateTimeIsWeeksAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-14);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("2 weeks ago", message);
		}

		[TestMethod]
		public void WhenDateTimeIsOneWeekAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-8);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("a week ago", message);
		}


		[TestMethod]
		public void WhenDateTimeIsMonthsAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-(4 * 31));
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("4 months ago", message);
		}

		[TestMethod]
		public void WhenDateTimeIsOneMonthAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-32);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("a month ago", message);
		}

		[TestMethod]
		public void WhenDateTimeIsYearsAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddYears(-4);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("4 years ago", message);
		}

		[TestMethod]
		public void WhenDateTimeIsOneYearAgo_ReturnSecondsBasedString() {
			var date = DateTime.UtcNow.AddDays(-366);
			var message = date.ToFriendlyString();
			Assert.AreEqual<string>("a year ago", message);
		}
	}
}

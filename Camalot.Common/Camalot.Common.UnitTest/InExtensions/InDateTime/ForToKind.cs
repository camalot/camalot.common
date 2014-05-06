using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InDateTime {
	[TestClass]
	public class ForToKind {
		[TestMethod]
		public void WhenDateTimeKindIsUnspecified_ReturnDateTimeUtc() {
			var fixture = new Fixture();
			var date = fixture.Create<DateTime>();
			var newDate = date.ToKind(DateTimeKind.Utc);
			Assert.AreEqual<DateTimeKind>(DateTimeKind.Utc, newDate.Kind);

		}

		[TestMethod]
		public void WhenDateTimeKindIsLocal_ReturnDateTimeUtc() {
			var fixture = new Fixture();
			var date = DateTime.SpecifyKind(fixture.Create<DateTime>(), DateTimeKind.Local);
			var newDate = date.ToKind(DateTimeKind.Utc);
			Assert.AreEqual<DateTimeKind>(DateTimeKind.Utc, newDate.Kind);
		}

		[TestMethod]
		public void WhenDateTimeKindIsUtc_ReturnDateTimeUtc() {
			var fixture = new Fixture();
			var date = DateTime.SpecifyKind(fixture.Create<DateTime>(), DateTimeKind.Utc);
			var newDate = date.ToKind(DateTimeKind.Utc);
			Assert.AreEqual<DateTimeKind>(DateTimeKind.Utc, newDate.Kind);
			Assert.AreEqual<DateTime>(date, newDate);
		}
	}
}

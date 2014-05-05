using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InRequire {
	[TestClass]
	public class ForRequireNegative {
		// RequireNegative(int)
		[TestMethod]
		public void WhenIntIsPositive_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<int>();
			var result = default(int);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<int>(default(int), result);
				return;
			}
			Assert.Fail("Required int with negative did not result in exception");
		}

		[TestMethod]
		public void WhenIntIsPositive_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = fixture.Create<int>();
			var result = default(int);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<int>(default(int), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required int with negative did not result in exception");
		}

		[TestMethod]
		public void WhenIntIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(int);
			var result = default(int);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<int>(default(int), test);
				Assert.AreEqual<int>(default(int), result);
				return;
			}
			Assert.Fail("Required int with negative did not result in exception");
		}

		[TestMethod]
		public void WhenIntIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(int);
			var result = default(int);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<int>(default(int), test);
				Assert.AreEqual<int>(default(int), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required int with negative did not result in exception");
		}

		[TestMethod]
		public void WhenIntIsNotPositive_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<int>() * -1;
			var result = test.RequireNegative();
			Assert.AreEqual<int>(test, result);
		}

		// RequireNegative(float)
		[TestMethod]
		public void WhenFloatIsPositive_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<float>();
			var result = default(float);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<float>(default(float), result);
				return;
			}
			Assert.Fail("Required float with negative did not result in exception");
		}

		[TestMethod]
		public void WhenFloatIsPositive_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = fixture.Create<float>();
			var result = default(float);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<float>(default(float), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required float with negative did not result in exception");
		}


		[TestMethod]
		public void WhenFloatIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(float);
			var result = default(float);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<float>(default(float), test);
				Assert.AreEqual<float>(default(float), result);
				return;
			}
			Assert.Fail("Required float with negative did not result in exception");
		}

		[TestMethod]
		public void WhenFloatIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(float);
			var result = default(float);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<float>(default(float), test);
				Assert.AreEqual<float>(default(float), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required float with negative did not result in exception");
		}

		[TestMethod]
		public void WhenFloatIsNotPositive_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<float>() * -1;
			var result = test.RequireNegative();
			Assert.AreEqual<float>(test, result);
		}

		// RequireNegative(double)
		[TestMethod]
		public void WhenDoubleIsPositive_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<double>();
			var result = default(double);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<double>(default(double), result);
				return;
			}
			Assert.Fail("Required double with negative did not result in exception");
		}

		[TestMethod]
		public void WhenDoubleIsPositive_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = fixture.Create<double>();
			var result = default(double);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<double>(default(double), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required double with negative did not result in exception");
		}

		[TestMethod]
		public void WhenDoubleIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(double);
			var result = default(double);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<double>(default(double), test);
				Assert.AreEqual<double>(default(double), result);
				return;
			}
			Assert.Fail("Required double with negative did not result in exception");
		}

		[TestMethod]
		public void WhenDoubleIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(double);
			var result = default(double);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<double>(default(double), test);
				Assert.AreEqual<double>(default(double), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required double with negative did not result in exception");
		}

		[TestMethod]
		public void WhenDoubleIsNotPositive_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<double>() * -1;
			var result = test.RequireNegative();
			Assert.AreEqual<double>(test, result);
		}

		// RequireNegative(short)
		[TestMethod]
		public void WhenShortIsPositive_MustThrowException() {
			var fixture = new Fixture();
			var test = (short)(fixture.Create<short>());
			var result = default(short);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<short>(default(short), result);
				return;
			}
			Assert.Fail("Required short with negative did not result in exception");
		}

		[TestMethod]
		public void WhenShortIsPositive_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = (short)(fixture.Create<short>());
			var result = default(short);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<short>(default(short), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required short with negative did not result in exception");
		}

		[TestMethod]
		public void WhenShortIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(short);
			var result = default(short);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<short>(default(short), test);
				Assert.AreEqual<short>(default(short), result);
				return;
			}
			Assert.Fail("Required short with negative did not result in exception");
		}

		[TestMethod]
		public void WhenShortIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(short);
			var result = default(short);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<short>(default(short), test);
				Assert.AreEqual<short>(default(short), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required short with negative did not result in exception");
		}

		[TestMethod]
		public void WhenShortIsNotPositive_MustNotThrowException() {
			var fixture = new Fixture();
			var test = (short)(fixture.Create<short>() * -1);
			var result = test.RequireNegative();
			Assert.AreEqual<short>(test, result);
		}

		// RequireNegative(long)
		[TestMethod]
		public void WhenLongIsPositive_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<long>();
			var result = default(long);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<long>(default(long), result);
				return;
			}
			Assert.Fail("Required long with negative did not result in exception");
		}

		[TestMethod]
		public void WhenLongIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(long);
			var result = default(long);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<long>(default(long), test);
				Assert.AreEqual<long>(default(long), result);
				return;
			}
			Assert.Fail("Required long with negative did not result in exception");
		}

		[TestMethod]
		public void WhenLongIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(long);
			var result = default(long);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<long>(default(long), test);
				Assert.AreEqual<long>(default(long), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required long with negative did not result in exception");
		}

		[TestMethod]
		public void WhenLongIsNotPositive_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<long>() * -1;
			var result = test.RequireNegative();
			Assert.AreEqual<long>(test, result);
		}

		// RequireNegative(decimal)
		[TestMethod]
		public void WhenDecimalIsPositive_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<decimal>();
			var result = default(decimal);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.AreEqual<decimal>(default(decimal), result);
				return;
			}
			Assert.Fail("Required decimal with negative did not result in exception");
		}

		[TestMethod]
		public void WhenDecimalIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(decimal);
			var result = default(decimal);
			try {
				result = test.RequireNegative();
			} catch(ArgumentException) {
				Assert.IsTrue(test == 0);
				Assert.AreEqual<decimal>(default(decimal), test);
				Assert.AreEqual<decimal>(default(decimal), result);
				return;
			}
			Assert.Fail("Required decimal with negative did not result in exception");
		}

		[TestMethod]
		public void WhenDecimalIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(decimal);
			var result = default(decimal);
			var param = "test";
			try {
				result = test.RequireNegative(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<decimal>(default(decimal), test);
				Assert.AreEqual<decimal>(default(decimal), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required decimal with negative did not result in exception");
		}

		[TestMethod]
		public void WhenDecimalIsNotPositive_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<decimal>() * -1;
			var result = test.RequireNegative();
			Assert.AreEqual<decimal>(test, result);
		}

	}
}

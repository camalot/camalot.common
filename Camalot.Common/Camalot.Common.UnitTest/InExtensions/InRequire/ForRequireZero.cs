using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;

/// <summary>
/// 
/// </summary>
namespace Camalot.Common.UnitTest.InExtensions.InRequire {
	[TestClass]
	public class ForRequireZero {
		// RequireZero(int)
		[TestMethod]
		public void WhenIntIsZero_MustNotThrowException() {
			var fixture = new Fixture();
			int test = 0;

			var result = test.RequireZero();
			Assert.AreEqual<int>(test, result);
		}

		[TestMethod]
		public void WhenIntIsZero_MustNotThrowExceptionWithMessage() {
			var fixture = new Fixture();
			int test = 0;
			var message = "test";
			var result = test.RequireZero(message);
			Assert.AreEqual<int>(test, result);
		}

		[TestMethod]
		public void WhenIntIsNotZero_MustThrowException() {
			var fixture = new Fixture();
			int test = 1;
			var result = default(int);
			try {
				result = test.RequireZero();
			} catch(ArgumentException) {
				Assert.AreEqual<int>(default(int), result);
				return;
			}
			Assert.Fail("Required int of zero did not result in exception");
		}

		[TestMethod]
		public void WhenIntIsNotZero_MustThrowExceptionWithParamName() {
			var fixture = new Fixture();
			int test = 1;
			var result = default(int);
			var message = "test";
			try {
				result = test.RequireZero(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<int>(default(int), result);
				Assert.IsTrue(aex.Message.Contains(message));
				return;
			}
			Assert.Fail("Required int of zero did not result in exception");
		}

		// RequireZero(short)
		[TestMethod]
		public void WhenShortIsZero_MustNotThrowException() {
			var fixture = new Fixture();
			short test = 0;

			var result = test.RequireZero();
			Assert.AreEqual<short>(test, result);
		}

		[TestMethod]
		public void WhenShortIsZero_MustNotThrowExceptionWithMessage() {
			var fixture = new Fixture();
			short test = 0;
			var message = "test";
			var result = test.RequireZero(message);
			Assert.AreEqual<short>(test, result);
		}

		[TestMethod]
		public void WhenShortIsNotZero_MustThrowException() {
			var fixture = new Fixture();
			short test = 1;
			var result = default(short);
			try {
				result = test.RequireZero();
			} catch(ArgumentException) {
				Assert.AreEqual<short>(default(short), result);
				return;
			}
			Assert.Fail("Required short of zero did not result in exception");
		}

		[TestMethod]
		public void WhenShortIsNotZero_MustThrowExceptionWithParamName() {
			var fixture = new Fixture();
			short test = 1;
			var result = default(short);
			var message = "test";
			try {
				result = test.RequireZero(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<short>(default(short), result);
				Assert.IsTrue(aex.Message.Contains(message));
				return;
			}
			Assert.Fail("Required short of zero did not result in exception");
		}

		// RequireZero(long)
		[TestMethod]
		public void WhenLongIsZero_MustNotThrowException() {
			var fixture = new Fixture();
			long test = 0L;

			var result = test.RequireZero();
			Assert.AreEqual<long>(test, result);
		}

		[TestMethod]
		public void WhenLongIsZero_MustNotThrowExceptionWithMessage() {
			var fixture = new Fixture();
			long test = 0L;
			var message = "test";
			var result = test.RequireZero(message);
			Assert.AreEqual<long>(test, result);
		}

		[TestMethod]
		public void WhenLongIsNotZero_MustThrowException() {
			var fixture = new Fixture();
			long test = 1L;
			var result = default(long);
			try {
				result = test.RequireZero();
			} catch(ArgumentException) {
				Assert.AreEqual<long>(default(long), result);
				return;
			}
			Assert.Fail("Required long of zero did not result in exception");
		}

		[TestMethod]
		public void WhenLongIsNotZero_MustThrowExceptionWithParamName() {
			var fixture = new Fixture();
			long test = 1;
			var result = default(long);
			var message = "test";
			try {
				result = test.RequireZero(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<long>(default(long), result);
				Assert.IsTrue(aex.Message.Contains(message));
				return;
			}
			Assert.Fail("Required long of zero did not result in exception");
		}

		// RequireZero(decimal)
		[TestMethod]
		public void WhenDecimalIsZero_MustNotThrowException() {
			var fixture = new Fixture();
			decimal test = 0M;

			var result = test.RequireZero();
			Assert.AreEqual<decimal>(test, result);
		}

		[TestMethod]
		public void WhenDecimalIsZero_MustNotThrowExceptionWithMessage() {
			var fixture = new Fixture();
			decimal test = 0M;
			var message = "test";
			var result = test.RequireZero(message);
			Assert.AreEqual<decimal>(test, result);
		}

		[TestMethod]
		public void WhenDecimalIsNotZero_MustThrowException() {
			var fixture = new Fixture();
			decimal test = 1M;
			var result = default(decimal);
			try {
				result = test.RequireZero();
			} catch(ArgumentException) {
				Assert.AreEqual<decimal>(default(decimal), result);
				return;
			}
			Assert.Fail("Required Decimal of zero did not result in exception");
		}

		[TestMethod]
		public void WhenDecimalIsNotZero_MustThrowExceptionWithParamName() {
			var fixture = new Fixture();
			decimal test = 1M;
			var result = default(decimal);
			var message = "test";
			try {
				result = test.RequireZero(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<decimal>(default(decimal), result);
				Assert.IsTrue(aex.Message.Contains(message));
				return;
			}
			Assert.Fail("Required Decimal of zero did not result in exception");
		}

		// RequireZero(double)
		[TestMethod]
		public void WhenDoubleIsZero_MustNotThrowException() {
			var fixture = new Fixture();
			double test = 0D;

			var result = test.RequireZero();
			Assert.AreEqual<double>(test, result);
		}

		[TestMethod]
		public void WhenDoubleIsZero_MustNotThrowExceptionWithMessage() {
			var fixture = new Fixture();
			double test = 0D;
			var message = "test";
			var result = test.RequireZero(message);
			Assert.AreEqual<double>(test, result);
		}

		[TestMethod]
		public void WhenDoubleIsNotZero_MustThrowException() {
			var fixture = new Fixture();
			double test = 1D;
			var result = default(double);
			try {
				result = test.RequireZero();
			} catch(ArgumentException) {
				Assert.AreEqual<double>(default(double), result);
				return;
			}
			Assert.Fail("Required Double of zero did not result in exception");
		}

		[TestMethod]
		public void WhenDoubleIsNotZero_MustThrowExceptionWithParamName() {
			var fixture = new Fixture();
			double test = 1D;
			var result = default(double);
			var message = "test";
			try {
				result = test.RequireZero(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<double>(default(double), result);
				Assert.IsTrue(aex.Message.Contains(message));
				return;
			}
			Assert.Fail("Required Double of zero did not result in exception");
		}

		// RequireZero(float)
		[TestMethod]
		public void WhenFloatIsZero_MustNotThrowException() {
			var fixture = new Fixture();
			float test = 0F;

			var result = test.RequireZero();
			Assert.AreEqual<float>(test, result);
		}

		[TestMethod]
		public void WhenFloatIsZero_MustNotThrowExceptionWithMessage() {
			var fixture = new Fixture();
			float test = 0F;
			var message = "test";
			var result = test.RequireZero(message);
			Assert.AreEqual<float>(test, result);
		}

		[TestMethod]
		public void WhenFloatIsNotZero_MustThrowException() {
			var fixture = new Fixture();
			float test = 1F;
			var result = default(float);
			try {
				result = test.RequireZero();
			} catch(ArgumentException) {
				Assert.AreEqual<float>(default(float), result);
				return;
			}
			Assert.Fail("Required Float of zero did not result in exception");
		}

		[TestMethod]
		public void WhenFloatIsNotZero_MustThrowExceptionWithParamName() {
			var fixture = new Fixture();
			float test = 1F;
			var result = default(float);
			var message = "test";
			try {
				result = test.RequireZero(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<float>(default(float), result);
				Assert.IsTrue(aex.Message.Contains(message));
				return;
			}
			Assert.Fail("Required Float of zero did not result in exception");
		}

	}
}

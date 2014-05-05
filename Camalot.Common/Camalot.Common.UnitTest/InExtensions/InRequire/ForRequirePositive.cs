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
	public class ForRequirePositive {
		// RequirePositive(int)
		[TestMethod]
		public void WhenIntIsNegative_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<int>() * -1;
			var result = default(int);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<int>(default(int), result);
				return;
			}
			Assert.Fail("Required int with positive did not result in exception");
		}

		[TestMethod]
		public void WhenIntIsNegative_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = fixture.Create<int>() * -1;
			var result = default(int);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<int>(default(int), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required int with positive did not result in exception");
		}

		[TestMethod]
		public void WhenIntIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(int);
			var result = default(int);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<int>(default(int), test);
				Assert.AreEqual<int>(default(int), result);
				return;
			}
			Assert.Fail("Required int with positive did not result in exception");
		}

		[TestMethod]
		public void WhenIntIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(int);
			var result = default(int);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<int>(default(int), test);
				Assert.AreEqual<int>(default(int), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required int with positive did not result in exception");
		}

		[TestMethod]
		public void WhenIntIsNotNegative_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<int>();
			var	result = test.RequirePositive();
			Assert.AreEqual<int>(test, result);
		}

		// RequirePositive(float)
		[TestMethod]
		public void WhenFloatIsNegative_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<float>() * -1;
			var result = default(float);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<float>(default(float), result);
				return;
			}
			Assert.Fail("Required float with positive did not result in exception");
		}

		[TestMethod]
		public void WhenFloatIsNegative_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = fixture.Create<float>() * -1;
			var result = default(float);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<float>(default(float), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required float with positive did not result in exception");
		}


		[TestMethod]
		public void WhenFloatIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(float);
			var result = default(float);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<float>(default(float), test);
				Assert.AreEqual<float>(default(float), result);
				return;
			}
			Assert.Fail("Required float with positive did not result in exception");
		}

		[TestMethod]
		public void WhenFloatIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(float);
			var result = default(float);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<float>(default(float), test);
				Assert.AreEqual<float>(default(float), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required float with positive did not result in exception");
		}

		[TestMethod]
		public void WhenFloatIsNotNegative_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<float>();
			var result = test.RequirePositive();
			Assert.AreEqual<float>(test, result);
		}

		// RequirePositive(double)
		[TestMethod]
		public void WhenDoubleIsNegative_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<double>() * -1;
			var result = default(double);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<double>(default(double), result);
				return;
			}
			Assert.Fail("Required double with positive did not result in exception");
		}

		[TestMethod]
		public void WhenDoubleIsNegative_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = fixture.Create<double>() * -1;
			var result = default(double);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<double>(default(double), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required double with positive did not result in exception");
		}

		[TestMethod]
		public void WhenDoubleIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(double);
			var result = default(double);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<double>(default(double), test);
				Assert.AreEqual<double>(default(double), result);
				return;
			}
			Assert.Fail("Required double with positive did not result in exception");
		}

		[TestMethod]
		public void WhenDoubleIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(double);
			var result = default(double);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<double>(default(double), test);
				Assert.AreEqual<double>(default(double), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required double with positive did not result in exception");
		}

		[TestMethod]
		public void WhenDoubleIsNotNegative_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<double>();
			var result = test.RequirePositive();
			Assert.AreEqual<double>(test, result);
		}

		// RequirePositive(short)
		[TestMethod]
		public void WhenShortIsNegative_MustThrowException() {
			var fixture = new Fixture();
			var test = (short)(fixture.Create<short>() * -1);
			var result = default(short);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<short>(default(short), result);
				return;
			}
			Assert.Fail("Required short with positive did not result in exception");
		}

		[TestMethod]
		public void WhenShortIsNegative_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = (short)(fixture.Create<short>() * -1);
			var result = default(short);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<short>(default(short), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required short with positive did not result in exception");
		}

		[TestMethod]
		public void WhenShortIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(short);
			var result = default(short);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<short>(default(short), test);
				Assert.AreEqual<short>(default(short), result);
				return;
			}
			Assert.Fail("Required short with positive did not result in exception");
		}

		[TestMethod]
		public void WhenShortIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(short);
			var result = default(short);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<short>(default(short), test);
				Assert.AreEqual<short>(default(short), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required short with positive did not result in exception");
		}

		[TestMethod]
		public void WhenShortIsNotNegative_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<short>();
			var result = test.RequirePositive();
			Assert.AreEqual<short>(test, result);
		}

		// RequirePositive(long)
		[TestMethod]
		public void WhenLongIsNegative_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<long>() * -1;
			var result = default(long);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<long>(default(long), result);
				return;
			}
			Assert.Fail("Required long with positive did not result in exception");
		}

		[TestMethod]
		public void WhenLongIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(long);
			var result = default(long);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<long>(default(long), test);
				Assert.AreEqual<long>(default(long), result);
				return;
			}
			Assert.Fail("Required long with positive did not result in exception");
		}

		[TestMethod]
		public void WhenLongIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(long);
			var result = default(long);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<long>(default(long), test);
				Assert.AreEqual<long>(default(long), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required long with positive did not result in exception");
		}

		[TestMethod]
		public void WhenLongIsNotNegative_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<long>();
			var result = test.RequirePositive();
			Assert.AreEqual<long>(test, result);
		}

		// RequirePositive(decimal)
		[TestMethod]
		public void WhenDecimalIsNegative_MustThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<decimal>() * -1;
			var result = default(decimal);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.AreEqual<decimal>(default(decimal), result);
				return;
			}
			Assert.Fail("Required decimal with positive did not result in exception");
		}

		[TestMethod]
		public void WhenDecimalIsZero_MustThrowException() {
			var fixture = new Fixture();
			var test = default(decimal);
			var result = default(decimal);
			try {
				result = test.RequirePositive();
			} catch(ArgumentException) {
				Assert.IsTrue(test == 0);
				Assert.AreEqual<decimal>(default(decimal), test);
				Assert.AreEqual<decimal>(default(decimal), result);
				return;
			}
			Assert.Fail("Required decimal with positive did not result in exception");
		}

		[TestMethod]
		public void WhenDecimalIsZero_MustThrowExceptionWithParam() {
			var fixture = new Fixture();
			var test = default(decimal);
			var result = default(decimal);
			var param = "test";
			try {
				result = test.RequirePositive(param);
			} catch(ArgumentException aex) {
				Assert.AreEqual<decimal>(default(decimal), test);
				Assert.AreEqual<decimal>(default(decimal), result);
				Assert.IsTrue(aex.Message.Contains(param));
				return;
			}
			Assert.Fail("Required decimal with positive did not result in exception");
		}

		[TestMethod]
		public void WhenDecimalIsNotNegative_MustNotThrowException() {
			var fixture = new Fixture();
			var test = fixture.Create<decimal>();
			var result = test.RequirePositive();
			Assert.AreEqual<decimal>(test, result);
		}

	}
}

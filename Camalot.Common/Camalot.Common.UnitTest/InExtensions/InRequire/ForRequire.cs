using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;
using Moq;

namespace Camalot.Common.UnitTest.InExtensions.InRequire {
	[TestClass]
	public class ForRequire {
		[TestMethod]
		public void WhenObjectNotNull_MustNotThrowException ( ) {
			var fixture = new Fixture ( );
			var obj = fixture.Build<object>().Create<object>();

			var result = obj.Require();
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void WhenObjectNull_MustThrowException() {
			var fixture = new Fixture();
			object obj = null;
			object result = null;
			try {
				result = obj.Require();
			} catch(ArgumentException) {
				Assert.IsNull(obj);
				Assert.IsNull(result);
				return;
			}

			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenObjectNotNull_MustNotThrowExceptionWithMessage() {
			var fixture = new Fixture();
			var obj = fixture.Build<object>().Create<object>();

			var result = obj.Require("No Message");
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void WhenObjectNull_MustThrowExceptionWithMessage() {
			var fixture = new Fixture();
			object obj = null;
			object result = null;
			var message = "Required";
			try {
				result = obj.Require(message);
			} catch(ArgumentException aex) {
				Assert.IsNull(obj);
				Assert.IsNull(result);
				Assert.AreEqual<string>(aex.Message, message);
				return;
			}

			Assert.Fail("Required null object did not result in exception");
		}


		// Require(Object)

		[TestMethod]
		public void WhenGuidIsEmpty_MustThrowException() {
			var fixture = new Fixture();
			var guid = default(Guid);
			Guid result = default(Guid);
			try {
				result = guid.Require();
			} catch(ArgumentException) {
				Assert.AreEqual<Guid>(default(Guid), guid);
				Assert.AreEqual<Guid>(default(Guid), result);
				return;
			}
			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenGuidIsEmpty_MustThrowExceptionWithMessage() {
			var fixture = new Fixture();
			var guid = default(Guid);
			var result = default(Guid);
			var message = "Required";
			try {
				result = guid.Require(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<Guid>(default(Guid), guid);
				Assert.AreEqual<Guid>(default(Guid), result);
				Assert.AreEqual<string>(aex.Message, message);
				return;
			}
			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenGuidIsNotEmpty_MustNotThrowException() {
			var fixture = new Fixture();
			var guid = Guid.NewGuid();
			var result = guid.Require();
			Assert.AreNotEqual<Guid>(default(Guid), result);
			Assert.AreEqual<Guid>(result, guid);
		}

		[TestMethod]
		public void WhenGuidIsNotEmpty_MustThrowNotExceptionWithMessage() {
			var fixture = new Fixture();
			var guid = Guid.NewGuid();
			var message = "Required";
			var result = guid.Require(message);
			Assert.AreNotEqual<Guid>(default(Guid), result);
			Assert.AreEqual<Guid>(result, guid);
		}


		// Require<T>

		[TestMethod]
		public void WhenTIsEmpty_MustThrowException() {
			var fixture = new Fixture();
			var guid = default(Guid);
			Guid result = default(Guid);
			try {
				result = guid.Require<Guid>();
			} catch(ArgumentException) {
				Assert.AreEqual<Guid>(default(Guid), guid);
				Assert.AreEqual<Guid>(default(Guid), result);
				return;
			}
			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenTIsEmpty_MustThrowExceptionWithMessage() {
			var fixture = new Fixture();
			var guid = default(Guid);
			var result = default(Guid);
			var message = "Required";
			try {
				result = guid.Require<Guid>(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<Guid>(default(Guid), guid);
				Assert.AreEqual<Guid>(default(Guid), result);
				Assert.AreEqual<string>(aex.Message, message);
				return;
			}
			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenTIsNotEmpty_MustNotThrowException() {
			var fixture = new Fixture();
			var guid = Guid.NewGuid();
			var result = guid.Require<Guid>();
			Assert.AreNotEqual<Guid>(default(Guid), result);
			Assert.AreEqual<Guid>(result, guid);
		}

		[TestMethod]
		public void WhenTIsNotEmpty_MustThrowNotExceptionWithMessage() {
			var fixture = new Fixture();
			var guid = Guid.NewGuid();
			var message = "Required";
			var result = guid.Require<Guid>(message);
			Assert.AreNotEqual<Guid>(default(Guid), result);
			Assert.AreEqual<Guid>(result, guid);
		}


		// Require(String)

		[TestMethod]
		public void WhenStringIsEmpty_MustThrowException() {
			var fixture = new Fixture();
			var str = default(string);
			var result = default(string);
			try {
				result = str.Require();
			} catch(ArgumentException) {
				Assert.AreEqual<string>(default(string), str);
				Assert.AreEqual<string>(default(string), result);
				return;
			}
			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenStringIsEmpty_MustThrowExceptionWithMessage() {
			var fixture = new Fixture();
			var str = default(string);
			var result = default(string);
			var message = "Required";
			try {
				result = str.Require(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<string>(default(string), str);
				Assert.AreEqual<string>(default(string), result);
				Assert.AreEqual<string>(aex.Message, message);
				return;
			}
			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenStringIsNotEmpty_MustNotThrowException() {
			var fixture = new Fixture();
			var str = fixture.Create<string>();
			var result = str.Require();
			Assert.AreNotEqual<string>(default(string), result);
			Assert.AreEqual<string>(result, str);
		}

		[TestMethod]
		public void WhenStringIsNotEmpty_MustThrowNotExceptionWithMessage() {
			var fixture = new Fixture();
			var str = fixture.Create<string>();
			var message = "Required";
			var result = str.Require(message);
			Assert.AreNotEqual<string>(default(string), result);
			Assert.AreEqual<string>(result, str);
		}

		// Require<T?>

		[TestMethod]
		public void WhenNullableTIsNull_MustThrowException() {
			var fixture = new Fixture();
			var guid = default(Guid?);
			var result = default(Guid?);
			try {
				result = guid.Require<Guid?>();
			} catch(ArgumentException) {
				Assert.AreEqual<Guid?>(default(Guid?), guid);
				Assert.AreEqual<Guid?>(default(Guid?), result);
				return;
			}
			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenNullableTIsNull_MustThrowExceptionWithMessage() {
			var fixture = new Fixture();
			var guid = default(Guid?);
			var result = default(Guid?);
			var message = "Required";
			try {
				result = guid.Require<Guid?>(message);
			} catch(ArgumentException aex) {
				Assert.AreEqual<Guid?>(default(Guid?), guid);
				Assert.AreEqual<Guid?>(default(Guid?), result);
				Assert.AreEqual<string>(aex.Message, message);
				return;
			}
			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenNullableTIsNotNull_MustNotThrowException() {
			var fixture = new Fixture();
			Guid? guid = Guid.NewGuid();
			var result = guid.Require<Guid?>();
			Assert.IsTrue(result.HasValue);
			Assert.AreNotEqual<Guid?>(default(Guid?), result);
			Assert.AreEqual<Guid?>(result, guid);
		}

		[TestMethod]
		public void WhenNullableTIsNotNull_MustThrowNotExceptionWithMessage() {
			var fixture = new Fixture();
			Guid? guid = Guid.NewGuid();
			var message = "Required";
			var result = guid.Require<Guid?>(message);
			Assert.AreNotEqual<Guid?>(default(Guid?), result);
			Assert.AreEqual<Guid?>(result, guid);
		}
	}
}

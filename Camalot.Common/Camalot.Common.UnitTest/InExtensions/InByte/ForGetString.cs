using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InByte {
	[TestClass]
	public class ForGetString {
		[TestMethod]
		public void WhenUnicodeByteArrayIsNotNull_MustReturnString() {
			var fixture = new Fixture();
			var source = "source string";
			var bytes = source.GetBytes(Encoding.Unicode);
			Assert.AreEqual<string>(source, bytes.GetString());
			Assert.AreEqual<string>(source, bytes.GetString(Encoding.Unicode));
		}

		[TestMethod]
		public void WhenAsciiByteArrayIsNotNull_MustReturnString() {
			var fixture = new Fixture();
			var source = "source string";
			var bytes = source.GetBytes(Encoding.ASCII);
			Assert.AreEqual<string>(source, bytes.GetString(Encoding.ASCII));
		}

		[TestMethod]
		public void WhenByteArrayIsNull_MustThrowException() {
			try {
				var bytes = default(byte[]);
				var result = bytes.GetString();
			} catch(ArgumentNullException ane) {
				Assert.AreEqual<string>("bytes", ane.ParamName);
				return;
			}
			Assert.Fail("Expected exception");
		}
	}
}

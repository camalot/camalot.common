using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InByte {
	[TestClass]
	public class ForToHex {
		[TestMethod]
		public void WhenByteArrayIsNotNull_MustReturnHexString() {
			var b = new byte[] { (byte)255 };
			var h = b.ToHex();
			Assert.AreEqual<string>("FF", h);
		}

		[TestMethod]
		public void WhenByteArrayIsNull_MustThrowException() {
			try {
				var bytes = default(byte[]);
				var h = bytes.ToHex();
			} catch(ArgumentNullException ane) {
				Assert.AreEqual<string>("source", ane.ParamName);
				return;
			}
			Assert.Fail("Expected exception");
		}


		[TestMethod]
		public void WhenByteIsZero_MustReturnHexString() {
			var b = (byte)0;
			var h = b.ToHex();
			Assert.AreEqual<string>("00", h);
		}
	}
}

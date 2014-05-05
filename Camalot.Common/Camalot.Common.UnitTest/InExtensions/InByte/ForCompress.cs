using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using Ploeh.AutoFixture;

namespace Camalot.Common.UnitTest.InExtensions.InByte {
	[TestClass]
	public class ForCompress {
		[TestMethod]
		public void WhenByteArrayIsNotNull_MustReturnCompressedByteArray() {
			var fixture = new Fixture();
			var bytes = fixture.Create<byte[]>();
			var compressed = bytes.Compress();
			Assert.IsTrue(compressed.Length > 0);
		}

		[TestMethod]
		public void WhenByteArrayIsNotNull_MustThrowException() {
			try {
				var bytes = default(byte[]);
				var compressed = bytes.Compress();
			} catch(ArgumentNullException ane) {
				Assert.AreEqual<string>("buffer", ane.ParamName);
				return;
			}
			Assert.Fail("Expected exception did not happen.");
		}


		[TestMethod]
		public async Task WhenByteArrayIsNotNull_MustReturnCompressedByteArrayAsync() {
			var fixture = new Fixture();
			var bytes = fixture.Create<byte[]>();
			var compressed = await bytes.CompressAsync();
			Assert.IsTrue(compressed.Length > 0);
		}

		[TestMethod]
		public async Task WhenByteArrayIsNotNull_MustThrowExceptionAsync() {
			try {
				var bytes = default(byte[]);
				var compressed = await bytes.CompressAsync();
			} catch(ArgumentNullException ane) {
				Assert.AreEqual<string>("buffer", ane.ParamName);
				return;
			}
			Assert.Fail("Expected exception did not happen.");
		}
	}
}

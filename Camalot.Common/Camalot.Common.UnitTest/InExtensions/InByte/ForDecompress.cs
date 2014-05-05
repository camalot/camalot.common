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
	public class ForDecompress {
		[TestMethod]
		public void WhenByteArrayIsNotNull_MustReturnDecompressedByteArray() {
			var fixture = new Fixture();
			var bytes = fixture.Create<byte[]>();
			var compressed = bytes.Compress();

			var decompressed = compressed.Decompress();

			Assert.AreEqual<int>(bytes.Length,decompressed.Length);
			for(int i = 0; i < bytes.Length; ++i) {
				Assert.AreEqual<byte>(bytes[i], decompressed[i]);
			}
		}

		[TestMethod]
		public void WhenByteArrayIsNotNull_MustThrowException() {
			try {
				var bytes = default(byte[]);
				var compressed = bytes.Decompress();
			} catch(ArgumentNullException ane) {
				Assert.AreEqual<string>("buffer", ane.ParamName);
				return;
			}
			Assert.Fail("Expected exception did not happen.");
		}


		[TestMethod]
		public async Task WhenByteArrayIsNotNull_MustReturnDecompressedByteArrayAsync() {
			var fixture = new Fixture();
			var bytes = fixture.Create<byte[]>();
			var compressed = await bytes.CompressAsync();

			var decompressed = await compressed.DecompressAsync();

			Assert.AreEqual<int>(bytes.Length, decompressed.Length);
			for(int i = 0; i < bytes.Length; ++i) {
				Assert.AreEqual<byte>(bytes[i], decompressed[i]);
			}
		}

		[TestMethod]
		public async Task WhenByteArrayIsNotNull_MustThrowExceptionAsync() {
			try {
				var bytes = default(byte[]);
				var compressed = await bytes.DecompressAsync();
			} catch(ArgumentNullException ane) {
				Assert.AreEqual<string>("buffer", ane.ParamName);
				return;
			}
			Assert.Fail("Expected exception did not happen.");
		}
	}
}

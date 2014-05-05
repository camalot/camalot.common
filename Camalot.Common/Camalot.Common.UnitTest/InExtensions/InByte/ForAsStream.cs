using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using Ploeh.AutoFixture;
using System.IO;

namespace Camalot.Common.UnitTest.InExtensions.InByte {
	[TestClass]
	public class ForAsStream {
		[TestMethod]
		public void WhenByteArrayIsNotNull_ReturnWritableStream() {
			var fixture = new Fixture();
			var bytes = fixture.Create<byte[]>();
			using(var stream = bytes.AsStream()) {
				Assert.IsTrue(stream.Length == bytes.Length);
				Assert.IsTrue(stream.Is<MemoryStream>());
				Assert.IsTrue(stream.CanWrite);
			}
		}

		[TestMethod]
		public void WhenByteArrayIsNotNull_ReturnReadonlyStream() {
			var fixture = new Fixture();
			var bytes = fixture.Create<byte[]>();
			using(var stream = bytes.AsStream(false)) {
				Assert.IsTrue(stream.Length == bytes.Length);
				Assert.IsTrue(stream.Is<MemoryStream>());
				Assert.IsFalse(stream.CanWrite);
			}
		}

		[TestMethod]
		public void WhenByteArrayIsNotNull_FromRangeOfBytesReturnWritableStream() {
			var fixture = new Fixture();
			var bytes = fixture.Create<byte[]>();
			using(var stream = bytes.AsStream(0,bytes.Length)) {
				Assert.IsTrue(stream.Length == bytes.Length);
				Assert.IsTrue(stream.Is<MemoryStream>());
				Assert.IsTrue(stream.CanWrite);
			}
		}

		[TestMethod]
		public void WhenByteArrayIsNotNull_FromRangeOfBytesReturnReadonlyStream() {
			var fixture = new Fixture();
			var bytes = fixture.Create<byte[]>();
			using(var stream = bytes.AsStream(0, bytes.Length,false)) {
				Assert.IsTrue(stream.Length == bytes.Length);
				Assert.IsTrue(stream.Is<MemoryStream>());
				Assert.IsFalse(stream.CanWrite);
			}
		}
	}
}

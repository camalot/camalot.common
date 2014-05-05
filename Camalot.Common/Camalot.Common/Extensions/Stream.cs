using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Gets the byte array from a stream.
		/// </summary>
		/// <param name="stream">The stream.</param>
		/// <returns></returns>
		public static byte[] ToByteArray(this Stream stream) {
			var bytes = new byte[4096];
			using(stream) {
				using(var ms = new MemoryStream()) {
					stream.CopyTo(ms);
					ms.Position = 0;
					return ms.ToArray();
				}
			}
		}

		/// <summary>
		/// Gets the byte array from a stream.
		/// </summary>
		/// <param name="stream">The stream.</param>
		/// <returns></returns>
		public async static Task<byte[]> ToByteArrayAsync(this Stream stream) {
			var bytes = new byte[4096];
			using(stream) {
				using(var ms = new MemoryStream()) {
					await stream.CopyToAsync(ms);
					ms.Position = 0;
					return ms.ToArray();
				}
			}
		}


		/// <summary>
		/// Compresses the stream using GZIP compression.
		/// </summary>
		/// <param name="stream">The stream.</param>
		/// <returns></returns>
		public static Stream Compress(this Stream stream) {
			var output = new MemoryStream();
			using(var gz = new GZipStream(output, CompressionMode.Compress)) {
				stream.CopyTo(gz);
			}
			return output.ToArray().AsStream();
		}

		/// <summary>
		/// Compresses the stream using GZIP compression.
		/// </summary>
		/// <param name="stream">The stream.</param>
		/// <returns></returns>
		public async static Task<Stream> CompressAsync(this Stream stream) {
			var output = new MemoryStream();
			using(var gz = new GZipStream(output, CompressionMode.Compress)) {
				await stream.CopyToAsync(gz);
			}
			return output.ToArray().AsStream();
		}

		/// <summary>
		/// Decompresses the GZIP stream.
		/// </summary>
		/// <param name="stream">The stream.</param>
		/// <returns></returns>
		public static Stream Decompress(this Stream stream) {
			var output = new System.IO.MemoryStream();
			using(var decompressed = new GZipStream(stream, CompressionMode.Decompress)) {
				decompressed.CopyTo(output);
			}
			return output.ToArray().AsStream();
		}

		/// <summary>
		/// Decompresses the GZIP stream.
		/// </summary>
		/// <param name="stream">The stream.</param>
		/// <returns></returns>
		public async static Task<Stream> DecompressAsync(this Stream stream) {
			var output = new System.IO.MemoryStream();
			using(var decompressed = new GZipStream(stream, CompressionMode.Decompress)) {
				await decompressed.CopyToAsync(output);
			}
			return output.ToArray().AsStream();
		}
	}
}

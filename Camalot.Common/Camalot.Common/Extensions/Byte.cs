using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Gets the string representation of the array of bytes.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <param name="encoding">The encoding.</param>
		/// <returns></returns>
		public static String GetString(this byte[] bytes, Encoding encoding) {
			return encoding.GetString(bytes);
		}

		/// <summary>
		/// Gets the string representation of the array of bytes.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public static String GetString(this byte[] bytes) {
			return GetString(bytes, Encoding.Unicode);
		}

		/// <summary>
		/// Converts the byte array to a base64 encoded string.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public static String ToBase64String(this byte[] bytes) {
			return Convert.ToBase64String(bytes);
		}

		/// <summary>
		/// Converts the byte array to a hexadecimal string.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public static String ToHex(this byte[] bytes) {
			var sb = new StringBuilder();
			bytes.ForEach(b => sb.Append(b.ToString("X2")));
			return sb.ToString();
		}

		/// <summary>
		/// Converts the byte array to a hexadecimal string.
		/// </summary>
		/// <param name="b">The byte array.</param>
		/// <returns></returns>
		public static String ToHex(this byte b) {
			return b.ToString("X2");
		}

		/// <summary>
		/// Turns the byte array in to a Stream.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public static Stream AsStream(this byte[] bytes) {
			return new MemoryStream(bytes);
		}

		/// <summary>
		/// Turns the byte array in to a Stream.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <param name="writable">if set to <c>true</c> then the stream is writable.</param>
		/// <returns></returns>
		public static Stream AsStream(this byte[] bytes, bool writable) {
			return new MemoryStream(bytes, writable);
		}

		/// <summary>
		/// Turns the byte array in to a Stream.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <param name="index">The index.</param>
		/// <param name="count">The count.</param>
		/// <returns></returns>
		public static Stream AsStream(this byte[] bytes, int index, int count) {
			return new MemoryStream(bytes, index, count);
		}

		/// <summary>
		/// Turns the byte array in to a Stream.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <param name="index">The index.</param>
		/// <param name="count">The count.</param>
		/// <param name="writable">if set to <c>true</c> then the stream is writable.</param>
		/// <returns></returns>
		public static Stream AsStream(this byte[] bytes, int index, int count, bool writable) {
			return new MemoryStream(bytes, index, count, writable);
		}

		/// <summary>
		/// Compresses the bytes using GZIP compression.
		/// </summary>
		/// <param name="bytes">The byte array.</param>
		/// <returns></returns>
		public static byte[] Compress(this byte[] bytes) {
			using(var stream = bytes.AsStream()) {
				using(var cstream = stream.Compress()) {
					return cstream.ToByteArray();
				}
			}
		}

		/// <summary>
		/// Compresses the bytes using GZIP compression.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public async static Task<byte[]> CompressAsync(this byte[] bytes) {
			using(var stream = bytes.AsStream()) {
				var compressed = await stream.CompressAsync();
				return await compressed.ToByteArrayAsync();
			}
		}

		/// <summary>
		/// Decompresses the GZIP byte array.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public static byte[] Decompress(this byte[] bytes) {
			using(var stream = bytes.AsStream()) {
				using(var dstream = stream.Decompress()) {
					return dstream.ToByteArray();
				}
			}
		}

		/// <summary>
		/// Decompresses the GZIP byte array.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <returns></returns>
		public async static Task<byte[]> DecompressAsync(this byte[] bytes) {
			using(var stream = bytes.AsStream()) {
				var decompress = await stream.DecompressAsync();
				return await decompress.ToByteArrayAsync();
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
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
		public static byte[] ToByteArray ( this Stream stream ) {
			var bytes = new byte[4096];
			using ( stream ) {
				using ( var ms = new MemoryStream ( ) ) {
					var bread = 0;
					while ( ( bread = stream.Read ( bytes, 0, bytes.Length ) ) > 0 ) {
						ms.Write ( bytes, 0, bread );
					}
					ms.Position = 0;
					return ms.ToArray ( );
				}
			}
		}
	}
}

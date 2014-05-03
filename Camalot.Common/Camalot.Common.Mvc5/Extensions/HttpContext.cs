using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Camalot.Common.Mvc.Extensions {
	public static partial class CamalotCommonMvcExtensions {
		/// <summary><![CDATA[
		/// Compresses the response using the browsers acceptable content compressions (GZIP or DEFLATE).
		/// ]]>
		/// </summary>
		/// <param name="context">The context.</param>
		/// <seealso cref="http://www.gzip.org/zlib/rfc-gzip.html">GZIP</seealso>
		/// <seealso cref="http://www.gzip.org/zlib/rfc-deflate.html">DEFLATE</seealso>
		public static void CompressResponse ( this HttpContextBase context ) {
			var request = context.Request;
			var accepts = ( request.Headers["Accept-Encoding"] ?? string.Empty ).ToUpperInvariant ( ).Split ( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
			
			var response = context.Response;

			if ( accepts.Any ( s => s.Equals ( "GZIP" ) ) ) {
				response.Headers.Add ( "Content-Encoding", "gzip" );
				response.Filter = new GZipStream ( response.Filter, CompressionMode.Compress );	
				return;
			}

			if ( accepts.Any ( s => s.Equals ( "DEFLATE" ) ) ) {
				response.Headers.Add ( "Content-Encoding", "deflate" );
				response.Filter = new DeflateStream ( response.Filter, CompressionMode.Compress );
				return;
			}
		}
	}
}

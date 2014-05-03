using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mime {
	/// <summary>
	/// This reads http://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types and builds a list of mimeTypes that can be queried against.
	/// </summary>
	/// <seealso cref="http://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types">Apache Mime Types</seealso>
	public class ApacheFileTypeMap : FileTypeMap {
		private static ICollection<MimeType> MimeTypeCache;
		/// <summary>
		/// Gets the mime type of the file.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <returns></returns>
		/// <seealso cref="M:Camalot.Common.Mime.FileTypeMap.GetMimeType"/>
		public override MimeType GetMimeType ( System.IO.FileInfo file ) {
			return GetMimeType ( file.Name );
		}

		/// <summary>
		/// Gets the mime type of the file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns></returns>
		/// <seealso cref="M:Camalot.Common.Mime.FileTypeMap.GetAllMimeTypes"/>
		public override MimeType GetMimeType ( string fileName ) {
			var ext = new String ( fileName.Skip ( fileName.LastIndexOf ( '.' ) + 1 ).ToArray ( ) );
			if ( string.IsNullOrWhiteSpace ( ext ) ) {
				return new MimeType { MediaType = DefaultMimeType };
			}

			CheckCache ( );

			var result = MimeTypeCache.FirstOrDefault ( x => x.Extensions.Any ( y => string.Compare ( y, ext, StringComparison.InvariantCultureIgnoreCase ) == 0 ) );
			if ( result == null ) {
				return new MimeType {
					MediaType = DefaultMimeType,
					Extensions = new List<string> { ext }
				};
			}

			return result;
		}

		/// <summary>
		/// Gets all MimeTypes.
		/// </summary>
		/// <returns></returns>
		public override ICollection<MimeType> GetAllMimeTypes ( ) {
			CheckCache ( );
			return MimeTypeCache;
		}

		/// <summary>
		/// Checks the cache to see if it has been retrieved.
		/// </summary>
		private void CheckCache ( ) {
			if ( MimeTypeCache == null ) {
				// load the cache
				MimeTypeCache = new ApacheMimeTypesFileReader ( ).Load ( );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private class ApacheMimeTypesFileReader {
			private const string SOURCE = "http://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types";

			/// <summary>
			/// Loads this instance.
			/// </summary>
			/// <returns></returns>
			public ICollection<MimeType> Load ( ) {
				var options = RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase;

				var result = new List<MimeType> ( );
				var req = WebRequest.CreateHttp ( SOURCE );
				var resp = req.GetResponse ( );
				using ( var strm = new StreamReader ( resp.GetResponseStream ( ) ) ) {
					while ( !strm.EndOfStream ) {
						var line = strm.ReadLine ( );
						line.Match ( @"^([^\#]\S+)\s+(.*)$", options ).ForEach ( x => {
							result.Add ( new MimeType {
								Extensions = x.Groups[2].Value.Split ( new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries ).ToList ( ),
								MediaType = x.Groups[1].Value
							} );
						} );
					}
				}
				return result;
			}
		}
	}
}

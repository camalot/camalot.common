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
	public class ApacheFileTypeMap : FileTypeMap {
		private static ICollection<MimeType> MimeTypeCache;
		public override MimeType GetMimeType ( System.IO.FileInfo file ) {
			return GetMimeType ( file.Name );
		}

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

		public override ICollection<MimeType> GetAllMimeTypes ( ) {
			CheckCache ( );
			return MimeTypeCache;
		} 

		private void CheckCache ( ) {
			if ( MimeTypeCache == null ) {
				// load the cache
				MimeTypeCache = new ApacheMimeTypesFileReader ( ).Load ( );
			}
		}

		private class ApacheMimeTypesFileReader {
			private const string SOURCE = "http://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types";

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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using MoreLinq;

namespace Camalot.Common.Mime {
	public class RegistryFileTypeMap : FileTypeMap {
		private const string ValueKeyName = "Content Type";
		public override MimeType GetMimeType ( System.IO.FileInfo file ) {
			return GetMimeType ( file.FullName );
		}

		public override MimeType GetMimeType ( string fileName ) {
			// set a default mimetype if not found.
			var contentType = this.DefaultMimeType;
			var ext = Path.GetExtension ( fileName );
			if ( string.IsNullOrWhiteSpace ( fileName ) || string.IsNullOrWhiteSpace ( ext ) ) {
				return new MimeType { MediaType = DefaultMimeType };
			}
			try {
				// get the registry classes root
				RegistryKey classes = Registry.ClassesRoot;
				// find the sub key based on the file extension
				using ( RegistryKey fileClass = classes.OpenSubKey ( Path.GetExtension ( fileName ), false ) ) {
					if ( fileClass.GetValueNames ( ).Any ( x => x == ValueKeyName ) ) {
						contentType = fileClass.GetValue ( ValueKeyName ).ToString ( );
					}
				}
			} catch { }
			return new MimeType {
				Extensions = new List<string> { ext.Substring ( 1 ) },
				MediaType = contentType
			};
		}

		public override ICollection<MimeType> GetAllMimeTypes ( ) {
			var result = new List<MimeType> ( );
			try {
				// get the registry classes root
				var classes = Registry.ClassesRoot;
				var keys = classes.GetSubKeyNames ( ).Where ( x => x.StartsWith ( "." ) );
				keys.ForEach ( k => {
					using ( var fileClass = classes.OpenSubKey ( Path.GetExtension ( k ), false ) ) {
						if ( fileClass.GetValueNames ( ).Any ( x => x == ValueKeyName ) ) {
							var contentType = fileClass.GetValue ( ValueKeyName ).ToString ( );
							var item = result.SingleOrDefault ( x => x.MediaType == contentType );
							if ( item == null ) {
								result.Add ( new MimeType {
									MediaType = contentType,
									Extensions = new List<string> { k.Substring ( 1 ).ToLower ( ) }
								} );
							} else {
								item.Extensions.Add ( k.Substring ( 1 ).ToLower ( ) );
							}
						}
					}
				} );
				// find the sub key based on the file extension
			} catch ( SecurityException ) {
			} catch ( UnauthorizedAccessException ) {
			}
			return result;
		}
	}
}

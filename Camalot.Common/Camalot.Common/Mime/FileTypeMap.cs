using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Mime {
	public abstract class FileTypeMap {
		public FileTypeMap ( ) {

		}

		static FileTypeMap ( ) {
			DefaultFileTypeMap = new ApacheFileTypeMap ( );
		}

		public static FileTypeMap DefaultFileTypeMap { get; private set; }

		public abstract MimeType GetMimeType ( FileInfo file );
		public abstract MimeType GetMimeType ( string fileName );
		public abstract ICollection<MimeType> GetAllMimeTypes ( );
		public virtual string DefaultMimeType {
			get {
				return "application/octet-stream";
			}
		}
	}
}

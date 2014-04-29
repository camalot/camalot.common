using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Mime {
	/// <summary>
	/// A default file type map handler.
	/// </summary>
	public abstract class FileTypeMap {
		/// <summary>
		/// Initializes a new instance of the <see cref="FileTypeMap" /> class.
		/// </summary>
		public FileTypeMap ( ) {

		}

		/// <summary>
		/// Initializes the <see cref="FileTypeMap"/> class.
		/// </summary>
		static FileTypeMap ( ) {
			DefaultFileTypeMap = new ApacheFileTypeMap ( );
		}

		/// <summary>
		/// Gets the default file type map.
		/// </summary>
		/// <value>
		/// The default file type map.
		/// </value>
		public static FileTypeMap DefaultFileTypeMap { get; private set; }

		/// <summary>
		/// Gets the mime type of the file.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <returns></returns>
		public abstract MimeType GetMimeType ( FileInfo file );
		/// <summary>
		/// Gets the mime type of the file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <returns></returns>
		public abstract MimeType GetMimeType ( string fileName );
		/// <summary>
		/// Gets all MimeTypes.
		/// </summary>
		/// <returns></returns>
		public abstract ICollection<MimeType> GetAllMimeTypes ( );
		/// <summary>
		/// Gets the default mimetype if it is unknown.
		/// </summary>
		/// <value>
		/// The default type of the MIME.
		/// </value>
		public virtual string DefaultMimeType {
			get {
				return "application/octet-stream";
			}
		}
	}
}

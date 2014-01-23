using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Mime;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Gets the mime type of the specified file using the specified FileTypeMap.
		/// </summary>
		/// <typeparam name="TFileTypeMap">The type of the file type map.</typeparam>
		/// <param name="file">The file.</param>
		/// <returns></returns>
		public static MimeType GetMimeType<TFileTypeMap> ( this FileInfo file ) where TFileTypeMap : FileTypeMap, new() {
			var type = typeof(TFileTypeMap);
			var ftmap = Activator.CreateInstance<TFileTypeMap> ( );

			return ftmap.GetMimeType ( file );
		}

		/// <summary>
		/// Gets the mime type of the specified file using the Default FileTypeMap.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <returns></returns>
		public static MimeType GetMimeType ( this FileInfo file ) {
			return FileTypeMap.DefaultFileTypeMap.GetMimeType ( file );
		}
	}
}

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

		/// <summary>
		/// Renames the specified file.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <param name="fileName">Name of the file. If it does not contain an extension, it will use the old extension.</param>
		/// <returns>The file info for the newly renamed file.</returns>
		/// <gist id="6d30bb5587fb13855204" />
		public static FileInfo Rename(this FileInfo file, string fileName) {
			var oldPath = file.Directory;
			var oldExt = file.Extension;
			var hasNewExtension = fileName.IndexOf('.') >= 0;
			var newPath = Path.Combine(oldPath.FullName,"{0}{1}".With(fileName,hasNewExtension ? "" : oldExt));
			file.MoveTo(newPath);
			return new FileInfo(newPath);
		}



		/// <summary>
		/// Reads the bytes of a file and returns the bytes.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <returns></returns>
		public static byte[] GetBytes(this FileInfo file) {
			if(file == null) {
				return new byte[0];
			}
			using(var ms = new MemoryStream()) {
				using(var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read)) {
					var bread = 0;
					var buffer = new byte[4096];
					while((bread = fs.Read(buffer, 0, buffer.Length)) > 0) {
						ms.Write(buffer, 0, bread);
					}
				}
				ms.Position = 0;
				return ms.ToArray();
			}
		}

		/// <summary>
		/// Reads the bytes of a file and returns the bytes.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <param name="maxLength">The maximum length of bytes to read.</param>
		/// <returns></returns>
		public static byte[] GetBytes(this FileInfo file, int maxLength) {
			if(file == null) {
				return new byte[0];
			}
			using(var ms = new MemoryStream()) {
				using(var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read)) {
					var bread = 0;
					var buffer = new byte[maxLength];
					if((bread = fs.Read(buffer, 0, buffer.Length)) > 0) {
						ms.Write(buffer, 0, bread);
					}
				}
				ms.Position = 0;
				return ms.ToArray();
			}
		}

		/// <summary>
		/// Gets the extension of the specified file.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <returns>Just the extension, there will not be a leading ".".</returns>
		public static String Extension(this FileInfo file) {
			var ext = Path.GetExtension(file.Name);
			ext = ext.REReplace(@"^\.", String.Empty);
			return ext;
		}

		/// <summary>
		/// Gets the file name without extension.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <returns></returns>
		public static string NameWithoutExtension(this FileInfo file) {
			return Path.GetFileNameWithoutExtension(file.Name);
		}

	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		public static String GetString ( this byte[] bytes, Encoding encoding ) {
			return encoding.GetString ( bytes );
		}

		public static String GetString ( this byte[] bytes ) {
			return GetString ( bytes, Encoding.Unicode );
		}

		public static String ToHex ( this byte[] bytes ) {
			var sb = new StringBuilder ( );
			bytes.ForEach ( b => sb.Append ( b.ToString ( "X2" ) ) );
			return sb.ToString ( );
		}

		public static String ToHex ( this byte b ) {
			return b.ToString ( "X2" );
		}

		public static Stream AsStream ( this byte[] bytes ) {
			return new MemoryStream ( bytes );
		}

		public static Stream AsStream ( this byte[] bytes, bool writable ) {
			return new MemoryStream ( bytes, writable );
		}

		public static Stream AsStream ( this byte[] bytes, int index, int count ) {
			return new MemoryStream ( bytes, index, count );
		}

		public static Stream AsStream ( this byte[] bytes, int index, int count, bool writable ) {
			return new MemoryStream ( bytes, index, count, writable );
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		public static Object Or ( this Object obj, Object value ) {
			return obj ?? value;
		}

		public static Guid Or ( this Guid guid, Guid value ) {
			if ( guid == Guid.Empty ) {
				throw new ArgumentException ( );
			}
			return guid == Guid.Empty ? value : guid;
		}

		public static T Or<T> ( this T s, T value ) {
			return s.Equals ( default ( T ) ) ? value : s;
		}

		public static String Or ( this String s, String value ) {
			return String.IsNullOrWhiteSpace ( s ) ? value : s;
		}

		public static T? Or<T> ( this T? s, T value ) where T : struct, IComparable {
			return !s.HasValue ? value : s;
		}
	}

}

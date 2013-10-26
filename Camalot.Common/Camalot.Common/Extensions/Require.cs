using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		public static Object Require ( this Object obj ) {
			if ( obj == null ) {
				throw new ArgumentException ( );
			}
			return obj;
		}

		public static Object Require ( this Object obj, String message ) {
			if ( obj == null ) {
				throw new ArgumentException ( message );
			}
			return obj;
		}

		public static bool IsEmpty ( this Guid guid ) {
			return guid == Guid.Empty;
		}

		public static Guid Require ( this Guid guid ) {
			if ( guid == Guid.Empty ) {
				throw new ArgumentException ( );
			}
			return guid;
		}

		public static Guid Require ( this Guid guid, String message ) {
			if ( guid == null ) {
				throw new ArgumentException ( message );
			}
			return guid;
		}

		public static T Require<T> ( this T s, String message ) {
			if ( s.Equals ( default ( T ) ) ) {
				throw new ArgumentException ( message );
			}
			return s;
		}

		public static T Require<T> ( this T s ) {
			if ( s.Equals ( default ( T ) ) ) {
				throw new ArgumentException ( );
			}
			return s;
		}

		public static String Require ( this String s, String message ) {
			if ( String.IsNullOrWhiteSpace ( s ) ) {
				throw new ArgumentException ( message );
			}
			return s;
		}
		public static String Require ( this String s ) {
			if ( String.IsNullOrWhiteSpace ( s ) ) {
				throw new ArgumentException ( );
			}
			return s;
		}

		public static T? Require<T> ( this T? s, String message ) where T : struct, IComparable {
			if ( !s.HasValue ) {
				throw new ArgumentException ( message );
			}
			return s;
		}
		public static T? Require<T> ( this T? s ) where T : struct, IComparable {
			if ( !s.HasValue ) {
				throw new ArgumentException ( );
			}
			return s;
		}

		public static int RequirePositive ( this int i, String param ) {
			return RequireBetween ( i, 0, int.MaxValue, param );
		}

		public static int RequirePositive ( this int i ) {
			return RequireBetween ( i, 0, int.MaxValue );
		}

		public static int RequireNegative ( this int i, String param ) {
			return RequireBetween ( i, int.MinValue, 0, param );
		}

		public static int RequireNegative ( this int i ) {
			return RequireBetween ( i, int.MinValue, 0 );
		}

		public static int RequireBetween ( this int i, int low, int high, String param ) {
			if ( i <= low || i >= high ) {
				throw new ArgumentException ( "value '{2}' must be a value value between {0} and {1}".With ( low, high, i ), param );
			}
			return i;
		}

		public static int RequireBetween ( this int i, int low, int high ) {
			if ( i <= low || i >= high ) {
				throw new ArgumentException ( "value '{2}' must be a value value between {0} and {1}".With ( low, high, i ) );
			}
			return i;
		}



		public static short RequirePositive ( this short i, String param ) {
			return RequireBetween ( i, (short)0, short.MaxValue, param );
		}

		public static short RequirePositive ( this short i ) {
			return RequireBetween ( i, (short)0, short.MaxValue );
		}

		public static short RequireNegative ( this short i, String param ) {
			return RequireBetween ( i, short.MinValue, (short)0, param );
		}

		public static short RequireNegative ( this short i ) {
			return RequireBetween ( i, short.MinValue, (short)0 );
		}

		public static short RequireBetween ( this short i, short low, short high, String param ) {
			if ( i <= low || i >= high ) {
				throw new ArgumentException ( "value '{2}' must be a value value between {0} and {1}".With ( low, high, i ), param );
			}
			return i;
		}

		public static short RequireBetween ( this short i, short low, short high ) {
			if ( i <= low || i >= high ) {
				throw new ArgumentException ( "value '{2}' must be a value value between {0} and {1}".With ( low, high, i ) );
			}
			return i;
		}
	}
}

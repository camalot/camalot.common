using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Properties;

namespace Camalot.Common.Extensions {
	/// <summary>
	/// 
	/// </summary>
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static Object Require ( this Object obj ) {
			if ( obj == null ) {
				throw new ArgumentException ( Resources.Common_NullOrEmpty );
			}
			return obj;
		}

		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="abd4a899b9fe766184de" />
		public static Object Require(this Object obj, String message) {
			if ( obj == null ) {
				throw new ArgumentException ( message );
			}
			return obj;
		}


		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="guid">The unique identifier.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static Guid Require(this Guid guid) {
			if ( guid == Guid.Empty ) {
				throw new ArgumentException ( Resources.Common_NullOrEmpty );
			}
			return guid;
		}

		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="guid">The unique identifier.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <gist id="abd4a899b9fe766184de" />
		public static Guid Require(this Guid guid, String message) {
			if ( guid == null ) {
				throw new ArgumentException ( message );
			}
			return guid;
		}

		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The object.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="abd4a899b9fe766184de" />
		public static T Require<T>(this T t, String message) {
			if ( t.Equals ( default ( T ) ) ) {
				throw new ArgumentException ( message );
			}
			return t;
		}

		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The object.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static T Require<T>(this T t) {
			if ( t.Equals ( default ( T ) ) ) {
				throw new ArgumentException ( Resources.Common_NullOrEmpty );
			}
			return t;
		}

		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="abd4a899b9fe766184de" />
		public static String Require(this String s, String message) {
			if ( String.IsNullOrWhiteSpace ( s ) ) {
				throw new ArgumentException ( message );
			}
			return s;
		}
		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static String Require(this String s) {
			if ( String.IsNullOrWhiteSpace ( s ) ) {
				throw new ArgumentException ( Resources.Common_NullOrEmpty );
			}
			return s;
		}

		/// <summary>
		/// Requires the specified nullable object to have a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The object.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="abd4a899b9fe766184de" />
		public static T? Require<T>(this T? t, String message) where T : struct, IComparable {
			if ( !t.HasValue ) {
				throw new ArgumentException ( message );
			}
			return t;
		}
		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The object.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static T? Require<T>(this T? t) where T : struct, IComparable {
			if ( !t.HasValue ) {
				throw new ArgumentException ( Resources.Common_NullOrEmpty );
			}
			return t;
		}


		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero.With ( i )</exception>
		public static int RequireZero ( this int i ) {
			if ( i != 0 ) {
				throw new ArgumentException ( Resources.Require_Zero.With ( i ) );
			}
			return i;
		}
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static int RequireZero ( this int i, String param ) {
			if ( i != 0 ) {
				throw new ArgumentException ( Resources.Require_Zero.With ( i ), param );
			}
			return i;
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The int.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static int RequirePositive ( this int i, String param ) {
			return RequireBetween ( i, 0, int.MaxValue, param );
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The int.</param>
		/// <returns></returns>
		public static int RequirePositive ( this int i ) {
			return RequireBetween ( i, 0, int.MaxValue );
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The int.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static int RequireNegative ( this int i, String param ) {
			return RequireBetween ( i, int.MinValue, 0, param );
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The int.</param>
		/// <returns></returns>
		public static int RequireNegative ( this int i ) {
			return RequireBetween ( i, int.MinValue, 0 );
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static int RequireBetween ( this int i, int low, int high, String param ) {
			if ( i <= low || i >= high ) {
				throw new ArgumentException ( Resources.Require_Between.With ( low, high, i ), param );
			}
			return i;
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static int RequireBetween ( this int i, int low, int high ) {
			if ( i <= low || i >= high ) {
				throw new ArgumentException ( Resources.Require_Between.With ( low, high, i ) );
			}
			return i;
		}

		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static short RequireZero ( this short i ) {
			if ( i != 0 ) {
				throw new ArgumentException ( Resources.Require_Zero.With ( i ) );
			}
			return i;
		}
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static short RequireZero ( this short i, String param ) {
			if ( i != 0 ) {
				throw new ArgumentException ( Resources.Require_Zero.With ( i ), param );
			}
			return i;
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static short RequirePositive ( this short i, String param ) {
			return RequireBetween ( i, (short)0, short.MaxValue, param );
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static short RequirePositive ( this short i ) {
			return RequireBetween ( i, (short)0, short.MaxValue );
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static short RequireNegative ( this short i, String param ) {
			return RequireBetween ( i, short.MinValue, (short)0, param );
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static short RequireNegative ( this short i ) {
			return RequireBetween ( i, short.MinValue, (short)0 );
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static short RequireBetween ( this short i, short low, short high, String param ) {
			if ( i <= low || i >= high ) {
				throw new ArgumentException ( Resources.Require_Between.With ( low, high, i ), param );
			}
			return i;
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static short RequireBetween ( this short i, short low, short high ) {
			if ( i <= low || i >= high ) {
				throw new ArgumentException ( Resources.Require_Between.With ( low, high, i ) );
			}
			return i;
		}
	}
}

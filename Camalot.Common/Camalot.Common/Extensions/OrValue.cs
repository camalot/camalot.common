using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Properties;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Returns the object or the specified value object if null (or empty).
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static Object Or ( this Object obj, Object value ) {
			return obj ?? value;
		}

		/// <summary>
		/// Returns the guid or the specified value guid if empty.
		/// </summary>
		/// <param name="guid">The unique identifier.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static Guid Or ( this Guid guid, Guid value ) {
			return guid == Guid.Empty ? value : guid;
		}

		/// <summary>
		/// Returns the object or the specified value object if null (or empty).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="s">The object.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T Or<T> ( this T s, T value ) {
			return s.Equals ( default ( T ) ) ? value : s;
		}

		/// <summary>
		/// Returns the string or the specified value if null (or empty).
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static String Or ( this String s, String value ) {
			return String.IsNullOrWhiteSpace ( s ) ? value : s;
		}

		/// <summary>
		/// Returns the object or the specified value object if null (or empty).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="s">The nullable object.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T? Or<T> ( this T? s, T value ) where T : struct, IComparable {
			return !s.HasValue ? value : s;
		}
	}

}

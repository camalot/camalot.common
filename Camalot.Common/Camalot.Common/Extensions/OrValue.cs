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
		public static Object Or(this Object obj, Object value) {
			return obj.Or<Object>(x => { return x != default(Object); }, value);
		}


		/// <summary>
		/// Returns the guid or the specified value guid if empty.
		/// </summary>
		/// <param name="guid">The unique identifier.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static Guid Or(this Guid guid, Guid value) {
			return guid.Or(g => { return guid != Guid.Empty; }, value);
		}

		/// <summary>
		/// Returns the object or the specified value object if null (or empty).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="s">The object.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T Or<T>(this T s, T value) where T : class {
			return s.Or(x => { return x != default(T); }, value);
		}

		/// <summary>
		/// Returns the object or the specified value object if test is false.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="s">The s.</param>
		/// <param name="test">The test.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T Or<T>(this T s, Func<T, bool> test, T value) {
			return test(s) ? s : value;
		}

		/// <summary>
		/// Returns the string or the specified value if null (or empty).
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static String Or(this String s, String value) {
			return s.Or(x => { return !String.IsNullOrWhiteSpace(x); }, value);
		}

		/// <summary>
		/// Returns the object or the specified value object if null (or empty).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="s">The nullable object.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T? Or<T>(this T? s, T value) where T : struct, IComparable {
			return s.Or(x => { return x.HasValue; }, value);
		}
	}

}

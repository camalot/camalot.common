using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {

		/// <summary>
		/// Converts the object to the specified type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidCastException"></exception>
		/// <exception cref="System.OverflowException"></exception>
		/// <exception cref="System.FormatException"></exception>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static T To<T>(this IConvertible obj) {
			return (T)Convert.ChangeType(obj, typeof(T));

		}

		/// <summary>
		/// Converts the object to the specified type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The object.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidCastException"></exception>
		/// <exception cref="System.OverflowException"></exception>
		/// <exception cref="System.FormatException"></exception>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static T To<T>(this IConvertible obj, IFormatProvider formatProvider) {
			return (T)Convert.ChangeType(obj, typeof(T), formatProvider);
		}

		/// <summary>
		/// Converts the object to the specified type or to the default value if it cannot
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static T ToOrDefault<T>(this IConvertible obj) {
			return obj.ToOrValue<T>(default(T));
		}

		/// <summary>
		/// Converts the object to the specified type or to the default value if it cannot
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The object.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static T ToOrDefault<T>(this IConvertible obj, IFormatProvider formatProvider) {
			return obj.ToOrValue<T>(formatProvider, default(T));
		}

		/// <summary>
		/// Converts the object to the specified type or to the specified value if it cannot
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The object.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static T ToOrValue<T>(this IConvertible obj, T value) {
			T result;
			try {
				result = To<T>(obj);
			} catch(InvalidCastException) {
				result = value;
			} catch(OverflowException) {
				result = value;
			} catch(FormatException) {
				result = value;
			}
			return result;
		}

		/// <summary>
		/// Converts the object to the specified type or to the specified value if it cannot
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The object.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException"></exception>
		public static T ToOrValue<T>(this IConvertible obj, IFormatProvider formatProvider, T value) {
			T result;
			try {
				result = To<T>(obj, formatProvider);
			} catch (InvalidCastException) {
				result = value;
			} catch(OverflowException) {
				result = value;
			} catch(FormatException) {
				result = value;
			}
			return result;
		}
	}
}

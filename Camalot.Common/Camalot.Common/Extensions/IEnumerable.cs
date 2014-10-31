using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {

		/// <summary>
		/// Gets the first item in the enumeration. If it is empty, then it returns the specified value instead of the "Default".
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T FirstOrValue<T>(this IEnumerable<T> enumeration, Func<T,bool> predicate, T value) {
			var r = enumeration.FirstOrDefault(predicate);
			if(r.Equals(default(T))) {
				return value;
			} else {
				return r;
			}
		}
		/// <summary>
		/// Gets the first item in the enumeration. If it is empty, then it returns the specified value instead of the "Default".
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T FirstOrValue<T>(this IEnumerable<T> enumeration, T value) {
			return enumeration.FirstOrValue(x => { return true; }, value);
		}

		/// <summary>
		/// Gets a Single item in the enumeration. If the enumeration is not only a single item then it returns the specified value instead of the "Default".
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T SingleOrValue<T>(this IEnumerable<T> enumeration, Func<T,bool> predicate, T value) {
			var r = enumeration.SingleOrDefault(predicate);
			if(r.Equals(default(T))) {
				return value;
			} else {
				return r;
			}
		}

		/// <summary>
		/// Gets a Single item in the enumeration. If the enumeration is not only a single item then it returns the specified value instead of the "Default".
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumeration">The enumeration.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static T SingleOrValue<T>(this IEnumerable<T> enumeration, T value) {
			return enumeration.SingleOrValue(x => { return true; }, value);
		}
	}
}

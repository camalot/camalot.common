using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Checks if the source is in the specified list of values
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="list">The list.</param>
		/// <returns></returns>
		public static bool In<T>(this T source, params T[] list) {
			return source.In(new List<T>(list));
		}

		/// <summary>
		/// Checks if the source is in the specified list of values
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="list">The list.</param>
		/// <returns></returns>
		public static bool In<T>(this T source, IEnumerable<T> list) {
			return list.Contains(source.Require());
		}
	}
}

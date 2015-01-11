using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Collections;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Converts the IEnumerable to a PagedEnumerable
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="page">The page.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns></returns>
		public static IPagedEnumerable<T> AsPagedEnumerable<T>(this IEnumerable<T> source, int page, int pageSize) {
			return new PagedEnumerable<T>(source, page, pageSize);
		}

		/// <summary>
		/// Converts the IEnumerable to a PagedEnumerable
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="settings">The settings.</param>
		/// <returns></returns>
		public static IPagedEnumerable<T> AsPagedEnumerable<T>(this IEnumerable<T> source, IPagingSettings<T> settings) {
			return new PagedEnumerable<T>(source, settings);
		}


	}
}

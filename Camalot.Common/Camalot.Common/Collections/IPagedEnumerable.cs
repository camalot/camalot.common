using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Collections {
	public interface IPagedEnumerable<T> /*: IEnumerable<T>*/ {
		/// <summary>
		/// Gets the total.
		/// </summary>
		/// <value>
		/// The total.
		/// </value>
		int Total { get; }
		/// <summary>
		/// Gets the size of the page.
		/// </summary>
		/// <value>
		/// The size of the page.
		/// </value>
		int PageSize { get; }
		/// <summary>
		/// Gets the index of the page.
		/// </summary>
		/// <value>
		/// The index of the page.
		/// </value>
		int PageIndex { get; }
		/// <summary>
		/// Gets the page count.
		/// </summary>
		/// <value>
		/// The page count.
		/// </value>
		int PageCount { get; }

		/// <summary>
		/// Gets the results.
		/// </summary>
		/// <value>
		/// The results.
		/// </value>
		IEnumerable<T> Results { get; set; }
	}
}

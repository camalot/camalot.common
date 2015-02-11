using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Collections {
	public class PagedEnumerableModel {
		/// <summary>
		/// Gets the total.
		/// </summary>
		/// <value>
		/// The total.
		/// </value>
		public int Total { get; set; }

		/// <summary>
		/// Gets the size of the page.
		/// </summary>
		/// <value>
		/// The size of the page.
		/// </value>
		public int PageSize { get; set; }

		/// <summary>
		/// Gets the index of the page.
		/// </summary>
		/// <value>
		/// The index of the page.
		/// </value>
		public int PageIndex { get; set; }

		/// <summary>
		/// Gets the page count.
		/// </summary>
		/// <value>
		/// The page count.
		/// </value>
		public int PageCount {
			get {
				if(Total > 0) {
					return (int)Math.Ceiling(Total / (double)PageSize);
				}
				return 0;
			}
		}
	}

	/// <summary>
	/// This is used to map between PagedEnumerable and something that can be mapped out with automapper.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PagedEnumerableModel<T> : PagedEnumerableModel {
			/// <summary>
			/// Gets the total.
			/// </summary>
			/// <value>
			/// The total.
			/// </value>
			public int Total { get; set; }

			/// <summary>
			/// Gets the size of the page.
			/// </summary>
			/// <value>
			/// The size of the page.
			/// </value>
			public int PageSize { get; set; }

			/// <summary>
			/// Gets the index of the page.
			/// </summary>
			/// <value>
			/// The index of the page.
			/// </value>
			public int PageIndex { get; set; }

			/// <summary>
			/// Gets the page count.
			/// </summary>
			/// <value>
			/// The page count.
			/// </value>
			public int PageCount {
				get {
					if(Total > 0) {
						return (int)Math.Ceiling(Total / (double)PageSize);
					}
					return 0;
				}
			}

			/// <summary>
			/// Gets the results.
			/// </summary>
			/// <value>
			/// The results.
			/// </value>
			public IEnumerable<T> Results { get; set; }
		}
}

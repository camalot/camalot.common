﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;

namespace Camalot.Common.Collections {
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PagedEnumerable<T> : IPagedEnumerable<T> {
		/// <summary>
		/// Initializes a new instance of the <see cref="PagedEnumerable{T}"/> class.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="pageIndex">Index of the page.</param>
		/// <param name="pageSize">Size of the page.</param>
		public PagedEnumerable(IEnumerable<T> source, int pageIndex, int pageSize)
			: this(source, new PagingSettings<T>(pageIndex, pageSize)) {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PagedEnumerable{T}"/> class.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="paging">The paging.</param>
		public PagedEnumerable(IEnumerable<T> source, IPagingSettings<T> paging) {
			PageIndex = paging.Skip == 0 ? 0 : (int)Math.Ceiling(paging.Skip / (double)paging.Take);
			PageSize = paging.Take;
			Total = source.Count();
			Results = source.Require().Skip(paging.Skip).Take(paging.Take);
		}

		/// <summary>
		/// Gets the total.
		/// </summary>
		/// <value>
		/// The total.
		/// </value>
		public int Total { get; private set; }

		/// <summary>
		/// Gets the size of the page.
		/// </summary>
		/// <value>
		/// The size of the page.
		/// </value>
		public int PageSize { get; private set; }

		/// <summary>
		/// Gets the index of the page.
		/// </summary>
		/// <value>
		/// The index of the page.
		/// </value>
		public int PageIndex { get; private set; }

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

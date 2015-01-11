using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Collections;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Converts the specified source to the target.
		/// </summary>
		/// <typeparam name="TSource">The type of the source.</typeparam>
		/// <typeparam name="TTarget">The type of the target.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		public static IPagingSettings<TTarget> ConvertTo<TSource, TTarget>(this IPagingSettings<TSource> source){
			return new PagingSettings<TTarget> {
				Skip = source.Skip,
				Take = source.Take
			};
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;

namespace Camalot.Common.Comparers {
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Comparer<T> : IComparer<T>{
		private Func<T, T, int> compare;
		/// <summary>
		/// Initializes a new instance of the <see cref="Comparer{T}"/> class.
		/// </summary>
		/// <param name="func">The function.</param>
		public Comparer(Func<T,T,int> func) {
			compare = func.Require();
		}

		/// <summary>
		/// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
		/// </summary>
		/// <param name="x">The first object to compare.</param>
		/// <param name="y">The second object to compare.</param>
		/// <returns>
		/// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.
		/// </returns>
		public int Compare(T x, T y) {
			return compare(x, y);
		}
	}
}

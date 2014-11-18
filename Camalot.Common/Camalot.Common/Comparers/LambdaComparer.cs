using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;

namespace Camalot.Common.Comparers {
	public class LambdaComparer<T> : IEqualityComparer<T> {
		private readonly Func<T, T, bool> comparer;
		private readonly Func<T, int> hash;
		/// <summary>
		/// Initializes a new instance of the <see cref="LambdaComparer{T}"/> class.
		/// </summary>
		/// <param name="comparer">The comparer.</param>
		/// <param name="hash">The hash.</param>
		public LambdaComparer(Func<T,T,bool> comparer, Func<T,int> hash) {
			this.comparer = comparer.Require();
			this.hash = hash.Require();
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="LambdaComparer{T}"/> class.
		/// </summary>
		/// <param name="comparer">The comparer.</param>
		public LambdaComparer(Func<T, T, bool> comparer) : this(comparer,new Func<T,int>(x => x.GetHashCode())) {
			
		}
		/// <summary>
		/// Determines whether the specified objects are equal.
		/// </summary>
		/// <param name="x">The first object of type <paramref name="T" /> to compare.</param>
		/// <param name="y">The second object of type <paramref name="T" /> to compare.</param>
		/// <returns>
		/// true if the specified objects are equal; otherwise, false.
		/// </returns>
		public bool Equals(T x, T y) {
			return comparer(x, y);
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public int GetHashCode(T obj) {
			return hash(obj);
		}
	}
}

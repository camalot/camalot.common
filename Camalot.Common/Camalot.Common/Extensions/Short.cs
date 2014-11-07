using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Determines whether the specified value is even.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsEven(this short value) {
			return (value % 2) == 0;
		}

		/// <summary>
		/// Determines whether the specified value is odd.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsOdd(this short value) {
			return (value % 2) != 0;
		}
		/// <summary>
		/// Determines whether the specified value is even.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsEven(this ushort value) {
			return (value % 2) == 0;
		}

		/// <summary>
		/// Determines whether the specified value is odd.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsOdd(this ushort value) {
			return (value % 2) != 0;
		}
	}
}

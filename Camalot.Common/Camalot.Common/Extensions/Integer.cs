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
		public static bool IsEven(this int value) {
			return (value % 2) == 0;
		}

		/// <summary>
		/// Determines whether the specified value is odd.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsOdd(this int value) {
			return (value % 2) != 0;
		}

		/// <summary>
		/// Determines whether the specified value is even.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsEven(this uint value) {
			return (value % 2) == 0;
		}

		/// <summary>
		/// Determines whether the specified value is odd.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsOdd(this uint value) {
			return (value % 2) != 0;
		}

	}
}

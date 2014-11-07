using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		#region float
		/// <summary>
		/// Determines whether the specified value is even.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsEven(this float value) {
			return (value % 2) == 0;
		}

		/// <summary>
		/// Determines whether the specified value is odd.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsOdd(this float value) {
			return (value % 2) != 0;
		}

		#endregion
		#region decimal
		/// <summary>
		/// Determines whether the specified value is even.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsEven(this decimal value) {
			return (value % 2) == 0;
		}

		/// <summary>
		/// Determines whether the specified value is odd.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsOdd(this decimal value) {
			return (value % 2) != 0;
		}
		#endregion
		#region double
		/// <summary>
		/// Determines whether the specified value is even.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsEven(this double value) {
			return (value % 2) == 0;
		}

		/// <summary>
		/// Determines whether the specified value is odd.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsOdd(this double value) {
			return (value % 2) != 0;
		}
		#endregion
	}
}

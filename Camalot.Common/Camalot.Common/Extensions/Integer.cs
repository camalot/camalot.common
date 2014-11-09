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

		/// <summary>
		/// Multiplies the value by 2^10
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static int Kilo(this int value) {
			return value * 1024;
		}

		/// <summary>
		/// Multiplies the value by 10^3 (one thousand)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static int K(this int value) {
			return value * 1000;
		}

		/// <summary>
		/// Multiplies the value by 2^10
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static uint Kilo(this uint value) {
			return value * 1024;
		}

		/// <summary>
		/// Multiplies the value by 10^3 (one thousand)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static uint K(this uint value) {
			return value * 1000;
		}


		/// <summary>
		/// Multiplies the value by 2^20
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static int Mega(this int value) {
			return value.Kilo() * 1024;
		}

		/// <summary>
		/// Multiplies the value by 10^6 (one million)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static int M(this int value) {
			return value.K() * 1000;
		}

		/// <summary>
		/// Multiplies the value by 2^20
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static uint Mega(this uint value) {
			return value.Kilo() * 1024;
		}

		/// <summary>
		/// Multiplies the value by 10^6 (one million)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static uint M(this uint value) {
			return value.K() * 1000;

		}

		/// <summary>
		/// Multiplies the value by 2^30
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static int Giga(this int value) {
			return value.Mega() * 1024;
		}

		/// <summary>
		/// Multiplies the value by 10^9 (one billion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static int B(this int value) {
			return value.M() * 1000;
		}

		/// <summary>
		/// Multiplies the value by 2^30
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static uint Giga(this uint value) {
			return value.Mega() * 1024;
		}

		/// <summary>
		/// Multiplies the value by 10^9 (one billion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static uint B(this uint value) {
			return value.M() * 1000;
		}

	}
}

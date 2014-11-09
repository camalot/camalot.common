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
		public static bool IsEven(this long value) {
			return (value % 2) == 0;
		}

		/// <summary>
		/// Determines whether the specified value is odd.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsOdd(this long value) {
			return (value % 2) != 0;
		}

		/// <summary>
		/// Determines whether the specified value is even.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsEven(this ulong value) {
			return (value % 2) == 0;
		}

		/// <summary>
		/// Determines whether the specified value is odd.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static bool IsOdd(this ulong value) {
			return (value % 2) != 0;
		}


		/// <summary>
		/// Multiplies the value by 2^10
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static long Kilo(this long value) {
			return value * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^3 (one thousand)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static long K(this long value) {
			return value * 1000L;
		}

		/// <summary>
		/// Multiplies the value by 2^10
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static ulong Kilo(this ulong value) {
			return value * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^3 (one thousand)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static ulong K(this ulong value) {
			return value * 1000L;
		}


		/// <summary>
		/// Multiplies the value by 2^20
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static long Mega(this long value) {
			return value.Kilo() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^6 (one million)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static long M(this long value) {
			return value.K() * 1000L;
		}

		/// <summary>
		/// Multiplies the value by 2^20
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static ulong Mega(this ulong value) {
			return value.Kilo() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^6 (one million)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static ulong M(this ulong value) {
			return value.K() * 1000L;

		}

		/// <summary>
		/// Multiplies the value by 2^30
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static long Giga(this long value) {
			return value.Mega() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^9 (one billion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static long B(this long value) {
			return value.M() * 1000L;
		}

		/// <summary>
		/// Multiplies the value by 2^30
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static ulong Giga(this ulong value) {
			return value.Mega() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^9 (one billion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static ulong B(this ulong value) {
			return value.M() * 1000;
		}


		/// <summary>
		/// Multiplies the value by 2^40
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="1061db9b00620852af88" />
		public static long Tera(this long value) {
			return value.Giga() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^12 (one trillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="1061db9b00620852af88" />
		public static long T(this long value) {
			return value.B() * 1000L;
		}

		/// <summary>
		/// Multiplies the value by 2^40
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="1061db9b00620852af88" />
		public static ulong Tera(this ulong value) {
			return value.Giga() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^12 (one trillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="1061db9b00620852af88" />
		public static ulong T(this ulong value) {
			return value.B() * 1000;
		}



		/// <summary>
		/// Multiplies the value by 2^50
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="c9dc04638a360990984a" />
		public static long Peta(this long value) {
			return value.Tera() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^15 (one quadrillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="c9dc04638a360990984a" />
		public static long P(this long value) {
			return value.T() * 1000L;
		}

		/// <summary>
		/// Multiplies the value by 2^50
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="c9dc04638a360990984a" />
		public static ulong Peta(this ulong value) {
			return value.Tera() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^15 (one quadrillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="c9dc04638a360990984a" />
		public static ulong P(this ulong value) {
			return value.T() * 1000;
		}



		/// <summary>
		/// Multiplies the value by 2^60
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="2d53fbbd5442e8b731a0" />
		public static long Exa(this long value) {
			return value.Peta() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^18 (one quintillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="2d53fbbd5442e8b731a0" />
		public static long E(this long value) {
			return value.P() * 1000L;
		}

		/// <summary>
		/// Multiplies the value by 2^60
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="2d53fbbd5442e8b731a0" />
		public static ulong Exa(this ulong value) {
			return value.Peta() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^18 (one quintillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="2d53fbbd5442e8b731a0" />
		public static ulong E(this ulong value) {
			return value.P() * 1000;
		}

		/// <summary>
		/// Multiplies the value by 2^70
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="28b00f2ec3e2c83ef173" />
		public static ulong Zetta(this ulong value) {
			return value.Exa() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^21 (one sextillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="28b00f2ec3e2c83ef173" />
		public static ulong Z(this ulong value) {
			return value.E() * 1000;
		}


		/// <summary>
		/// Multiplies the value by 2^80
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="749614ebc92dc68211b7" />
		public static ulong Yotta(this ulong value) {
			return value.Zetta() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^24 (one septillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="749614ebc92dc68211b7" />
		public static ulong Y(this ulong value) {
			return value.Z() * 1000;
		}
	}
}

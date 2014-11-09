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

		/// <summary>
		/// Multiplies the value by 2^10
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static double Kilo(this double value) {
			return value * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^3 (one thousand)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="00deb6720cc278be8ca9" />
		public static double K(this double value) {
			return value * 1000L;
		}



		/// <summary>
		/// Multiplies the value by 2^20
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static double Mega(this double value) {
			return value.Kilo() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^6 (one million)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="d01704cf490ec59fc1e9" />	
		public static double M(this double value) {
			return value.K() * 1000L;

		}


		/// <summary>
		/// Multiplies the value by 2^30
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static double Giga(this double value) {
			return value.Mega() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^9 (one billion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="f1b33489ed80d3f8bc0f" />
		public static double B(this double value) {
			return value.M() * 1000;
		}

		/// <summary>
		/// Multiplies the value by 10^12 (one trillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="1061db9b00620852af88" />
		public static double T(this double value) {
			return value.B() * 1000L;
		}

		/// <summary>
		/// Multiplies the value by 2^40
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="1061db9b00620852af88" />
		public static double Tera(this double value) {
			return value.Giga() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 2^50
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="c9dc04638a360990984a" />
		public static double Peta(this double value) {
			return value.Tera() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^15 (one quadrillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="c9dc04638a360990984a" />
		public static double P(this double value) {
			return value.T() * 1000;
		}

		/// <summary>
		/// Multiplies the value by 2^60
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="2d53fbbd5442e8b731a0" />
		public static double Exa(this double value) {
			return value.Peta() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^18 (one quintillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="2d53fbbd5442e8b731a0" />
		public static double E(this double value) {
			return value.P() * 1000;
		}

		/// <summary>
		/// Multiplies the value by 2^70
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="28b00f2ec3e2c83ef173" />
		public static double Zetta(this double value) {
			return value.Exa() * 1024L;
		}

		/// <summary>
		/// Multiplies the value by 10^21 (one sextillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="28b00f2ec3e2c83ef173" />
		public static double Z(this double value) {
			return value.E() * 1000;
		}


		/// <summary>
		/// Multiplies the value by 2^80
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="749614ebc92dc68211b7" />
		public static double Yotta(this double value) {
			return value.Zetta() * 1024;
		}

		/// <summary>
		/// Multiplies the value by 10^24 (one septillion)
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		/// <gist id="749614ebc92dc68211b7" />
		public static double Y(this double value) {
			return value.Z() * 1000;
		}
	}

}

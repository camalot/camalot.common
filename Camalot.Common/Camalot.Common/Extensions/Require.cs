using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Properties;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static Object Require(this Object obj) {
			return obj.Require(x => x != null, Resources.Common_NullOrEmpty);
		}

		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="abd4a899b9fe766184de" />
		public static Object Require(this Object obj, String message) {
			return obj.Require(x => x != null, message);
		}


		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="guid">The unique identifier.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static Guid Require(this Guid guid) {
			return guid.Require(x => x != default(Guid), Resources.Common_NullOrEmpty);
		}

		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="guid">The unique identifier.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <gist id="abd4a899b9fe766184de" />
		public static Guid Require(this Guid guid, String message) {
			return guid.Require(x => x != default(Guid), message);
		}

		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The object.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="abd4a899b9fe766184de" />
		public static T Require<T>(this T t, String message) {
			return t.Require(x => !x.Equals(default(T)), message);
		}

		/// <summary>
		/// Requires the specified object to pass the predicate test.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The t.</param>
		/// <param name="test">The test must evaluate to true, or the exception will be thrown.</param>
		/// <param name="message">The message.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">Throws if test returns false.</exception>
		public static T Require<T>(this T t, Func<T, bool> test, string message, string param) {
			if(test(t)) {
				return t;
			}
			throw new ArgumentException(message, param);
		}

		/// <summary>
		/// Requires the specified object to pass the predicate test.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The t.</param>
		/// <param name="test">The test.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">Throws if test returns false.</exception>
		public static T Require<T>(this T t, Func<T, bool> test, string message) {
			if(test(t)) {
				return t;
			}
			throw new ArgumentException(message);
		}


		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The object.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static T Require<T>(this T t) {
			return t.Require(x => !x.Equals(default(T)), Resources.Common_NullOrEmpty);
		}

		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="abd4a899b9fe766184de" />
		public static String Require(this String s, String message) {
			return s.Require(x => !string.IsNullOrWhiteSpace(s), message);
		}
		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static String Require(this String s) {
			return s.Require(x => !string.IsNullOrWhiteSpace(s), Resources.Common_NullOrEmpty);
		}

		/// <summary>
		/// Requires the specified nullable object to have a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The object.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="abd4a899b9fe766184de" />
		public static T? Require<T>(this T? t, String message) where T : struct, IComparable {
			return t.Require(x => x.HasValue, message);
		}
		/// <summary>
		/// Requires the specified object to have a value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The object.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		/// <gist id="bf5ce83be2f8b47d03e8"></gist>
		public static T? Require<T>(this T? t) where T : struct, IComparable {
			return t.Require(x => x.HasValue, Resources.Common_NullOrEmpty);
		}

		#region Integer
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero.With ( i )</exception>
		public static int RequireZero(this int i) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i));
		}
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static int RequireZero(this int i, String param) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i), param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The int.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static int RequirePositive(this int i, String param) {
			return RequireBetween(i, 1, int.MaxValue, param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The int.</param>
		/// <returns></returns>
		public static int RequirePositive(this int i) {
			return RequireBetween(i, 1, int.MaxValue);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The int.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static int RequireNegative(this int i, String param) {
			return RequireBetween(i, int.MinValue, -1, param);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The int.</param>
		/// <returns></returns>
		public static int RequireNegative(this int i) {
			return RequireBetween(i, int.MinValue, -1);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static int RequireBetween(this int i, int low, int high, String param) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i), param);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static int RequireBetween(this int i, int low, int high) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i));
		}
		#endregion

		#region Short
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static short RequireZero(this short i) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i));
		}
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static short RequireZero(this short i, String param) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i),param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static short RequirePositive(this short i, String param) {
			return RequireBetween(i, (short)1, short.MaxValue, param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static short RequirePositive(this short i) {
			return RequireBetween(i, (short)1, short.MaxValue);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static short RequireNegative(this short i, String param) {
			return RequireBetween(i, short.MinValue, (short)-1, param);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static short RequireNegative(this short i) {
			return RequireBetween(i, short.MinValue, (short)-1);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static short RequireBetween(this short i, short low, short high, String param) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i), param);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static short RequireBetween(this short i, short low, short high) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i));
		}
		#endregion

		#region Long
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static long RequireZero(this long i) {
			return i.Require(x => x == 0, Resources.Require_Zero);
		}
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static long RequireZero(this long i, String param) {
			return i.Require(x => x == 0, Resources.Require_Zero,param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static long RequirePositive(this long i, String param) {
			return RequireBetween(i, (long)1, long.MaxValue, param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static long RequirePositive(this long i) {
			return RequireBetween(i, (long)1, long.MaxValue);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static long RequireNegative(this long i, String param) {
			return RequireBetween(i, long.MinValue, (long)-1, param);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static long RequireNegative(this long i) {
			return RequireBetween(i, long.MinValue, (long)-1);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static long RequireBetween(this long i, long low, long high, String param) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i), param);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static long RequireBetween(this long i, long low, long high) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i));
		}
		#endregion

		#region Decimal
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static decimal RequireZero(this decimal i) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i));
		}
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static decimal RequireZero(this decimal i, String param) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i), param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static decimal RequirePositive(this decimal i, String param) {
			return RequireBetween(i, (decimal)1, decimal.MaxValue, param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static decimal RequirePositive(this decimal i) {
			return RequireBetween(i, (decimal)1, decimal.MaxValue);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static decimal RequireNegative(this decimal i, String param) {
			return RequireBetween(i, decimal.MinValue, (decimal)-1, param);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static decimal RequireNegative(this decimal i) {
			return RequireBetween(i, decimal.MinValue, (decimal)-1);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static decimal RequireBetween(this decimal i, decimal low, decimal high, String param) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i), param);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static decimal RequireBetween(this decimal i, decimal low, decimal high) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i));
		}
		#endregion

		#region Double
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static double RequireZero(this double i) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i));
		}
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static double RequireZero(this double i, String param) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i), param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static double RequirePositive(this double i, String param) {
			return RequireBetween(i, (double)1, double.MaxValue, param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static double RequirePositive(this double i) {
			return RequireBetween(i, (double)1, double.MaxValue);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static double RequireNegative(this double i, String param) {
			return RequireBetween(i, double.MinValue, (double)-1, param);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static double RequireNegative(this double i) {
			return RequireBetween(i, double.MinValue, (double)-1);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static double RequireBetween(this double i, double low, double high, String param) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i), param);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static double RequireBetween(this double i, double low, double high) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i));
		}
		#endregion

		#region Float
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static float RequireZero(this float i) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i));
		}
		/// <summary>
		/// Requires the specified number to be zero.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{0}' must zero..With ( i )</exception>
		public static float RequireZero(this float i, String param) {
			return i.Require(x => x == 0, Resources.Require_Zero.With(i), param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static float RequirePositive(this float i, String param) {
			return RequireBetween(i, (float)1, float.MaxValue, param);
		}

		/// <summary>
		/// Requires the specified number to be a positive value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static float RequirePositive(this float i) {
			return RequireBetween(i, (float)1, float.MaxValue);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		public static float RequireNegative(this float i, String param) {
			return RequireBetween(i, float.MinValue, (float)-1, param);
		}

		/// <summary>
		/// Requires the specified number to be a negative value.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns></returns>
		public static float RequireNegative(this float i) {
			return RequireBetween(i, float.MinValue, (float)-1);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <param name="param">The parameter.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static float RequireBetween(this float i, float low, float high, String param) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i), param);
		}

		/// <summary>
		/// Requires the specified number to be between the high and low.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="low">The low.</param>
		/// <param name="high">The high.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">value '{2}' must be a value between {0} and {1}.With ( low, high, i )</exception>
		public static float RequireBetween(this float i, float low, float high) {
			return i.Require(x => !(x < low || x > high), Resources.Require_Between.With(low, high, i));
		}
		#endregion
	}
}

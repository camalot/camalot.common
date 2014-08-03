using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Camalot.Common.Properties;
using MoreLinq;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Sets the source string format with the values passed as arguments 
		/// </summary>
		/// <param name="s">The source string format.</param>
		/// <param name="args">The arguments.</param>
		/// <returns></returns>
		public static String With(this String s, params object[] args) {
			return String.Format(s, args);
		}

		/// <summary>
		/// Sets the source string format with the values passed as arguments 
		/// </summary>
		/// <param name="s">The source string format.</param>
		/// <param name="culture">The culture info
		/// .</param>
		/// <param name="args">The arguments.</param>
		/// <returns></returns>
		public static String With(this String s, CultureInfo culture, params object[] args) {
			return String.Format(culture, s, args);
		}


		/// <summary>
		/// Performs a Regular Expression Match.
		/// </summary>
		/// <param name="s">The string to match.</param>
		/// <param name="pattern">The pattern.</param>
		/// <returns>The regular expression match.</returns>
		public static Match Match(this String s, String pattern) {
			return Match(s, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// Performs a Regular Expression Match.
		/// </summary>
		/// <param name="s">The string to match.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static Match Match(this String s, String pattern, RegexOptions options) {
			return Regex.Match(s, pattern, options);
		}


		/// <summary>
		/// Determines whether the specified string is match to the specified pattern.
		/// </summary>
		/// <param name="s">The string to match.</param>
		/// <param name="pattern">The pattern.</param>
		/// <returns></returns>
		public static bool IsMatch(this String s, String pattern) {
			return IsMatch(s, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// Determines whether the specified string is match to the specified pattern.
		/// </summary>
		/// <param name="s">The string to match.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static bool IsMatch(this String s, String pattern, RegexOptions options) {
			return Regex.IsMatch(s, pattern, options);
		}

		/// <summary>
		/// Does a Regex Replace on the string based on the specified pattern and the specified replacement.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="replacement">The replacement.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static String Replace(this String s, String pattern, String replacement, RegexOptions options) {
			return REReplace(s, pattern, replacement, options);
		}

		/// <summary>
		/// Does a Regex Replace on the string based on the specified pattern and the specified replacement.
		/// </summary>
		/// <param name="s">The s.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="evaluator">The evaluator.</param>
		/// <returns></returns>
		public static String Replace(this String s, String pattern, MatchEvaluator evaluator) {
			return Regex.Replace(s, pattern, evaluator);
		}

		/// <summary>
		/// Does a Regex Replace on the string based on the specified pattern and the specified evaluator.
		/// </summary>
		/// <param name="s">The s.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <param name="evaluator">The evaluator.</param>
		/// <returns></returns>
		public static String Replace(this String s, String pattern, RegexOptions options, MatchEvaluator evaluator) {
			return Regex.Replace(s, pattern, evaluator, options);
		}

		/// <summary>
		/// Does a Regex Replace on the specified string based on the specified pattern and replacement.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="replacement">The replacement.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static String REReplace(this String s, String pattern, String replacement, RegexOptions options) {
			return Regex.Replace(s, pattern, replacement, options);
		}

		/// <summary>
		/// Does a Regex Replace on the specified string based on the specified pattern and replacement.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="replacement">The replacement.</param>
		/// <returns></returns>
		public static String REReplace(this String s, String pattern, String replacement) {
			return REReplace(s, pattern, replacement, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// Does a Regex Replace on the string based on the specified pattern and the specified evaluator.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="options">The options.</param>
		/// <param name="evaluator">The evaluator.</param>
		/// <returns></returns>
		public static String REReplace(this String s, String pattern, RegexOptions options, MatchEvaluator evaluator) {
			return Regex.Replace(s, pattern, evaluator, options);
		}

		/// <summary>
		/// Does a Regex Replace on the string based on the specified pattern and the specified evaluator.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="pattern">The pattern.</param>
		/// <param name="evaluator">The evaluator.</param>
		/// <returns></returns>
		public static String REReplace(this String s, String pattern, MatchEvaluator evaluator) {
			return REReplace(s, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase, evaluator);
		}

		/// <summary>
		/// Gets the bytes from the specified string.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="encoding">The encoding.</param>
		/// <returns></returns>
		public static byte[] GetBytes(this String s, Encoding encoding) {
			return encoding.GetBytes(s);
		}

		/// <summary>
		/// Gets the bytes from the specified string.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns></returns>
		public static byte[] GetBytes(this String s) {
			return GetBytes(s, Encoding.Default);
		}

		/// <summary>
		/// Converts a string to a URL friendly value
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		/// <see cref="http://stackoverflow.com/questions/25259/how-do-you-include-a-webpage-title-as-part-of-a-webpage-url"/>
		public static String Slug(this String input) {
			return String.IsNullOrEmpty(input) ?
				String.Empty :
				input.ToLower()
						 .Trim()
						 .REReplace(@"\w+;", "", RegexOptions.Compiled)
						 .REReplace(@"(?<!-)(\s|,|\.|\/|\\|\-)", "-")
						 .REReplace("-$", "")
						 .REReplace("[^a-z0-9-]", "")
						 .REReplace("-{2,}", "-");

		}

		/// <summary>
		/// Converts the objects string representation to camelCase.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static String ToCamelCase(this object input) {
			return input.Require(Resources.Common_NullOrEmpty).ToString().ToCamelCase();
		}

		/// <summary>
		/// Converts the objects string representation to camelCase.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static String ToCamelCase(this String input) {
			return input.Require(Resources.Common_NullOrEmpty).Replace(input[0], input.ToLower()[0]);
		}

		/// <summary>
		/// Converts the objects string representation to PascalCase.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static String ToPascalCase(this String input) {
			return CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(input.Require(Resources.Common_NullOrEmpty));
		}

		/// <summary>
		/// Splits the string based on the specified separator and trims each item.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="separator">The separator.</param>
		/// <param name="options">The options.</param>
		/// <returns></returns>
		public static String[] SplitAndTrim(this String input, char[] separator, StringSplitOptions options) {
			var result = new List<String>();
			if(String.IsNullOrWhiteSpace(input)) {
				return result.ToArray();
			}
			input.Split(separator, options).ForEach(i => result.Add(i.Trim()));
			return result.ToArray();
		}

		/// <summary>
		/// Splits the string based on the specified separator and trims each item.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="separator">The separator.</param>
		/// <returns></returns>
		public static String[] SplitAndTrim(this String input, char[] separator) {
			return SplitAndTrim(input, separator, StringSplitOptions.RemoveEmptyEntries);
		}


		/// <summary>
		/// Converts the string to an SHA1 hash
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		/// <remarks><![CDATA[This is the equivalent of <code>CAST(HASHBYTES('SHA1', RTRIM(LTRIM(LOWER([COLUMN_NAME])))) AS VARBINARY(20))</code> in TSQL.]]></remarks>
		public static byte[] ToDatabaseHash(this String input) {
			var bytes = Encoding.Unicode.GetBytes(input.Require().Trim().ToLower());
			var sha1 = new SHA1CryptoServiceProvider();
			return sha1.ComputeHash(bytes);
		}

		/// <summary>
		/// Base64 Encodes the specified string.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static string ToBase64String(this string input) {
			return ToBase64String(input.Require(), Encoding.UTF8).ToBase64String();
		}

		/// <summary>
		/// Base64 Encodes the specified string.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="encoding">The encoding.</param>
		/// <returns></returns>
		public static string ToBase64String(this string input, Encoding encoding) {
			return Encoding.UTF8.GetBytes(input.Require()).ToBase64String();
		}

		/// <summary>
		/// HTML encodes the input string
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static string HtmlEncode(this string input) {
			return System.Net.WebUtility.HtmlEncode(input);
		}

		/// <summary>
		/// HTML encodes the input string
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="output">The output.</param>
		public static void HtmlEncode(this string input, TextWriter output) {
			System.Net.WebUtility.HtmlEncode(input, output);
		}

		/// <summary>
		/// Url encodes the input string
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static string UrlEncode(this string input) {
			return System.Net.WebUtility.UrlEncode(input);
		}

		/// <summary>
		/// Decodes the HTML encoded input string
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static string HtmlDecode(this string input) {
			return System.Net.WebUtility.HtmlDecode(input);
		}

		/// <summary>
		/// Decodes the HTML encoded input string
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="output">The output.</param>
		public static void HtmlDecode(this string input, TextWriter output) {
			System.Net.WebUtility.HtmlDecode(input, output);
		}

		/// <summary>
		/// Decodes a url encoded input string
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static string UrlDecode(this string input) {
			return System.Net.WebUtility.UrlDecode(input);
		}
	}
}

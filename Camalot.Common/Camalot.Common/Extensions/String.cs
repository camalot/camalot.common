using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Camalot.Common.Properties;
using MoreLinq;

namespace Camalot.Common.Extensions {
	public static partial class BawsaqExtensions {
		/// <summary>
		/// Sets the source string format with the values passed as arguments 
		/// </summary>
		/// <param name="s">The source string format.</param>
		/// <param name="args">The arguments.</param>
		/// <returns></returns>
		public static String With ( this String s, params object[] args ) {
			return String.Format ( s, args );
		}

		public static Match Match ( this String s, String pattern ) {
			return Match ( s, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase );
		}

		public static Match Match ( this String s, String pattern, RegexOptions options ) {
			return Regex.Match ( s, pattern, options );
		}


		public static bool IsMatch ( this String s, String pattern ) {
			return IsMatch ( s, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase );
		}

		public static bool IsMatch ( this String s, String pattern, RegexOptions options ) {
			return Regex.IsMatch ( s, pattern, options );
		}

		public static String Replace ( this String s, String pattern, String replacement, RegexOptions options ) {
			return REReplace ( s, pattern, replacement, options );
		}

		public static String Replace ( this String s, String pattern, MatchEvaluator evaluator ) {
			return Regex.Replace ( s, pattern, evaluator );
		}

		public static String Replace ( this String s, String pattern, RegexOptions options, MatchEvaluator evaluator ) {
			return Regex.Replace ( s, pattern, evaluator, options );
		}

		public static String REReplace ( this String s, String pattern, String replacement, RegexOptions options ) {
			return Regex.Replace ( s, pattern, replacement, options );
		}

		public static String REReplace ( this String s, String pattern, String replacement ) {
			return REReplace ( s, pattern, replacement, RegexOptions.Compiled | RegexOptions.IgnoreCase );
		}

		public static String REReplace ( this String s, String pattern, RegexOptions options, MatchEvaluator evaluator ) {
			return Regex.Replace ( s, pattern, evaluator, options );
		}

		public static String REReplace ( this String s, String pattern, MatchEvaluator evaluator ) {
			return REReplace ( s, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase, evaluator );
		}

		public static byte[] GetBytes ( this String s, Encoding encoding ) {
			return encoding.GetBytes ( s );
		}

		public static byte[] GetBytes ( this String s ) {
			return GetBytes ( s, Encoding.Default );
		}

		// Originally started as this
		// http://stackoverflow.com/questions/25259/how-do-you-include-a-webpage-title-as-part-of-a-webpage-url
		public static String Slug ( this String input ) {
			return String.IsNullOrEmpty ( input ) ?
				String.Empty :
				input.ToLower ( )
						 .Trim ( )
						 .REReplace ( @"\w+;", "", RegexOptions.Compiled )
						 .REReplace ( @"(?<!-)(\s|,|\.|\/|\\|\-)", "-" )
						 .REReplace ( "-$", "" )
						 .REReplace ( "[^a-z0-9-]", "" )
						 .REReplace ( "-{2,}", "-" );

		}

		public static String ToCamelCase ( this object input ) {
			return input.ToString ( ).ToCamelCase ( );
		}

		public static String ToCamelCase ( this String input ) {
			return input.Require ( Resources.Common_NullOrEmpty ).Replace ( input[0], input.ToLower ( )[0] );
		}

		public static String ToPascalCase ( this String input ) {
			return CultureInfo.CurrentUICulture.TextInfo.ToTitleCase ( input.Require ( Resources.Common_NullOrEmpty ) );
		}

		public static String[] SplitAndTrim ( this String input, char[] separator, StringSplitOptions options ) {
			var result = new List<String> ( );
			if ( String.IsNullOrWhiteSpace ( input ) ) {
				return result.ToArray ( );
			}
			input.Split ( separator, options ).ForEach ( i => result.Add ( i.Trim ( ) ) );
			return result.ToArray ( );
		}

		public static String[] SplitAndTrim ( this String input, char[] separator ) {
			return SplitAndTrim ( input, separator, StringSplitOptions.RemoveEmptyEntries );
		}


		/// <summary>
		/// this is like: CAST(HASHBYTES('SHA1', RTRIM(LTRIM(LOWER([COLUMN_NAME])))) AS VARBINARY(20))
		/// in TSQL
		/// </summary>
		public static byte[] ToDatabaseHash ( this String input ) {
			var bytes = Encoding.Unicode.GetBytes ( input.Require ( ).Trim().ToLower ( ) );
			var sha1 = new SHA1CryptoServiceProvider ( );
			return sha1.ComputeHash ( bytes );
		}
	}
}

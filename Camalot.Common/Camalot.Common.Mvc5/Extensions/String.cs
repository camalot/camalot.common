using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Camalot.Common.Mvc.Extensions {
	public static partial class CamalotCommonMvcExtensions {
		/// <summary>
		/// URL encodes a string.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns></returns>
		public static string UrlEncode ( this string s ) {
			return HttpUtility.UrlEncode ( s );
		}

		/// <summary>
		/// URL encodes a string.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="encoding">The encoding.</param>
		/// <returns></returns>
		public static string UrlEncode ( this string s, Encoding encoding ) {
			return HttpUtility.UrlEncode ( s, encoding );
		}

		/// <summary>
		/// URL decodes a string.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns></returns>
		public static string UrlDecode ( this string s ) {
			return HttpUtility.UrlDecode ( s );
		}

		/// <summary>
		/// URL decodes a string.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="encoding">The encoding.</param>
		/// <returns></returns>
		public static string UrlDecode ( this string s, Encoding encoding ) {
			return HttpUtility.UrlDecode ( s, encoding );
		}

		/// <summary>
		/// HTML encodes a string.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns></returns>
		public static string HtmlEncode ( this string s ) {
			return HttpUtility.HtmlEncode ( s );
		}

		/// <summary>
		/// HTML decodes a string.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <returns></returns>
		public static string HtmlDecode ( this string s ) {
			return HttpUtility.HtmlDecode ( s );
		}

	}
}

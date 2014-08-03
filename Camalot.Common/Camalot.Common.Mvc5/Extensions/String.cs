using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Camalot.Common.Mvc.Extensions {
	public static partial class CamalotCommonMvcExtensions {
		/// <summary>
		/// Encodes a URL string using the specified encoding object.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="encoding">The Encoding object that specifies the encoding scheme.</param>
		/// <returns></returns>
		/// <remarks>This method can be used to encode the entire URL, including query-string values. If characters such as blanks and punctuation are passed in an HTTP stream, 
		/// they might be misinterpreted at the receiving end. URL encoding converts characters that are not allowed in a URL into character-entity equivalents; URL decoding 
		/// reverses the encoding. For example, when the characters &lt; and &gt; are embedded in a block of text to be transmitted in a URL, they are encoded as %3c and %3e.</remarks>
		/// <seealso cref="http://msdn.microsoft.com/en-us/library/h10z5byc.aspx">HttpUtility.UrlEncode</seealso>
		public static string UrlEncode(this string s, Encoding encoding) {
			return HttpUtility.UrlEncode ( s, encoding );
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
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Properties;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Transforms the Color to an HTML hexadecimal string (#FFFFFF).
		/// </summary>
		/// <param name="color">The color.</param>
		/// <returns></returns>
		public static string ToHtmlHex ( this Color color ) {
			return "#" + color.R.ToString ( "X2" ) + color.G.ToString ( "X2" ) + color.B.ToString ( "X2" );
		}

		/// <summary>
		/// Transforms HTML hexadecimal string (#FFFFFF) in to a Color object
		/// </summary>
		/// <param name="htmlColor">Color of the HTML.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException">Unexpected html color string format.</exception>
		public static Color ToColor ( this string htmlColor ) {
			if ( !htmlColor.IsMatch ( @"^\#[a-f0-9]{6}$" ) ) {
				throw new ArgumentException ( Resources.Color_UnexpectedFormat );
			}
			return ColorTranslator.FromHtml ( htmlColor );
		}
	}
}

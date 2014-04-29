using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Enumerate through each match. Automatically calls NextMatch for you.
		/// </summary>
		/// <param name="m"></param>
		/// <param name="action">The action to execute on each match</param>
		public static void ForEach ( this Match m, Action<Match> action ) {
			while ( m.Success ) {
				action ( m );
				m = m.NextMatch ( );
			}
		}
	}
}

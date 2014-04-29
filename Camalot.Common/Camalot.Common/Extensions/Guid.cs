using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {

		/// <summary>
		/// Determines whether the specified unique identifier is empty.
		/// </summary>
		/// <param name="guid">The unique identifier.</param>
		/// <returns></returns>
		public static bool IsEmpty(this Guid guid) {
			return guid == Guid.Empty;
		}
	}
}

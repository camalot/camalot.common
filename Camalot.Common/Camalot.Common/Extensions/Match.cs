using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Camalot.Common.Properties;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Enumerate through each match. Automatically calls NextMatch for you.
		/// </summary>
		/// <param name="m"></param>
		/// <param name="action">The action to execute on each match</param>
		public static void ForEach(this Match m, Action<Match> action) {
			while(m.Success) {
				action(m);
				m = m.NextMatch();
			}
		}

		/// <summary>
		/// Gets the first match group value.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">
		/// </exception>
		public static string First(this Match m) {
			if(m.Success) {
				if(m.Groups.Count > 0) {
					// return group[1] because 0 is the full string.
					return m.Groups[1].Value;
				} else {
					throw new InvalidOperationException(Resources.Sequence_Empty);
				}
			} else {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
		}

		/// <summary>
		/// Gets the first match group value.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <returns></returns>
		public static string FirstOrDefault(this Match m) {
			if(m.Success) {
				if(m.Groups.Count > 0) {
					// return group[1] because 0 is the full string.
					return m.Groups[1].Value;
				} else {
					return string.Empty;
				}
			} else {
				return string.Empty;
			}
		}

		/// <summary>
		/// Gets a single match group.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">
		/// </exception>
		public static string Single(this Match m) {
			if(m.Success) {
				if(m.Groups.Count == 2) {
					// return group[1] because 0 is the full string.
					return m.Groups[1].Value;
				} else {
					throw new InvalidOperationException(Resources.Sequence_Empty);
				}
			} else {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
		}

		/// <summary>
		/// Gets a single match group or a default if no match.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <returns></returns>
		public static string SingleOrDefault(this Match m) {
			if(m.Success) {
				if(m.Groups.Count == 2) {
					return m.Groups[1].Value;
				} else {
					return string.Empty;
				}
			} else {
				return string.Empty;
			}
		}
	}
}

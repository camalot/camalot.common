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
		/// Converts the matches to a list of matches.
		/// </summary>
		/// <param name="match">The match.</param>
		/// <returns></returns>
		public static IList<Match> ToList(this Match match) {
			var result = new List<Match>();
			while(match.Success) {
				result.Add(match);
				match = match.NextMatch();
			}
			return result;
		}

		/// <summary>
		/// Converts the matches to an array of match items
		/// </summary>
		/// <param name="match">The match.</param>
		/// <returns></returns>
		public static Match[] ToArray(this Match match) {
			return match.ToList().ToArray();
		}

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
		/// Gets the first match item from the specified match.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">
		/// </exception>
		public static Match First(this Match m) {
			return m.First(x => true);
		}

		/// <summary>
		/// Gets the first match item from the specified match.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static Match First(this Match m, Func<Match, bool> predicate) {
			var result = m.FirstOrDefault(x => predicate(x));
			if(result == default(Match)) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
			return result;
		}


		/// <summary>
		/// Gets the first match item from the specified match.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <returns></returns>
		public static Match FirstOrDefault(this Match m) {
			return m.FirstOrDefault(x => true);
		}

		/// <summary>
		/// Gets the first match item from the specified match.
		/// </summary>
		/// <param name="m">The m.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		public static Match FirstOrDefault(this Match m, Func<Match, bool> predicate) {
			var matches = new List<Match>();
			while(m.Success) {
				matches.Add(m);
				m = m.NextMatch();
			}

			if(matches.Where(x => predicate(x)).Count() >= 1) {
				return matches[0];
			} else {
				return default(Match);
			}
		}


		/// <summary>
		/// Gets a single match.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">
		/// </exception>
		public static Match Single(this Match m) {
			return m.Single(x => true);
		}

		/// <summary>
		/// Gets a single match.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static Match Single(this Match m, Func<Match, bool> predicate) {
			var result = m.SingleOrDefault(x => predicate(x));
			if(result == default(Match)) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
			return result;
		}

		/// <summary>
		/// Gets a single match or a default if no match.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <returns></returns>
		public static Match SingleOrDefault(this Match m) {
			return m.SingleOrDefault(x => true);
		}

		/// <summary>
		/// Gets a single match or a default if no match.
		/// </summary>
		/// <param name="m">The match.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static Match SingleOrDefault(this Match m, Func<Match, bool> predicate) {
			var matches = new List<Match>();
			while(m.Success) {
				matches.Add(m);
				m = m.NextMatch();
			}
			var filtered = matches.Where(x => predicate(x));
			if(filtered.Count() == 1) {
				return matches[0];
			} else if(filtered.Count() == 0) {
				return default(Match);
			} else {
				throw new InvalidOperationException(Resources.Sequence_MoreTanOne);
			}

		}
	}
}

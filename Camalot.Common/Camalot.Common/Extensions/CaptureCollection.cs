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
		/// Converts the capture collection to a list of capture items.
		/// </summary>
		/// <param name="captures">The captures.</param>
		/// <returns></returns>
		public static IList<Capture> ToList(this CaptureCollection captures) {
			var result = new List<Capture>();
			foreach(Capture c in captures) {
				result.Add(c);
			}
			return result;
		}

		/// <summary>
		/// Converts the capture collection to an array of capture items.
		/// </summary>
		/// <param name="captures">The captures.</param>
		/// <returns></returns>
		public static Capture[] ToArray(this CaptureCollection captures) {
			return captures.ToList().ToArray();
		}

		/// <summary>
		/// Enumerate through each Capture.
		/// </summary>
		/// <param name="captures">The Captures.</param>
		/// <param name="action">The action.</param>
		public static void ForEach(this CaptureCollection captures, Action<Capture> action) {
			captures.ForEach(x => true, x => action(x));
		}

		/// <summary>
		/// Enumerate through each Capture.
		/// </summary>
		/// <param name="captures">The Captures.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="action">The action.</param>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static void ForEach(this CaptureCollection captures, Func<Capture, bool> predicate, Action<Capture> action) {
			if(captures.Count == 0) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}

			foreach(Capture g in captures) {
				if(predicate(g)) {
					action(g);
				}
			}
		}

		/// <summary>
		/// Gets the first match Capture from the specified match.
		/// </summary>
		/// <param name="g">The Capture collection.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public static Capture First(this CaptureCollection g) {
			return g.First(x => true);
		}

		/// <summary>
		/// Gets the first match capture from the specified match.
		/// </summary>
		/// <param name="g">The capture collection.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static Capture First(this CaptureCollection g, Func<Capture, bool> predicate) {
			var result = g.FirstOrDefault(x => predicate(x));
			if(result == default(Capture)) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
			return result;
		}

		/// <summary>
		/// Gets the first match capture from the specified match.
		/// </summary>
		/// <param name="c">The capture collection.</param>
		/// <returns></returns>
		public static Capture FirstOrDefault(this CaptureCollection c) {
			return c.FirstOrDefault(x => true);
		}

		/// <summary>
		/// Gets the first match capture from the specified match.
		/// </summary>
		/// <param name="c">The capture collection.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		public static Capture FirstOrDefault(this CaptureCollection c, Func<Capture, bool> predicate) {
			var filtered = new List<Capture>();
			foreach(Capture f in c) {
				if(predicate(f)) {
					filtered.Add(f);
				}
			}
			// skip the first because it contains the full match
			return filtered.FirstOrDefault();
		}

		/// <summary>
		/// Gets the first match capture from the specified match.
		/// </summary>
		/// <param name="c">The capture collection.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public static Capture Single(this CaptureCollection c) {
			var result = c.SingleOrDefault(x => true);
			if(result == default(Capture)) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
			return result;
		}

		/// <summary>
		/// Gets the first match capture from the specified match.
		/// </summary>
		/// <param name="c">The g.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static Capture Single(this CaptureCollection c, Func<Capture, bool> predicate) {
			var result = c.SingleOrDefault(x => predicate(x));
			if(result == default(Capture)) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
			return result;
		}

		/// <summary>
		/// Gets the first match capture from the specified match.
		/// </summary>
		/// <param name="c">The g.</param>
		/// <returns></returns>
		public static Capture SingleOrDefault(this CaptureCollection c) {
			return c.SingleOrDefault(x => true);
		}

		/// <summary>
		/// Gets the first match capture from the specified match.
		/// </summary>
		/// <param name="c">The capture collection.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		public static Capture SingleOrDefault(this CaptureCollection c, Func<Capture, bool> predicate) {
			var filtered = new List<Capture>();
			foreach(Capture f in c) {
				if(predicate(f)) {
					filtered.Add(f);
				}
			}
			// skip the first because it contains the full match
			return filtered.SingleOrDefault();
		}
	}
}

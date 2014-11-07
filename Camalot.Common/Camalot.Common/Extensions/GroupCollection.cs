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
		/// Converts the group collection to a list of group items.
		/// </summary>
		/// <param name="groups">The groups.</param>
		/// <returns></returns>
		public static IList<Group> ToList(this GroupCollection groups) {
			var result = new List<Group>();
			foreach(Group g in groups) {
				result.Add(g);
			}
			return result;
		}

		/// <summary>
		/// Converts the group collection to an array of group items.
		/// </summary>
		/// <param name="groups">The groups.</param>
		/// <returns></returns>
		public static Group[] ToArray(this GroupCollection groups) {
			return groups.ToList().ToArray();
		}

		/// <summary>
		/// Enumerate through each group.
		/// </summary>
		/// <param name="groups">The groups.</param>
		/// <param name="action">The action.</param>
		public static void ForEach(this GroupCollection groups, Action<Group> action) {
			groups.ForEach(x => true, x => action(x));
		}

		/// <summary>
		/// Enumerate through each group.
		/// </summary>
		/// <param name="groups">The groups.</param>
		/// <param name="predicate">The predicate.</param>
		/// <param name="action">The action.</param>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static void ForEach(this GroupCollection groups, Func<Group, bool> predicate, Action<Group> action) {
			if(groups.Count == 0) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}

			foreach(Group g in groups) {
				if(predicate(g)) {
					action(g);
				}
			}
		}

		/// <summary>
		/// Gets the first match group from the specified match.
		/// </summary>
		/// <param name="g">The group collection.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public static Group First(this GroupCollection g) {
			return g.First(x => true);
		}

		/// <summary>
		/// Gets the first match group from the specified match.
		/// </summary>
		/// <param name="g">The group collection.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static Group First(this GroupCollection g, Func<Group, bool> predicate) {
			var result = g.FirstOrDefault(x => predicate(x));
			if(result == default(Group)) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
			return result;
		}

		/// <summary>
		/// Gets the first match group from the specified match.
		/// </summary>
		/// <param name="g">The group collection.</param>
		/// <returns></returns>
		public static Group FirstOrDefault(this GroupCollection g) {
			return g.FirstOrDefault(x => true);
		}

		/// <summary>
		/// Gets the first match group from the specified match.
		/// </summary>
		/// <param name="g">The group collection.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		public static Group FirstOrDefault(this GroupCollection g, Func<Group, bool> predicate) {
			var filtered = new List<Group>();
			foreach(Group f in g) {
				if(predicate(f)) {
					filtered.Add(f);
				}
			}
			// skip the first because it contains the full match
			return filtered.Skip(1).FirstOrDefault();
		}

		/// <summary>
		/// Gets the first match group from the specified match.
		/// </summary>
		/// <param name="g">The group collection.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException"></exception>
		public static Group Single(this GroupCollection g) {
			var result = g.SingleOrDefault(x => true);
			if(result == default(Group)) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
			return result;
		}

		/// <summary>
		/// Gets the first match group from the specified match.
		/// </summary>
		/// <param name="g">The g.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static Group Single(this GroupCollection g, Func<Group, bool> predicate) {
			var result = g.SingleOrDefault(x => predicate(x));
			if(result == default(Group)) {
				throw new InvalidOperationException(Resources.Sequence_Empty);
			}
			return result;
		}

		/// <summary>
		/// Gets the first match group from the specified match.
		/// </summary>
		/// <param name="g">The g.</param>
		/// <returns></returns>
		public static Group SingleOrDefault(this GroupCollection g) {
			return g.SingleOrDefault(x => true);
		}

		/// <summary>
		/// Gets the first match group from the specified match.
		/// </summary>
		/// <param name="g">The group collection.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns></returns>
		public static Group SingleOrDefault(this GroupCollection g, Func<Group, bool> predicate) {
			var filtered = new List<Group>();
			foreach(Group f in g) {
				if(predicate(f)) {
					filtered.Add(f);
				}
			}
			// skip the first because it contains the full match
			return filtered.Skip(1).SingleOrDefault();
		}
	}
}

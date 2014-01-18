using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Gets the custom attribute value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="Expected">The type of the expected.</typeparam>
		/// <param name="member">The member.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static Expected GetCustomAttributeValue<T, Expected> ( this MemberInfo member, Func<T, Expected> expression ) where T : Attribute {
			var attribute = member.GetCustomAttribute<T> ( );
			if ( attribute == null )
				return default ( Expected );
			return expression ( attribute );
		}

		/// <summary>
		/// Gets member info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="members">The members.</param>
		/// <returns></returns>
		public static IEnumerable<MemberInfo> WithAttribute<T> ( this IEnumerable<MemberInfo> members ) where T : Attribute {
			return members.Where ( m => !( m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Determines whether the specified member has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="member">The member.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this MemberInfo member ) where T : Attribute {
			return !member.GetCustomAttribute<T> ( ).Equals ( default ( T ) );
		}

		/// <summary>
		/// Determines whether the specified members has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="members">The members.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<MemberInfo> members ) where T : Attribute {
			return !( members.Any ( m => m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}
	}
}

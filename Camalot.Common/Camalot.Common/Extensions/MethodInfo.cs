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
		/// <param name="method">The method.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static Expected GetCustomAttributeValue<T, Expected> ( this MethodInfo method, Func<T, Expected> expression ) where T : Attribute {
			var attribute = method.GetCustomAttribute<T> ( );
			if ( attribute == null )
				return default ( Expected );
			return expression ( attribute );
		}
		/// <summary>
		/// Gets method info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="methods">The methods.</param>
		/// <returns></returns>
		public static IEnumerable<MethodInfo> WithAttribute<T> ( this IEnumerable<MethodInfo> methods ) where T : Attribute {
			return methods.Where ( m => m.GetCustomAttribute<T> ( ) != default ( T ) );
		}
		/// <summary>
		/// Determines whether the specified method has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="method">The method.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this MethodInfo method ) where T : Attribute {
			return method.GetCustomAttribute<T> ( ) != default ( T );
		}

		/// <summary>
		/// Determines whether the specified methods has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="methods">The methods.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<MethodInfo> methods ) where T : Attribute {
			return methods.Any ( m => m.GetCustomAttribute<T> ( ) != default ( T ) );
		}
	}
}

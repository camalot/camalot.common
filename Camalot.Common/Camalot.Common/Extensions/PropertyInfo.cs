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
		/// <param name="property">The property.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static Expected GetCustomAttributeValue<T, Expected> ( this PropertyInfo property, Func<T, Expected> expression ) where T : Attribute {
			var attribute = property.GetCustomAttribute<T> ( );
			if ( attribute == null )
				return default ( Expected );
			return expression ( attribute );
		}

		/// <summary>
		/// Gets property info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="properties">The properties.</param>
		/// <returns></returns>
		public static IEnumerable<PropertyInfo> WithAttribute<T> ( this IEnumerable<PropertyInfo> properties ) where T : Attribute {
			return properties.Where ( m => m.GetCustomAttribute<T> ( ) != default ( T ) );
		}

		/// <summary>
		/// Determines whether the specified property has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="property">The property.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this PropertyInfo property ) where T : Attribute {
			return property.GetCustomAttribute<T> ( ) != default ( T );
		}

		/// <summary>
		/// Determines whether the specified properties has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="properties">The properties.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<PropertyInfo> properties ) where T : Attribute {
			return properties.Any ( m => m.GetCustomAttribute<T> ( ) != default ( T ) );
		}
	}
}

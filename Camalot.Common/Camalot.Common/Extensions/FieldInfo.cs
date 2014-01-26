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
		/// <param name="field">The field.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static Expected GetCustomAttributeValue<T, Expected> ( this FieldInfo field, Func<T, Expected> expression ) where T : Attribute {
			var attribute = field.GetCustomAttribute<T> ( );
			if ( attribute == null )
				return default ( Expected );
			return expression ( attribute );
		}

		/// <summary>
		/// Gets field info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="fields">The fields.</param>
		/// <returns></returns>
		public static IEnumerable<FieldInfo> WithAttribute<T> ( this IEnumerable<FieldInfo> fields ) where T : Attribute {
			return fields.Where ( m => m.GetCustomAttribute<T> ( ) != default ( T ) );
		}

		/// <summary>
		/// Determines whether the specified field has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="field">The field.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this FieldInfo field ) where T : Attribute {
			return field.GetCustomAttribute<T> ( ) != default ( T );
		}

		/// <summary>
		/// Determines whether the specified fields has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="fields">The fields.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<FieldInfo> fields ) where T : Attribute {
			return  fields.Any ( m => m.GetCustomAttribute<T> ( ) != default ( T ) );
		}
	}
}

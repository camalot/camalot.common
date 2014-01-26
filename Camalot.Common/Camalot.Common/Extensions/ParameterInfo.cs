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
		/// <param name="param">The parameter.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static Expected GetCustomAttributeValue<T, Expected> ( this ParameterInfo param, Func<T, Expected> expression ) where T : Attribute {
			var attribute = param.GetCustomAttribute<T> ( );
			if ( attribute == null )
				return default ( Expected );
			return expression ( attribute );
		}

		/// <summary>
		/// Gets parameter info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="parameters">The parameters.</param>
		/// <returns></returns>
		public static IEnumerable<ParameterInfo> WithAttribute<T> ( this IEnumerable<ParameterInfo> parameters ) where T : Attribute {
			return parameters.Where ( m => m.GetCustomAttribute<T> ( ) != default ( T ) );
		}
	}
}

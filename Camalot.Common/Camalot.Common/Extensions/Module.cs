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
		/// <param name="module">The module.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static Expected GetCustomAttributeValue<T, Expected> ( this Module module, Func<T, Expected> expression ) where T : Attribute {
			var attribute = module.GetCustomAttribute<T> ( );
			if ( attribute == null )
				return default ( Expected );
			return expression ( attribute );
		}
		/// <summary>
		/// Gets module info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="modules">The modules.</param>
		/// <returns></returns>
		public static IEnumerable<Module> WithAttribute<T> ( this IEnumerable<Module> modules ) where T : Attribute {
			return modules.Where ( m => m.GetCustomAttribute<T> ( ) != default ( T ) );
		}

	}
}

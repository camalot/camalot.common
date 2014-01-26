using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Withes the attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="assembly">The assembly.</param>
		/// <returns></returns>
		public static IEnumerable<Type> WithAttribute<T> ( this Assembly assembly ) where T : Attribute {
			return assembly.GetTypes ( ).WithAttribute<T> ( );
		}

		/// <summary>
		/// Gets the types that are assignable from TType.
		/// </summary>
		/// <typeparam name="TType">The type of the type.</typeparam>
		/// <param name="assembly">The assembly.</param>
		/// <returns></returns>
		public static IEnumerable<Type> GetTypesThatAre<TType> ( this Assembly assembly ) where TType : class {
			return assembly.GetTypes ( ).Where ( t => typeof ( TType ).IsAssignableFrom ( t ) && !t.IsAbstract && !t.IsGenericType && !t.IsInterface && !t.IsEquivalentTo ( typeof ( TType ) ) );
		}


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Gets all types that have the specified attribute
		/// </summary>
		/// <typeparam name="T">The attribute.</typeparam>
		/// <param name="assembly">The assembly.</param>
		/// <returns></returns>
		/// <gist id="41883d902a6ed6bd8da4">This sample shows AppDomain, but works the same for assemblies as well.</gist>
		public static IEnumerable<Type> WithAttribute<T>(this Assembly assembly) where T : Attribute {
			return assembly.GetTypes ( ).WithAttribute<T> ( );
		}

		/// <summary>
		/// Gets the types that are assignable from TType.
		/// </summary>
		/// <typeparam name="TType">The type of the type.</typeparam>
		/// <param name="assembly">The assembly.</param>
		/// <returns></returns>
		/// <gist id="6e8707f256ad0398cbff">This sample shows AppDomain, but works the same for assemblies as well.</gist>
		public static IEnumerable<Type> GetTypesThatAre<TType>(this Assembly assembly) where TType : class {
			return assembly.GetTypes ( ).Where ( t => typeof ( TType ).IsAssignableFrom ( t ) && !t.IsAbstract && !t.IsGenericType && !t.IsInterface && !t.IsEquivalentTo ( typeof ( TType ) ) );
		}


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Withes the attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="domain">The domain.</param>
		/// <returns></returns>
		public static IEnumerable<Type> WithAttribute<T> ( this AppDomain domain ) where T : Attribute {
			var types = new List<Type> ( );
			domain.GetAssemblies ( ).ForEach ( a => types.AddRange ( a.WithAttribute<T> ( ) ) );
			return types;
		}

		/// <summary>
		/// Gets the types that are assignable from TType.
		/// </summary>
		/// <typeparam name="TType">The type.</typeparam>
		/// <param name="domain">The domain.</param>
		/// <returns></returns>
		public static IEnumerable<Type> GetTypesThatAre<TType> ( this AppDomain domain ) where TType : class {
			var types = new List<Type> ( );
			domain.GetAssemblies ( ).ForEach ( a => types.AddRange ( a.GetTypesThatAre<TType> ( ) ) );
			return types;
		}
	}
}

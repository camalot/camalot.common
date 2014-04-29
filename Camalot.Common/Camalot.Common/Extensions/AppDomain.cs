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
		/// Gets all types that have the specified attribute
		/// </summary>
		/// <typeparam name="T">The attribute.</typeparam>
		/// <param name="domain">The domain.</param>
		/// <returns></returns>
		/// <gist id="41883d902a6ed6bd8da4"></gist>
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
		/// <gist id="6e8707f256ad0398cbff"></gist>
		public static IEnumerable<Type> GetTypesThatAre<TType> ( this AppDomain domain ) where TType : class {
			var types = new List<Type> ( );
			domain.GetAssemblies ( ).ForEach ( a => types.AddRange ( a.GetTypesThatAre<TType> ( ) ) );
			return types;
		}
	}
}

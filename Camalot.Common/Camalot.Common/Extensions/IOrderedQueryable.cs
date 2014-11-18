using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Extensions {

	public static partial class CamalotCommonExtensions {
		// source: http://stackoverflow.com/a/233505/32502

		/// <summary>
		/// Order by the specified property ascending.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="property">The property.</param>
		/// <returns></returns>
		public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property) {
			return ApplyOrder<T>(source, property, "OrderBy");
		}
		/// <summary>
		/// Order by the specified property descending.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="property">The property.</param>
		/// <returns></returns>
		public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property) {
			return ApplyOrder<T>(source, property, "OrderByDescending");
		}
		/// <summary>
		/// Then order by the specified property ascending.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="property">The property.</param>
		/// <returns></returns>
		public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property) {
			return ApplyOrder<T>(source, property, "ThenBy");
		}
		/// <summary>
		/// Then order by the specified property descending.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="property">The property.</param>
		/// <returns></returns>
		public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property) {
			return ApplyOrder<T>(source, property, "ThenByDescending");
		}
		private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName) {
			string[] props = property.Split('.');
			Type type = typeof(T);
			var arg = Expression.Parameter(type, "x");
			Expression expr = arg;
			foreach(string prop in props) {
				// use reflection (not ComponentModel) to mirror LINQ
				var pi = type.GetProperty(prop);
				expr = Expression.Property(expr, pi);
				type = pi.PropertyType;
			}
			var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
			var lambda = Expression.Lambda(delegateType, expr, arg);

			var result = typeof(Queryable).GetMethods().Single(
							method => method.Name == methodName
											&& method.IsGenericMethodDefinition
											&& method.GetGenericArguments().Length == 2
											&& method.GetParameters().Length == 2)
							.MakeGenericMethod(typeof(T), type)
							.Invoke(null, new object[] { source, lambda });
			return (IOrderedQueryable<T>)result;
		} 
	}
}

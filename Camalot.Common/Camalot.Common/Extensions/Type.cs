﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace Camalot.Common.Extensions {
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Determines whether the specified type is nullable.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>
		///   <c>true</c> if the specified type is nullable; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullable ( this Type type ) {
			return ( type.IsGenericType && type.GetGenericTypeDefinition ( ) == typeof ( Nullable<> ) );
		}

		/// <summary>
		/// Determines whether the specified type is primitive.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static bool IsPrimitive ( this Type type ) {
			return type.IsPrimitive || type.Is<String> ( ) || type == typeof ( Decimal ) || type == typeof ( DateTime ) || type == typeof ( TimeSpan ) || type.Is<Object> ( );
		}

		/// <summary>
		/// Determines whether the specified type an awaitable task.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static bool IsAwaitableTask ( this Type type ) {
			return ( type.IsGenericType && type.GetGenericTypeDefinition ( ).Is<Task> ( ) );
		}

		/// <summary>
		/// Gets the type of the underlying.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static Type GetUnderlyingType ( this Type type ) {
			var lowType = type;
			if ( type.IsAwaitableTask ( ) ) {
				lowType = type.GenericTypeArguments[0];
			}

			return lowType.IsGenericType && lowType.GenericTypeArguments.Length == 1 ?
				lowType.GenericTypeArguments[0] :
				lowType;
		}

		/// <summary>
		/// Determines whether the specified type is a system type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static bool IsSystemType ( this Type type ) {
			return type.FullName.Equals ( "System" ) || type.FullName.StartsWith ( "System." );
		}

		/// <summary>
		/// Determines whether [is] [the specified attribute].
		/// </summary>
		/// <typeparam name="TType">The type of the type.</typeparam>
		/// <param name="t">The type.</param>
		/// <returns></returns>
		public static bool Is<TType> ( this TType t ) /*where TType : class*/ {
			return t.GetType ( ).Is<TType> ( );
		}

		/// <summary>
		/// Determines whether [is] [the specified attribute].
		/// </summary>
		/// <typeparam name="TType">The type of the type.</typeparam>
		/// <param name="t">The type.</param>
		/// <returns></returns>
		public static bool Is<TType> ( this object t ) {
			return t is TType;
		}

		/// <summary>
		/// Determines whether [is] [the specified attribute].
		/// </summary>
		/// <typeparam name="TType">The type of the type.</typeparam>
		/// <param name="t">The attribute.</param>
		/// <returns></returns>
		public static bool Is<TType> ( this Type t ) /*where TType : class*/ {
			return typeof ( TType ).IsAssignableFrom ( t );
		}

		/// <summary>
		/// Gets the custom attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static T GetCustomAttribute<T> ( this Type type ) where T : Attribute {
			var attr = type.GetCustomAttributes<T> ( ).FirstOrDefault ( );
			return attr;
		}


		/// <summary>
		/// Gets the custom attribute value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="Expected">The type of the Expected.</typeparam>
		/// <param name="type">The type.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static Expected GetCustomAttributeValue<T, Expected> ( this Type type, Func<T, Expected> expression ) where T : Attribute {
			var attribute = type.GetCustomAttribute<T> ( );
			if ( attribute == null )
				return default ( Expected );
			return expression ( attribute );
		}

		/// <summary>
		/// Gets types that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="types">The types.</param>
		/// <returns></returns>
		public static IEnumerable<Type> WithAttribute<T> ( this IEnumerable<Type> types ) where T : Attribute {
			return types.Where ( m => !( m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Gets the methods that have the specified return type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static IEnumerable<MethodInfo> GetMethodsOfReturnType<T> ( this Type type ) {
			return GetMethodsOfReturnType<T> ( type, BindingFlags.Instance | BindingFlags.Public );
		}


		/// <summary>
		/// Gets the methods that have the specified return type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type">The type.</param>
		/// <param name="bindingFlags">The binding flags.</param>
		/// <returns></returns>
		public static IEnumerable<MethodInfo> GetMethodsOfReturnType<T> ( this Type type, BindingFlags bindingFlags ) {
			return type.GetMethods ( bindingFlags )
				.Where ( m => m.ReturnType.IsAssignableFrom ( typeof ( T ) ) )
				.Select ( m => m );
		}

		/// <summary>
		/// Determines whether the specified type has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this Type type ) where T : Attribute {
			return type.GetCustomAttribute<T> ( ) != default ( T ) ;
		}

		/// <summary>
		/// Determines whether the specified types has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="types">The types.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<Type> types ) where T : Attribute {
			return types.Any ( m => m.GetCustomAttribute<T> ( ) != default ( T ) );
		}


		/// <summary>
		/// Gets the fully qualified name of the type
		/// </summary>
		/// <param name="t">The type.</param>
		/// <returns></returns>
		public static String QualifiedName ( this Type t ) {
			return "{0}, {1}".With ( t.FullName, t.Assembly.GetName ( ).Name );
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The type.</param>
		/// <returns></returns>
		public static T CreateInstance<T> ( this Type t ) {
			var result = (T)Activator.CreateInstance ( t );
			return result;
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <returns></returns>
		public static object CreateInstance ( this Type t ) {
			var result = Activator.CreateInstance ( t );
			return result;
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The type.</param>
		/// <param name="args">The arguments.</param>
		/// <returns></returns>
		public static T CreateInstance<T> ( this Type t, params object[] args ) {
			var result = (T)Activator.CreateInstance ( t, args );
			return result;
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <param name="args">The arguments.</param>
		/// <returns></returns>
		public static object CreateInstance ( this Type t, params object[] args ) {
			var result = Activator.CreateInstance ( t, args );
			return result;
		}

	}
}

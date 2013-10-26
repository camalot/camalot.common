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
		/// Determines whether the specified type is nullable.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>
		///   <c>true</c> if the specified type is nullable; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullable ( this Type type ) {
			return ( type.IsGenericType && type.GetGenericTypeDefinition ( ) == typeof ( Nullable<> ) );
		}

		public static T GetCustomAttribute<T> ( this Type type ) where T : Attribute {
			var attr = type.GetCustomAttributes<T> ( ).FirstOrDefault ( );
			return attr;
		}

		/// <summary>
		/// Gets member info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="members">The members.</param>
		/// <returns></returns>
		public static IEnumerable<MemberInfo> WithAttribute<T> ( this IEnumerable<MemberInfo> members ) where T : Attribute {
			return members.Where ( m => !( m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Gets field info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="fields">The fields.</param>
		/// <returns></returns>
		public static IEnumerable<FieldInfo> WithAttribute<T> ( this IEnumerable<FieldInfo> fields ) where T : Attribute {
			return fields.Where ( m => !( m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Gets module info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="modules">The modules.</param>
		/// <returns></returns>
		public static IEnumerable<Module> WithAttribute<T> ( this IEnumerable<Module> modules ) where T : Attribute {
			return modules.Where ( m => !( m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Gets method info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="methods">The methods.</param>
		/// <returns></returns>
		public static IEnumerable<MethodInfo> WithAttribute<T> ( this IEnumerable<MethodInfo> methods ) where T : Attribute {
			return methods.Where ( m => !( m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Gets parameter info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="parameters">The parameters.</param>
		/// <returns></returns>
		public static IEnumerable<ParameterInfo> WithAttribute<T> ( this IEnumerable<ParameterInfo> parameters ) where T : Attribute {
			return parameters.Where ( m => !( m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Gets property info that have the specified attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="properties">The properties.</param>
		/// <returns></returns>
		public static IEnumerable<PropertyInfo> WithAttribute<T> ( this IEnumerable<PropertyInfo> properties ) where T : Attribute {
			return properties.Where ( m => !( m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
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
		/// Gets the types that are assignable from TType.
		/// </summary>
		/// <typeparam name="TType">The type of the type.</typeparam>
		/// <param name="assembly">The assembly.</param>
		/// <returns></returns>
		public static IEnumerable<Type> GetTypesThatAre<TType> ( this Assembly assembly ) where TType : class {
			return assembly.GetTypes ( ).Where ( t => typeof ( TType ).IsAssignableFrom ( t ) && !t.IsAbstract && !t.IsGenericType && !t.IsInterface && !t.IsEquivalentTo ( typeof ( TType ) ) );
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
		/// Determines whether the specified member has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="member">The member.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this MemberInfo member ) where T : Attribute {
			return !member.GetCustomAttribute<T> ( ).Equals ( default ( T ) );
		}

		/// <summary>
		/// Determines whether the specified property has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="property">The property.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this PropertyInfo property ) where T : Attribute {
			return !property.GetCustomAttribute<T> ( ).Equals ( default ( T ) );
		}

		/// <summary>
		/// Determines whether the specified type has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this Type type ) where T : Attribute {
			return !type.GetCustomAttribute<T> ( ).Equals ( default ( T ) );
		}

		/// <summary>
		/// Determines whether the specified field has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="field">The field.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this FieldInfo field ) where T : Attribute {
			return !field.GetCustomAttribute<T> ( ).Equals ( default ( T ) );
		}

		/// <summary>
		/// Determines whether the specified method has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="method">The method.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this MethodInfo method ) where T : Attribute {
			return !method.GetCustomAttribute<T> ( ).Equals ( default ( T ) );
		}


		/// <summary>
		/// Determines whether the specified members has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="members">The members.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<MemberInfo> members ) where T : Attribute {
			return !( members.Any ( m => m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Determines whether the specified properties has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="properties">The properties.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<PropertyInfo> properties ) where T : Attribute {
			return !( properties.Any ( m => m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Determines whether the specified types has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="types">The types.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<Type> types ) where T : Attribute {
			return !( types.Any ( m => m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Determines whether the specified fields has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="fields">The fields.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<FieldInfo> fields ) where T : Attribute {
			return !( fields.Any ( m => m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}

		/// <summary>
		/// Determines whether the specified methods has attribute.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="methods">The methods.</param>
		/// <returns></returns>
		public static bool HasAttribute<T> ( this IEnumerable<MethodInfo> methods ) where T : Attribute {
			return !( methods.Any ( m => m.GetCustomAttribute<T> ( ).Equals ( default ( T ) ) ) );
		}


		/// <summary>
		/// Determines whether [is] [the specified attribute].
		/// </summary>
		/// <typeparam name="TType">The type of the type.</typeparam>
		/// <param name="t">The attribute.</param>
		/// <returns></returns>
		public static bool Is<TType> ( this TType t ) where TType : class {
			return t.GetType ( ).Is<TType> ( );
		}

		/// <summary>
		/// Determines whether [is] [the specified attribute].
		/// </summary>
		/// <typeparam name="TType">The type of the type.</typeparam>
		/// <param name="t">The attribute.</param>
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
		public static bool Is<TType> ( this Type t ) where TType : class {
			return typeof ( TType ).IsAssignableFrom ( t );
		}


		/// <summary>
		/// Qualifieds the name.
		/// </summary>
		/// <param name="t">The attribute.</param>
		/// <returns></returns>
		public static String QualifiedName ( this Type t ) {
			return "{0}, {1}".With ( t.FullName, t.Assembly.GetName ( ).Name );
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The attribute.</param>
		/// <returns></returns>
		public static T CreateInstance<T> ( this Type t ) {
			var result = (T)Activator.CreateInstance ( t );
			return result;
		}

		public static object CreateInstance ( this Type t ) {
			var result = Activator.CreateInstance ( t );
			return result;
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t">The attribute.</param>
		/// <param name="args">The arguments.</param>
		/// <returns></returns>
		public static T CreateInstance<T> ( this Type t, params object[] args ) {
			var result = (T)Activator.CreateInstance ( t, args );
			return result;
		}

		public static object CreateInstance ( this Type t, params object[] args ) {
			var result = Activator.CreateInstance ( t, args );
			return result;
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Camalot.Common.Serialization {
	/// <summary>
	/// An Xml Serialization Builder
	/// </summary>
	public sealed class XmlSerializationBuilder {
		/// <summary>
		/// Prevents a default instance of the <see cref="XmlSerializationBuilder"/> class from being created.
		/// </summary>
		private XmlSerializationBuilder ( ) {
			Types = new List<Type>{
				typeof(System.DBNull)
			};
		}

		/// <summary>
		/// Start the building of the Xml Serializer
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static XmlSerializationBuilder Build<T> ( ) {
			return new XmlSerializationBuilder {
				BaseType = typeof ( T )
			};
		}

		/// <summary>
		/// Adds the type to the builder for a supported serialization type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public XmlSerializationBuilder AddType<T> ( ) {
			Types.Add ( typeof ( T ) );
			return this;
		}

		/// <summary>
		/// Sets the default xml namespace.
		/// </summary>
		/// <param name="ns">The namespace to set as the default.</param>
		/// <returns></returns>
		public XmlSerializationBuilder SetDefaultNamespace ( string ns ) {
			DefaultNamespace = ns;
			return this;
		}

		/// <summary>
		/// Creates an instance of an XML Serializer with the options set from the builder.
		/// </summary>
		/// <returns></returns>
		public XmlSerializer Create ( ) {
			return new XmlSerializer ( BaseType, null, this.Types.ToArray ( ),null, this.DefaultNamespace );
		}

		/// <summary>
		/// Gets or sets the default namespace.
		/// </summary>
		/// <value>
		/// The default namespace.
		/// </value>
		private string DefaultNamespace { get; set; }
		/// <summary>
		/// Gets or sets the type of the base.
		/// </summary>
		/// <value>
		/// The type of the base.
		/// </value>
		private Type BaseType { get; set; }
		/// <summary>
		/// Gets or sets the types.
		/// </summary>
		/// <value>
		/// The types.
		/// </value>
		private List<Type> Types { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Camalot.Common.Serialization {
	public sealed class XmlSerializationBuilder {
		private XmlSerializationBuilder ( ) {
			Types = new List<Type>{
				typeof(System.DBNull)
			};
		}

		public static XmlSerializationBuilder Build<T> ( ) {
			return new XmlSerializationBuilder {
				BaseType = typeof ( T )
			};
		}

		public XmlSerializationBuilder AddType<T> ( ) {
			Types.Add ( typeof ( T ) );
			return this;
		}

		public XmlSerializationBuilder SetDefaultNamespace ( string ns ) {
			DefaultNamespace = ns;
			return this;
		}

		public XmlSerializer Create ( ) {
			return new XmlSerializer ( BaseType, null, this.Types.ToArray ( ),null, this.DefaultNamespace );
		}

		private string DefaultNamespace { get; set; }
		private Type BaseType { get; set; }
		private List<Type> Types { get; set; }

	}
}

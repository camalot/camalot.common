using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Camalot.Common.Properties;
using Camalot.Common.Serialization;

namespace Camalot.Common.Extensions {
	/// <summary>
	/// 
	/// </summary>
	public static partial class CamalotCommonExtensions {
		/// <summary>
		/// Creates a configuration section handler.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="section">Section XML node.</param>
		/// <returns>
		/// The created section handler object.
		/// </returns>
		/// <exception cref="System.ArgumentException">Unknown Xml Node Type</exception>
		public static T CreateConfigurationInstanceFromConfigurationNode<T> ( this XmlNode section ) {
			// the node has to be an xml element.
			if ( !section.Is<XmlElement> ( ) ) {
				throw new ArgumentException ( Resources.XmlNode_UnknownNodeType );
			}
			var serializer = XmlSerializationBuilder.Build<T> ( ).Create ( );
			var doc = new XmlDocument ( );
			var ele = (XmlElement)doc.ImportNode ( section, true );
			doc.AppendChild ( doc.CreateXmlDeclaration ( "1.0", "utf-8", string.Empty ) );
			doc.AppendChild ( ele );
			using ( var ms = new MemoryStream ( ) ) {
				doc.Save ( ms );
				ms.Position = 0;
				return (T)serializer.Deserialize ( ms );
			}
		}
	}
}

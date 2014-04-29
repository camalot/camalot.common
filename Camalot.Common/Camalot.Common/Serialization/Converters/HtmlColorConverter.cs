using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Camalot.Common.Extensions;

namespace Camalot.Common.Serialization.Converters {
	/// <summary>
	/// Converts Html Colors when reading / writing JSON.
	/// </summary>
	public class HtmlColorConverter : JsonConverter {
		/// <summary>
		/// Determines whether this instance can convert the specified object type.
		/// </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>
		///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
		/// </returns>
		public override bool CanConvert ( Type objectType ) {
			return objectType == typeof ( Color ) || objectType.Is<string> ( );
		}

		/// <summary>
		/// Reads the JSON representation of the object.
		/// </summary>
		/// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing value of object being read.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <returns>
		/// The object value.
		/// </returns>
		/// <exception cref="System.ArgumentException">Unexpected token parsing color. Expected string, got {0}. {1}.With (
		/// 						reader.TokenType )</exception>
		public override object ReadJson ( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer ) {
			if ( reader.TokenType == JsonToken.Null ) {
				return null;
			}
			if ( reader.TokenType != JsonToken.String ) {
				throw new ArgumentException ( "Unexpected token parsing color. Expected string, got {0}. {1}".With (
						reader.TokenType ) );
			}
			return System.Drawing.ColorTranslator.FromHtml ( (string)reader.Value );
		}

		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <exception cref="System.ArgumentException">Expected token parsing color, expected Color, got {0}..With ( value.GetType ( ).Name )</exception>
		public override void WriteJson ( JsonWriter writer, object value, JsonSerializer serializer ) {
			Color outColor;
			if ( value is Color ) {
				outColor = ( (Color)value );
				var clrName = outColor.ToHtmlHex ( );
				writer.WriteValue ( clrName );
			} else if ( value.Is<IEnumerable<Color>> ( ) ) {
				serializer.Serialize ( writer, ( (IEnumerable<Color>)value ).Select ( c => c.ToHtmlHex ( ) ) );
			} else {
				throw new ArgumentException ( "Expected token parsing color, expected Color, got {0}.".With ( value.GetType ( ).Name ) );
			}
		}
	}
}

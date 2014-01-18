using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Camalot.Common.Extensions;

namespace Camalot.Common.Serialization.Converters {
	public class HtmlColorConverter : JsonConverter {
		public override bool CanConvert ( Type objectType ) {
			return objectType == typeof ( Color ) || objectType.Is<string> ( );
		}

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Camalot.Common.Serialization.Converters {
	public class GuidConverter : JsonConverter {

		public override object ReadJson ( JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer ) {
			if ( reader.TokenType != JsonToken.String ) {
				throw new Exception ( String.Format ( "Unexpected token parsing guid. Expected String, got {0}. {1}",
						reader.TokenType, reader.Value ) );
			}
			return reader.Value != null ? Guid.Parse ( (String)reader.Value ) : Guid.Empty;
		}

		public override void WriteJson ( JsonWriter writer, object value,
		JsonSerializer serializer ) {
			Guid outVal;
			if ( value is Guid ) {
				var guid = (Guid)value;
				outVal = guid;
			} else {
				throw new Exception ( "Expected guid object value." );
			}
			writer.WriteValue ( outVal.ToString ( "N" ) );
		}

		public override bool CanConvert ( Type objectType ) {
			return objectType == typeof ( Guid );
		}
	}
}

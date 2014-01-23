using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Camalot.Common.Serialization.Converters {
	/// <summary>
	/// Converts Guids when Reading/Writing JSON
	/// </summary>
	public class GuidConverter : JsonConverter {

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
		/// <exception cref="Exception"></exception>
		public override object ReadJson ( JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer ) {
			if ( reader.TokenType != JsonToken.String ) {
				throw new Exception ( String.Format ( "Unexpected token parsing guid. Expected String, got {0}. {1}",
						reader.TokenType, reader.Value ) );
			}
			return reader.Value != null ? Guid.Parse ( (String)reader.Value ) : Guid.Empty;
		}

		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <exception cref="Exception">Expected guid object value.</exception>
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

		/// <summary>
		/// Determines whether this instance can convert the specified object type.
		/// </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>
		///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
		/// </returns>
		public override bool CanConvert ( Type objectType ) {
			return objectType == typeof ( Guid );
		}
	}
}

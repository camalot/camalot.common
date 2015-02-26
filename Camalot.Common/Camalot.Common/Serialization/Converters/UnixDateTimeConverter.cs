using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camalot.Common.Serialization.Converters {
	/// <summary>
	/// Converts DateTime to Unix DateTime when reading / writing JSON.
	/// </summary>
	public class UnixDateTimeConverter : DateTimeConverterBase {
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
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer) {
			if(reader.TokenType != JsonToken.Float && reader.TokenType != JsonToken.Integer) {
				throw new Exception(
						String.Format("Unexpected token parsing date. Expected Integer, got {0}. {1}",
						reader.TokenType, reader.Value));
			}

			if(reader.Value != null) {
				try {
					var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
					var val = reader.Value.ToString();
					if(reader.TokenType == JsonToken.Float) {
						if(val.Length >= 13) {
							var ticks = (double)reader.Value;
							date = date.AddMilliseconds(ticks / 1000);
						} else {
							var ticks = (double)reader.Value;
							date = date.AddSeconds(ticks);
						}
					} else {
						if(val.Length >= 13) {
							var ticks = (long)reader.Value;
							date = date.AddMilliseconds(ticks / 1000);
						} else {
							var ticks = (long)reader.Value;
							date = date.AddSeconds(ticks);
						}
					}
					return DateTime.SpecifyKind(date, DateTimeKind.Utc);
				} catch(IndexOutOfRangeException ioore) {
					return existingValue;
				}
			} else {
				return existingValue;
			}
		}
		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		/// <exception cref="Exception">Expected date object value.</exception>
		public override void WriteJson(JsonWriter writer, object value,
		JsonSerializer serializer) {
			long ticks;
			if(value is DateTime) {

				var epoc = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

				var dt = (DateTime)value;
				if(dt.Kind == DateTimeKind.Local) {
					dt = new DateTimeOffset(dt.ToUniversalTime(), new TimeSpan(0)).DateTime;
				}

				var delta = dt - epoc;
				if(delta.TotalSeconds < 0) {
					ticks = 0;
				} else {
					ticks = (long)delta.TotalSeconds;
				}
			} else {
				throw new Exception("Expected date object value.");
			}
			writer.WriteValue(ticks);
		}
	}
}

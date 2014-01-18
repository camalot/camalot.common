using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camalot.Common.Serialization.Converters {
	public class UnixDateTimeConverter : DateTimeConverterBase {
		public override object ReadJson ( JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer ) {
			if ( reader.TokenType != JsonToken.Float && reader.TokenType != JsonToken.Integer ) {
				throw new Exception (
						String.Format ( "Unexpected token parsing date. Expected Integer, got {0}. {1}",
						reader.TokenType, reader.Value ) );
			}


			if ( reader.Value != null ) {
				var date = new DateTime ( 1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc );
				if ( reader.TokenType == JsonToken.Float ) {
					var ticks = (double)reader.Value;
					date = date.AddSeconds ( ticks );
				} else {
					var ticks = (long)reader.Value;
					date = date.AddSeconds ( ticks );
				}
				return DateTime.SpecifyKind ( date, DateTimeKind.Utc );
			} else {
				return null;
			}
		}
		public override void WriteJson ( JsonWriter writer, object value,
		JsonSerializer serializer ) {
			long ticks;
			if ( value is DateTime ) {
				var epoc = new DateTime ( 1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc );

				var dt = (DateTime)value;
				if ( dt.Kind == DateTimeKind.Local ) {
					dt = new DateTimeOffset ( dt.ToUniversalTime ( ), new TimeSpan ( 0 ) ).DateTime;
				}

				var delta = dt - epoc;
				if ( delta.TotalSeconds < 0 ) {
					throw new ArgumentOutOfRangeException (
							String.Format ( "Unix epoch starts January 1st, 1970 - {0}", value.ToString ( ) ) );
				}
				ticks = (long)delta.TotalSeconds;
			} else {
				throw new Exception ( "Expected date object value." );
			}
			writer.WriteValue ( ticks );
		}
	}
}

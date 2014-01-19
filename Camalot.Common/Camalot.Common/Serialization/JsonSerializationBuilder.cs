using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Serialization.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Camalot.Common.Serialization {
	public sealed class JsonSerializationBuilder {
		private JsonSerializationBuilder ( ) {
			InternalSettings = new JsonSerializerSettings {
				Binder = new DefaultSerializationBinder(),
				ConstructorHandling = ConstructorHandling.Default,
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = new List<JsonConverter> {
					new GuidConverter(),
					new UnixDateTimeConverter(),
					new HtmlColorConverter()
				},
				CheckAdditionalContent = true,
				DateFormatHandling = DateFormatHandling.IsoDateFormat,
				DefaultValueHandling = DefaultValueHandling.Include,
				FloatFormatHandling = FloatFormatHandling.DefaultValue,
				FloatParseHandling = FloatParseHandling.Decimal,
				Formatting = Formatting.None,
				MaxDepth = null,
				MissingMemberHandling = MissingMemberHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore,
				ObjectCreationHandling = ObjectCreationHandling.Auto,
				PreserveReferencesHandling = PreserveReferencesHandling.None,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				StringEscapeHandling = StringEscapeHandling.Default,
				TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full,
				TypeNameHandling = TypeNameHandling.None
			};
		}
		private JsonSerializerSettings InternalSettings { get; set; }
		public JsonSerializationBuilder Settings<V> ( Expression<Func<JsonSerializerSettings, V>> xpression, V value ) {
			var memberSelectorExpression = xpression.Body as MemberExpression;
			if ( memberSelectorExpression != null ) {
				var property = memberSelectorExpression.Member as PropertyInfo;
				if ( property != null ) {
					property.SetValue ( InternalSettings, value, null );
				}
			}
			return this;
		}

		public JsonSerializer Create ( ) {
			return JsonSerializer.Create ( InternalSettings );
		}

		public static JsonSerializationBuilder Build ( ) {
			return new JsonSerializationBuilder ( );
		}

	}
}

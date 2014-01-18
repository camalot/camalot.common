using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Serialization.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Camalot.Common.Serialization {
	public sealed class JsonSerializerFactory {
		public static JsonSerializer Create ( ) {
			var s = new JsonSerializer {
				// force camelCase properties
				ContractResolver = new CamelCasePropertyNamesContractResolver ( ),
				ConstructorHandling = ConstructorHandling.Default,
				Formatting = Formatting.None,
				MissingMemberHandling = MissingMemberHandling.Ignore,
				ObjectCreationHandling = ObjectCreationHandling.Auto,
				PreserveReferencesHandling = PreserveReferencesHandling.None,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				TypeNameHandling = TypeNameHandling.None,
				NullValueHandling = NullValueHandling.Ignore,
			};

			s.Converters.Add ( new GuidConverter ( ) );
			s.Converters.Add ( new UnixDateTimeConverter ( ) );
			s.Converters.Add ( new HtmlColorConverter ( ) );
			return s;
		}
	}
}

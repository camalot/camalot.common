using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Camalot.Common.Serialization;
using Newtonsoft.Json;

namespace Camalot.Common.Mvc.Results {
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class JsonpResult<T> : JsonResult<T> {
		/// <summary>
		/// Initializes a new instance of the <see cref="JsonpResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public JsonpResult ( T data ) : this(data,"callback") {
		
		}

		public JsonpResult ( T data, string callback ) : base(data) {
			this.Callback = callback ?? "callback";
		}

		public string Callback { get; set; }

		public override void ExecuteResult ( System.Web.Mvc.ControllerContext context ) {
			var response = context.HttpContext.Response;
			var request = context.HttpContext.Request;
			var callback = this.Callback ?? "callback";
			// check if the callback is a querystring param, or is it the actual callback name.
			if ( request.QueryString.AllKeys.Any ( s => string.Compare ( s, callback, StringComparison.InvariantCultureIgnoreCase ) == 0 ) ) {
				callback = request.QueryString[callback];
			}
			response.ContentType = "application/javascript";
			response.ContentEncoding = Encoding.UTF8;
			using ( var sw = new StreamWriter ( response.OutputStream ) ) {
				using ( var jw = new JsonTextWriter ( sw ) ) {
					jw.WriteRaw ( callback + "(" );
					JsonSerializerFactory.Create ( ).Serialize ( jw, this.Data );
					jw.WriteRaw ( ");" );
				}
			}
		}
	}
}

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
	public class JsonResult<T> : JsonResult {
		public JsonResult ( T data ) {

		}

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <returns>The data.</returns>
		public T Data { get; set; }

		/// <summary>
		/// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
		/// </summary>
		/// <param name="context">The context within which the result is executed.</param>
		public override void ExecuteResult ( ControllerContext context ) {
			var response = context.HttpContext.Response;

			response.ContentType = "application/json";
			response.ContentEncoding = Encoding.UTF8;

			using ( var sw = new StreamWriter ( response.OutputStream ) ) {
				using ( var jw = new JsonTextWriter ( sw ) ) {
					JsonSerializerFactory.Create ( ).Serialize ( jw, this.Data );
				}
			}
		}
	}
}

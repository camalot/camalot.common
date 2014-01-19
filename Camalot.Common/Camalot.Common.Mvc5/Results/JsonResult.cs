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
		/// <summary>
		/// Initializes a new instance of the <see cref="JsonResult{T}"/> class.
		/// </summary>
		public JsonResult ( )
			: this ( default(T) ) {

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="JsonResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public JsonResult ( T data )
			: this ( data, Encoding.UTF8 ) {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="encoding">The encoding.</param>
		public JsonResult ( T data, Encoding encoding ) {
			this.Data = data;
			this.Encoding = encoding;
		}

		/// <summary>
		/// Gets or sets the encoding.
		/// </summary>
		/// <value>
		/// The encoding.
		/// </value>
		public Encoding Encoding { get; set; }
		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <returns>The data.</returns>
		public new T Data { get; set; }

		/// <summary>
		/// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
		/// </summary>
		/// <param name="context">The context within which the result is executed.</param>
		public override void ExecuteResult ( ControllerContext context ) {
			var response = context.HttpContext.Response;

			response.ContentType = "application/json";
			response.ContentEncoding = this.Encoding;

			using ( var sw = new StreamWriter ( response.OutputStream ) ) {
				using ( var jw = new JsonTextWriter ( sw ) ) {
					JsonSerializationBuilder.Build ( ).Create ( ).Serialize ( jw, this.Data );
				}
			}
		}
	}
}

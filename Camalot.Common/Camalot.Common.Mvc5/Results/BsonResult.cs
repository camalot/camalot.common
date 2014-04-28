using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Camalot.Common.Serialization;
using Newtonsoft.Json.Bson;

namespace Camalot.Common.Mvc.Results {
	/// <summary>
	/// Represents a response as BSON.
	/// </summary>
	public class BsonResult : ActionResult {
		/// <summary>
		/// Initializes a new instance of the <see cref="BsonResult"/> class.
		/// </summary>
		public BsonResult()
			: this(null) {

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="BsonResult"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public BsonResult(object data) {
			Data = data;
		}
		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		public object Data { get; set; }

		/// <summary>
		/// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
		/// </summary>
		/// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
		public override void ExecuteResult(ControllerContext context) {
			var response = context.HttpContext.Response;
			response.ContentType = "application/bson";
			using(var jw = new BsonWriter(response.OutputStream)) {
				JsonSerializationBuilder.Build().Create().Serialize(jw, this.Data);
			}
		}

	}

	/// <summary>
	/// Represents a response as BSON.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BsonResult<T> : BsonResult {
		/// <summary>
		/// Initializes a new instance of the <see cref="BsonResult{T}"/> class.
		/// </summary>
		public BsonResult()
			: base(null) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BsonResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public BsonResult(T data) : base(data) { }
		public new T Data { get; set; }
	}
}

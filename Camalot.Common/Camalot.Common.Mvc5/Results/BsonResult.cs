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
	/// 
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

		public override void ExecuteResult(ControllerContext context) {
			var response = context.HttpContext.Response;
			response.ContentType = "application/bson";
			using(var jw = new BsonWriter(response.OutputStream)) {
				JsonSerializationBuilder.Build().Create().Serialize(jw, this.Data);
			}
		}

	}

	public class BsonResult<T> : BsonResult {
		public BsonResult()
			: base(null) {
		}

		public BsonResult(T data) : base(data) { }
		public new T Data { get; set; }
	}
}

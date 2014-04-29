using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Camalot.Common.Serialization;

namespace Camalot.Common.Mvc.Results {
	/// <summary>
	/// Represents a response as XML.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>Content-Type: text/xml</remarks>
	/// <ignore>true</ignore>
	public class XmlResult<T> : XmlResult {
		/// <summary>
		/// Initializes a new instance of the <see cref="XmlResult{T}"/> class.
		/// </summary>
		public XmlResult() : base() {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="XmlResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public XmlResult(T data) : base(data) {
		
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="XmlResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="encoding">The encoding.</param>
		public XmlResult(T data, Encoding encoding) : base(data,encoding) { }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <returns>The data.</returns>
		public new T Data { get; set; }

		/// <summary>
		/// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
		/// </summary>
		/// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
		public override void ExecuteResult(ControllerContext context) {
			var response = context.HttpContext.Response;

			response.ContentType = "text/xml";
			response.ContentEncoding = this.Encoding;

			var ser = XmlSerializationBuilder.Build<T>().Create();
			ser.Serialize(context.HttpContext.Response.OutputStream, this.Data);
		}
	}
	/// <summary>
	/// Represents a response as XML.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <remarks>Content-Type: text/xml</remarks>
	/// <ignore>true</ignore>
	public abstract class XmlResult : ActionResult {
		/// <summary>
		/// Initializes a new instance of the <see cref="XmlResult{T}"/> class.
		/// </summary>
		public XmlResult ( )
			: this ( null, Encoding.UTF8 ) {

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="XmlResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public XmlResult ( object data )
			: this ( data, Encoding.UTF8 ) {

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="XmlResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="encoding">The encoding.</param>
		public XmlResult ( object data, Encoding encoding ) {
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
		public object Data { get; set; }

		/// <summary>
		/// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
		/// </summary>
		/// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
		public abstract override void ExecuteResult(ControllerContext context);
	}
}

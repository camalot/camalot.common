using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Camalot.Common.Serialization;

namespace Camalot.Common.Mvc.Results {
	public class XmlResult<T> : ActionResult {
		public XmlResult ( )
			: this ( default ( T ), Encoding.UTF8 ) {

		}
		public XmlResult ( T data ) {

		}

		public XmlResult ( T data, Encoding encoding ) {
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

		public override void ExecuteResult ( ControllerContext context ) {
			var response = context.HttpContext.Response;

			response.ContentType = "text/xml";
			response.ContentEncoding = this.Encoding;

			var ser = XmlSerializationBuilder.Build<T> ( ).Create ( );
			ser.Serialize ( context.HttpContext.Response.OutputStream, this.Data );
		}
	}
}

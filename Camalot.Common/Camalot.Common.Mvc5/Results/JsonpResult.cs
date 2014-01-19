using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Camalot.Common.Serialization;
using Camalot.Common.Extensions;
using Camalot.Common.Mvc.Extensions;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Camalot.Common.Properties;

namespace Camalot.Common.Mvc.Results {
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class JsonpResult<T> : JsonResult<T> {
		/// <summary>
		/// Initializes a new instance of the <see cref="JsonpResult{T}"/> class.
		/// </summary>
		public JsonpResult ( )
			: this ( default ( T ) ) {

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="JsonpResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public JsonpResult ( T data ) : this ( data, "callback", Encoding.UTF8 ) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonpResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="callback">The callback.</param>
		public JsonpResult ( T data, string callback ) : this ( data, callback, Encoding.UTF8 ) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="JsonpResult{T}"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="callback">The callback.</param>
		/// <param name="encoding">The encoding.</param>
		public JsonpResult ( T data, string callback, Encoding encoding )
			: base ( data, encoding ) {
			this.Callback = callback ?? "callback";
		}


		/// <summary>
		/// Gets or sets the callback.
		/// </summary>
		/// <value>
		/// The callback.
		/// </value>
		private string Callback { get; set; }

		/// <summary>
		/// <summary>
		/// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
		/// </summary>
		/// <param name="context">The context within which the result is executed.</param>
		public override void ExecuteResult ( System.Web.Mvc.ControllerContext context ) {
			var response = context.HttpContext.Response;
			var request = context.HttpContext.Request;
			var callback = this.Callback ?? "callback";
			// check if the callback is a querystring param, or is it the actual callback name.
			if ( request.QueryString.AllKeys.Any ( s => string.Compare ( s, callback, StringComparison.InvariantCultureIgnoreCase ) == 0 ) ) {
				callback = request.QueryString[callback];
			}

			if ( !IsValidJsonPIdentifier ( callback ) ) {
				throw new ArgumentException ( Resources.JsonP_InvalidIdentifier.With ( callback.HtmlEncode ( ) ) );
			}

			response.ContentType = "application/javascript";
			response.ContentEncoding = this.Encoding;
			using ( var sw = new StreamWriter ( response.OutputStream ) ) {
				using ( var jw = new JsonTextWriter ( sw ) ) {
					jw.WriteRaw ( callback.Trim() + "(" );
					JsonSerializationBuilder.Build ( ).Create ( ).Serialize ( jw, this.Data );
					jw.WriteRaw ( ");" );
				}
			}
		}


		private bool IsValidJsonPIdentifier ( string identifier ) {
			if ( string.IsNullOrWhiteSpace ( identifier ) ) {
				return false;
			}
			var reserved = new[] {
				 "abstract", "boolean", "break", "byte", "case", "catch", "char", "class",
					"const", "continue", "debugger", "default", "delete", "do", "double",
					"else", "enum", "export", "extends", "false", "final", "finally", "float",
					"for", "function", "goto", "if", "implements", "import", "in", "instanceof",
					"int", "interface", "long", "native", "new", "null", "package", "private",
					"protected", "public", "return", "short", "static", "super", "switch",
					"synchronized", "this", "throw", "throws", "transient", "true", "try",
					"typeof", "var", "void", "volatile", "while", "with", "let", "yeild"
			 };
			var trimmed = identifier.Trim ( );
			var isMatch = trimmed.IsMatch ( "^[$_a-z][a-z0-9$\\-_\\.]*$", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.Singleline );
			var isReserved = reserved.Any ( x => x == trimmed );
			var isValid = isMatch && !isReserved;
			return isValid;
		}
	}
}

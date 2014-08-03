using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MoreLinq;
using Camalot.Common.Extensions;

namespace Camalot.Common.Mvc.Results {
	/// <summary>
	/// Creates a smart api result that returns data based on the accept header.
	/// </summary>
	/// <ignore>true</ignore>
	public class ApiResult : ActionResult {
		/// <summary>
		/// Initializes a new instance of the <see cref="ApiResult"/> class.
		/// </summary>
		/// <param name="data">The data.</param>
		public ApiResult(object data) {
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

			var accepts = context.HttpContext.Request.AcceptTypes.ToList();
			var knownContentTypes = new string[] { "application/json", "text/xml", "application/bson", "application/javascript" }.ToList();
			var knownHandlers = new Type[] { typeof(JsonResult<object>), typeof(XmlResult), typeof(BsonResult), typeof(JsonpResult<object>)}.ToList();
			var acceptIndexes = new List<KeyValuePair<string, int>>();
			knownContentTypes.ForEach(k => {
				acceptIndexes.Add(new KeyValuePair<string, int>(k, accepts.IndexOf(k)));
			});
			var handlers = acceptIndexes.Where(x => x.Value >= 0);
			if(handlers == default(IEnumerable<KeyValuePair<string,int>> ) || handlers.Count() == 0 ) {
				handlers = new List<KeyValuePair<string,int>> { new KeyValuePair<string,int>( "application/json", 0)};
			}
			var index = knownContentTypes.IndexOf(handlers.MinBy(x => x.Value).Key.Or(knownContentTypes[0]));
			var instance = (ActionResult)knownHandlers[index].CreateInstance(this.Data);
			if(instance != null) {
				instance.ExecuteResult(context);
			} else {
				((ActionResult)typeof(JsonResult<object>).CreateInstance(this.Data)).ExecuteResult(context);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Camalot.Common.Mvc.Results;

namespace Camalot.Common.Mvc.Extensions {
	public static partial class CamalotCommonMvcExtensions {

		/// <summary>
		/// Serializes the data to json and returns a JsonResult
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="controller">The controller.</param>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		public static JsonResult Json<T> ( this Controller controller, T data ) {
			return new JsonResult<T> ( data );
		}

		/// <summary>
		/// Serializes the data to json and returns a JsonPResult
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="controller">The controller.</param>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		public static JsonpResult<T> JsonP<T> ( this Controller controller, T data ) {
			return JsonP<T> ( controller, data, "callback" );
		}

		public static JsonpResult<T> JsonP<T> ( this Controller controller, T data, string callback ) {
			return new JsonpResult<T> ( data, callback );
		}
	}
}

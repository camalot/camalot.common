﻿using System;
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
		public static JsonResult JSON<T> ( this Controller controller, T data ) {
			return new JsonResult<T> ( data );
		}

		/// <summary>
		/// Serializes the data to json and returns a JsonPResult
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="controller">The controller.</param>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		public static JsonpResult<T> JSONP<T> ( this Controller controller, T data ) {
			return JSONP<T> ( controller, data, "callback" );
		}

		/// <summary>
		/// Serializes the data to json and returns a JsonPResult
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="controller">The controller.</param>
		/// <param name="data">The data.</param>
		/// <param name="callback">The callback.</param>
		/// <returns></returns>
		public static JsonpResult<T> JSONP<T> ( this Controller controller, T data, string callback ) {
			return new JsonpResult<T> ( data, callback );
		}

		/// <summary>
		/// Serializes the data to bson and returns a BsonPResult
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="controller">The controller.</param>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		public static BsonResult BSON<T>(this Controller controller, T data) {
			return new BsonResult<T>(data);
		}

		/// <summary>
		/// returns the content as XML
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="controller">The controller.</param>
		/// <param name="data">The data.</param>
		/// <returns></returns>
		public static XmlResult<T> XML<T> ( this Controller controller, T data ) {
			return new XmlResult<T> ( data );
		}
	}
}

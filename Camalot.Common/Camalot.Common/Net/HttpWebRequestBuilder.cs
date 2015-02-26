using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Net {

	/// <summary>
	/// 
	/// </summary>
	public class HttpMethods {
		/// <summary>
		/// The OPTIONS method represents a request for information about the communication options available on the request/response chain identified by the Request-URI. 
		/// This method allows the client to determine the options and/or requirements associated with a resource, or the capabilities of a server, without implying a resource 
		/// action or initiating a resource retrieval.
		/// </summary>
		public const string OPTIONS = "OPTIONS";
		/// <summary>
		/// The GET method means retrieve whatever information (in the form of an entity) is identified by the Request-URI. If the Request-URI refers to a data-producing process, 
		/// it is the produced data which shall be returned as the entity in the response and not the source text of the process, unless that text happens to be the output of 
		/// the process.
		/// </summary>
		public const string GET = "GET";
		/// <summary>
		/// <para>The HEAD method is identical to GET except that the server MUST NOT return a message-body in the response. The meta-information contained in the HTTP headers in 
		/// response to a HEAD request SHOULD be identical to the information sent in response to a GET request. This method can be used for obtaining meta-information about 
		/// the entity implied by the request without transferring the entity-body itself. This method is often used for testing hypertext links for validity, accessibility, 
		/// and recent modification.</para>
		/// <para>The response to a HEAD request MAY be cacheable in the sense that the information contained in the response MAY be used to update a previously cached entity 
		/// from that resource. If the new field values indicate that the cached entity differs from the current entity (as would be indicated by a change in Content-Length, 
		/// Content-MD5, ETag or Last-Modified), then the cache MUST treat the cache entry as stale.</para>
		/// </summary>
		public const string HEAD = "HEAD";
		/// <summary>
		/// The POST method is used to request that the origin server accept the entity enclosed in the request as a new subordinate of the resource identified by the 
		/// Request-URI in the Request-Line.
		/// </summary>
		public const string POST = "POST";
		/// <summary>
		/// The PUT method requests that the enclosed entity be stored under the supplied Request-URI. If the Request-URI refers to an already existing resource, the 
		/// enclosed entity SHOULD be considered as a modified version of the one residing on the origin server. If the Request-URI does not point to an existing resource, 
		/// and that URI is capable of being defined as a new resource by the requesting user agent, the origin server can create the resource with that URI. If a new resource
		/// is created, the origin server MUST inform the user agent via the 201 (Created) response. If an existing resource is modified, either the 200 (OK) or 204 (No Content) 
		/// response codes SHOULD be sent to indicate successful completion of the request. If the resource could not be created or modified with the Request-URI, an appropriate 
		/// error response SHOULD be given that reflects the nature of the problem. The recipient of the entity MUST NOT ignore any Content-* (e.g. Content-Range) headers that it 
		/// does not understand or implement and MUST return a 501 (Not Implemented) response in such cases.
		/// </summary>
		public const string PUT = "PUT";
		/// <summary>
		/// The DELETE method requests that the origin server delete the resource identified by the Request-URI. This method MAY be overridden by human intervention 
		/// (or other means) on the origin server. The client cannot be guaranteed that the operation has been carried out, even if the status code returned from the origin 
		/// server indicates that the action has been completed successfully. However, the server SHOULD NOT indicate success unless, at the time the response is given, it 
		/// intends to delete the resource or move it to an inaccessible location.
		/// </summary>
		public const string DELETE = "DELETE";
		/// <summary>
		/// The TRACE method is used to invoke a remote, application-layer loop- back of the request message. The final recipient of the request SHOULD reflect the message 
		/// received back to the client as the entity-body of a 200 (OK) response. The final recipient is either the origin server or the first proxy or gateway to receive 
		/// a Max-Forwards value of zero (0) in the request (see section 14.31). A TRACE request MUST NOT include an entity.
		/// </summary>
		public const string TRACE = "TRACE";
		/// <summary>
		/// This specification reserves the method name CONNECT for use with a proxy that can dynamically switch to being a tunnel (e.g. SSL tunneling [44]).
		/// </summary>
		public const string CONNECT = "CONNECT";

	}

	/// <summary>
	/// 
	/// </summary>
	public class HttpWebRequestBuilder {
		private HttpWebRequestBuilder(Uri uri) {
			Request = HttpWebRequest.CreateHttp(uri);
		}
		/// <summary>
		/// Starts building the HttpWebRequest.
		/// </summary>
		/// <param name="uri">The URI.</param>
		/// <returns></returns>
		public static HttpWebRequestBuilder Build(Uri uri) {
			return new HttpWebRequestBuilder(uri);
		}

		/// <summary>
		/// Settings the specified setting.
		/// </summary>
		/// <typeparam name="V"></typeparam>
		/// <param name="xpression">The xpression.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public HttpWebRequestBuilder Setting<V>(Expression<Func<HttpWebRequest, V>> xpression, V value) {
			var memberSelectorExpression = xpression.Body as MemberExpression;
			if(memberSelectorExpression != null) {
				var property = memberSelectorExpression.Member as PropertyInfo;
				if(property != null) {
					property.SetValue(Request, value, null);
				}
			}
			return this;
		}

		/// <summary>
		/// Sets a header.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public HttpWebRequestBuilder SetHeader(string name, string value) {
			// if the value is null, it will not set the header. It should be set to [EMPTY] if you want to set it empty.
			if(value == null) {
				return this;
			}
			if(Request.Headers.HasKeys() && Request.Headers.AllKeys.Contains(name)) {
				Request.Headers[name] = value;
			} else {
				Request.Headers.Add(name, value);
			}
			return this;
		}

		/// <summary>
		/// Sets a header.
		/// </summary>
		/// <param name="header">The header.</param>
		/// <returns></returns>
		public HttpWebRequestBuilder SetHeader(string header) {
			var kvp = header.Split(new string[] { ":" }, 2, StringSplitOptions.RemoveEmptyEntries);
			return SetHeader(kvp[0], kvp.Length == 2 ? kvp[1] : string.Empty);
		}

		/// <summary>
		/// Creates the instance of the HttpWebRequest.
		/// </summary>
		/// <returns></returns>
		public HttpWebRequest Create() {
			return Request;
		}
		private HttpWebRequest Request { get; set; }
	}
}

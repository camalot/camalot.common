using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Camalot.Common.Properties;

namespace Camalot.Common.Mvc.Attributes {
	/// <summary>
	/// This checks the request headers for the request verification token if the request is an ajax request.
	/// </summary>
	[AttributeUsage ( AttributeTargets.Class | AttributeTargets.Method )]
	public class AjaxValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter {
		private const string TOKEN_FIELD = "__RequestVerificationToken";
		private static HttpAntiForgeryException CreateValidationException ( string message ) {
			return new HttpAntiForgeryException ( message );
		}

		public void OnAuthorization ( AuthorizationContext filterContext ) {
			if ( filterContext == null ) {
				throw new ArgumentNullException ( "filterContext" );
			}
			var request = filterContext.HttpContext.Request;

			if ( request.IsAjaxRequest ( ) ) {
				var cookie = request.Cookies.Get ( AntiForgeryConfig.CookieName );
				if ( !request.Headers.AllKeys.Contains ( TOKEN_FIELD ) ) {
					throw CreateValidationException ( Resources.AntiForgeryToken_ValidationFailed );
				}
				var tokenValue = request.Headers.GetValues ( TOKEN_FIELD ).FirstOrDefault ( );
				if ( string.IsNullOrWhiteSpace ( tokenValue ) ) {
					throw CreateValidationException ( Resources.AntiForgeryToken_ValidationFailed );
				}
				AntiForgery.Validate ( cookie != null ? cookie.Value : null, tokenValue );
			} else {
				if ( request.HttpMethod == WebRequestMethods.Http.Post ) {
					new ValidateAntiForgeryTokenAttribute ( ).OnAuthorization ( filterContext );
				} else {
					// for forms, only POST is supported.
					throw CreateValidationException ( Resources.AntiForgeryToken_InvalidMethod );
				}
			}
		}
	}
}

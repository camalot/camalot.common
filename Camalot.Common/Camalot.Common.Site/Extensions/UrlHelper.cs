using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Camalot.Common.Extensions;
using Camalot.Common.Mvc.Extensions;

namespace Camalot.Common.Site.Extensions {
	public static partial class CamalotCommonSiteExtensions {
		public static string ParseReferenceUrl(this UrlHelper helper, string url ) {
			if(url.IsMatch("^!:")) {
				return url.Substring(2);
			} else if ( url.IsMatch("^(T|M|P):")) {
				return "#{0}".With(url.Substring(2).Slug());
			} else {
				return url;
			}
		}

		public static string ParseReferenceAsText(this UrlHelper helper, string url) {
			if(url.IsMatch("^(!|T|M|P):")) {
				return "{0}".With(url.Substring(2));
			} else {
				return url;
			}
		}
	}
}
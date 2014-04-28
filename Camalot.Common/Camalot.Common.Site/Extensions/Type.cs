using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Camalot.Common.Extensions;

namespace Camalot.Common.Site.Extensions {
	public  static partial class CamalotCommonSiteExtensions {
		public static bool IsInNamespace(this Type type, string @namespace) {
			return type != null && !string.IsNullOrWhiteSpace(type.Namespace) && type.Namespace.Equals(@namespace, StringComparison.InvariantCulture);
		}

		public static bool IsInChildNamespace(this Type type, string rootNamespace) {
			return type != null && !string.IsNullOrWhiteSpace(type.Namespace) && type.Namespace.StartsWith(rootNamespace, StringComparison.InvariantCulture) && !type.Namespace.Equals(rootNamespace, StringComparison.InvariantCulture);
		}

		public static string ToSafeName(this Type type) {
			if(type.IsGenericType) {
				var gparams = type.GetGenericArguments();
				return "{0}{1}".With(gparams.Count() > 0 ? type.Name.Substring(0,type.Name.IndexOf("`")) : type.Name, gparams.Count() > 0 ? "<{0}>".With(String.Join(", ", gparams.Select(g => g.ToSafeName()))) : "");
			} else {
				return type.Name;
			}
		}
	}
}
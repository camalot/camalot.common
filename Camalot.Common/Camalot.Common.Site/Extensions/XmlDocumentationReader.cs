using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Camalot.Common.Extensions;

namespace Camalot.Common.Site.Extensions {
	public static partial class CamalotCommonSiteExtensions {

		public static string GetXmlDocumentationName(this MethodInfo mi) {
			var mparams = mi.GetParameters();
			var gcount = mi.GetGenericArguments().Count();
			return "M:{0}.{1}{3}({2})".With(
				mi.ReflectedType.XmlDocumentTypeSafeName(),
				mi.Name,
				string.Join(",", mparams.Select(p => p.ParameterType.XmlDocumentParameterSafeName())),
				gcount > 0 ? "``{0}".With(gcount) : "");
		}

		private static string XmlDocumentTypeSafeName(this Type type) {
			return "{1}.{0}".With(type.Name.Replace("`", "``"), type.Namespace);
		}

		private static string XmlDocumentParameterSafeName(this Type type) {
			var gparams = type.GetGenericArguments();
			var s = new StringBuilder();
			s.Append("{");
			for(var i = 0; i < gparams.Length; ++i) {
				s.Append("``{0},".With(i));
			}
			if(s.Length > 1) {
				s.Remove(s.Length - 1, 1);
			}
			s.Append("}");
			if(type.IsGenericType) {
				return "{1}.{0}{2}".With(type.Name.Substring(0, type.Name.LastIndexOf("`")), type.Namespace, s);
			} else {
				return "{1}.{0}".With(type.Name, type.Namespace);
			}
		}

		public static Models.Documentation.Xml.Member GetDocumenation(this XmlDocument doc, MethodInfo mi) {
			var itemName = mi.GetXmlDocumentationName();
			var tdoc = new XmlDocument();

			var node = doc.SelectSingleNode("//member[@name=\"{0}\"]".With(itemName));
			if(node == null) {
				return null;
			}
			var nnode = tdoc.ImportNode(node, true);
			tdoc.AppendChild(nnode);
			var serializer = new XmlSerializer(typeof(Models.Documentation.Xml.Member));
			using(var reader = new StringReader(tdoc.OuterXml)) {
				using(var xreader = XmlReader.Create(reader)) {
					var member = serializer.Deserialize(xreader) as Models.Documentation.Xml.Member;
					if(mi.IsExtension()) {
						if(member.Params.Count > 0) {
							member.Params.RemoveAt(0);
						}
					}
					return member;
				}
			}
		}


	}
}
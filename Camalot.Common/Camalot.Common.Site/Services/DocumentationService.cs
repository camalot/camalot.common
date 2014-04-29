using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Camalot.Common.Site.Models.Documentation;
using MoreLinq;
using Camalot.Common.Extensions;
using Camalot.Common.Site.Extensions;
using System.Xml;
using System.Web.Hosting;
using System.IO;
using System.Security.AccessControl;

namespace Camalot.Common.Site.Services {
	public class DocumentationService {

		public NamespaceModel Build(string assemblyName) {
			var nm = new NamespaceModel {
				Name = assemblyName,
			};
			var exclude = this.GetType().Assembly;

			var xml = LoadXml(assemblyName);

			AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic && a != exclude && a.GetName().Name.Equals(assemblyName, StringComparison.InvariantCultureIgnoreCase)).ForEach(a => {
				a.GetTypes()
					.Where(t => t.IsInChildNamespace(assemblyName))
					.Select(t => t.Namespace)
					.Distinct()
					.ForEach(ns => {
						if(string.IsNullOrWhiteSpace(nm.AssemblyVersion)) {
							nm.AssemblyVersion = a.GetName().Version.ToString();
						}
						nm.Namespaces.Add(ProcessNamespace(ns, xml));
					});
			});
			return nm;
		}

		private XmlDocument LoadXml(string assemblyName) {
			var fn = "{0}.xml".With(assemblyName);
			var dir = HostingEnvironment.MapPath("~/app_data/");
			var file = new FileInfo(Path.Combine(dir, fn));
			if(file.Exists) {
				var doc = new XmlDocument();
				using(var fs = new FileStream(file.FullName, FileMode.Open, FileSystemRights.Read, FileShare.Read, 2048, FileOptions.None)) {
					doc.Load(fs);
				}
				return doc;
			} else {
				throw new FileNotFoundException();
			}
		}


		private NamespaceModel ProcessNamespace(string @namespace, XmlDocument xml) {
			var nm = new NamespaceModel {
				Name = @namespace
			};



			AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).ForEach(a => {
				a.GetTypes().Where(t => t.IsPublic && t.IsClass && t.IsInNamespace(@namespace)).ForEach(t => {
					nm.Classes.Add(ProcessType(t, xml));
				});
			});
			return nm;
		}

		private ClassModel ProcessType(Type type, XmlDocument xml) {
			return new ClassModel {
				Name = type.ToSafeName(),
				Namespace = type.Namespace,
				Assembly = type.Assembly.GetName().Name,
				Description = type.GetCustomAttributeValue<DescriptionAttribute, String>(x => x.Description).Or(""),
				Methods = ProcessMethods(type, xml)
			};
		}

		private IList<MethodModel> ProcessMethods(Type type, XmlDocument xml) {

			return type.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.DeclaredOnly).Where(m =>
				!m.IsConstructor &&
				!m.Name.StartsWith("get_", StringComparison.CurrentCulture) &&
				!m.Name.StartsWith("set_", StringComparison.CurrentCulture)
				).Select(m => new MethodModel {
					Name = m.Name,
					Documentation = xml.GetDocumenation(m),
					GenericParameters = ProcessMethodGenericParameters(m),
					Parameters = ProcessParams(m),
					ExtensionOf = m.ExtensionOf()
				}).ToList();
		}

		private IList<TypeModel> ProcessMethodGenericParameters(System.Reflection.MethodInfo m) {
			if(m.IsGenericMethod) {
				return m.GetGenericArguments().Select(t => new TypeModel { BaseType = t, Name = t.ToSafeName() }).ToList();
			} else {
				return default(IList<TypeModel>);
			}
		}

		private IList<ParameterModel> ProcessParams(System.Reflection.MethodInfo m) {
			return m.GetParameters().Select(p => new ParameterModel {
				Type = new TypeModel { BaseType = p.ParameterType, Name = p.ParameterType.ToSafeName() },
				Name = p.Name,
				IsOut = p.IsOut,
				IsIn = p.IsIn,
				IsOptional = p.IsOptional
			}).ToList();
		}
	}
}
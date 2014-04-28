using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Camalot.Common.Site.Models.Documentation;
using MoreLinq;
using Camalot.Common.Extensions;
using Camalot.Common.Site.Extensions;

namespace Camalot.Common.Site.Services {
	public class DocumentationService {

		public NamespaceModel Build(string assemblyName) {
			var nm = new NamespaceModel {
				Name = assemblyName,
			};
			var exclude = this.GetType().Assembly;
			AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic && a != exclude && a.GetName().Name.Equals(assemblyName, StringComparison.InvariantCultureIgnoreCase)).ForEach(a => {
				a.GetTypes()
					.Where(t => t.IsInChildNamespace(assemblyName))
					.Select(t => t.Namespace)
					.Distinct()
					.ForEach(ns => {
						nm.Namespaces.Add(ProcessNamespace(ns));
					});
			});
			return nm;
		}


		private NamespaceModel ProcessNamespace(string @namespace) {
			var nm = new NamespaceModel {
				Name = @namespace
			};
			AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).ForEach(a => {
				a.GetTypes().Where(t => t.IsPublic && t.IsClass && t.IsInNamespace(@namespace)).ForEach(t => {
					nm.Classes.Add(ProcessType(t));
				});
			});
			return nm;
		}

		private ClassModel ProcessType(Type type) {
			return new ClassModel {
				Name = type.ToSafeName(),
				Namespace = type.Namespace,
				Assembly = type.Assembly.GetName().Name,
				Description = type.GetCustomAttributeValue<DescriptionAttribute, String>(x => x.Description).Or(""),
				Methods = ProcessMethods(type)
			};
		}

		private IList<MethodModel> ProcessMethods(Type type) {
			return type.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.DeclaredOnly).Where(m =>
				!m.IsConstructor &&
				!m.Name.StartsWith("get_", StringComparison.CurrentCulture) &&
				!m.Name.StartsWith("set_", StringComparison.CurrentCulture)
				).Select(m => new MethodModel {
					Name = m.Name,
					GenericParameters = ProcessMethodGenericParameters(m),
					Parameters = ProcessParams(m)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Camalot.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Camalot.Common.UnitTest.InExtensions.InMethodInfo {
	[TestClass]
	public class ForExtensionOf {
		[TestMethod]
		public void WhenMethodIsExtensionOfType_MustReturnType() {
			var method = typeof(CamalotCommonExtensions).GetMethods().First(x => x.Name == "ForEach");
			Assert.IsNotNull(method);
			Assert.IsNotNull(method.ExtensionOf());
		}


		[TestMethod]
		public void WhenMethodIsNotExtension_MustReturnNull() {
			var method = typeof(MethodInfo).GetMethod("GetBaseDefinition");
			Assert.IsNotNull(method);
			Assert.IsNull(method.ExtensionOf());
		}
	}
}

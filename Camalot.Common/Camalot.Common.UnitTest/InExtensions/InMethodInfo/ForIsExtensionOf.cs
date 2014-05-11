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
	public class ForIsExtensionOf {
		[TestMethod]
		public void WhenMethodIsExtensionOfType_MustReturnTrue() {
			var method = typeof(CamalotCommonExtensions).GetMethod("ForEach");
			Assert.IsNotNull(method);
			Assert.IsTrue(method.IsExtensionOf<Match>());
		}

		[TestMethod]
		public void WhenMethodIsNotExtensionOfType_MustReturnFalse() {
			var method = typeof(CamalotCommonExtensions).GetMethod("ForEach");
			Assert.IsNotNull(method);
			Assert.IsFalse(method.IsExtensionOf<DateTime>());
		}

		[TestMethod]
		public void WhenMethodIsNotExtension_MustReturnFalse() {
			var method = typeof(MethodInfo).GetMethod("GetBaseDefinition");
			Assert.IsNotNull(method);
			Assert.IsFalse(method.IsExtensionOf<MethodInfo>());
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InMethodInfo {
	[TestClass]
	public class ForIsExtension {
		[TestMethod]
		public void WhenMethodIsExtension_MustReturnTrue() {
			var method = typeof(CamalotCommonExtensions).GetMethod("IsExtension");
			Assert.IsNotNull(method);
			Assert.IsTrue(method.IsExtension());
		}
	}
}

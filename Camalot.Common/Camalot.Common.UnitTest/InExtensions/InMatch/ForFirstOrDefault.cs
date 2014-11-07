using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using System.Text.RegularExpressions;

namespace Camalot.Common.UnitTest.InExtensions.InMatch {
	[TestClass]
	public class ForFirstOrDefault {
		[TestMethod]
		public void WhenMatchFindsOneOrMore_MustReturnFirst() {
			var input = "String1 String2 String3";
			var result = input.Match("String\\d").FirstOrDefault();
			Assert.AreEqual("String1", result.Value);
		}

		[TestMethod]
		public void WhenMatchFindsNone_MustReturnDefault() {
			var input = "String1 String2 String3";
			var result = input.Match("Number\\d").FirstOrDefault();
			Assert.AreEqual(default(Match), result);
		}
	}
}

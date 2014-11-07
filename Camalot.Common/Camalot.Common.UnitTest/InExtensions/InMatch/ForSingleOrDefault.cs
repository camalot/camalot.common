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
	public class ForSingleOrDefault {
		[TestMethod]
		public void WhenMatchFindsMoreThanOne_MustThrowException() {
			try {
				var input = "String1 String2 String3";
				var result = input.Match("String\\d").SingleOrDefault();
			} catch(InvalidOperationException) {
				return;
			}
			Assert.Fail("First did not throw expected exception.");
		}
		[TestMethod]
		public void WhenMatchFindsOne_MustReturnSingle() {
			var input = "Number1 String2 Number3";
			var result = input.Match("String\\d").SingleOrDefault();
			Assert.AreEqual("String2", result.Value);
		}


		[TestMethod]
		public void WhenMatchFindsNone_MustReturnDefault() {
			var input = "String1 String2 String3";
			var result = input.Match("Number\\d").SingleOrDefault();
			Assert.AreEqual(default(Match), result);
		}
	}
}

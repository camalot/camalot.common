using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InMatch {
	[TestClass]
	public class ForFirst {
		[TestMethod]
		public void WhenMatchFindsOneOrMore_MustReturnFirst() {
			var input = "String1 String2 String3";
			var  result = input.Match("String\\d").First();
			Assert.AreEqual("String1", result.Value);
		}

		[TestMethod]
		public void WhenMatchFindsNone_MustThrowException() {
			try {
				var input = "Number1 Number2 Number3";
				var result = input.Match("String\\d").First();
			} catch(InvalidOperationException) {
				return;
			}
			Assert.Fail("First did not throw expected exception.");
		}
	}
}

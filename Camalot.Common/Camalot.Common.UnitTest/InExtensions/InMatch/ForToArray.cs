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
	public class ForToArray {
		[TestMethod]
		public void WhenMatchIsNotSuccess_MustReturnEmptyArray() {
			var input = "Number1 Number2 Number3";
			var result = input.Match("String\\d").ToArray();
			Assert.IsTrue(result != null);
			Assert.IsInstanceOfType(result, typeof(Match[]));
			Assert.IsTrue(result.Length == 0);
		}

		[TestMethod]
		public void WhenMatchIsSuccess_MustReturnArray() {
			var input = "Number1 Number2 Number3";
			var result = input.Match("Number\\d").ToArray();
			Assert.IsTrue(result != null);
			Assert.IsInstanceOfType(result, typeof(Match[]));
			Assert.IsTrue(result.Length == input.Split(' ').Length);
		}

	}
}

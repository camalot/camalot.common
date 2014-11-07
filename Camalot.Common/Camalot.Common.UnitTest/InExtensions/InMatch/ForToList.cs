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
	public class ForToList {
		[TestMethod]
		public void WhenMatchIsNotSuccess_MustReturnEmptyList() {
			var input = "Number1 Number2 Number3";
			var result = input.Match("String\\d").ToList();
			Assert.IsTrue(result != null);
			Assert.IsInstanceOfType(result, typeof(List<Match>));
			Assert.IsTrue(result.Count == 0);
		}

		[TestMethod]
		public void WhenMatchIsSuccess_MustReturnList() {
			var input = "Number1 Number2 Number3";
			var result = input.Match("Number\\d").ToList();
			Assert.IsTrue(result != null);
			Assert.IsInstanceOfType(result, typeof(List<Match>));
			Assert.IsTrue(result.Count == input.Split(' ').Count());
		}

	}
}

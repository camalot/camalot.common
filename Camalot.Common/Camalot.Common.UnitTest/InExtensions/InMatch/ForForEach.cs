using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InMatch {
	[TestClass]
	public class ForForEach {
		[TestMethod]
		public void WhenThereIsNoMatch_MustDoNothing() {
			var input = "Input String";
			input.Match(@"^no\smatch$").ForEach(m => {
				Assert.Fail("Expected this to Never Happen.");
			});
		}
		[TestMethod]
		public void WhenThereIsAMatch_MustPerformAction() {
			var input = "Input String";
			int count = 0;
			input.Match(@"^Input.*String$").ForEach(m => {
				count++;
			});
			Assert.AreEqual<int>(1, count);
		}
		[TestMethod]
		public void WhenThereAreMatches_MustPerformActions() {
			var input = "String String";
			int count = 0;
			input.Match(@"String").ForEach(m => {
				count++;
			});
			Assert.AreEqual<int>(2, count);
		}
	}
}

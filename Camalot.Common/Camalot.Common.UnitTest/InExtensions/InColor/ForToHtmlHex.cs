using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using System.Drawing;

namespace Camalot.Common.UnitTest.InExtensions.InColor {
	[TestClass]
	public class ForToHtmlHex {
		[TestMethod]
		public void WhenColorIsValid_ReturnHtmlColorString() {
			var color = Color.White;
			Assert.AreEqual<string>("#FFFFFF", color.ToHtmlHex());
			color = Color.FromArgb(0, 255, 255, 255);
			Assert.AreEqual<string>("#FFFFFF", color.ToHtmlHex());
		}

		[TestMethod]
		public void WhenHtmlColorIsNotValid_ThrowException() {
			try {
				var html = "#fffffff".ToColor();
			} catch(ArgumentException) {
				return;
			}
			Assert.Fail("Expected exception did not occur.");
		}

		[TestMethod]
		public void WhenHtmlColorIsValid_ReturnColor() {
			var color = "#ffffff".ToColor();
			Assert.AreEqual<int>(Color.White.ToArgb(), color.ToArgb());
		}
	}
}

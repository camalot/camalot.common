using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using Ploeh.AutoFixture;

namespace Camalot.Common.UnitTest.InExtensions.InByte {
	[TestClass]
	public class ForToBase64String {
		[TestMethod]
		public void WhenByteArrayIsNotNull_MustReturnString() {
			var tsource = "source string";
			var b64Source = "cwBvAHUAcgBjAGUAIABzAHQAcgBpAG4AZwA=";
			var b64 = tsource.GetBytes(Encoding.Unicode).ToBase64String();
			Assert.AreEqual<string>(b64Source, b64);
			Assert.AreEqual<string>(b64Source, b64);
		}

		[TestMethod]
		public void WhenAsciiByteArrayIsNotNull_MustReturnString() {
			var tsource = "source string";
			var b64Source = "c291cmNlIHN0cmluZw==";
			var b64 = tsource.GetBytes(Encoding.ASCII).ToBase64String();
			Assert.AreEqual<string>(b64Source, b64);
		}

		[TestMethod]
		public void WhenByteArrayIsNull_MustThrowException() {
			try {
				var bytes = default(byte[]);
				var result = bytes.ToBase64String();
			} catch(ArgumentNullException ane) {
				Assert.AreEqual<string>("inArray", ane.ParamName);
				return;
			}
			Assert.Fail("Expected exception");
		}
	}
}

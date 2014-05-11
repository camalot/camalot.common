using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using Camalot.Common.Mime;

namespace Camalot.Common.UnitTest.InExtensions.InFileInfo {
	[TestClass]
	public class ForGetMimeType {
		[TestMethod]
		public void WhenFileDoesNotExist_MustReturnValidMimeTypeForExtension() {
			var fileInfo = new FileInfo(@"c:\file.txt");
			var mt = fileInfo.GetMimeType();
			Assert.AreEqual<string>("text/plain", mt.MediaType);
			Assert.AreEqual<string>("txt", mt.Extensions.First());
		}

		[TestMethod]
		public void WhenFileDoesNotExist_MustReturnValidMimeTypeForExtensionFromApache() {
			var fileInfo = new FileInfo(@"c:\file.txt");
			var mt = fileInfo.GetMimeType<ApacheFileTypeMap>();
			Assert.AreEqual<string>("text/plain", mt.MediaType);
			Assert.AreEqual<string>("txt", mt.Extensions.First());
		}

		[TestMethod]
		public void WhenFileDoesNotExist_MustReturnValidMimeTypeForExtensionFromRegistry() {
			var fileInfo = new FileInfo(@"c:\file.txt");
			var mt = fileInfo.GetMimeType<RegistryFileTypeMap>();
			Assert.AreEqual<string>("text/plain", mt.MediaType);
			Assert.AreEqual<string>("txt", mt.Extensions.First());
		}
	}
}

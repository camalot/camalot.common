﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InMatch {
	[TestClass]
	public class ForSingle {
		[TestMethod]
		public void WhenMatchFindsOne_MustReturnSingle() {
			var input = "Number1 String2 Number3";
			var result = input.Match("String\\d").Single();
			Assert.AreEqual("String2", result.Value);
		}

		[TestMethod]
		public void WhenMatchFindsNone_MustThrowException() {
			try {
				var input = "Number1 Number2 Number3";
				var result = input.Match("String\\d").Single();
			} catch(InvalidOperationException) {
				return;
			}
			Assert.Fail("Single did not throw expected exception.");
		}

		[TestMethod]
		public void WhenMatchFindsMoreThanOne_MustThrowException() {
			try {
			var input = "String1 String2 String3";
			var result = input.Match("String\\d{1,}").Single();
			} catch(InvalidOperationException) {
				return;
			}
			Assert.Fail("Single did not throw expected exception.");
		}
	}
}

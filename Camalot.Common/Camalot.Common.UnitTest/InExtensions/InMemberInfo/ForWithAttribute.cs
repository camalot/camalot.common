using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InMemberInfo {
	[TestClass]
	public class ForWithAttribute {

		public class TestClass {
			[System.ComponentModel.Description("My very own field")]
			public int SomeField = default(int);
			[System.ComponentModel.Description("My very own field")]
			public string AnotherField = default(string);
			public string ThirdField = default(string);
		}

		public class NoFieldsTestClass {

		}

		[TestMethod]
		public void WhenTypeHasFieldInfo_MustReturnCollectionOfFieldInfos() {
			var members = typeof(TestClass).GetMembers();
			var result = members.WithAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 2);
		}

		[TestMethod]
		public void WhenTypeDoesNotHaveFieldInfo_MustReturnCollectionOfFieldInfos() {
			var members = typeof(NoFieldsTestClass).GetMembers();
			var result = members.WithAttribute<System.ComponentModel.DescriptionAttribute>();
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count() == 0);
		}
	}
}

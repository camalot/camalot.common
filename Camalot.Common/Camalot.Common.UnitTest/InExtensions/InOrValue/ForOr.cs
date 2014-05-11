using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;
namespace Camalot.Common.UnitTest.InExtensions.InOrValue {
	[TestClass]
	public class ForOr {
		[TestMethod]
		public void WhenObjectIsNotNull_MustReturnObject() {
			var fixture = new Fixture();
			var obj = fixture.Create<Object>();
			Assert.IsNotNull(obj);
			var result = obj.Or(new { foo = "bar" });
			Assert.AreEqual(obj, result);
		}

		[TestMethod]
		public void WhenObjectIsNull_MustReturnAlternateObject() {
			var fixture = new Fixture();
			var obj = default(object);
			Assert.IsNull(obj);
			var result = obj.Or(new { foo = "bar" });
			Assert.AreNotEqual(obj, result);
		}


		[TestMethod]
		public void WhenGuidIsNotEmpty_MustReturnGuid() {
			var fixture = new Fixture();
			var guid1 = fixture.Create<Guid>();
			var guid2 = fixture.Create<Guid>();
			var result = guid1.Or(guid2);
			Assert.AreEqual(guid1, result);
			Assert.AreNotEqual(guid1, guid2);
		}

		[TestMethod]
		public void WhenGuidIsEmpty_MustReturnAlternateGuid() {
			var fixture = new Fixture();
			var guid1 = default(Guid);
			var guid2 = fixture.Create<Guid>();
			var result = guid1.Or(guid2);
			Assert.AreEqual(guid2, result);
			Assert.AreNotEqual(guid1, guid2);
		}

		[TestMethod]
		public void WhenNullableGuidIsNotNull_MustReturnGuid() {
			var fixture = new Fixture();
			var guid1 = fixture.Create<Guid?>();
			var guid2 = fixture.Create<Guid>();
			var result = guid1.Or(guid2);
			Assert.IsNotNull(guid1);
			Assert.AreEqual(guid1, result);
			Assert.AreNotEqual(guid1, guid2);
		}

		[TestMethod]
		public void WhenNullableGuidIsNull_MustReturnAlternateGuid() {
			var fixture = new Fixture();
			var guid1 = default(Guid?);
			var guid2 = fixture.Create<Guid>();
			var result = guid1.Or(guid2);
			Assert.IsNull(guid1);
			Assert.AreEqual(guid2, result);
			Assert.AreNotEqual(guid1, guid2);
		}

		[TestMethod]
		public void WhenStringIsNotNull_MustReturnString() {
			var fixture = new Fixture();
			var string1 = fixture.Create<string>();
			var string2 = fixture.Create<string>();
			var result = string1.Or(string2);
			Assert.IsNotNull(string1);
			Assert.AreEqual(string1, result);
			Assert.AreNotEqual(string1, string2);
		}

		[TestMethod]
		public void WhenStringIsNull_MustReturnAlternateString() {
			var fixture = new Fixture();
			var string1 = default(string);
			var string2 = fixture.Create<string>();
			var result = string1.Or(string2);
			Assert.IsNull(string1);
			Assert.AreEqual(string2, result);
			Assert.AreNotEqual(string1, string2);
		}

		[TestMethod]
		public void WhenTypeIsNotNull_MustReturnType() {
			var type1 = typeof(string);
			var type2 = typeof(int);
			var result = type1.Or(type2);
			Assert.IsNotNull(type1);
			Assert.AreEqual(type1, result);
			Assert.AreNotEqual(type1, type2);
		}

		[TestMethod]
		public void WhenTypeIsNull_MustReturnAlternateType() {
			var type1 = default(Type);
			var type2 = typeof(int);
			var result = type1.Or(type2);
			Assert.IsNull(type1);
			Assert.AreEqual(type2, result);
			Assert.AreNotEqual(type1, type2);
		}

		[TestMethod]
		public void WhenStringBuilderIsNotNull_MustReturnStringBuilder() {
			var fixture = new Fixture();
			var sb1 = fixture.Create<StringBuilder>();
			var sb2 = fixture.Create<StringBuilder>();
			var result = sb1.Or(sb2);
			Assert.IsNotNull(sb1);
			Assert.AreEqual(sb1, result);
			Assert.AreNotEqual(sb1, sb2);
		}

		[TestMethod]
		public void WhenStringBuilderIsNull_MustReturnAlternateStringBuilder() {
			var fixture = new Fixture();
			var sb1 = default(StringBuilder);
			var sb2 = fixture.Create<StringBuilder>();
			var result = sb1.Or(sb2);
			Assert.IsNull(sb1);
			Assert.AreEqual(sb2, result);
			Assert.AreNotEqual(sb1, sb2);
		}
	}
}

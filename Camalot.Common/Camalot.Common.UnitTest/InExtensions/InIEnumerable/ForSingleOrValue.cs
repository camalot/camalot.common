using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Camalot.Common.UnitTest.InExtensions.InIEnumerable {
	[TestClass]
	public class ForSingleOrValue {
		[TestMethod]
		public void WhenCollectionIsEmpty_MustReturnValue() {
			var list = Enumerable.Empty<Guid>();
			var fixture = new Fixture();

			Assert.IsNotNull(list);
			var guid = Guid.NewGuid();
			var result = list.SingleOrValue(guid);
			Assert.AreEqual(guid, result);
		}

		[TestMethod]
		public void WhenCollectionIsEmptyAfterTest_MustReturnValue() {
			var list = Enumerable.Empty<Guid>();
			var fixture = new Fixture();

			Assert.IsNotNull(list);
			var guid = Guid.NewGuid();
			Assert.AreNotEqual<Guid>(Guid.Empty, guid);
			var result = list.SingleOrValue(x => x == Guid.Empty, guid);
			Assert.AreEqual(guid, result);
		}

		[TestMethod]
		public void WhenCollectionIsNotEmptyAfterTestAndHasMoreThanOne_MustReturnValue() {
			var fixture = new Fixture();
			var list = fixture.CreateMany<Guid>().ToList();

			Assert.IsNotNull(list);
			var guid = Guid.NewGuid();
			Assert.AreNotEqual<Guid>(Guid.Empty, guid);
			var result = list.SingleOrValue(x => x == Guid.Empty, guid);
			Assert.AreEqual(guid, result);
		}

		[TestMethod]
		public void WhenCollectionIsNotEmptyAndHasOnlyOne_MustReturnSingle() {
			var fixture = new Fixture();
			var list = fixture.CreateMany<Guid>().Take(1).ToList();
			Assert.IsNotNull(list);
			var firstItem = list[0];
			var guid = Guid.NewGuid();
			Assert.AreNotEqual<Guid>(Guid.Empty, guid);
			var result = list.SingleOrValue(guid);
			Assert.AreNotEqual(guid, result);
			Assert.AreEqual(firstItem, result);
		}

		[TestMethod]
		public void WhenCollectionIsNotEmptyAfterTestAndHasOnlyOne_MustReturnSingle() {
			var fixture = new Fixture();
			var list = fixture.CreateMany<Guid>().ToList();
			list.Add(Guid.Empty);
			Assert.IsNotNull(list);
			var firstItem = list[0];
			var guid = Guid.NewGuid();
			Assert.AreNotEqual<Guid>(Guid.Empty, guid);
			var result = list.SingleOrValue(x => x == firstItem, guid);
			Assert.AreNotEqual(guid, result);
			Assert.AreEqual(firstItem, result);
		}
	}
}

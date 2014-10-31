using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InIEnumerable {
	[TestClass]
	public class ForFirstOrValue {
		[TestMethod]
		public void WhenCollectionIsEmpty_MustReturnValue() {
			var list = Enumerable.Empty<Guid>();
			var fixture = new Fixture();
		
			Assert.IsNotNull(list);
			var guid = Guid.NewGuid();
			var result = list.FirstOrValue(guid);
			Assert.AreEqual(guid, result);
		}

		[TestMethod]
		public void WhenCollectionIsEmptyAfterTest_MustReturnValue() {
			var list = Enumerable.Empty<Guid>();
			var fixture = new Fixture();

			Assert.IsNotNull(list);
			var guid = Guid.NewGuid();
			Assert.AreNotEqual<Guid>(Guid.Empty, guid);
			var result = list.FirstOrValue(x => x == Guid.Empty, guid);
			Assert.AreEqual(guid, result);
		}

		[TestMethod]
		public void WhenCollectionIsNotEmpty_MustReturnFirst() {
			var fixture = new Fixture();
			var list = fixture.CreateMany<Guid>().ToList();
			Assert.IsNotNull(list);
			var firstItem = list[0];
			var guid = Guid.NewGuid();
			Assert.AreNotEqual<Guid>(Guid.Empty, guid);
			var result = list.FirstOrValue(guid);
			Assert.AreNotEqual(guid, result);
			Assert.AreEqual(firstItem, result);
		}

		[TestMethod]
		public void WhenCollectionIsNotEmptyAfterTest_MustReturnFirst() {
			var fixture = new Fixture();
			var list = fixture.CreateMany<Guid>().ToList();
			list.Add(Guid.Empty);
			Assert.IsNotNull(list);
			var firstItem = list[0];
			var guid = Guid.NewGuid();
			Assert.AreNotEqual<Guid>(Guid.Empty, guid);
			var result = list.FirstOrValue(x => x != Guid.Empty, guid);
			Assert.AreNotEqual(guid, result);
			Assert.AreEqual(firstItem, result);
		}
	}
}

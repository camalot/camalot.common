using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InInList {
	[TestClass]
	public class ForIn {
		[TestMethod]
		public void WhenSourceExistsInList_MustReturnTrue() {
			var fixture = new Fixture();
			var list = fixture.CreateMany<Guid>().ToList();
			Assert.IsNotNull(list);
			var item = list[0];
			Assert.IsTrue(item.In(list));
		}

		[TestMethod]
		public void WhenSourceIsEmpty_MustThrowException() {
			var fixture = new Fixture();
			var list = fixture.CreateMany<Guid>().ToList();
			Assert.IsNotNull(list);
			var item = Guid.Empty;
			try {
				item.In(list);
			} catch(ArgumentException) {
				Assert.IsTrue(item == Guid.Empty);
				return;
			}
			Assert.Fail("Required null object did not result in exception");
		}

		[TestMethod]
		public void WhenSourceNotExistsInList_MustReturnFalse() {
			var fixture = new Fixture();
			var list = fixture.CreateMany<Guid>().ToList();
			Assert.IsNotNull(list);
			var item = fixture.Create<Guid>();
			Assert.IsFalse(item.In(list.ToArray()));
		}
	}
}

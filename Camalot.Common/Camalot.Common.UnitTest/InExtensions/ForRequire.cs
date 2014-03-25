using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Camalot.Common.Extensions;
using Moq;
namespace Camalot.Common.UnitTest.InExtensions {
	[TestClass]
	public class ForRequire {

		public void WhenObjectNotNull_MustNotThrowException ( ) {
			var fixture = new Fixture ( );
			var obj = fixture.Build<object>().Create<object>();
			
			
		}

	}
}

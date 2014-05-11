using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;
using System.Reflection;

namespace Camalot.Common.UnitTest.InExtensions.InType {
	[TestClass]
	public class ForIsPrimitive {
		[TestMethod]
		public void WhenTypeIsFloat_MustReturnTrue() {
			var type = typeof(float);
			var result = type.IsPrimitive();
			Assert.IsNotNull(type);
			Assert.IsTrue(result);

		}

		[TestMethod]
		public void WhenTypeIsDouble_MustReturnTrue() {
			var type = typeof(double);
			var result = type.IsPrimitive();
			Assert.IsNotNull(type);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenTypeIsDecimal_MustReturnTrue() {
			var type = typeof(decimal);
			var result = type.IsPrimitive();
			Assert.IsNotNull(type);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenTypeIsDateTime_MustReturnTrue() {
			var type = typeof(DateTime);
			var result = type.IsPrimitive();
			Assert.IsNotNull(type);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenTypeIsTimeSpan_MustReturnTrue() {
			var type = typeof(TimeSpan);
			var result = type.IsPrimitive();
			Assert.IsNotNull(type);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenTypeIsString_MustReturnTrue() {
			var type = typeof(string);
			var result = type.IsPrimitive();
			Assert.IsNotNull(type);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenTypeIsObject_MustReturnTrue() {
			var type = typeof(object);
			var result = type.IsPrimitive();
			Assert.IsNotNull(type);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void WhenTypeIsNotPrimitive_MustReturnFalse() {
			var type = typeof(MethodInfo);
			var result = type.IsPrimitive();
			Assert.IsNotNull(type);
			Assert.IsFalse(result);
		}
	}
}

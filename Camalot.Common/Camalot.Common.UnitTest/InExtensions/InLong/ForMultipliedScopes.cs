using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camalot.Common.Extensions;

namespace Camalot.Common.UnitTest.InExtensions.InLong {
	[TestClass]
	public class ForMultipliedScopes {
		/* Kilo */
		[TestMethod]
		public void WhenLongValue_ReturnKMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(10, 3), v.K());
		}

		[TestMethod]
		public void WhenULongValue_ReturnKMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(10, 3), v.K());
		}

		[TestMethod]
		public void WhenLongValue_ReturnKiloMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(2, 10), v.Kilo());
		}

		[TestMethod]
		public void WhenULongValue_ReturnKiloMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(2, 10), v.Kilo());
		}

		/* Mega */
		[TestMethod]
		public void WhenLongValue_ReturnMMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(10, 6), v.M());
		}

		[TestMethod]
		public void WhenULongValue_ReturnMMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(10, 6), v.M());
		}

		[TestMethod]
		public void WhenLongValue_ReturnMegaMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(2, 20), v.Mega());
		}

		[TestMethod]
		public void WhenULongValue_ReturnMegaMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(2, 20), v.Mega());
		}

		/* Giga */
		[TestMethod]
		public void WhenLongValue_ReturnBMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(10, 9), v.B());
		}

		[TestMethod]
		public void WhenULongValue_ReturnBMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(10, 9), v.B());
		}

		[TestMethod]
		public void WhenLongValue_ReturnGigaMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(2, 30), v.Giga());
		}

		[TestMethod]
		public void WhenULongValue_ReturnGigaMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(2, 30), v.Giga());
		}

		/* Tera */
		[TestMethod]
		public void WhenLongValue_ReturnTMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(10, 12), v.T());
		}

		[TestMethod]
		public void WhenULongValue_ReturnTMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(10, 12), v.T());
		}

		[TestMethod]
		public void WhenLongValue_ReturnTeraMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(2, 40), v.Tera());
		}

		[TestMethod]
		public void WhenULongValue_ReturnTeraMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(2, 40), v.Tera());
		}

		/* Peta */
		[TestMethod]
		public void WhenLongValue_ReturnPMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(10, 15), v.P());
		}

		[TestMethod]
		public void WhenULongValue_ReturnPMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(10, 15), v.P());
		}

		[TestMethod]
		public void WhenLongValue_ReturnPetaMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(2, 50), v.Peta());
		}

		[TestMethod]
		public void WhenULongValue_ReturnPetaMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(2, 50), v.Peta());
		}

		/* Exa */
		[TestMethod]
		public void WhenLongValue_ReturnEMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(10, 18), v.E());
		}

		[TestMethod]
		public void WhenULongValue_ReturnEMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(10, 18), v.E());
		}

		[TestMethod]
		public void WhenLongValue_ReturnExaMultipliedValue() {
			var v = 1L;
			Assert.AreEqual<long>(v * (long)Math.Pow(2, 60), v.Exa());
		}

		[TestMethod]
		public void WhenULongValue_ReturnExaMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(2, 60), v.Exa());
		}


		[TestMethod]
		public void WhenULongValue_ReturnZettaMultipliedValue() {
			ulong v = 1L;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(2, 70), v.Zetta());
		}

		[TestMethod]
		public void WhenULongValue_ReturnYottaMultipliedValue() {
			ulong v = 1;
			Assert.AreEqual<ulong>(v * (ulong)Math.Pow(2, 80), v.Yotta());
		}

	}
}

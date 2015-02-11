using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camalot.Common.Extensions;

namespace Camalot.Common.Collections {
	public interface IPagingSettings<T> {
		int Skip { get; set; }
		int Take { get; set; }
		string OrderBy { get; set; }
		bool IsOrderDescending { get; set; }

	}

	public class PagingSettings<T> : IPagingSettings<T> {
		public PagingSettings()
			: this(0, 10) {

		}

		public PagingSettings(int page, int perPage) {
			Skip = page.RequireBetween(0, int.MaxValue) * perPage.RequirePositive();
			Take = perPage;
		}
		public int Skip { get; set; }
		public int Take { get; set; }

		public string OrderBy { get; set; }
		public bool IsOrderDescending { get; set; }

	}
}

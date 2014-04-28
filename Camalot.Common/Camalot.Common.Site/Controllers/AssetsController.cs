using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Camalot.Common.Site.Controllers {
	public class AssetsController : Controller {
		// GET: Assets
		public PartialViewResult Gist(String id) {
			return PartialView(model: id);
		}
	}
}
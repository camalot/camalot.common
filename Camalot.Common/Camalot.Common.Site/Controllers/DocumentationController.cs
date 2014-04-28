using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Camalot.Common.Site.Services;

namespace Camalot.Common.Site.Controllers {
	public class DocumentationController : Controller {
		// GET: Documentation
		public ActionResult Index (String id) {
			var builder = new DocumentationService();
			var model = builder.Build(id);
			return View(model);
		}
	}
}
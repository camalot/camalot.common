using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Camalot.Common.Mvc.Extensions;

namespace Camalot.Common.Site.Controllers {
	public class HomeController : Controller {
		public ActionResult Index() {
			return View();
		}

		public ActionResult Test() {
			return this.API(new DataModel {
				IsEnabled = true,
				Name = "Foo"
			});
		}

		[XmlRoot("data")]
		public class DataModel {
			[XmlElement("isEnabled")]
			public bool IsEnabled { get; set; }
			[XmlElement("name")]
			public string Name { get; set; }
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Mime {
	public class MimeType {
		public string MediaType { get; set; }
		public ICollection<string> Extensions { get; set; }
	}
}

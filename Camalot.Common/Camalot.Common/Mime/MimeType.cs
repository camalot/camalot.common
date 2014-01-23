using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camalot.Common.Mime {
	/// <summary>
	/// 
	/// </summary>
	public class MimeType {
		/// <summary>
		/// Gets or sets the type of the media.
		/// </summary>
		/// <value>
		/// The type of the media.
		/// </value>
		public string MediaType { get; set; }
		/// <summary>
		/// Gets or sets the extensions.
		/// </summary>
		/// <value>
		/// The extensions.
		/// </value>
		public ICollection<string> Extensions { get; set; }
	}
}

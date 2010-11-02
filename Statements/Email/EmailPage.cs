using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Globalization;
using System.Web;
using System.Web.Hosting;

namespace ShomreiTorah.Billing.Statements.Email {
	public abstract class EmailPage : Page {
		public StatementInfo Info { get; internal set; }
		public string ImagePrefix { get; internal set; }

		public abstract string EmailSubject { get; }
		public abstract StatementKind Kind { get; }

		public virtual IEnumerable<string> ImageNames { get { yield break; } }

		internal string RenderPage() {
			var request = new SimpleWorkerRequest("", null, null);
			HttpContext.Current = new HttpContext(request);
			ProcessRequest(new HttpContext(request));
			using (var writer = new StringWriter(CultureInfo.InvariantCulture)) {
				using (var htmlWriter = new HtmlTextWriter(writer))
					RenderControl(htmlWriter);
				return writer.ToString();
			}
		}
	}
}

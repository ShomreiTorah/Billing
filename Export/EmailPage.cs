using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Globalization;
using System.Web;
using System.Web.Hosting;

namespace ShomreiTorah.Billing.Export {
	public abstract class EmailPage : Page {
		public BillingData.MasterDirectoryRow Person { get; internal set; }
		public DateTime StartDate { get; internal set; }

		public abstract string EmailSubject { get; }

		internal string RenderPage() {
			var request = new SimpleWorkerRequest("", null, null);

			ProcessRequest(new HttpContext(request));
			using (var writer = new StringWriter(CultureInfo.InvariantCulture)) {
				using (var htmlWriter = new HtmlTextWriter(writer))
					RenderControl(htmlWriter);
				return writer.ToString();
			}
		}
	}
}

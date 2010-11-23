using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using System.IO;
using System.Globalization;
using System.Web.Hosting;
using System.Web.Compilation;
using System.Net.Mail;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	static class EmailCreator {
		public static EmailPage<TRow> CreatePage<TRow>(string virtualPath) {
			if (HttpRuntime.AppDomainAppVirtualPath == null) return null;
			return BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(EmailPage<TRow>)) as EmailPage<TRow>;
		}

		public static MailMessage CreateMessage<TRow>(TRow row, string virtualPath) {
			var page = CreatePage<TRow>(virtualPath);
			page.Row = row;

			return new MailMessage {
				Body = page.RenderPage(),
				Subject = page.EmailSubject,
				SubjectEncoding = Email.DefaultEncoding,
				BodyEncoding = Email.DefaultEncoding
			};
		}
	}

	public abstract class EmailPage<TRow> : Page {
		public TRow Row { get; internal set; }

		public abstract string EmailSubject { get; }

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

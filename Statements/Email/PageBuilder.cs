using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using ShomreiTorah.Common;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Statements.Email {
	using Email = Common.Email;

	static class PageBuilder {
		public static T CreateHost<T>() {
			return (T)ApplicationHost.CreateApplicationHost(typeof(T), "/", Program.AspxPath);
		}

		public static TPage CreatePage<TPage>(string virtualPath) where TPage : Page {
			if (HttpRuntime.AppDomainAppVirtualPath == null) return null;
			return BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(TPage)) as TPage;
		}

		static readonly Dictionary<string, string> MediaTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
			{ ".png",	"image/png"		},
			{ ".gif",	"image/gif"		},
			{ ".jpeg",	"image/jpeg"	},
			{ ".jpg",	"image/jpeg"	},
		};
		public static readonly string ImagesPath = Path.Combine(Program.AspxPath, @"Images\");
		static readonly MailAddress BillingAddress = new MailAddress("Billing@ShomreiTorah.us", "Shomrei Torah Billing");

		public static MailMessage CreateMessage(Person person, string virtualPath, DateTime startDate, out StatementInfo info) {
			using (var page = PageBuilder.CreatePage<EmailPage>(virtualPath)) {
				page.ImagePrefix = "cid:";
				page.Info = info = new StatementInfo(person, startDate, page.Kind);
				if (!page.Info.ShouldSend) return null;

				var message = new MailMessage { From = BillingAddress, SubjectEncoding = Email.DefaultEncoding };

				var htmlContent = AlternateView.CreateAlternateViewFromString(page.RenderPage(), Email.DefaultEncoding, "text/html");

				htmlContent.TransferEncoding = TransferEncoding.QuotedPrintable;
				htmlContent.LinkedResources.AddRange(page.ImageNames.Select(name =>
					new LinkedResource(Path.Combine(ImagesPath, name), MediaTypes[Path.GetExtension(name)]) { ContentId = name }
				));

				message.AlternateViews.Add(htmlContent);

				message.Subject = page.EmailSubject;

				return message;
			}
		}
	}
}

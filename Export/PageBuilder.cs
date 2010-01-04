using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.Hosting;
using System.Web;
using System.Web.Configuration;
using System.Reflection;
using System.Globalization;
using System.Web.UI;
using System.Web.Compilation;
using System.CodeDom.Compiler;
using System.Net.Mail;
using ShomreiTorah.Common;
using System.Net.Mime;

namespace ShomreiTorah.Billing.Export {
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
		public static MailMessage CreateMessage(BillingData.MasterDirectoryRow person, string virtualPath, DateTime startDate) {
			using (var page = PageBuilder.CreatePage<EmailPage>(virtualPath)) {
				page.ImagePrefix = "cid:";
				page.Info = new BillInfo(person, startDate, page.Kind);
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

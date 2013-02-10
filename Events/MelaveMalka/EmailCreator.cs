using System.Net.Mail;
using RazorEngine.Templating;
using ShomreiTorah.Common;
using ShomreiTorah.Singularity;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	static class EmailCreator {
		public static MailMessage CreateMessage<TRow>(this ITemplateService service, TRow row, string name) {
			var page = (EmailPage<TRow>)service.Resolve(name,null);
			page.Row = row;

			return new MailMessage {
				Body = page.RenderPage().Trim(),
				IsBodyHtml = true,
				Subject = page.EmailSubject,
				SubjectEncoding = Email.DefaultEncoding,
				BodyEncoding = Email.DefaultEncoding
			};
		}
	}

	public abstract class EmailPage<TRow> : TemplateBase {
		public DataContext DataContext { get { return Program.Current.DataContext; } }
		public TRow Row { get; internal set; }

		public string EmailSubject { get; protected set; }

		internal string RenderPage() { return ((ITemplate)this).Run(new ExecuteContext()); }
	}

	public abstract class PartialPage<TModel> : TemplateBase, ITemplate<TModel> {
		public DataContext DataContext { get { return Program.Current.DataContext; } }
		public TModel Model { get; set; }
	}
}
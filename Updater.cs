using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using ShomreiTorah.Common;
using ShomreiTorah.Common.Updates;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing {
	static class Updater {
		public static readonly UpdateChecker Checker = UpdateChecker.CreateForCaller();
		static readonly System.Timers.Timer timer = Checker == null ? null :
			new System.Timers.Timer(TimeSpan.FromMinutes(30).TotalMilliseconds) { AutoReset = false };

		///<summary>If true, an update has been downloaded and will be applied after the program exits.</summary>
		public static bool RestartPending { get; private set; }

		public static void RunBackground() {
			if (Checker == null) return;
			if (RestartPending) return;
			timer.Elapsed += timer_Elapsed;
			timer.Start();
		}

		static void timer_Elapsed(object sender, ElapsedEventArgs e) {
			RunCheck();
		}

		public static void RunCheck() {
			if (Checker == null) return;
			if (RestartPending) return;

			UpdateInfo update = null;
			if (Program.UIInvoker != null && Program.UIInvoker.InvokeRequired) {
				update = Checker.FindUpdate();
			} else {	//If we're running on the UI thread
				ProgressWorker.Execute(ui => {
					ui.Caption = "Searching for updates...";
					update = Checker.FindUpdate();
				}, false);
			}
			if (update == null || !UIInvoke(() => ApplyUpdate(update)))
				timer.Start();	//If we didn't find an update, or if the update wasn't applied, check again later
		}
		///<summary>Called on the UI thread to download and apply an update.</summary>
		///<returns>True if the update was downloaded and applied.</returns>
		public static bool ApplyUpdate(UpdateInfo update) {
			if (Updater.RestartPending) {
				if (DialogResult.Yes == XtraMessageBox.Show("An update has already been downloaded.\r\nDo you want to restart the program and apply the update?",
															"Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
					Application.Exit();
				return true;
			}

			UserLookAndFeel.Default.SkinName = "Office 2010 Blue";		//This must be set here in case we're on the splash thread at launch time.
			SkinManager.EnableFormSkins();
			var parent = (IWin32Window)Program.UIInvoker;	//For some reason, I must set the parent to MainForm or it won't be properly modal.
			var description = update.GetChanges(Checker.CurrentVersion);

			if (DialogResult.No == XtraMessageBox.Show(parent, "An update is available.  Do you want to install it?\r\n\r\nThis update provides the following features:\r\n" + description,
													   "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				return false;

			string updatePath = null;
			try {
				if (!ProgressWorker.Execute(parent, ui => {
					ui.Caption = "Downloading update...";
					updatePath = update.DownloadFiles(existingFiles: Program.AppDirectory, organizationId: Config.ReadAttribute("Updates", "OrganizationId"), ui: ui);
					if (!ui.WasCanceled)
						ui.Caption = "Applying update";
				}, true))
					return false;
			} catch (TargetInvocationException tex) {
				Exception ex = tex.GetBaseException();

				if (!Debugger.IsAttached)
					Email.Warn("Billing Update Error", "New Version: " + update.NewVersion + "\r\nDescription: \r\n" + description + "\r\n\r\n" + ex);

				XtraMessageBox.Show(parent, "An error occurred while downloading the update.\r\n" + ex,
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
			if (updatePath == null) return false;

			//Updates will (usually) include a billing config file,
			//but I don't want a billing config file at home.
			if (!File.Exists(Path.Combine(Program.AppDirectory, "ShomreiTorah.Billing.Config.xml")))
				File.Delete(Path.Combine(updatePath, "ShomreiTorah.Billing.Config.xml"));	//File.Delete doesn't throw FileNotFound

			if (Program.Current.SyncContext != null)	//If an update was applied at launch, the database will not have been loaded yet.
				Program.Current.SaveDatabase();
			UpdateChecker.ApplyUpdate(updatePath, Program.AppDirectory);

			try {
				Email.Default.Send(Email.AlertsAddress, Email.AdminAddress, Environment.UserName + " updated ShomreiTorah.Billing on " + Environment.MachineName,
					"Old version: " + Checker.CurrentVersion + "\r\n"
				  + "New version: " + update.NewVersion + " (Published on " + update.PublishDate.ToString("F", CultureInfo.InvariantCulture)
				  + ")\r\n\r\nPath: " + Program.AppDirectory + "\r\n\r\nChanges:\r\n"
				  + description
				  + "\r\n\r\nUpdated files:\r\n • "
				  + update.Files.Where(f => !f.Matches(Program.AppDirectory)).Join("\r\n • ", f => f.RelativePath)
				  + "\r\n\r\nPre-update files:\r\n • "
				  + String.Join("\r\n • ", Directory.GetFiles(Program.AppDirectory, "*.*", SearchOption.AllDirectories))
				, false);
			} catch (SmtpException) { }

			timer.Stop();	//In case we were called by the Update button in MainForm
			RestartPending = true;

			var cea = new CancelEventArgs();
			Application.Exit(cea);
			if (cea.Cancel)
				XtraMessageBox.Show(parent, "The update will be applied after you exit the program.", "Shomrei Torah Billing");
			return true;
		}

		static T UIInvoke<T>(Func<T> method) {
			if (Program.UIInvoker != null && Program.UIInvoker.InvokeRequired)
				return (T)Program.UIInvoker.Invoke(method, null);
			else
				return method();
		}
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using ShomreiTorah.Common;
using ShomreiTorah.Common.Updates;
using ShomreiTorah.WinForms.Forms;
using System.Diagnostics;

namespace ShomreiTorah.Billing {
	class Program : MarshalByRefObject {
		static Forms.Splash Splash;
		public static void CloseSplash() { Splash.CloseSplash(); }

		public static DateTime LaunchTime { get; private set; }
		public static string AppDirectory { get; private set; }
		public static string AspxPath { get { return Path.Combine(AppDirectory, "Email Templates"); } }
		public static BillingData Data { get; private set; }

		public static ISynchronizeInvoke UIInvoker { get; set; }

		public static void DoReload() {
			Data.Save();
			using (BillingData newData = new BillingData()) {
				ProgressWorker.Execute(ui => {
					ui.Caption = "Reading data from SQL Server";
					newData.RefreshData(Data.AdapterManager);
				}, false);
				Data.Merge(newData);
			}
		}

		[STAThread]
		static void Main() {
			try {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				Splash = new Forms.Splash();
				new Thread(delegate() { Splash.ShowDialog(); }) { ApartmentState = ApartmentState.STA, IsBackground = true }.Start();

				AppDirectory = Path.GetDirectoryName(new Uri(typeof(Program).Assembly.CodeBase).LocalPath);
				Splash.Caption = "Loading assemblies";

				//Calling these methods will load other assemblies after showing the splash.

				//This method loads the config file in the original AppDomain.
				//It is loaded in the ASP.Net AppDomain in PostInitAspxDomain.
				LoadConfig();
				if (CheckForUpdate()) return;

				CreateAspxDomain();	//This call executes the program in the ASP.Net AppDomain
			} catch (Exception ex) { CloseSplash(); new Forms.ErrorForm(ex).ShowDialog(); }
		}
		///<summary>Called in both AppDomains to load a specific ShomreiTorahConfig.xml, if one is present.</summary>
		///<remarks>This method must be called before JITing any methods that use ShomreiTorahConfig in static initializers (eg, UpdateChecker).</remarks>
		static void LoadConfig() {
			Debug.Assert(!Config.Loaded, "ShomreiTorahConfig was already loaded!");

			var configPath = Path.Combine(AppDirectory, "ShomreiTorah.Billing.Config.xml");
			if (File.Exists(configPath)) {
				try {
					File.Encrypt(configPath);
				} catch (PlatformNotSupportedException) { } catch (NotSupportedException) { }

				Config.FilePath = configPath;
			}
		}
		///<summary>Called in the original (non-ASP.Net) AppDomain to apply updates on launch.</summary>
		///<returns>True if an update was applied (in which case the program should be restarted)</returns>
		static bool CheckForUpdate() {
			Splash.Caption = "Checking for updates";
			var update = Updater.Checker.FindUpdate();
			if (update != null) {
				//All launch-time UI must be shown in the splash thread
				//or it'll be covered by the splash. Therefore, it must
				//be run in the original AppDomain unless everything is
				//serializable.

				Splash.Caption = "Update found";
				if ((bool)Splash.Invoke(new Func<UpdateInfo, bool>(Updater.ApplyUpdate), update))
					return true;
			}
			return false;
		}

		///<summary>Called in the original AppDomain to create the ASP.Net AppDomain and launch the program in it.</summary>
		///<remarks>If the ASP.Net AppDomain couldn't be created, this method will launch the program in the original AppDomain.</remarks>
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error message")]
		[SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
		static void CreateAspxDomain() {
			Splash.Caption = "Initializing ASP.Net";

			//ASP.Net loads assemblies from the bin folder; I need to copy 
			//our exe their so that I can run my code in the new AppDomain.
			var binCopyPath = Path.Combine(AspxPath, @"Bin\" + Path.GetFileName(typeof(Program).Assembly.Location));
			Directory.CreateDirectory(Path.GetDirectoryName(binCopyPath));
			//GetLastWriteTime return 1/1/1601 for non-existant files
			if (File.GetLastWriteTimeUtc(typeof(Program).Assembly.Location) != File.GetLastWriteTimeUtc(binCopyPath))
				File.Copy(typeof(Program).Assembly.Location, binCopyPath, true);

			Program instance;
			try {
				instance = Export.PageBuilder.CreateHost<Program>();
				instance.InitAspxDomain(AppDirectory);
			} catch (Exception ex) {
				MessageBox.Show("An error occurred while initializing ASP.Net.\r\nEmail bills will not work.\r\n\r\n\r\n" + ex, "Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				instance = new Program();
			}
			instance.Execute(Splash);
		}

		///<summary>Prepares the ASP.Net AppDomain to run the program.</summary>
		///<param name="baseDir">The directory containing the initial EXE.  (As oppsoed to the one in EmailPages\Bin, which this AppDomain is running from)</param>
		///<remarks>This is only called if the ASP.Net AppDomain was created.
		///If it wasn't, this method is not run, and Execute is called immediately.</remarks>
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Cross-domain calls")]
		void InitAspxDomain(string baseDir) {
			AppDirectory = baseDir;

			AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>	//GetAssemblyName stores the path
				Assembly.Load(AssemblyName.GetAssemblyName(Path.Combine(AppDirectory, new AssemblyName(e.Name).Name + ".dll")));

			PostInitAspxDomain();	//This must be called after handling AssemblyResolve
		}
		///<summary>Continues preparing the ASP.Net AppDomain to run the program.</summary>
		///<remarks>This is called by InitAspxDomain after the AssemblyResolve handler has been added.
		///Any code that requires assembly resolution must be placed here.</remarks>
		static void PostInitAspxDomain() {
			//The config file is loaded in the original AppDomain by Main.
			LoadConfig();
		}

		///<summary>Executes the program.</summary>
		///<param name="splash">The splash form from the initial AppDomain.</param>
		///<remarks>This method is called in the ASP.Net AppDomain by CreateAspxDomain.
		///If PageBuilder.CreateHost failed, it will be called in the original AppDomain.</remarks>
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Cross-domain calls")]
		void Execute(Forms.Splash splash) {
			LaunchTime = DateTime.Now;
			Splash = splash;
			Application.ThreadException += Application_ThreadException;

			Splash.Caption = "Reading database";
			Data = new BillingData();
			Data.Load();

			Splash.Caption = "Loading UI";
			SkinManager.EnableFormSkinsIfNotVista();
			UserLookAndFeel.Default.SkinName = "Lilian";
			Application.Run(new Forms.MainForm());
		}

		static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) { new Forms.ErrorForm(e.Exception).Show(); }
	}
}

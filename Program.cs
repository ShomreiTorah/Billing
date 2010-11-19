using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Billing.Properties;
using ShomreiTorah.Common;
using ShomreiTorah.Common.Updates;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Data.UI.Grid;
using ShomreiTorah.Singularity;
using ShomreiTorah.Singularity.Sql;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Controls.Lookup;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing {
	//TODO: Replace XtraMessageBox with Dialog class
	//TODO: Use ESA on all forms & controls
	//TODO: Replace most references to Names with designer ESA
	//TODO: Prevent duplicate emails
	//TODO: Map doesn't work on first shown PersonDetails

	[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
	class Program : AppFramework {
		///<summary>Ensures that a table is loaded.</summary>
		public static void LoadTable<TRow>() where TRow : Row { LoadTables(TypedSchema<TRow>.Instance); }
		public static void LoadTables(params TableSchema[] schemas) { LoadTables((IEnumerable<TableSchema>)schemas); }

		public static void LoadTables(IEnumerable<TableSchema> schemas) {
			var allSchemas = new HashSet<TableSchema>();
			foreach (var schema in schemas.Where(s => Current.DataContext.Tables[s] == null)) {
				allSchemas.Add(schema);
				allSchemas.UnionWith(schema.GetDependencies());
			}

			if (allSchemas.Count == 0) return;	//All of the tables are already loaded
			var tables = allSchemas
				.SortDependencies()
				.Except(Current.DataContext.Tables.Select(t => t.Schema))	//Must be called after SortDependencies, since sorting requires all dependencies
				.Select(ts => ts.CreateTable())
				.ToList();

			tables.ForEach(Current.DataContext.Tables.AddTable);

			var syncers = tables.ConvertAll(t => new TableSynchronizer(t, SchemaMapping.GetPrimaryMapping(t.Schema), Current.SyncContext.SqlProvider));
			syncers.ForEach(Current.SyncContext.Tables.Add);

			var threadContext = SynchronizationContext.Current;
			ProgressWorker.Execute(ui => {
				if (Current.HasDataChanged)
					Current.SyncContext.WriteData(ui);			//I must save before loading in case a parent row was deleted.  (The DB is expected to cascade)

				ui.Maximum = -1;
				ui.Caption = "Loading " + tables.Join(", ", t => t.Schema.Name);
				Current.SyncContext.ReadData(threadContext);	//I must refresh everything to pick up potential changes in parent rows
			}, false);
		}
		#region Config
		protected override DataSyncContext CreateDataContext() {
			var context = new DataContext();

			//These columns cannot be added in the strongly-typed row
			//because the Person table must be usable without pledges
			//or payments.  (eg, ListMaker)
			if (!Person.Schema.Columns.Contains("TotalPaid")) {	//This can be called multiple times in the designer AppDomain
				Person.Schema.Columns.AddCalculatedColumn<Person, decimal>("TotalPaid", person => person.Payments.Sum(p => p.Amount));
				Person.Schema.Columns.AddCalculatedColumn<Person, decimal>("TotalPledged", person => person.Pledges.Sum(p => p.Amount));
				Person.Schema.Columns.AddCalculatedColumn<decimal>("BalanceDue", person => person.Field<decimal>("TotalPledged") - person.Field<decimal>("TotalPaid"));
			}

			context.Tables.AddTable(Payment.CreateTable());
			context.Tables.AddTable(Pledge.CreateTable());
			context.Tables.AddTable(EmailAddress.CreateTable());
			context.Tables.AddTable(LoggedStatement.CreateTable());
			context.Tables.AddTable(Person.CreateTable());
			context.Tables.AddTable(Deposit.CreateTable());

			if (IsDesignTime) {	//These tables are only loaded when needed.  However, I still want them in the designer.
				context.Tables.AddTable(SeatingReservation.CreateTable());
				context.Tables.AddTable(MelaveMalkaInfo.CreateTable());
				context.Tables.AddTable(MelaveMalkaInvitation.CreateTable());
				context.Tables.AddTable(MelaveMalkaSeat.CreateTable());
			}

			var syncContext = new DataSyncContext(context, new SqlServerSqlProvider(DB.Default));
			syncContext.Tables.AddPrimaryMappings();
			return syncContext;
		}
		protected override void RegisterSettings() {
			SkinManager.EnableFormSkinsIfNotVista();
			OfficeSkins.Register();
			UserLookAndFeel.Default.SkinName = "Office 2010 Blue";
			Dialog.DefaultTitle = "Shomrei Torah Billing";

			//TODO: Register HebrewDate editor

			RegisterRowDetail<Person>(p => new Forms.PersonDetails(p) { MdiParent = MainForm }.Show());
			RegisterRowDetail<Pledge>(p => new Forms.PledgeEditPopup(p).Show(MainForm));
			RegisterRowDetail<Payment>(p => new Forms.PaymentEditPopup(p).Show(MainForm));

			SeatingReservation.Schema.ToString();//Force static ctor
			RegisterRowDetail<SeatingReservation>(p => new Events.Seating.SeatingReservationPopup(p).Show(MainForm));

			GridManager.RegisterBehavior(Deposit.Schema,
				DeletionBehavior.WithMessages<Deposit>(
					singular: d => "Are you sure you want to delete this " + d.Amount.ToString("c", CultureInfo.CurrentCulture) + " deposit?\r\nThe payments will not be deleted.",
					plural: deposits => "Are you sure you want to delete "
										+ (deposits.Count().ToString(CultureInfo.InvariantCulture) + " pledges containing "
										+ deposits.Sum(p => p.Amount).ToString("c", CultureInfo.CurrentCulture) + "?\r\nThe payments in the deposits will not be deleted.")
			));

			GridManager.RegisterColumn((SmartGridColumn sgc) => {
				return sgc.View.GetSourceSchema() == SeatingReservation.Schema && sgc.FieldName == "Person";
			}, new MissingPersonController());
			RegisterLookupValidation();
		}
		#region Person Lookup
		const string SuppressValidate = "NoValidate";
		static void RegisterLookupValidation() {
			EditorRepository.PersonLookup.AddConfigurator(properties => {
				properties.Columns.RemoveAt(properties.Columns.Count - 1);
				properties.Columns.Add(new DataSourceColumn {
					FieldName = "BalanceDue",
					Caption = "Total Due",
					FormatString = "{0:c}",
				});

				//Only PersonSelectors should get validation (not search lookups)
				var ps = properties as RepositoryItemPersonSelector;
				if (ps != null) {
					ps.PersonSelecting += (sender, e) => {
						if (e.Cancel || ps.Tag == (object)SuppressValidate) return;	//SuppressValidation will be called after EndInit

						if (e.Method == PersonSelectionReason.ResultClick) {
							if (!e.Person.Pledges.Any() && !e.Person.Payments.Any())
								e.Cancel = !Dialog.Warn(e.Person.FullName + " has not made any pledges or payments.\r\nAre you sure you selected the correct person?");
						}
					};
				}
			});
		}
		///<summary>Prevents a PersonLookup from validating prior activity.</summary>
		public static void SuppressValidation(RepositoryItemPersonSelector selector) {
			selector.Tag = SuppressValidate;
		}
		#endregion

		class MissingPersonController : PersonColumnController {
			protected override void OnCustomUnboundColumnData(CustomColumnDataEventArgs e) {
				var row = e.Column.View.DataController.GetRowByListSourceIndex(e.ListSourceRowIndex) as IOwnedObject;
				if (e.IsGetData && row != null)
					e.Value = row.Person;
			}
		}
		#endregion

		static ISplashScreen Splash;
		public static void CloseSplash() { Splash.CloseSplash(); }

		public const string SettingsPath = @"HKEY_CURRENT_USER\Software\Shomrei Torah\Billing\";
		public static DateTime LaunchTime { get; private set; }
		public static string AppDirectory { get; internal set; }
		public static string AspxPath { get { return Path.Combine(AppDirectory, "Email Templates"); } }

		public static ISynchronizeInvoke UIInvoker { get; set; }

		[STAThread]
		static void Main() {
			try {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				Splash = new Data.UI.Forms.SplashForm(Resources.SplashImage, new Rectangle(165, 281, 169, 37), Color.Black);
				var splashThread = new Thread(delegate() { Splash.RunSplash(); }) { IsBackground = true };
				splashThread.SetApartmentState(ApartmentState.STA);
				splashThread.Start();

				AppDirectory = Path.GetDirectoryName(new Uri(typeof(Program).Assembly.CodeBase).LocalPath);
				Splash.SetCaption("Loading assemblies");

				//Calling these methods will load other assemblies after showing the splash.

				//This method loads the config file in the original AppDomain.
				//It is loaded in the ASP.Net AppDomain in PostInitAspxDomain.
				LoadConfig();
				if (CheckForUpdate()) return;

				CreateAspxDomain();	//This call executes the program in the ASP.Net AppDomain
			} catch (Exception ex) {
				CloseSplash();
				if (Debugger.IsAttached)
					throw;
				else
					new Data.UI.Forms.ExceptionReporter(ex).ShowDisposingDialog();
			}
		}
		///<summary>Called in both AppDomains to load a specific ShomreiTorahConfig.xml, if one is present.</summary>
		///<remarks>This method must be called before JITing any methods that use ShomreiTorahConfig in static initializers (eg, UpdateChecker).</remarks>
		internal static void LoadConfig() {
			Debug.Assert(!Config.Loaded, "ShomreiTorahConfig was already loaded!");

			var configPath = Path.Combine(AppDirectory, "ShomreiTorah.Billing.Config.xml");
			if (File.Exists(configPath)) {
				try {
					File.Encrypt(configPath);
				} catch (PlatformNotSupportedException) { } catch (NotSupportedException) { } catch (IOException) { }

				Config.FilePath = configPath;
			}
		}
		///<summary>Called in the original (non-ASP.Net) AppDomain to apply updates on launch.</summary>
		///<returns>True if an update was applied (in which case the program should be restarted)</returns>
		static bool CheckForUpdate() {
			Splash.SetCaption("Checking for updates");
			var update = Updater.Checker.FindUpdate();
			if (update != null) {
				//All launch-time UI must be shown in the splash thread
				//or it'll be covered by the splash. Therefore, it must
				//be run in the original AppDomain unless everything is
				//serializable.

				Splash.SetCaption("Update found");
				if ((bool)((Control)Splash).Invoke(new Func<UpdateInfo, bool>(Updater.ApplyUpdate), update))
					return true;
			}
			return false;
		}

		//All the code in this region exists to create the ASP.Net
		//AppDomain and call Execute() in it.
		#region Manage ASP.Net AppDomain
		///<summary>Called in the original AppDomain to create the ASP.Net AppDomain and launch the program in it.</summary>
		///<remarks>If the ASP.Net AppDomain couldn't be created, this method will launch the program in the original AppDomain.</remarks>
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error message")]
		[SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
		static void CreateAspxDomain() {
			Splash.SetCaption("Initializing ASP.Net");

			//The old version has an incompatible Web.config; the new version doesn't need any.
			File.Delete(Path.Combine(AspxPath, "Web.Config"));	//Won't throw if not found

			//ASP.Net loads assemblies from the bin folder; I need to copy 
			//our exe their so that I can run my code in the new AppDomain.
			CopyAspxBinAssembly(typeof(Program).Assembly);
			CopyAspxBinAssembly(typeof(Person).Assembly);
			CopyAspxBinAssembly(typeof(Table).Assembly);

			Action<ISplashScreen> executor;
			try {
				var cdc = Statements.Email.PageBuilder.CreateHost<CrossDomainCaller>();
				cdc.InitAspxDomain(AppDirectory);
				executor = cdc.Execute;
			} catch (Exception ex) {
				MessageBox.Show("An error occurred while initializing ASP.Net.\r\nEmail bills will not work.\r\n\r\n\r\n" + ex, "Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				var instance = new Program();
				executor = instance.Execute;
			}
			executor(Splash);	//Outside the try block
		}

		///<summary>Ensures that a source assembly is present in the ASP.Net Bin folder.</summary>
		///<remarks>This method must be called for assemblies needed by the C# compiler
		///for the ASPX pages.</remarks>
		static void CopyAspxBinAssembly(Assembly source) {
			var binCopyPath = Path.Combine(AspxPath, @"Bin\" + Path.GetFileName(source.Location));
			Directory.CreateDirectory(Path.GetDirectoryName(binCopyPath));
			//GetLastWriteTime returns 1/1/1601 for non-existent files
			if (File.GetLastWriteTimeUtc(source.Location) != File.GetLastWriteTimeUtc(binCopyPath))
				File.Copy(source.Location, binCopyPath, true);
		}
		#endregion

		///<summary>Executes the program.</summary>
		///<param name="splash">The splash form from the initial AppDomain.</param>
		///<remarks>This method is called in the ASP.Net AppDomain by CreateAspxDomain.
		///If PageBuilder.CreateHost failed, it will be called in the original AppDomain.</remarks>
		internal void Execute(ISplashScreen splash) {
			LaunchTime = DateTime.Now;
			Splash = splash;

			IsWinFormsSetup = true;  //Prevent the base from calling SetCompatibleTextRenderingDefault since we've already shown the splash
			Run();
		}

		//Since I manage the splash manually, I don't
		//return anything.
		protected override ISplashScreen CreateSplash() { return null; }
		protected override void SetSplashCaption(string message) {
			Splash.SetCaption(message);
		}

		protected override Form CreateMainForm() { return new Forms.MainForm(); }
	}
	///<summary>Marshals calls to Program methods in the ASP.Net AppDomain.</summary>
	///<remarks>This cannot be in the Program class since it inherits a type from a different DLL.</remarks>
	[SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by ASP.Net")]
	class CrossDomainCaller : MarshalByRefObject {
		Program program;

		static readonly string[] assemblyExtensions = new[] { ".dll", ".exe" };
		///<summary>Prepares the ASP.Net AppDomain to run the program.</summary>
		///<param name="baseDir">The directory containing the initial EXE.  (As opposed to the one in EmailPages\Bin, which this AppDomain is running from)</param>
		///<remarks>This is only called if the ASP.Net AppDomain was created.
		///If it wasn't, this method is not run, and Execute is called immediately.</remarks>
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Cross-domain calls")]
		public void InitAspxDomain(string baseDir) {

			//Prevent ASP.Net from automatically unloading
			//the AppDomain if any files or folders change
			StopFileMonitoring();

			AppDomain.CurrentDomain.AssemblyResolve += (sender, e) => {	//GetAssemblyName stores the path
				var baseName = Path.Combine(baseDir, new AssemblyName(e.Name).Name);
				var extension = assemblyExtensions.FirstOrDefault(ex => File.Exists(baseName + ex));
				if (extension == null)
					return null;
				else
					return Assembly.Load(AssemblyName.GetAssemblyName(baseName + extension));
			};

			PostInitAspxDomain(baseDir);	//This must be called after handling AssemblyResolve
		}

		static void StopFileMonitoring() {
			var theRuntime = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
			var fcmField = typeof(HttpRuntime).GetField("_fcm", BindingFlags.NonPublic | BindingFlags.Instance);

			var fcm = fcmField.GetValue(theRuntime);
			fcmField.FieldType.GetMethod("Stop", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(fcm, null);
		}

		///<summary>Continues preparing the ASP.Net AppDomain to run the program.</summary>
		///<remarks>This is called by InitAspxDomain after the AssemblyResolve handler has been added.
		///Any code that requires assembly resolution must be placed here.</remarks>
		void PostInitAspxDomain(string baseDir) {
			Program.AppDirectory = baseDir;
			//The config file is loaded in the original AppDomain by Main.
			Program.LoadConfig();
			program = new Program();
		}
		public void Execute(ISplashScreen splash) { program.Execute(splash); }
	}
}

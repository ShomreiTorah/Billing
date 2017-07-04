using System;
using System.ComponentModel;
using System.Composition.Hosting;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Billing.Properties;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Data.UI.Grid;
using ShomreiTorah.Singularity;
using ShomreiTorah.Singularity.Sql;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Controls.Lookup;

namespace ShomreiTorah.Billing {
	//TODO: Replace XtraMessageBox with Dialog class
	//TODO: Use ESA on all forms & controls
	//TODO: Replace most references to Names with designer ESA
	//TODO: Prevent duplicate emails
	//TODO: Map doesn't work on first shown PersonDetails

	[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
	public class Program : AppFramework {
		#region Config
		protected override DataSyncContext CreateDataContext() {
			var context = new DataContext();

			//These columns cannot be added in the strongly-typed row
			//because the People table must be usable without pledges
			//or payments.  (eg, ListMaker or Rafflizer)
			if (!Person.Schema.Columns.Contains("TotalPaid")) { //This can be called multiple times in the designer AppDomain
				Person.Schema.Columns.AddCalculatedColumn<Person, decimal>("TotalPaid", person => person.Payments.Sum(p => p.Amount));
				Person.Schema.Columns.AddCalculatedColumn<Person, decimal>("TotalPledged", person => person.Pledges.Sum(p => p.Amount));
				Person.Schema.Columns.AddCalculatedColumn<decimal>("BalanceDue", person => person.Field<decimal>("TotalPledged") - person.Field<decimal>("TotalPaid"));

				Pledge.Schema.Columns.AddCalculatedColumn<Pledge, decimal>("UnlinkedAmount", p => p.Amount <= 0 ? 0 : p.Amount - p.LinkedPayments.Sum(o => o.Amount));

				EmailAddress.PersonColumn.AddIndex();
				Pledge.PersonColumn.AddIndex();
				Payment.PersonColumn.AddIndex();
				PledgeLink.PaymentColumn.AddIndex();
				PledgeLink.PledgeColumn.AddIndex();
			}

			context.Tables.AddTable(PledgeLink.CreateTable());
			context.Tables.AddTable(Payment.CreateTable());
			context.Tables.AddTable(Pledge.CreateTable());
			context.Tables.AddTable(EmailAddress.CreateTable());
			context.Tables.AddTable(LoggedStatement.CreateTable());
			context.Tables.AddTable(Person.CreateTable());
			context.Tables.AddTable(Deposit.CreateTable());
			context.Tables.AddTable(RelativeLink.CreateTable());

			if (IsDesignTime)
				AddDesignTimeTables(context);

			var syncContext = new DataSyncContext(context, new SqlServerSqlProvider(DB.Default));
			syncContext.Tables.AddPrimaryMappings();
			return syncContext;
		}
		///<summary>Creates tables that should only be loaded at design-time.</summary>
		///<remarks>At runtime, these tables are loaded when needed.  However, I still want them in the designer.</remarks>
		static void AddDesignTimeTables(DataContext context) {
			context.Tables.AddTable(SeatingReservation.CreateTable());
			context.Tables.AddTable(MelaveMalkaInfo.CreateTable());
			context.Tables.AddTable(MelaveMalkaInvitation.CreateTable());
			context.Tables.AddTable(MelaveMalkaSeat.CreateTable());
			context.Tables.AddTable(Caller.CreateTable());
			context.Tables.AddTable(AdReminderEmail.CreateTable());
			context.Tables.AddTable(RaffleTicket.CreateTable());
		}
		protected override void RegisterSettings() {
			SkinManager.EnableFormSkinsIfNotVista();

			if (Config.IsDebug)
				UserLookAndFeel.Default.SkinName = "Office 2010 Black";
			else
				UserLookAndFeel.Default.SkinName = "Office 2010 Blue";
			Dialog.DefaultTitle = "Shomrei Torah Billing";

			//TODO: Register HebrewDate editor

			RegisterRowDetail<Person>(p => new Forms.PersonDetails(p) { MdiParent = MainForm }.Show());
			RegisterRowDetail<Pledge>(p => new Forms.PledgeEditPopup(p).Show(MainForm));
			RegisterRowDetail<Payment>(p => new Forms.PaymentEditPopup(p).Show(MainForm));

			SeatingReservation.Schema.ToString();//Force static ctor
			RegisterRowDetail<SeatingReservation>(p => new Events.Seating.SeatingReservationPopup(p).Show(MainForm));

			GridManager.RegisterColumn(Pledge.Schema.Columns["UnlinkedAmount"],
				new ColumnController(c => {
					c.DisplayFormat.FormatType = FormatType.Numeric;
					c.DisplayFormat.FormatString = "c";

					c.MaxWidth = 85;
					c.SummaryItem.DisplayFormat = "{0:c} Total Unpaid-for";
					c.SummaryItem.SummaryType = SummaryItemType.Sum;
				})
			);

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
						if (e.Cancel || ps.Tag == (object)SuppressValidate) return; //SuppressValidation will be called after EndInit

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

		public const string SettingsPath = @"HKEY_CURRENT_USER\Software\Shomrei Torah\Billing\";
		public static DateTime LaunchTime { get; private set; }
		public static string AppDirectory { get; internal set; }

		///<summary>Gets the directory with Emai Templates and Word Templates folders.</summary>
		public static string TemplatesDirectory
#if DEBUG
			// Use templates from the local Config repo, not the deployed bin/ folder.
			=> Path.Combine(Config.FilePath, @"..\..\");
#else
			=> AppDirectory;
#endif

		public static ISynchronizeInvoke UIInvoker { get; set; }

		///<summary>Gets the MEF container for the application.  Do not reference this property outside of entry-points.</summary>
		private CompositionHost MefContainer { get; set; }

		[STAThread]
		static void Main() {
			try {
				LaunchTime = DateTime.Now;
				AppDirectory = Path.GetDirectoryName(new Uri(typeof(Program).Assembly.CodeBase).LocalPath);

				new Program().Run();
			} catch (Exception ex) {
				if (Debugger.IsAttached)
					throw;
				else
					new Data.UI.Forms.ExceptionReporter(ex).ShowDisposingDialog();
			}
		}

		protected override bool OnBeforeInit() {
			LoadConfig();
			if (CheckForUpdate())
				return false;
			SetupMef();
			return true;
		}
		///<summary>Loads a specific ShomreiTorahConfig.xml, if one is present.</summary>
		///<remarks>This method must be called before JITing any methods that use ShomreiTorahConfig in static initializers (eg, UpdateChecker).</remarks>
		internal static void LoadConfig() {
			Debug.Assert(!Config.Loaded, "ShomreiTorahConfig was already loaded!");

			// Delete old name for config file.
			File.Delete(Path.Combine(AppDirectory, "ShomreiTorah.Billing.Config.xml"));
			var configPath = Path.Combine(AppDirectory, "ShomreiTorahConfig.xml");
			if (File.Exists(configPath)) {
				try {
					File.Encrypt(configPath);
				} catch (PlatformNotSupportedException) { } catch (NotSupportedException) { } catch (IOException) { } catch (UnauthorizedAccessException) { }

				Config.FilePath = configPath;
			}
		}
		///<summary>Apply updates on launch.</summary>
		///<returns>True if an update was applied (in which case the program should be restarted).</returns>
		bool CheckForUpdate() {
			if (Updater.Checker == null)
				return false;

			SetSplashCaption("Checking for updates");
			var update = Updater.Checker.FindUpdate();
			if (update != null) {
				//All launch-time UI must be shown in the splash thread
				//or it'll be covered by the splash.

				SetSplashCaption("Update found");
				if (InvokeSplash(() => Updater.ApplyUpdate(update)))
					return true;
			}
			return false;
		}

		protected override ISplashScreen CreateSplash() {
			var form = new Data.UI.Forms.SplashForm(Resources.SplashImage, new Rectangle(165, 281, 169, 37), Color.Black);
			UIInvoker = form;
			return form;
		}
		protected override Form CreateMainForm() { return (Form)MefContainer.GetExport<IMainForm>(); }

		void SetupMef() {
			MefContainer = new ContainerConfiguration()
				.WithAssembly(typeof(Program).Assembly)
				.WithAssemblies(Directory.EnumerateFiles(AppDirectory, typeof(Program).Assembly.GetName().Name + ".*.dll")
										 .Select(Assembly.LoadFrom))
				.CreateContainer();
		}
	}
}
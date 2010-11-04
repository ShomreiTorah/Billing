using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Utils;
using PowerPointJournal;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.WinForms;
using AdType = PowerPointJournal.AdType;

namespace ShomreiTorah.Billing.Import.Journal {
	sealed partial class JournalImporter : XtraForm {
		static readonly string Account = Names.DefaultAccount;

		public static void Execute() {
			Program.Current.RefreshDatabase();

			string dbPath;
			using (var dialog = new OpenFileDialog {
				Filter = "Journal Database (Ads.xml)|Ads.xml|XML Files|*.xml|All Files|*.*",
				Title = "Open Journal Database"
			}) {
				try {
					dialog.InitialDirectory = Config.ReadAttribute("Journal", "Path");
					dialog.FileName = Path.Combine(dialog.InitialDirectory, "Ads.xml");
				} catch (ConfigurationException) { }

				if (dialog.ShowDialog() == DialogResult.Cancel) return;
				dbPath = dialog.FileName;
			}
			int year = YearPrompt.Prompt();
			Resolver resolver = new Resolver("Journal " + year);
			string modifier = "Journal " + year + " Import";
			string source = "Journal " + year;
			using (JournalDB journal = new JournalDB()) {
				journal.ReadXml(dbPath);

				foreach (var ad in journal.Ads.Where(a => a.AmountToBill <= 0).ToArray())
					journal.Ads.Rows.Remove(ad);	//Don't worry; the database isn't saved.

				AdCollection ads = new AdCollection();

				for (int i = 0; i < journal.Ads.Count; i++) {
					var iad = new ImportedAd(journal.Ads[i], year);
					iad.Person = resolver.Resolve(new PersonData(iad.Ad));

					#region Pledge
					iad.Pledge = Program.Table<Pledge>().Rows.FirstOrDefault(p => p.ExternalSource == source
																			  && p.ExternalId == iad.Ad.InternalID);
					if (iad.Pledge == null) {
						iad.Pledge = new Pledge {
							Person = iad.Person.ResolvedRow,
							Date = iad.Ad.DateEntered,
							Type = "Melave Malka Journal",
							SubType = GetSubType(iad.Ad.Type),
							Account = Account,
							Amount = iad.Ad.AmountToBill,
							Comments = iad.GeneratedComments,
							ExternalSource = source,
							ExternalId = iad.Ad.InternalID,
						};
						Program.Table<Pledge>().Rows.Add(iad.Pledge);
						iad.Pledge.Modifier = modifier;

						iad.State = ImportState.Added;
					} else
						iad.State = ImportState.ExistingIdentical;
					#endregion

					#region Payment
					iad.Payment = Program.Table<Payment>().Rows.FirstOrDefault(p => p.ExternalSource == source
																				 && p.ExternalId == iad.Ad.InternalID);
					if (iad.Ad.PaymentMethod == "Unpaid") {
						if (iad.Payment != null)
							iad.State = ImportState.ExistingChanged;	//We have a payment, but we shouldn't
					} else {
						if (iad.Payment == null) {
							iad.CreatePayment();
							if (iad.State == ImportState.ExistingIdentical)
								iad.State = ImportState.ExistingChanged;
						}
					}
					#endregion

					iad.CheckModified();

					ads.Add(iad);
				}
				new JournalImporter(ads, journal.Ads).ShowDisposingDialog();
			}
		}
		static string GetSubType(AdType type) {
			if (type.Name == "Greeting")
				return "Greeting ad";
			if (type.DefaultPrice > 180)
				return type.Name + " ad";
			else
				return type.Name + " page ad";
		}

		class AdCollection : KeyedCollection<JournalDB.AdsRow, ImportedAd> {
			protected override JournalDB.AdsRow GetKeyForItem(ImportedAd item) { return item.Ad; }
		}
		static readonly SeatsFormatter Seats = new SeatsFormatter();
		class ImportedAd {
			readonly string modifier, source;
			public ImportedAd(JournalDB.AdsRow ad, int year) {
				modifier = "Journal " + year + " Import";
				source = "Journal " + year;
				Ad = ad;
				#region Comments
				GeneratedComments = "Imported from Journal " + year + Environment.NewLine
								  + "Internal ID: " + Ad.InternalID + Environment.NewLine
								  + "External ID: " + Ad.ExternalID + Environment.NewLine
								  + "Men: " + Seats.Format(null, Ad.MensSeats, null) + ", Women: " + Seats.Format(null, Ad.WomensSeats, null) + Environment.NewLine
								  + "Status: " + Ad.Status.Name;

				if (!Ad.IsEmailNull() && !String.IsNullOrEmpty(Ad.Email))
					GeneratedComments += "Email: " + Ad.Email + Environment.NewLine;
				if (!Ad.IsNotesNull() && !String.IsNullOrEmpty(Ad.Notes))
					GeneratedComments += Environment.NewLine + Environment.NewLine + Ad.Notes;
				#endregion
			}

			public JournalDB.AdsRow Ad { get; private set; }
			public ResolvedPerson Person { get; set; }
			public string GeneratedComments { get; private set; }
			public Pledge Pledge { get; set; }
			public Payment Payment { get; set; }

			public ImportState State { get; set; }

			public void CreatePayment() {
				Payment = new Payment {
					Person = Person.ResolvedRow,
					Date = Ad.DateEntered,
					Method = Ad.PaymentMethod,
					CheckNumber = Ad.IsCheckNumberNull() ? null : Ad.CheckNumber.ToString(CultureInfo.InvariantCulture),
					Account = Account,
					Amount = Ad.AmountToBill,
					Comments = GeneratedComments,
					ExternalSource = source,
					ExternalId = Ad.InternalID
				};
				Program.Table<Payment>().Rows.Add(Payment);
				Payment.Modifier = modifier;
			}

			public void CheckModified() {
				#region Check for changes
				if (State == ImportState.ExistingIdentical) {
					if (Pledge.Amount != Ad.AmountToBill
					 || Pledge.Comments != GeneratedComments
					 || Pledge.Type != "Melave Malka Journal"
					 || Pledge.SubType != GetSubType(Ad.Type)
					 || Pledge.Account != Account
					 || Pledge.Person != Person.ResolvedRow
					 )
						State = ImportState.ExistingChanged;
					else if (Payment != null && (
							Payment.Account != Account
						 || Payment.Amount != Ad.AmountToBill
						 || Payment.Field<int?>("CheckNumber") != Ad.Field<int?>("CheckNumber")
						 || Payment.Comments != GeneratedComments
						 || Payment.Method != Ad.PaymentMethod
						 || Payment.Person != Person.ResolvedRow
					 ))
						State = ImportState.ExistingChanged;
				}
				#endregion
			}
		}
		class ImportState : IComparable {
			public static readonly ImportState ExistingIdentical = new ImportState { Color = Color.Green, Name = "Already imported" };
			public static readonly ImportState ExistingChanged = new ImportState { Color = Color.DarkOrange, Name = "Already imported, but changed" };
			public static readonly ImportState Added = new ImportState { Color = Color.LightBlue, Name = "Not imported yet" };

			Color color;
			public Color Color {
				get { return color; }
				private set {
					color = value;
					BackColor1 = ControlPaint.LightLight(value);
					BackColor2 = ControlPaint.Light(value);
				}
			}
			public Color BackColor1 { get; private set; }
			public Color BackColor2 { get; private set; }
			public string Name { get; private set; }
			public override string ToString() { return Name; }

			public int CompareTo(object obj) { return String.Compare(Name, (obj ?? "").ToString(), StringComparison.CurrentCultureIgnoreCase); }
		}

		readonly AdCollection ads;
		JournalImporter(AdCollection ads, JournalDB.AdsDataTable table) {
			InitializeComponent();

			colMensSeats.DisplayFormat.Format = new LabelledSeatesFormatter("Men");
			colWomensSeats.DisplayFormat.Format = new LabelledSeatesFormatter("Women");
			this.ads = ads;
			adsGrid.DataSource = table;

			accountEdit1.Properties.Items.AddRange(Names.AccountNames);
			accountEdit2.Properties.Items.AddRange(Names.AccountNames);

			accountEdit1.Properties.DropDownRows = accountEdit2.Properties.DropDownRows = Names.AccountNames.Count;

			methodEdit.Properties.Items.AddRange(Names.PaymentMethods);
			methodEdit.Properties.DropDownRows = Names.PaymentMethods.Count;

			pledgesBindingSource.DataSource = Program.Table<Pledge>().Rows;
			paymentsBindingSource.DataSource = Program.Table<Payment>().Rows;

			adsView.BestFitColumns();
			CheckSelection();
		}
		class LabelledSeatesFormatter : SeatsFormatter {
			readonly string prefix;
			public LabelledSeatesFormatter(string prefix) { this.prefix = prefix; }
			public override string Format(string format, object arg, IFormatProvider formatProvider) {
				return prefix + ": " + base.Format(format, arg, formatProvider);
			}
		}

		private void adsView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			var ad = (JournalDB.AdsRow)adsView.GetDataRow(e.RowHandle);
			if (e.Column == colAdType)
				e.Value = ad.Type.Name;
			else if (e.Column == colAdStatus)
				e.Value = ad.Status.Name;
			else if (e.Column == colImportState)
				e.Value = ads[ad].State;
			else if (e.Column == colResolveType)
				e.Value = ads[ad].Person.Action;
		}

		private void adsView_RowStyle(object sender, RowStyleEventArgs e) {
			if (e.RowHandle < 0) {
				if (!(adsView.GetGroupRowValue(e.RowHandle) is ImportState)) return;
				var type = (ImportState)adsView.GetGroupRowValue(e.RowHandle);

				if (type.Color == Color.Yellow)
					e.Appearance.ForeColor = Color.Goldenrod;
				else if (type.Color == Color.LightBlue)
					e.Appearance.ForeColor = Color.Blue;
				else
					e.Appearance.ForeColor = type.Color;
			} else {
				var row = adsView.GetDataRow(e.RowHandle) as JournalDB.AdsRow;
				if (row == null) return;

				var iad = ads[row];
				var type = iad.State;
				e.Appearance.BackColor = type.BackColor1;
				e.Appearance.BackColor2 = type.BackColor2;
				e.Appearance.GradientMode = LinearGradientMode.ForwardDiagonal;

				if (iad.Person.Action == ResolveAction.AddNew && (row.City == "Passaic" || row.City == "Clifton"))
					e.Appearance.ForeColor = Color.Red;
			}
		}

		private void adsView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) { CheckSelection(); }
		void CheckSelection() {
			if (adsView.FocusedRowHandle == GridControl.InvalidRowHandle) {
				splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
				return;
			}
			var iad = ads[(JournalDB.AdsRow)adsView.GetFocusedDataRow()];
			personSelector.ResolvedPerson = iad.Person;
			personDetails.Text = "Action: " + iad.Person.Action + "\r\n" + new PersonData(iad.Person.ResolvedRow).ToFullString();

			pledgesBindingSource.Position = pledgesBindingSource.IndexOf(iad.Pledge);
			importPayment.Checked = iad.Payment != null;
			if (iad.Payment != null)
				paymentsBindingSource.Position = paymentsBindingSource.IndexOf(iad.Payment);

			splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
		}

		//TODO: RepositoryItem?
		//TODO: Remove class; handle Selecting event
		class ResolvingPersonSelector : Data.UI.Controls.PersonSelector {
			ResolvedPerson resolvedPerson;
			[Browsable(false)]
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
			public ResolvedPerson ResolvedPerson {
				get { return resolvedPerson; }
				set {
					resolvedPerson = value;
					SelectedPerson = value.ResolvedRow;
				}
			}
			protected override void OnEditValueChanged() {
				base.OnEditValueChanged();
				if (SelectedPerson != null)
					ResolvedPerson.SetUseExisting(SelectedPerson);
			}
			protected override Person PromptNew() {
				//using (var dialog = new NewPerson(p => { ResolvedPerson.SetAddNew(p); return ResolvedPerson.ResolvedRow; })) {
				//    dialog.ShowDialog(FindForm());
				//}
				return ResolvedPerson.ResolvedRow;
			}
		}

		private void importPayment_CheckedChanged(object sender, EventArgs e) {
			paymentGroup.Visibility = importPayment.Checked ? LayoutVisibility.Always : LayoutVisibility.Never;

			var iad = ads[(JournalDB.AdsRow)adsView.GetFocusedDataRow()];
			if (importPayment.Checked == (iad.Payment != null)) return;

			if (importPayment.Checked) {
				iad.CreatePayment();
				paymentsBindingSource.Position = paymentsBindingSource.IndexOf(iad.Payment);
			} else {
				iad.Payment.RemoveRow();
				iad.Payment = null;
			}
		}
	}
}
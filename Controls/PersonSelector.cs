using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShomreiTorah.WinForms.Controls;
using DevExpress.XtraEditors;

namespace ShomreiTorah.Billing.Controls {
	partial class PersonSelector : Lookup {
		public PersonSelector() {
			InitializeComponent();
			addNew.SendToBack();

			var x = Columns.Last().Left;
			Columns.RemoveAt(Columns.Count - 1);
			Columns.Add(new ColumnInfo("BalanceDue", x, 200, "Dues: {0:c}"));
		}
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			if (Program.Data != null)
				SearchTable = Program.Data.MasterDirectory;
		}

		protected override void OnItemSelected(ItemSelectionEventArgs e) {
			var person = (BillingData.MasterDirectoryRow)e.SelectedRow;
			if (person.TotalPaid == 0 && person.TotalPledged == 0) {
				if (DialogResult.No == XtraMessageBox.Show(person.FullName + " has not made any pledges or payments.\r\nAre you sure you selected the correct person?",
														   "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
					return;
			}
			var args = new SelectingPersonEventArgs(person);
			OnSelectingPerson(args);
			if (args.Cancel) return;

			SelectedPerson = person;
			PopupOpen = false;
			base.OnItemSelected(e);
		}
		private void addNew_Click(object sender, EventArgs e) { OnAddNew(); }
		protected virtual void OnAddNew() {
			using (var dialog = new NewPerson()) {
				var person = (dialog.ShowDialog() == DialogResult.OK) ? dialog.SelectedPerson : null;
				if (person == null) return;

				var args = new SelectingPersonEventArgs(person);
				OnSelectingPerson(args);
				if (args.Cancel) return;

				SelectedPerson = person;
				RaiseItemSelected(new ItemSelectionEventArgs(SelectedPerson));
			}
		}
		protected void RaiseItemSelected(ItemSelectionEventArgs e) { base.OnItemSelected(e); }

		///<summary>Gets or sets the ID of the selected person.  Used for databinding.</summary>
		[DefaultValue(null)]
		[Category("Data")]
		[Description("Gets or sets the ID of the selected person.  Used for databinding.")]
		[Bindable(true)]
		public object Value {
			get { return SelectedPerson == null ? DBNull.Value : (object)SelectedPerson.Id; }
			set { SelectedPerson = value is Guid ? Program.Data.MasterDirectory.FindById((Guid)value) : null; }
		}

		BillingData.MasterDirectoryRow selectedPerson;
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public BillingData.MasterDirectoryRow SelectedPerson {
			get { return selectedPerson; }
			set {
				selectedPerson = value;
				if (SelectedPerson == null) {
					Caption = "Select a person:";
					DefaultText = "Please click here to select a person";
				} else {
					Caption = SelectedPerson.VeryFullName;
					DefaultText = "Click here to select a different person";
				}
				OnSelectedPersonChanged();
			}
		}
		///<summary>Occurs when the Value property is changed.</summary>
		public event EventHandler ValueChanged {
			add { SelectedPersonChanged += value; }
			remove { SelectedPersonChanged -= value; }
		}

		///<summary>Occurs when a person is selected.</summary>
		public event EventHandler SelectedPersonChanged;
		///<summary>Raises the SelectedPersonChanged event.</summary>
		internal protected virtual void OnSelectedPersonChanged() { OnSelectedPersonChanged(EventArgs.Empty); }
		///<summary>Raises the SelectedPersonChanged event.</summary>
		///<param name="e">An EventArgs object that provides the event data.</param>
		internal protected virtual void OnSelectedPersonChanged(EventArgs e) {
			if (SelectedPersonChanged != null)
				SelectedPersonChanged(this, e);
		}
		///<summary>Occurs when the user is about to select a new person.</summary>
		public event EventHandler<SelectingPersonEventArgs> SelectingPerson;
		///<summary>Raises the SelectingPerson event.</summary>
		///<param name="e">A CancelEventArgs object that provides the event data.</param>
		internal protected virtual void OnSelectingPerson(SelectingPersonEventArgs e) {
			if (SelectingPerson != null)
				SelectingPerson(this, e);
		}
	}
	class SelectingPersonEventArgs : CancelEventArgs {
		public SelectingPersonEventArgs(BillingData.MasterDirectoryRow person) { Person = person; }
		public BillingData.MasterDirectoryRow Person { get; private set; }
	}
}

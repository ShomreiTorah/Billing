using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Controls {
	partial class PledgeEdit : XtraUserControl {
		public PledgeEdit() {
			InitializeComponent();

			account.Properties.Items.Clear();
			account.Properties.Items.AddRange(Names.AccountNames);
			account.Properties.DropDownRows = Names.AccountNames.Count;

			typeTree.Nodes.Clear();
			foreach (var type in Names.PledgeTypes) {
				var node = typeTree.Nodes.Add(type.Name);
				foreach (var subtype in type.Subtypes)
					node.Nodes.Add(subtype);
			}

			if (Program.Current != null) {	//Bugfix for nested designer
				pledgesBindingSource.DataSource = Program.Current.DataContext;
				Program.Table<Pledge>().LoadCompleted += Table_LoadCompleted;
			}
		}

		void Table_LoadCompleted(object sender, EventArgs e) {
			// Make sure that new items inserted during load don't steal the PhantomItem's position
			if (commit.CommitType == CommitType.Create) {
				pledgesBindingSource.Position = pledgesBindingSource.Count;
			}
		}


		///<summary>Releases the unmanaged resources used by the PaymentEdit and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				Program.Table<Pledge>().LoadCompleted -= Table_LoadCompleted;
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
		void SetCommentsHeight() {
			if (commit.Visible)
				comments.Height = account.Bottom - comments.Top;
			else
				comments.Height = note.Bottom - comments.Top;
		}
		private void commit_VisibleChanged(object sender, EventArgs e) { SetCommentsHeight(); }


		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Pledge CurrentPledge {
			get { return (Pledge)pledgesBindingSource.Current; }
			set {
				if (value == null) return;
				pledgesBindingSource.Position = pledgesBindingSource.IndexOf(value);
				commit.Hide();
				SetCommentsHeight();	//For some reason, VisibleChanged doesn't fire.
			}
		}

		public void AddNew() {
			Person oldPerson = ModifierKeys == 0 ? null : person.SelectedPerson;

			commit.Show();
			commit.CommitType = CommitType.Create;
			pledgesBindingSource.AddNew();
			typeTree.CollapseAll();

			person.SelectedPerson = oldPerson;
			if (oldPerson == null)
				person.Focus();
		}
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error message")]
		private void commit_Click(object sender, EventArgs e) {
			if (!commit.Visible) {
				Debug.Assert(false, "How was commit clicked?");
				return;
			}
			var pledge = CurrentPledge;
			if (pledge == null) {
				XtraMessageBox.Show("Something's wrong.");
				return;
			}
			if (person.SelectedPerson == null) {
				XtraMessageBox.Show("Please select the person who made the pledge.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (!(amount.EditValue is decimal) || amount.Value < 0) {
				XtraMessageBox.Show("Amount cannot be negative",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try {
				pledgesBindingSource.EndEdit();
			} catch (Exception ex) {
				XtraMessageBox.Show("Couldn't add pledge.\r\n" + ex.Message, "Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (commit.CommitType == CommitType.Create) {
				InfoMessage.Show("A " + pledge.Amount.ToString("c", CultureInfo.CurrentCulture) + " " + pledge.Type + " pledge has been added for " + pledge.Person.FullName);
				AddNew();
				date.EditValue = pledge.Date;
			}
		}
		#region UI Behavior
		private void TypeChanged(object sender, EventArgs e) {
			var node = typeTree.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text.Equals(typeText.Text, StringComparison.OrdinalIgnoreCase));

			if (node != null && node.Nodes.Count > 0)
				node = node.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text.Equals(subtypeText.Text, StringComparison.OrdinalIgnoreCase))
					?? node;
			else if (!String.IsNullOrEmpty(subtypeText.Text))
				node = null;

			typeTree.SelectedNode = node;
		}
		private void typeText_Leave(object sender, EventArgs e) { BeginInvoke(new Action(SetAccount)); }
		void SetAccount() {
			if (String.IsNullOrWhiteSpace(account.Text) || Names.AccountNames.Contains(account.Text))
				CurrentPledge.Account = account.Text = (typeText.Text == "Building Fund" ? "Building Fund" : "Operating Fund");
		}
		private void typeTree_AfterSelect(object sender, TreeViewEventArgs e) {
			if (e.Action == TreeViewAction.Collapse || e.Action == TreeViewAction.Expand || e.Action == TreeViewAction.Unknown) return;
			if (e.Node != null) {

				if (e.Node.Parent == null) {
					CurrentPledge.Type = typeText.Text = e.Node.Text;
					CurrentPledge.SubType = subtypeText.Text = "";
				} else {
					CurrentPledge.Type = typeText.Text = e.Node.Parent.Text;
					CurrentPledge.SubType = subtypeText.Text = e.Node.Text;
				}
				SetAccount();

				e.Node.Expand();
			}
		}

		private void person_EditValueChanged(object sender, EventArgs e) {
			typeTree.Focus();
		}

		private void Input_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter && commit.Visible)
				commit.PerformClick();
		}
		#endregion

		//TODO: Remove
		private void person_PersonSelecting(object sender, PersonSelectingEventArgs e) {
			if (e.Person != person.SelectedPerson
			 && person.SelectedPerson != null
				//&& !commit.Visible	//Abba wants to always confirm
			 && DialogResult.No == XtraMessageBox.Show("Are you sure you want to change this pledge to be associated with " + e.Person.VeryFullName + "?",
													   "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				e.Cancel = true;
		}

		private void note_EditValueChanged(object sender, EventArgs e) {
			if (!(amount.EditValue is decimal) && note.Text.Contains("מתנה"))
				amount.Value = 0;
		}
	}
}

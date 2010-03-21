using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.WinForms.Controls;
using System.Diagnostics.CodeAnalysis;
using ShomreiTorah.WinForms.Forms;
using System.Globalization;
using System.Diagnostics;

namespace ShomreiTorah.Billing.Controls {
	partial class PledgeEdit : XtraUserControl {
		public PledgeEdit() {
			InitializeComponent();

			account.Properties.Items.Clear();
			account.Properties.Items.AddRange(BillingData.AccountNames);
			account.Properties.DropDownRows = BillingData.AccountNames.Count;

			if (Program.Data != null)	//Bugfix for nested designer
				pledgesBindingSource.DataSource = Program.Data;
		}
		protected override void OnLayout(LayoutEventArgs e) {
			base.OnLayout(e);
			person.MaxPopupHeight = Height - person.Bottom;
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
		public BillingData.PledgesRow CurrentPledge {
			get { return pledgesBindingSource.Current == null ? null : (BillingData.PledgesRow)((DataRowView)pledgesBindingSource.Current).Row; }
			set {
				if (value == null) return;
				pledgesBindingSource.Position = pledgesBindingSource.Find("PledgeId", value.PledgeId);
				commit.Hide();
				SetCommentsHeight();	//For some reason, VisibleChanged doesn't fire.
			}
		}

		public void AddNew() {
			commit.Show();
			commit.CommitType = CommitType.Create;
			pledgesBindingSource.AddNew();
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
			if (pledge.IsNull("Amount") || pledge.Amount <= 0) {
				XtraMessageBox.Show("Amount must be positive",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (pledge.IsNull("PledgeId"))
				pledge.PledgeId = Guid.NewGuid();

			try {
				pledgesBindingSource.EndEdit();
			} catch (Exception ex) {
				XtraMessageBox.Show("Couldn't add pledge.\r\n" + ex.Message, "Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (commit.CommitType == CommitType.Create) {
				InfoMessage.Show("A " + pledge.Amount.ToString("c", CultureInfo.CurrentUICulture) + " " + pledge.Type + " pledge has been added for " + pledge.MasterDirectoryRow.FullName);
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
			if (BillingData.AccountNames.Contains(account.Text))
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
			}
		}

		private void person_ItemSelected(object sender, ItemSelectionEventArgs e) {
			typeTree.Focus();
		}

		private void Input_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Enter && commit.Visible)
				commit.PerformClick();
		}
		#endregion

		private void person_SelectingPerson(object sender, SelectingPersonEventArgs e) {
			if (e.Person != person.SelectedPerson
			 && !commit.Visible
			 && DialogResult.No == XtraMessageBox.Show("Are you sure you want to change this pledge to be associated with " + e.Person.VeryFullName + "?",
													   "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				e.Cancel = true;
		}
	}
}

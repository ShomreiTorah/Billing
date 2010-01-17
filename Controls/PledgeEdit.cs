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

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public BillingData.PledgesRow CurrentPledge {
			get { return pledgesBindingSource.Current == null ? null : (BillingData.PledgesRow)((DataRowView)pledgesBindingSource.Current).Row; }
		}

		public void AddNew() {
			commit.CommitType = CommitType.Create;
			pledgesBindingSource.AddNew();
			person.Focus();
		}
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error message")]
		private void commit_Click(object sender, EventArgs e) {
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
			if (pledge.Amount <= 0) {
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
			account.Text = typeText.Text == "Building Fund" ? "Building Fund" : "Operating Fund";
		}

		private void typeTree_AfterSelect(object sender, TreeViewEventArgs e) {
			if (e.Action == TreeViewAction.Unknown && e.Node != null && e.Node.Index == 0 && String.IsNullOrEmpty(typeText.Text)) {
				typeTree.SelectedNode = null;	//This happens when the control is first shown
				return;
			}
			if (e.Action == TreeViewAction.Collapse || e.Action == TreeViewAction.Expand || e.Action == TreeViewAction.Unknown) return;
			if (e.Node != null) {
				if (e.Node.Parent == null) {
					typeText.Text = e.Node.Text;
					subtypeText.Text = "";
				} else {
					typeText.Text = e.Node.Parent.Text;
					subtypeText.Text = e.Node.Text;
				}
			}
		}

		private void person_ItemSelected(object sender, ItemSelectionEventArgs e) {
			typeTree.Focus();
		}

		private void Input_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Enter)
				commit.PerformClick();
		}
		#endregion
	}
}

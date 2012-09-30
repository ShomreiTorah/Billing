using ShomreiTorah.Data.UI.Controls;
namespace ShomreiTorah.Billing.Controls {
	partial class PaymentEdit {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentEdit));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.linkDropDownEdit = new DevExpress.XtraEditors.PopupContainerEdit();
			this.linkPopup = new DevExpress.XtraEditors.PopupContainerControl();
			this.pledgeLinks = new ShomreiTorah.Billing.Controls.Editors.PledgeLinksEdit();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.commit = new ShomreiTorah.Billing.Controls.CommitButton();
			this.account = new DevExpress.XtraEditors.ComboBoxEdit();
			this.paymentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.billingData = new ShomreiTorah.Data.UI.FrameworkBindingSource(this.components);
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.amount = new DevExpress.XtraEditors.SpinEdit();
			this.checkNumberLabel = new DevExpress.XtraEditors.LabelControl();
			this.checkNumber = new ShomreiTorah.Data.UI.Controls.CheckNumberEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.method = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comments = new DevExpress.XtraEditors.MemoEdit();
			this.date = new DevExpress.XtraEditors.DateEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.person = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.linkDropDownEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.linkPopup)).BeginInit();
			this.linkPopup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.account.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.amount.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.method.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comments.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.date.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.date.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.person.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
			this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.groupControl1.Controls.Add(this.linkDropDownEdit);
			this.groupControl1.Controls.Add(this.labelControl6);
			this.groupControl1.Controls.Add(this.commit);
			this.groupControl1.Controls.Add(this.account);
			this.groupControl1.Controls.Add(this.labelControl3);
			this.groupControl1.Controls.Add(this.amount);
			this.groupControl1.Controls.Add(this.checkNumberLabel);
			this.groupControl1.Controls.Add(this.checkNumber);
			this.groupControl1.Controls.Add(this.labelControl2);
			this.groupControl1.Controls.Add(this.method);
			this.groupControl1.Controls.Add(this.comments);
			this.groupControl1.Controls.Add(this.date);
			this.groupControl1.Controls.Add(this.labelControl1);
			this.groupControl1.Controls.Add(this.linkPopup);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 20);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(789, 344);
			this.groupControl1.TabIndex = 1;
			this.groupControl1.Text = "Details";
			// 
			// linkDropDownEdit
			// 
			this.linkDropDownEdit.Location = new System.Drawing.Point(191, 51);
			this.linkDropDownEdit.Name = "linkDropDownEdit";
			toolTipTitleItem1.Text = "Linked Pledges";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Shows this person\'s unpaid pledges, allowing you to specify which pledges this pa" +
    "yment is covering.";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.linkDropDownEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown, "Pledges", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true)});
			this.linkDropDownEdit.Properties.PopupControl = this.linkPopup;
			this.linkDropDownEdit.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
			this.linkDropDownEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
			this.linkDropDownEdit.Size = new System.Drawing.Size(59, 20);
			this.linkDropDownEdit.TabIndex = 16;
			this.linkDropDownEdit.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.linkDropDownEdit_QueryPopUp);
			this.linkDropDownEdit.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.linkDropDownEdit_CloseUp);
			// 
			// linkPopup
			// 
			this.linkPopup.Controls.Add(this.pledgeLinks);
			this.linkPopup.Location = new System.Drawing.Point(38, 99);
			this.linkPopup.Name = "linkPopup";
			this.linkPopup.Size = new System.Drawing.Size(708, 234);
			this.linkPopup.TabIndex = 17;
			// 
			// pledgeLinks
			// 
			this.pledgeLinks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pledgeLinks.HostPayment = null;
			this.pledgeLinks.Location = new System.Drawing.Point(0, 0);
			this.pledgeLinks.Name = "pledgeLinks";
			this.pledgeLinks.Size = new System.Drawing.Size(708, 234);
			this.pledgeLinks.TabIndex = 0;
			// 
			// labelControl6
			// 
			this.labelControl6.Location = new System.Drawing.Point(5, 80);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new System.Drawing.Size(43, 13);
			this.labelControl6.TabIndex = 14;
			this.labelControl6.Text = "Account:";
			// 
			// commit
			// 
			this.commit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.commit.Location = new System.Drawing.Point(709, 316);
			this.commit.Name = "commit";
			this.commit.Size = new System.Drawing.Size(75, 23);
			this.commit.TabIndex = 6;
			this.commit.VisibleChanged += new System.EventHandler(this.commit_VisibleChanged);
			this.commit.Click += new System.EventHandler(this.commit_Click);
			// 
			// account
			// 
			this.account.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paymentsBindingSource, "Account", true));
			this.account.Location = new System.Drawing.Point(96, 77);
			this.account.Name = "account";
			this.account.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.account.Properties.DropDownRows = 2;
			this.account.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.account.Properties.Items.AddRange(new object[] {
            "Operating Fund",
            "Building Fund"});
			this.account.Size = new System.Drawing.Size(154, 20);
			this.account.TabIndex = 2;
			this.account.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			this.account.Leave += new System.EventHandler(this.LinksField_Leave);
			// 
			// paymentsBindingSource
			// 
			this.paymentsBindingSource.DataMember = "Payments";
			this.paymentsBindingSource.DataSource = this.billingData;
			this.paymentsBindingSource.Position = 0;
			// 
			// billingData
			// 
			this.billingData.Position = 0;
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(5, 54);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(37, 13);
			this.labelControl3.TabIndex = 8;
			this.labelControl3.Text = "Amount";
			// 
			// amount
			// 
			this.amount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paymentsBindingSource, "Amount", true));
			this.amount.EditValue = new decimal(new int[] {
            4556,
            0,
            0,
            0});
			this.amount.Location = new System.Drawing.Point(96, 51);
			this.amount.Name = "amount";
			this.amount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.amount.Properties.DisplayFormat.FormatString = "c";
			this.amount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amount.Properties.EditFormat.FormatString = "c";
			this.amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amount.Properties.Mask.EditMask = "c";
			this.amount.Size = new System.Drawing.Size(96, 20);
			this.amount.TabIndex = 1;
			this.amount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			this.amount.Leave += new System.EventHandler(this.LinksField_Leave);
			// 
			// checkNumberLabel
			// 
			this.checkNumberLabel.Location = new System.Drawing.Point(5, 133);
			this.checkNumberLabel.Name = "checkNumberLabel";
			this.checkNumberLabel.Size = new System.Drawing.Size(73, 13);
			this.checkNumberLabel.TabIndex = 6;
			this.checkNumberLabel.Text = "Check Number:";
			this.checkNumberLabel.Visible = false;
			// 
			// checkNumber
			// 
			this.checkNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paymentsBindingSource, "CheckNumber", true));
			this.checkNumber.Location = new System.Drawing.Point(96, 130);
			this.checkNumber.Name = "checkNumber";
			this.checkNumber.Size = new System.Drawing.Size(154, 20);
			this.checkNumber.TabIndex = 4;
			this.checkNumber.Visible = false;
			this.checkNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(5, 106);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(85, 13);
			this.labelControl2.TabIndex = 4;
			this.labelControl2.Text = "Payment Method:";
			// 
			// method
			// 
			this.method.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paymentsBindingSource, "Method", true));
			this.method.Location = new System.Drawing.Point(96, 103);
			this.method.Name = "method";
			this.method.Properties.AutoComplete = false;
			this.method.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.method.Properties.DropDownRows = 3;
			this.method.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.method.Properties.Items.AddRange(new object[] {
            "Cash",
            "Check"});
			this.method.Size = new System.Drawing.Size(154, 20);
			this.method.TabIndex = 3;
			this.method.EditValueChanged += new System.EventHandler(this.method_EditValueChanged);
			this.method.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// comments
			// 
			this.comments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comments.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paymentsBindingSource, "Comments", true));
			this.comments.Location = new System.Drawing.Point(256, 25);
			this.comments.Name = "comments";
			this.comments.Properties.NullValuePrompt = "Comments (will not show on invoice)";
			this.comments.Properties.NullValuePromptShowForEmptyValue = true;
			this.comments.Size = new System.Drawing.Size(528, 287);
			this.comments.TabIndex = 5;
			// 
			// date
			// 
			this.date.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paymentsBindingSource, "Date", true));
			this.date.EditValue = null;
			this.date.Location = new System.Drawing.Point(96, 25);
			this.date.Name = "date";
			this.date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.date.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			this.date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.date.Size = new System.Drawing.Size(154, 20);
			this.date.TabIndex = 0;
			this.date.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.date_EditValueChanging);
			this.date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(5, 28);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(27, 13);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Date:";
			// 
			// person
			// 
			this.person.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.paymentsBindingSource, "Person", true));
			this.person.Dock = System.Windows.Forms.DockStyle.Top;
			this.person.Location = new System.Drawing.Point(0, 0);
			this.person.Name = "person";
			toolTipItem2.Text = "Click to select a person";
			superToolTip2.Items.Add(toolTipItem2);
			toolTipTitleItem2.Text = "New Person...";
			toolTipItem3.Text = "Adds a new person to the master directory";
			superToolTip3.Items.Add(toolTipTitleItem2);
			superToolTip3.Items.Add(toolTipItem3);
			this.person.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip2, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("person.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, superToolTip3, true)});
			this.person.Size = new System.Drawing.Size(789, 20);
			this.person.TabIndex = 0;
			this.person.PersonSelecting += new System.EventHandler<ShomreiTorah.Data.UI.Controls.PersonSelectingEventArgs>(this.person_PersonSelecting);
			this.person.EditValueChanged += new System.EventHandler(this.person_EditValueChanged);
			// 
			// PaymentEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.person);
			this.MinimumSize = new System.Drawing.Size(347, 175);
			this.Name = "PaymentEdit";
			this.Size = new System.Drawing.Size(789, 364);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			this.groupControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.linkDropDownEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.linkPopup)).EndInit();
			this.linkPopup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.account.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.amount.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.method.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comments.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.date.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.date.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.person.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.DateEdit date;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.MemoEdit comments;
		private PersonSelector person;
		private System.Windows.Forms.BindingSource paymentsBindingSource;
		private ShomreiTorah.Data.UI.FrameworkBindingSource billingData;
		private DevExpress.XtraEditors.ComboBoxEdit method;
		private CommitButton commit;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.SpinEdit amount;
		private DevExpress.XtraEditors.LabelControl checkNumberLabel;
		private ShomreiTorah.Data.UI.Controls.CheckNumberEdit checkNumber;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.ComboBoxEdit account;
		private DevExpress.XtraEditors.PopupContainerControl linkPopup;
		private DevExpress.XtraEditors.PopupContainerEdit linkDropDownEdit;
		private Editors.PledgeLinksEdit pledgeLinks;

	}
}

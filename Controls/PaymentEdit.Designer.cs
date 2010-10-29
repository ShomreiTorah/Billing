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
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.commit = new ShomreiTorah.Billing.Controls.CommitButton();
			this.account = new DevExpress.XtraEditors.ComboBoxEdit();
			this.paymentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.billingData = new ShomreiTorah.Data.UI.FrameworkBindingSource();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.amount = new DevExpress.XtraEditors.SpinEdit();
			this.checkNumberLabel = new DevExpress.XtraEditors.LabelControl();
			this.checkNumber = new CheckNumberEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.method = new DevExpress.XtraEditors.ComboBoxEdit();
			this.comments = new DevExpress.XtraEditors.MemoEdit();
			this.date = new DevExpress.XtraEditors.DateEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.person = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
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
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 20);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(347, 155);
			this.groupControl1.TabIndex = 1;
			this.groupControl1.Text = "Details";
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
			this.commit.Location = new System.Drawing.Point(267, 127);
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
			this.account.Size = new System.Drawing.Size(126, 20);
			this.account.TabIndex = 2;
			this.account.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// paymentsBindingSource
			// 
			this.paymentsBindingSource.DataMember = "Payments";
			this.paymentsBindingSource.DataSource = this.billingData;
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
            0,
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
			this.amount.Size = new System.Drawing.Size(126, 20);
			this.amount.TabIndex = 1;
			this.amount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
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
			this.checkNumber.Size = new System.Drawing.Size(126, 20);
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
			this.method.Size = new System.Drawing.Size(126, 20);
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
			this.comments.Location = new System.Drawing.Point(228, 25);
			this.comments.Name = "comments";
			this.comments.Properties.NullValuePrompt = "Comments (will not show on invoice)";
			this.comments.Properties.NullValuePromptShowForEmptyValue = true;
			this.comments.Size = new System.Drawing.Size(114, 98);
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
			this.date.Size = new System.Drawing.Size(126, 20);
			this.date.TabIndex = 0;
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
			this.person.Size = new System.Drawing.Size(347, 20);
			this.person.TabIndex = 0;
			this.person.TabStop = false;
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
			this.Size = new System.Drawing.Size(347, 175);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			this.groupControl1.PerformLayout();
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

	}
}

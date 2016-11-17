using ShomreiTorah.Data.UI.Controls;
namespace ShomreiTorah.Billing.Controls {
	partial class PledgeEdit {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;


#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PledgeEdit));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.account = new DevExpress.XtraEditors.ComboBoxEdit();
			this.pledgesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.billingData = new ShomreiTorah.Data.UI.FrameworkBindingSource(this.components);
			this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
			this.date = new ShomreiTorah.Billing.Controls.HebrewCalendarEdit();
			this.commit = new ShomreiTorah.Billing.Controls.CommitButton();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			this.note = new ShomreiTorah.Billing.Controls.Editors.AliyahNoteEdit();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.subtypeText = new DevExpress.XtraEditors.TextEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.typeText = new DevExpress.XtraEditors.TextEdit();
			this.comments = new DevExpress.XtraEditors.MemoEdit();
			this.amount = new DevExpress.XtraEditors.SpinEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.typeTree = new ShomreiTorah.Data.UI.Controls.PledgeTypeTree();
			this.person = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.account.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.date.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.note.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.subtypeText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.typeText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comments.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.amount.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.person.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// groupControl1
			// 
			this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
			this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.groupControl1.Controls.Add(this.account);
			this.groupControl1.Controls.Add(this.labelControl6);
			this.groupControl1.Controls.Add(this.labelControl5);
			this.groupControl1.Controls.Add(this.date);
			this.groupControl1.Controls.Add(this.commit);
			this.groupControl1.Controls.Add(this.labelControl4);
			this.groupControl1.Controls.Add(this.note);
			this.groupControl1.Controls.Add(this.labelControl3);
			this.groupControl1.Controls.Add(this.subtypeText);
			this.groupControl1.Controls.Add(this.labelControl1);
			this.groupControl1.Controls.Add(this.typeText);
			this.groupControl1.Controls.Add(this.comments);
			this.groupControl1.Controls.Add(this.amount);
			this.groupControl1.Controls.Add(this.labelControl2);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupControl1.Location = new System.Drawing.Point(217, 30);
			this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(503, 267);
			this.groupControl1.TabIndex = 2;
			this.groupControl1.Text = "Details";
			// 
			// account
			// 
			this.account.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Account", true));
			this.account.Location = new System.Drawing.Point(82, 189);
			this.account.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.account.Name = "account";
			this.account.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
			this.account.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.account.Size = new System.Drawing.Size(207, 26);
			this.account.TabIndex = 4;
			this.account.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// pledgesBindingSource
			// 
			this.pledgesBindingSource.DataMember = "Pledges";
			this.pledgesBindingSource.DataSource = this.billingData;
			this.pledgesBindingSource.Position = 0;
			// 
			// billingData
			// 
			this.billingData.Position = 0;
			// 
			// labelControl6
			// 
			this.labelControl6.Location = new System.Drawing.Point(9, 193);
			this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.labelControl6.Name = "labelControl6";
			this.labelControl6.Size = new System.Drawing.Size(63, 19);
			this.labelControl6.TabIndex = 12;
			this.labelControl6.Text = "Account:";
			// 
			// labelControl5
			// 
			this.labelControl5.Location = new System.Drawing.Point(9, 41);
			this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.labelControl5.Name = "labelControl5";
			this.labelControl5.Size = new System.Drawing.Size(38, 19);
			this.labelControl5.TabIndex = 10;
			this.labelControl5.Text = "Date:";
			// 
			// date
			// 
			this.date.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Date", true));
			this.date.Location = new System.Drawing.Point(84, 37);
			this.date.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.date.Name = "date";
			this.date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.date.Properties.DisplayFormat.FormatString = "d";
			this.date.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.date.Properties.EditFormat.FormatString = "d";
			this.date.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.date.Properties.Mask.EditMask = "d";
			this.date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.date.Size = new System.Drawing.Size(206, 26);
			this.date.TabIndex = 0;
			this.date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// commit
			// 
			this.commit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.commit.Location = new System.Drawing.Point(376, 225);
			this.commit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.commit.Name = "commit";
			this.commit.Size = new System.Drawing.Size(120, 34);
			this.commit.TabIndex = 7;
			this.commit.VisibleChanged += new System.EventHandler(this.commit_VisibleChanged);
			this.commit.Click += new System.EventHandler(this.commit_Click);
			// 
			// labelControl4
			// 
			this.labelControl4.Location = new System.Drawing.Point(9, 231);
			this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(39, 19);
			this.labelControl4.TabIndex = 8;
			this.labelControl4.Text = "Note:";
			// 
			// note
			// 
			this.note.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Note", true));
			this.note.EditValue = "";
			this.note.Location = new System.Drawing.Point(84, 227);
			this.note.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.note.Name = "note";
			this.note.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.note.Properties.NullValuePrompt = "(will show on invoice)";
			this.note.Properties.NullValuePromptShowForEmptyValue = true;
			this.note.Size = new System.Drawing.Size(206, 26);
			this.note.TabIndex = 5;
			this.note.EditValueChanged += new System.EventHandler(this.note_EditValueChanged);
			this.note.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(9, 155);
			this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(63, 19);
			this.labelControl3.TabIndex = 7;
			this.labelControl3.Text = "Subtype:";
			// 
			// subtypeText
			// 
			this.subtypeText.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "SubType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.subtypeText.EditValue = "";
			this.subtypeText.Location = new System.Drawing.Point(84, 151);
			this.subtypeText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.subtypeText.Name = "subtypeText";
			this.subtypeText.Size = new System.Drawing.Size(206, 26);
			this.subtypeText.TabIndex = 3;
			this.subtypeText.EditValueChanged += new System.EventHandler(this.TypesText_EditValueChanged);
			this.subtypeText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(9, 117);
			this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(41, 19);
			this.labelControl1.TabIndex = 6;
			this.labelControl1.Text = "Type:";
			// 
			// typeText
			// 
			this.typeText.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Type", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.typeText.Location = new System.Drawing.Point(84, 113);
			this.typeText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.typeText.Name = "typeText";
			this.typeText.Size = new System.Drawing.Size(206, 26);
			this.typeText.TabIndex = 2;
			this.typeText.EditValueChanged += new System.EventHandler(this.TypesText_EditValueChanged);
			this.typeText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			this.typeText.Leave += new System.EventHandler(this.typeText_Leave);
			// 
			// comments
			// 
			this.comments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comments.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Comments", true));
			this.comments.EditValue = "";
			this.comments.Location = new System.Drawing.Point(298, 37);
			this.comments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.comments.Name = "comments";
			this.comments.Properties.NullValuePrompt = "Comments (will not show on invoice)";
			this.comments.Properties.NullValuePromptShowForEmptyValue = true;
			this.comments.Size = new System.Drawing.Size(197, 184);
			this.comments.TabIndex = 6;
			// 
			// amount
			// 
			this.amount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Amount", true));
			this.amount.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.amount.Location = new System.Drawing.Point(84, 75);
			this.amount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.amount.Name = "amount";
			this.amount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.amount.Properties.DisplayFormat.FormatString = "c";
			this.amount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amount.Properties.EditFormat.FormatString = "c";
			this.amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amount.Properties.Mask.EditMask = "c";
			this.amount.Size = new System.Drawing.Size(206, 26);
			this.amount.TabIndex = 1;
			this.amount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(9, 79);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(63, 19);
			this.labelControl2.TabIndex = 2;
			this.labelControl2.Text = "Amount:";
			// 
			// typeTree
			// 
			this.typeTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.typeTree.HideSelection = false;
			this.typeTree.Location = new System.Drawing.Point(0, 28);
			this.typeTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.typeTree.Name = "typeTree";
			this.typeTree.Size = new System.Drawing.Size(217, 269);
			this.typeTree.SubTypeField = this.subtypeText;
			this.typeTree.TabIndex = 1;
			this.typeTree.TypeField = this.typeText;
			this.typeTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.typeTree_AfterSelect);
			// 
			// person
			// 
			this.person.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Person", true));
			this.person.Dock = System.Windows.Forms.DockStyle.Top;
			this.person.Location = new System.Drawing.Point(0, 0);
			this.person.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.person.Name = "person";
			toolTipItem1.Text = "Click to select a person";
			superToolTip1.Items.Add(toolTipItem1);
			toolTipTitleItem1.Text = "New Person...";
			toolTipItem2.Text = "Adds a new person to the master directory";
			superToolTip2.Items.Add(toolTipTitleItem1);
			superToolTip2.Items.Add(toolTipItem2);
			this.person.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, superToolTip1, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("person.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, superToolTip2, true)});
			this.person.Properties.NewPersonTemplate = null;
			this.person.Size = new System.Drawing.Size(720, 28);
			this.person.TabIndex = 0;
			this.person.PersonSelecting += new System.EventHandler<ShomreiTorah.Data.UI.Controls.PersonSelectingEventArgs>(this.person_PersonSelecting);
			this.person.EditValueChanged += new System.EventHandler(this.person_EditValueChanged);
			// 
			// PledgeEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.typeTree);
			this.Controls.Add(this.person);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MinimumSize = new System.Drawing.Size(720, 297);
			this.Name = "PledgeEdit";
			this.Size = new System.Drawing.Size(720, 297);
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			this.groupControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.account.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.date.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.note.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.subtypeText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.typeText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comments.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.amount.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.person.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.MemoEdit comments;
		private DevExpress.XtraEditors.SpinEdit amount;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.TextEdit subtypeText;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.TextEdit typeText;
		private PledgeTypeTree typeTree;
		private System.Windows.Forms.BindingSource pledgesBindingSource;
		private ShomreiTorah.Data.UI.FrameworkBindingSource billingData;
		private Editors.AliyahNoteEdit note;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private PersonSelector person;
		private CommitButton commit;
		private DevExpress.XtraEditors.LabelControl labelControl5;
		private HebrewCalendarEdit date;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.ComboBoxEdit account;
	}
}

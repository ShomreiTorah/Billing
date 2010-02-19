namespace ShomreiTorah.Billing.Statements.Word {
	partial class ExportOptions {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportOptions));
			this.startDate = new DevExpress.XtraEditors.DateEdit();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.ok = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.docTypes = new DevExpress.XtraEditors.CheckedListBoxControl();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.docTypes)).BeginInit();
			this.SuspendLayout();
			// 
			// startDate
			// 
			this.startDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.startDate.EditValue = new System.DateTime(2010, 1, 14, 0, 0, 0, 0);
			this.startDate.Location = new System.Drawing.Point(12, 31);
			this.startDate.Name = "startDate";
			this.startDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.startDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.startDate.Properties.DisplayFormat.FormatString = "MMMM d, yyyy";
			this.startDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.startDate.Properties.EditFormat.FormatString = "MMMM d, yyyy";
			this.startDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.startDate.Properties.Mask.EditMask = "MMMM d, yyyy";
			this.startDate.Properties.NullValuePrompt = "Please select a date";
			this.startDate.Properties.ShowToday = false;
			this.startDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			this.startDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.startDate.Size = new System.Drawing.Size(156, 20);
			this.startDate.TabIndex = 12;
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(93, 158);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 13;
			this.cancel.Text = "Cancel";
			// 
			// ok
			// 
			this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ok.Enabled = false;
			this.ok.Location = new System.Drawing.Point(12, 158);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 23);
			this.ok.TabIndex = 14;
			this.ok.Text = "OK";
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 12);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(53, 13);
			this.labelControl1.TabIndex = 15;
			this.labelControl1.Text = "Start date:";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(12, 66);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(49, 13);
			this.labelControl2.TabIndex = 16;
			this.labelControl2.Text = "Generate:";
			// 
			// docTypes
			// 
			this.docTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.docTypes.CheckOnClick = true;
			this.docTypes.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.docTypes.HotTrackItems = true;
			this.docTypes.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
			this.docTypes.Location = new System.Drawing.Point(12, 85);
			this.docTypes.Name = "docTypes";
			this.docTypes.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.docTypes.Size = new System.Drawing.Size(156, 67);
			this.docTypes.TabIndex = 17;
			this.docTypes.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.docTypes_ItemCheck);
			// 
			// ExportOptions
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(180, 193);
			this.ControlBox = false;
			this.Controls.Add(this.docTypes);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.startDate);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(188, 221);
			this.Name = "ExportOptions";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Create Word Statements";
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.docTypes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.DateEdit startDate;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.SimpleButton ok;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.CheckedListBoxControl docTypes;
	}
}
namespace ShomreiTorah.Billing.Controls.Editors {
	partial class AliyahNotePopup {
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
			this.fullText = new DevExpress.XtraEditors.MemoEdit();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.isMatanah = new DevExpress.XtraEditors.CheckEdit();
			this.relative = new DevExpress.XtraEditors.ListBoxControl();
			((System.ComponentModel.ISupportInitialize)(this.fullText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.isMatanah.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.relative)).BeginInit();
			this.SuspendLayout();
			// 
			// fullText
			// 
			this.fullText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fullText.Location = new System.Drawing.Point(4, 4);
			this.fullText.Name = "fullText";
			this.fullText.Size = new System.Drawing.Size(223, 87);
			this.fullText.TabIndex = 0;
			this.fullText.EditValueChanged += new System.EventHandler(this.fullText_EditValueChanged);
			// 
			// groupControl1
			// 
			this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupControl1.Controls.Add(this.relative);
			this.groupControl1.Controls.Add(this.isMatanah);
			this.groupControl1.Location = new System.Drawing.Point(4, 98);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(223, 202);
			this.groupControl1.TabIndex = 1;
			this.groupControl1.Text = "עליה";
			// 
			// isMatanah
			// 
			this.isMatanah.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.isMatanah.Location = new System.Drawing.Point(5, 26);
			this.isMatanah.Name = "isMatanah";
			this.isMatanah.Properties.Caption = "מתנה";
			this.isMatanah.Size = new System.Drawing.Size(213, 18);
			this.isMatanah.TabIndex = 0;
			this.isMatanah.CheckedChanged += new System.EventHandler(this.isMatanah_CheckedChanged);
			// 
			// relative
			// 
			this.relative.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.relative.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.relative.HotTrackItems = true;
			this.relative.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
			this.relative.IncrementalSearch = true;
			this.relative.Location = new System.Drawing.Point(5, 50);
			this.relative.Name = "relative";
			this.relative.Size = new System.Drawing.Size(213, 147);
			this.relative.TabIndex = 1;
			this.relative.Click += new System.EventHandler(this.relative_Click);
			this.relative.SelectedIndexChanged += new System.EventHandler(this.relative_SelectedIndexChanged);
			// 
			// AliyahNotePopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.fullText);
			this.Name = "AliyahNotePopup";
			this.Size = new System.Drawing.Size(230, 303);
			((System.ComponentModel.ISupportInitialize)(this.fullText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.isMatanah.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.relative)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.MemoEdit fullText;
		private DevExpress.XtraEditors.GroupControl groupControl1;
		private DevExpress.XtraEditors.ListBoxControl relative;
		private DevExpress.XtraEditors.CheckEdit isMatanah;
	}
}

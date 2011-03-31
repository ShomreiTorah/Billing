namespace ShomreiTorah.Billing.Events.Auctions {
	partial class AuctionGroupSelector {
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
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			this.buttonEdit = new DevExpress.XtraEditors.ButtonEdit();
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonEdit
			// 
			this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonEdit.EditValue = "שמיני עצרת, תשע״א";
			this.buttonEdit.Location = new System.Drawing.Point(0, 0);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Left, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Left), serializableAppearanceObject1, "Previous", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Right), serializableAppearanceObject2, "Next", null, null, true)});
			this.buttonEdit.Properties.NullValuePrompt = "Select an auction";
			this.buttonEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.buttonEdit.Properties.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.buttonEdit_Properties_Spin);
			this.buttonEdit.Size = new System.Drawing.Size(229, 20);
			this.buttonEdit.TabIndex = 0;
			this.buttonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_ButtonClick);
			this.buttonEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonEdit_KeyDown);
			// 
			// AuctionGroupSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonEdit);
			this.Name = "AuctionGroupSelector";
			this.Size = new System.Drawing.Size(229, 20);
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.ButtonEdit buttonEdit;
	}
}

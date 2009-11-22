namespace ShomreiTorah.Billing.Controls {
	partial class PersonSelector {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonSelector));
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			this.addNew = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// addNew
			// 
			this.addNew.Dock = System.Windows.Forms.DockStyle.Right;
			this.addNew.Image = ((System.Drawing.Image)(resources.GetObject("addNew.Image")));
			this.addNew.Location = new System.Drawing.Point(478, 0);
			this.addNew.Name = "addNew";
			this.addNew.Size = new System.Drawing.Size(104, 20);
			toolTipTitleItem1.Text = "New Person";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Click to add a new person to the directory.";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.addNew.SuperTip = superToolTip1;
			this.addNew.TabIndex = 2;
			this.addNew.Text = "New Person...";
			this.addNew.Click += new System.EventHandler(this.addNew_Click);
			// 
			// PersonSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.Caption = "Select a person:";
			this.Controls.Add(this.addNew);
			this.Name = "PersonSelector";
			this.Controls.SetChildIndex(this.addNew, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton addNew;
	}
}

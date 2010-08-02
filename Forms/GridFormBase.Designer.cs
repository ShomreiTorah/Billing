namespace ShomreiTorah.Billing.Forms {
	partial class GridFormBase {
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
			this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.emailSelected = new DevExpress.XtraBars.BarButtonItem();
			this.emailVisible = new DevExpress.XtraBars.BarButtonItem();
			this.exportWordSelected = new DevExpress.XtraBars.BarButtonItem();
			this.exportWordVisible = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.ApplicationButtonText = null;
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.emailSelected,
            this.emailVisible,
            this.exportWordSelected,
            this.exportWordVisible});
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.MaxItemId = 4;
			this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
			this.ribbon.Name = "ribbon";
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbon.SelectedPage = this.ribbonPage1;
			this.ribbon.Size = new System.Drawing.Size(515, 116);
			this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
			// 
			// emailSelected
			// 
			this.emailSelected.Caption = "Selected Person";
			this.emailSelected.Id = 0;
			this.emailSelected.Name = "emailSelected";
			this.emailSelected.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.emailSelected_ItemClick);
			// 
			// emailVisible
			// 
			this.emailVisible.Caption = "Everyone in this grid";
			this.emailVisible.Id = 1;
			this.emailVisible.Name = "emailVisible";
			this.emailVisible.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.emailVisible_ItemClick);
			// 
			// exportWordSelected
			// 
			this.exportWordSelected.Appearance.Options.UseTextOptions = true;
			this.exportWordSelected.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.exportWordSelected.Caption = "Selected Person";
			this.exportWordSelected.Id = 2;
			this.exportWordSelected.Name = "exportWordSelected";
			this.exportWordSelected.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportWordSelected_ItemClick);
			// 
			// exportWordVisible
			// 
			this.exportWordVisible.Caption = "Everyone in this grid";
			this.exportWordVisible.Id = 3;
			this.exportWordVisible.Name = "exportWordVisible";
			this.exportWordVisible.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportWordVisible_ItemClick);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Statements";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.emailSelected, true);
			this.ribbonPageGroup1.ItemLinks.Add(this.emailVisible);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "Send Emails to";
			// 
			// ribbonPageGroup2
			// 
			this.ribbonPageGroup2.ItemLinks.Add(this.exportWordSelected, true);
			this.ribbonPageGroup2.ItemLinks.Add(this.exportWordVisible);
			this.ribbonPageGroup2.Name = "ribbonPageGroup2";
			this.ribbonPageGroup2.ShowCaptionButton = false;
			this.ribbonPageGroup2.Text = "Create Word Documents for";
			// 
			// GridFormBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(515, 422);
			this.Controls.Add(this.ribbon);
			this.Name = "GridFormBase";
			this.Text = "GridFormBase";
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraBars.BarButtonItem emailSelected;
		private DevExpress.XtraBars.BarButtonItem emailVisible;
		private DevExpress.XtraBars.BarButtonItem exportWordSelected;
		private DevExpress.XtraBars.BarButtonItem exportWordVisible;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
		protected DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
	}
}
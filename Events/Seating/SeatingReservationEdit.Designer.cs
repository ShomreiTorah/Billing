namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingReservationEdit {
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
			this.billingData = new ShomreiTorah.Billing.BillingData();
			this.seatingReservationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.NotesTextEdit = new DevExpress.XtraEditors.MemoEdit();
			this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
			this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
			this.pledgesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.pledgeTypeEdit = new DevExpress.XtraEditors.ComboBoxEdit();
			this.IdTextEdit = new DevExpress.XtraEditors.TextEdit();
			this.PledgeIdTextEdit = new DevExpress.XtraEditors.TextEdit();
			this.MensSeatsSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			this.WomensSeatsSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			this.BoysSeatsSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			this.GirlsSeatsSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			this.RowVersionPictureEdit = new DevExpress.XtraEditors.PictureEdit();
			this.StatusTextEdit = new DevExpress.XtraEditors.TextEdit();
			this.ItemForId = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForPledgeId = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForRowVersion = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.ItemForMensSeats = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForWomensSeats = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForBoysSeats = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForGirlsSeats = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForNotes = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForStatus = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.seatingReservationsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NotesTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
			this.dataLayoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeTypeEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.IdTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeIdTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MensSeatsSpinEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WomensSeatsSpinEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoysSeatsSpinEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GirlsSeatsSpinEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RowVersionPictureEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StatusTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPledgeId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForRowVersion)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForMensSeats)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForWomensSeats)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForBoysSeats)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForGirlsSeats)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForNotes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForStatus)).BeginInit();
			this.SuspendLayout();
			// 
			// billingData
			// 
			this.billingData.DataSetName = "BillingData";
			this.billingData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// seatingReservationsBindingSource
			// 
			this.seatingReservationsBindingSource.DataMember = "SeatingReservations";
			this.seatingReservationsBindingSource.DataSource = this.billingData;
			// 
			// NotesTextEdit
			// 
			this.NotesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "Notes", true));
			this.NotesTextEdit.Location = new System.Drawing.Point(465, 12);
			this.NotesTextEdit.Name = "NotesTextEdit";
			this.NotesTextEdit.Properties.NullValuePrompt = "Enter notes about the reservation (will not show on the bill)";
			this.NotesTextEdit.Properties.NullValuePromptShowForEmptyValue = true;
			this.NotesTextEdit.Size = new System.Drawing.Size(170, 68);
			this.NotesTextEdit.StyleController = this.dataLayoutControl1;
			this.NotesTextEdit.TabIndex = 7;
			// 
			// dataLayoutControl1
			// 
			this.dataLayoutControl1.Controls.Add(this.spinEdit1);
			this.dataLayoutControl1.Controls.Add(this.pledgeTypeEdit);
			this.dataLayoutControl1.Controls.Add(this.IdTextEdit);
			this.dataLayoutControl1.Controls.Add(this.PledgeIdTextEdit);
			this.dataLayoutControl1.Controls.Add(this.MensSeatsSpinEdit);
			this.dataLayoutControl1.Controls.Add(this.WomensSeatsSpinEdit);
			this.dataLayoutControl1.Controls.Add(this.BoysSeatsSpinEdit);
			this.dataLayoutControl1.Controls.Add(this.GirlsSeatsSpinEdit);
			this.dataLayoutControl1.Controls.Add(this.RowVersionPictureEdit);
			this.dataLayoutControl1.Controls.Add(this.NotesTextEdit);
			this.dataLayoutControl1.Controls.Add(this.StatusTextEdit);
			this.dataLayoutControl1.DataSource = this.seatingReservationsBindingSource;
			this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForId,
            this.ItemForPledgeId,
            this.ItemForRowVersion});
			this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
			this.dataLayoutControl1.Name = "dataLayoutControl1";
			this.dataLayoutControl1.OptionsFocus.AllowFocusControlOnLabelClick = true;
			this.dataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
			this.dataLayoutControl1.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
			this.dataLayoutControl1.Root = this.layoutControlGroup1;
			this.dataLayoutControl1.Size = new System.Drawing.Size(647, 92);
			this.dataLayoutControl1.TabIndex = 0;
			this.dataLayoutControl1.Text = "dataLayoutControl1";
			// 
			// spinEdit1
			// 
			this.spinEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Amount", true));
			this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.spinEdit1.Location = new System.Drawing.Point(89, 36);
			this.spinEdit1.Name = "spinEdit1";
			this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.spinEdit1.Properties.DisplayFormat.FormatString = "c";
			this.spinEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.spinEdit1.Properties.EditFormat.FormatString = "c";
			this.spinEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.spinEdit1.Properties.Mask.EditMask = "c";
			this.spinEdit1.Size = new System.Drawing.Size(96, 20);
			this.spinEdit1.StyleController = this.dataLayoutControl1;
			this.spinEdit1.TabIndex = 1;
			// 
			// pledgesBindingSource
			// 
			this.pledgesBindingSource.DataMember = "Pledges";
			this.pledgesBindingSource.DataSource = this.billingData;
			// 
			// pledgeTypeEdit
			// 
			this.pledgeTypeEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Type", true));
			this.pledgeTypeEdit.Location = new System.Drawing.Point(89, 12);
			this.pledgeTypeEdit.Name = "pledgeTypeEdit";
			this.pledgeTypeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pledgeTypeEdit.Properties.Items.AddRange(new object[] {
            "ימים נוראים Seating",
            "Membership",
            "Associate Membership"});
			this.pledgeTypeEdit.Size = new System.Drawing.Size(96, 20);
			this.pledgeTypeEdit.StyleController = this.dataLayoutControl1;
			this.pledgeTypeEdit.TabIndex = 0;
			// 
			// IdTextEdit
			// 
			this.IdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "Id", true));
			this.IdTextEdit.Location = new System.Drawing.Point(0, 0);
			this.IdTextEdit.Name = "IdTextEdit";
			this.IdTextEdit.Size = new System.Drawing.Size(0, 20);
			this.IdTextEdit.StyleController = this.dataLayoutControl1;
			this.IdTextEdit.TabIndex = 4;
			// 
			// PledgeIdTextEdit
			// 
			this.PledgeIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "PledgeId", true));
			this.PledgeIdTextEdit.Location = new System.Drawing.Point(0, 0);
			this.PledgeIdTextEdit.Name = "PledgeIdTextEdit";
			this.PledgeIdTextEdit.Size = new System.Drawing.Size(0, 20);
			this.PledgeIdTextEdit.StyleController = this.dataLayoutControl1;
			this.PledgeIdTextEdit.TabIndex = 5;
			// 
			// MensSeatsSpinEdit
			// 
			this.MensSeatsSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "MensSeats", true));
			this.MensSeatsSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.MensSeatsSpinEdit.Location = new System.Drawing.Point(266, 12);
			this.MensSeatsSpinEdit.Name = "MensSeatsSpinEdit";
			this.MensSeatsSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.MensSeatsSpinEdit.Properties.IsFloatValue = false;
			this.MensSeatsSpinEdit.Properties.Mask.EditMask = "N00";
			this.MensSeatsSpinEdit.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.MensSeatsSpinEdit.Size = new System.Drawing.Size(64, 20);
			this.MensSeatsSpinEdit.StyleController = this.dataLayoutControl1;
			this.MensSeatsSpinEdit.TabIndex = 2;
			// 
			// WomensSeatsSpinEdit
			// 
			this.WomensSeatsSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "WomensSeats", true));
			this.WomensSeatsSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.WomensSeatsSpinEdit.Location = new System.Drawing.Point(266, 36);
			this.WomensSeatsSpinEdit.Name = "WomensSeatsSpinEdit";
			this.WomensSeatsSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.WomensSeatsSpinEdit.Properties.IsFloatValue = false;
			this.WomensSeatsSpinEdit.Properties.Mask.EditMask = "N00";
			this.WomensSeatsSpinEdit.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.WomensSeatsSpinEdit.Size = new System.Drawing.Size(64, 20);
			this.WomensSeatsSpinEdit.StyleController = this.dataLayoutControl1;
			this.WomensSeatsSpinEdit.TabIndex = 3;
			// 
			// BoysSeatsSpinEdit
			// 
			this.BoysSeatsSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "BoysSeats", true));
			this.BoysSeatsSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.BoysSeatsSpinEdit.Location = new System.Drawing.Point(411, 12);
			this.BoysSeatsSpinEdit.Name = "BoysSeatsSpinEdit";
			this.BoysSeatsSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.BoysSeatsSpinEdit.Properties.IsFloatValue = false;
			this.BoysSeatsSpinEdit.Properties.Mask.EditMask = "N00";
			this.BoysSeatsSpinEdit.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.BoysSeatsSpinEdit.Size = new System.Drawing.Size(50, 20);
			this.BoysSeatsSpinEdit.StyleController = this.dataLayoutControl1;
			this.BoysSeatsSpinEdit.TabIndex = 4;
			// 
			// GirlsSeatsSpinEdit
			// 
			this.GirlsSeatsSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "GirlsSeats", true));
			this.GirlsSeatsSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.GirlsSeatsSpinEdit.Location = new System.Drawing.Point(411, 36);
			this.GirlsSeatsSpinEdit.Name = "GirlsSeatsSpinEdit";
			this.GirlsSeatsSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.GirlsSeatsSpinEdit.Properties.IsFloatValue = false;
			this.GirlsSeatsSpinEdit.Properties.Mask.EditMask = "N00";
			this.GirlsSeatsSpinEdit.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.GirlsSeatsSpinEdit.Size = new System.Drawing.Size(48, 20);
			this.GirlsSeatsSpinEdit.StyleController = this.dataLayoutControl1;
			this.GirlsSeatsSpinEdit.TabIndex = 5;
			// 
			// RowVersionPictureEdit
			// 
			this.RowVersionPictureEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "RowVersion", true));
			this.RowVersionPictureEdit.Location = new System.Drawing.Point(0, 0);
			this.RowVersionPictureEdit.Name = "RowVersionPictureEdit";
			this.RowVersionPictureEdit.Size = new System.Drawing.Size(0, 0);
			this.RowVersionPictureEdit.StyleController = this.dataLayoutControl1;
			this.RowVersionPictureEdit.TabIndex = 13;
			// 
			// StatusTextEdit
			// 
			this.StatusTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "Status", true));
			this.StatusTextEdit.Location = new System.Drawing.Point(89, 60);
			this.StatusTextEdit.Name = "StatusTextEdit";
			this.StatusTextEdit.Size = new System.Drawing.Size(96, 20);
			this.StatusTextEdit.StyleController = this.dataLayoutControl1;
			this.StatusTextEdit.TabIndex = 6;
			// 
			// ItemForId
			// 
			this.ItemForId.Control = this.IdTextEdit;
			this.ItemForId.CustomizationFormText = "Id";
			this.ItemForId.Location = new System.Drawing.Point(0, 0);
			this.ItemForId.Name = "ItemForId";
			this.ItemForId.Size = new System.Drawing.Size(0, 0);
			this.ItemForId.Text = "Id";
			this.ItemForId.TextSize = new System.Drawing.Size(50, 20);
			this.ItemForId.TextToControlDistance = 5;
			// 
			// ItemForPledgeId
			// 
			this.ItemForPledgeId.Control = this.PledgeIdTextEdit;
			this.ItemForPledgeId.CustomizationFormText = "Pledge Id";
			this.ItemForPledgeId.Location = new System.Drawing.Point(0, 0);
			this.ItemForPledgeId.Name = "ItemForPledgeId";
			this.ItemForPledgeId.Size = new System.Drawing.Size(0, 0);
			this.ItemForPledgeId.Text = "Pledge Id";
			this.ItemForPledgeId.TextSize = new System.Drawing.Size(50, 20);
			this.ItemForPledgeId.TextToControlDistance = 5;
			// 
			// ItemForRowVersion
			// 
			this.ItemForRowVersion.Control = this.RowVersionPictureEdit;
			this.ItemForRowVersion.CustomizationFormText = "Row Version";
			this.ItemForRowVersion.Location = new System.Drawing.Point(0, 0);
			this.ItemForRowVersion.Name = "ItemForRowVersion";
			this.ItemForRowVersion.Size = new System.Drawing.Size(0, 0);
			this.ItemForRowVersion.Text = "Row Version";
			this.ItemForRowVersion.TextSize = new System.Drawing.Size(50, 20);
			this.ItemForRowVersion.TextToControlDistance = 5;
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "Root";
			this.layoutControlGroup1.Size = new System.Drawing.Size(647, 92);
			this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Text = "Root";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlGroup2
			// 
			this.layoutControlGroup2.AllowDrawBackground = false;
			this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
			this.layoutControlGroup2.GroupBordersVisible = false;
			this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForMensSeats,
            this.ItemForWomensSeats,
            this.ItemForBoysSeats,
            this.ItemForGirlsSeats,
            this.ItemForNotes,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.ItemForStatus});
			this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup2.Name = "autoGeneratedGroup0";
			this.layoutControlGroup2.Size = new System.Drawing.Size(627, 72);
			this.layoutControlGroup2.Text = "autoGeneratedGroup0";
			// 
			// ItemForMensSeats
			// 
			this.ItemForMensSeats.Control = this.MensSeatsSpinEdit;
			this.ItemForMensSeats.CustomizationFormText = "Mens Seats";
			this.ItemForMensSeats.Location = new System.Drawing.Point(177, 0);
			this.ItemForMensSeats.MaxSize = new System.Drawing.Size(145, 24);
			this.ItemForMensSeats.MinSize = new System.Drawing.Size(145, 24);
			this.ItemForMensSeats.Name = "ItemForMensSeats";
			this.ItemForMensSeats.Size = new System.Drawing.Size(145, 24);
			this.ItemForMensSeats.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.ItemForMensSeats.Text = "Men\'s Seats";
			this.ItemForMensSeats.TextSize = new System.Drawing.Size(73, 13);
			// 
			// ItemForWomensSeats
			// 
			this.ItemForWomensSeats.Control = this.WomensSeatsSpinEdit;
			this.ItemForWomensSeats.CustomizationFormText = "Womens Seats";
			this.ItemForWomensSeats.Location = new System.Drawing.Point(177, 24);
			this.ItemForWomensSeats.Name = "ItemForWomensSeats";
			this.ItemForWomensSeats.Size = new System.Drawing.Size(145, 48);
			this.ItemForWomensSeats.Text = "Women\'s Seats";
			this.ItemForWomensSeats.TextSize = new System.Drawing.Size(73, 13);
			// 
			// ItemForBoysSeats
			// 
			this.ItemForBoysSeats.Control = this.BoysSeatsSpinEdit;
			this.ItemForBoysSeats.CustomizationFormText = "Boys\' Seats";
			this.ItemForBoysSeats.Location = new System.Drawing.Point(322, 0);
			this.ItemForBoysSeats.Name = "ItemForBoysSeats";
			this.ItemForBoysSeats.Size = new System.Drawing.Size(131, 24);
			this.ItemForBoysSeats.Text = "Boys\' Seats";
			this.ItemForBoysSeats.TextSize = new System.Drawing.Size(73, 13);
			// 
			// ItemForGirlsSeats
			// 
			this.ItemForGirlsSeats.Control = this.GirlsSeatsSpinEdit;
			this.ItemForGirlsSeats.CustomizationFormText = "Girls\' Seats";
			this.ItemForGirlsSeats.Location = new System.Drawing.Point(322, 24);
			this.ItemForGirlsSeats.MaxSize = new System.Drawing.Size(129, 24);
			this.ItemForGirlsSeats.MinSize = new System.Drawing.Size(129, 24);
			this.ItemForGirlsSeats.Name = "ItemForGirlsSeats";
			this.ItemForGirlsSeats.Size = new System.Drawing.Size(131, 48);
			this.ItemForGirlsSeats.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.ItemForGirlsSeats.Text = "Girls\' Seats";
			this.ItemForGirlsSeats.TextSize = new System.Drawing.Size(73, 13);
			// 
			// ItemForNotes
			// 
			this.ItemForNotes.Control = this.NotesTextEdit;
			this.ItemForNotes.CustomizationFormText = "Notes";
			this.ItemForNotes.Location = new System.Drawing.Point(453, 0);
			this.ItemForNotes.Name = "ItemForNotes";
			this.ItemForNotes.Size = new System.Drawing.Size(174, 72);
			this.ItemForNotes.Text = "Notes";
			this.ItemForNotes.TextSize = new System.Drawing.Size(0, 0);
			this.ItemForNotes.TextToControlDistance = 0;
			this.ItemForNotes.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.pledgeTypeEdit;
			this.layoutControlItem1.CustomizationFormText = "Pledge Type";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(177, 24);
			this.layoutControlItem1.Text = "Pledge Type";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 13);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.spinEdit1;
			this.layoutControlItem2.CustomizationFormText = "Amount";
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(177, 24);
			this.layoutControlItem2.Text = "Amount";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(73, 13);
			// 
			// ItemForStatus
			// 
			this.ItemForStatus.Control = this.StatusTextEdit;
			this.ItemForStatus.CustomizationFormText = "Status";
			this.ItemForStatus.Location = new System.Drawing.Point(0, 48);
			this.ItemForStatus.Name = "ItemForStatus";
			this.ItemForStatus.Size = new System.Drawing.Size(177, 24);
			this.ItemForStatus.Text = "Status";
			this.ItemForStatus.TextSize = new System.Drawing.Size(73, 13);
			// 
			// SeatingReservationEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dataLayoutControl1);
			this.Name = "SeatingReservationEdit";
			this.Size = new System.Drawing.Size(647, 92);
			((System.ComponentModel.ISupportInitialize)(this.billingData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.seatingReservationsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NotesTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
			this.dataLayoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeTypeEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.IdTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeIdTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MensSeatsSpinEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WomensSeatsSpinEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoysSeatsSpinEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GirlsSeatsSpinEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RowVersionPictureEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StatusTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPledgeId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForRowVersion)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForMensSeats)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForWomensSeats)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForBoysSeats)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForGirlsSeats)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForNotes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForStatus)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource seatingReservationsBindingSource;
		private BillingData billingData;
		private DevExpress.XtraEditors.MemoEdit NotesTextEdit;
		private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
		private DevExpress.XtraEditors.TextEdit IdTextEdit;
		private DevExpress.XtraEditors.TextEdit PledgeIdTextEdit;
		private DevExpress.XtraEditors.SpinEdit MensSeatsSpinEdit;
		private DevExpress.XtraEditors.SpinEdit WomensSeatsSpinEdit;
		private DevExpress.XtraEditors.SpinEdit BoysSeatsSpinEdit;
		private DevExpress.XtraEditors.SpinEdit GirlsSeatsSpinEdit;
		private DevExpress.XtraEditors.TextEdit StatusTextEdit;
		private DevExpress.XtraEditors.PictureEdit RowVersionPictureEdit;
		private DevExpress.XtraLayout.LayoutControlItem ItemForId;
		private DevExpress.XtraLayout.LayoutControlItem ItemForPledgeId;
		private DevExpress.XtraLayout.LayoutControlItem ItemForRowVersion;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
		private DevExpress.XtraLayout.LayoutControlItem ItemForMensSeats;
		private DevExpress.XtraLayout.LayoutControlItem ItemForWomensSeats;
		private DevExpress.XtraLayout.LayoutControlItem ItemForStatus;
		private DevExpress.XtraLayout.LayoutControlItem ItemForNotes;
		private DevExpress.XtraLayout.LayoutControlItem ItemForBoysSeats;
		private DevExpress.XtraLayout.LayoutControlItem ItemForGirlsSeats;
		private DevExpress.XtraEditors.SpinEdit spinEdit1;
		private System.Windows.Forms.BindingSource pledgesBindingSource;
		private DevExpress.XtraEditors.ComboBoxEdit pledgeTypeEdit;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
	}
}

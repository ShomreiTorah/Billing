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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatingReservationEdit));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			this.billingData = new ShomreiTorah.Data.UI.FrameworkBindingSource();
			this.seatingReservationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.NotesTextEdit = new DevExpress.XtraEditors.MemoEdit();
			this.layoutControl = new DevExpress.XtraDataLayout.DataLayoutControl();
			this.amountEditor = new DevExpress.XtraEditors.SpinEdit();
			this.pledgesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.pledgeTypeEditor = new DevExpress.XtraEditors.ComboBoxEdit();
			this.IdTextEdit = new DevExpress.XtraEditors.TextEdit();
			this.PledgeIdTextEdit = new DevExpress.XtraEditors.TextEdit();
			this.MensSeatsSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			this.WomensSeatsSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			this.BoysSeatsSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			this.GirlsSeatsSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			this.RowVersionPictureEdit = new DevExpress.XtraEditors.PictureEdit();
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
			((System.ComponentModel.ISupportInitialize)(this.billingData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.seatingReservationsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NotesTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
			this.layoutControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.amountEditor.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeTypeEditor.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.IdTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeIdTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MensSeatsSpinEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WomensSeatsSpinEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoysSeatsSpinEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GirlsSeatsSpinEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RowVersionPictureEdit.Properties)).BeginInit();
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
			this.SuspendLayout();
			// 
			// seatingReservationsBindingSource
			// 
			this.seatingReservationsBindingSource.DataMember = "SeatingReservations";
			this.seatingReservationsBindingSource.DataSource = this.billingData;
			// 
			// NotesTextEdit
			// 
			this.NotesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "Notes", true));
			this.NotesTextEdit.Location = new System.Drawing.Point(488, 12);
			this.NotesTextEdit.Name = "NotesTextEdit";
			this.NotesTextEdit.Properties.NullValuePrompt = "Enter notes about the reservation (will not show on the bill)";
			this.NotesTextEdit.Properties.NullValuePromptShowForEmptyValue = true;
			this.NotesTextEdit.Size = new System.Drawing.Size(147, 44);
			this.NotesTextEdit.StyleController = this.layoutControl;
			this.NotesTextEdit.TabIndex = 6;
			// 
			// layoutControl
			// 
			this.layoutControl.Controls.Add(this.amountEditor);
			this.layoutControl.Controls.Add(this.pledgeTypeEditor);
			this.layoutControl.Controls.Add(this.IdTextEdit);
			this.layoutControl.Controls.Add(this.PledgeIdTextEdit);
			this.layoutControl.Controls.Add(this.MensSeatsSpinEdit);
			this.layoutControl.Controls.Add(this.WomensSeatsSpinEdit);
			this.layoutControl.Controls.Add(this.BoysSeatsSpinEdit);
			this.layoutControl.Controls.Add(this.GirlsSeatsSpinEdit);
			this.layoutControl.Controls.Add(this.RowVersionPictureEdit);
			this.layoutControl.Controls.Add(this.NotesTextEdit);
			this.layoutControl.DataSource = this.seatingReservationsBindingSource;
			this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForId,
            this.ItemForPledgeId,
            this.ItemForRowVersion});
			this.layoutControl.Location = new System.Drawing.Point(0, 0);
			this.layoutControl.Name = "layoutControl";
			this.layoutControl.OptionsFocus.AllowFocusControlOnLabelClick = true;
			this.layoutControl.OptionsFocus.EnableAutoTabOrder = false;
			this.layoutControl.OptionsItemText.TextAlignMode = DevExpress.XtraLayout.TextAlignMode.AlignInGroups;
			this.layoutControl.Root = this.layoutControlGroup1;
			this.layoutControl.Size = new System.Drawing.Size(647, 68);
			this.layoutControl.TabIndex = 0;
			this.layoutControl.Text = "dataLayoutControl1";
			// 
			// amountEditor
			// 
			this.amountEditor.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Amount", true));
			this.amountEditor.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.amountEditor.Location = new System.Drawing.Point(89, 36);
			this.amountEditor.Name = "amountEditor";
			toolTipTitleItem1.Text = "Recalculate Price";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Recalculates the price of this seating reservation based on the pledge type and n" +
				"umber of seats reserved.";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.amountEditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("amountEditor.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Recalculate Price", null, superToolTip1, true)});
			this.amountEditor.Properties.DisplayFormat.FormatString = "c";
			this.amountEditor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amountEditor.Properties.EditFormat.FormatString = "c";
			this.amountEditor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amountEditor.Properties.Mask.EditMask = "c";
			this.amountEditor.Size = new System.Drawing.Size(119, 20);
			this.amountEditor.StyleController = this.layoutControl;
			this.amountEditor.TabIndex = 5;
			this.amountEditor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.amountEditor_ButtonClick);
			this.amountEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// pledgesBindingSource
			// 
			this.pledgesBindingSource.DataMember = "Pledges";
			this.pledgesBindingSource.DataSource = this.billingData;
			// 
			// pledgeTypeEditor
			// 
			this.pledgeTypeEditor.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.pledgesBindingSource, "Type", true));
			this.pledgeTypeEditor.Location = new System.Drawing.Point(89, 12);
			this.pledgeTypeEditor.Name = "pledgeTypeEditor";
			this.pledgeTypeEditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.pledgeTypeEditor.Properties.Items.AddRange(new object[] {
            "ימים נוראים Seats",
            "Membership",
            "Associate Membership"});
			this.pledgeTypeEditor.Size = new System.Drawing.Size(119, 20);
			this.pledgeTypeEditor.StyleController = this.layoutControl;
			this.pledgeTypeEditor.TabIndex = 0;
			this.pledgeTypeEditor.EditValueChanged += new System.EventHandler(this.Edit_EditValueChanged);
			this.pledgeTypeEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// IdTextEdit
			// 
			this.IdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "Id", true));
			this.IdTextEdit.Location = new System.Drawing.Point(0, 0);
			this.IdTextEdit.Name = "IdTextEdit";
			this.IdTextEdit.Size = new System.Drawing.Size(0, 20);
			this.IdTextEdit.StyleController = this.layoutControl;
			this.IdTextEdit.TabIndex = 4;
			// 
			// PledgeIdTextEdit
			// 
			this.PledgeIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "PledgeId", true));
			this.PledgeIdTextEdit.Location = new System.Drawing.Point(0, 0);
			this.PledgeIdTextEdit.Name = "PledgeIdTextEdit";
			this.PledgeIdTextEdit.Size = new System.Drawing.Size(0, 20);
			this.PledgeIdTextEdit.StyleController = this.layoutControl;
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
			this.MensSeatsSpinEdit.Location = new System.Drawing.Point(289, 12);
			this.MensSeatsSpinEdit.Name = "MensSeatsSpinEdit";
			this.MensSeatsSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.MensSeatsSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
			this.MensSeatsSpinEdit.Properties.IsFloatValue = false;
			this.MensSeatsSpinEdit.Properties.Mask.EditMask = "N00";
			this.MensSeatsSpinEdit.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.MensSeatsSpinEdit.Size = new System.Drawing.Size(64, 20);
			this.MensSeatsSpinEdit.StyleController = this.layoutControl;
			this.MensSeatsSpinEdit.TabIndex = 1;
			this.MensSeatsSpinEdit.EditValueChanged += new System.EventHandler(this.Edit_EditValueChanged);
			this.MensSeatsSpinEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// WomensSeatsSpinEdit
			// 
			this.WomensSeatsSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "WomensSeats", true));
			this.WomensSeatsSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.WomensSeatsSpinEdit.Location = new System.Drawing.Point(289, 36);
			this.WomensSeatsSpinEdit.Name = "WomensSeatsSpinEdit";
			this.WomensSeatsSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.WomensSeatsSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
			this.WomensSeatsSpinEdit.Properties.IsFloatValue = false;
			this.WomensSeatsSpinEdit.Properties.Mask.EditMask = "N00";
			this.WomensSeatsSpinEdit.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.WomensSeatsSpinEdit.Size = new System.Drawing.Size(64, 20);
			this.WomensSeatsSpinEdit.StyleController = this.layoutControl;
			this.WomensSeatsSpinEdit.TabIndex = 3;
			this.WomensSeatsSpinEdit.EditValueChanged += new System.EventHandler(this.Edit_EditValueChanged);
			this.WomensSeatsSpinEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// BoysSeatsSpinEdit
			// 
			this.BoysSeatsSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "BoysSeats", true));
			this.BoysSeatsSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.BoysSeatsSpinEdit.Location = new System.Drawing.Point(434, 12);
			this.BoysSeatsSpinEdit.Name = "BoysSeatsSpinEdit";
			this.BoysSeatsSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.BoysSeatsSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
			this.BoysSeatsSpinEdit.Properties.IsFloatValue = false;
			this.BoysSeatsSpinEdit.Properties.Mask.EditMask = "N00";
			this.BoysSeatsSpinEdit.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.BoysSeatsSpinEdit.Size = new System.Drawing.Size(50, 20);
			this.BoysSeatsSpinEdit.StyleController = this.layoutControl;
			this.BoysSeatsSpinEdit.TabIndex = 2;
			this.BoysSeatsSpinEdit.EditValueChanged += new System.EventHandler(this.Edit_EditValueChanged);
			this.BoysSeatsSpinEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// GirlsSeatsSpinEdit
			// 
			this.GirlsSeatsSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "GirlsSeats", true));
			this.GirlsSeatsSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.GirlsSeatsSpinEdit.Location = new System.Drawing.Point(434, 36);
			this.GirlsSeatsSpinEdit.Name = "GirlsSeatsSpinEdit";
			this.GirlsSeatsSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.GirlsSeatsSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
			this.GirlsSeatsSpinEdit.Properties.IsFloatValue = false;
			this.GirlsSeatsSpinEdit.Properties.Mask.EditMask = "N00";
			this.GirlsSeatsSpinEdit.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.GirlsSeatsSpinEdit.Size = new System.Drawing.Size(48, 20);
			this.GirlsSeatsSpinEdit.StyleController = this.layoutControl;
			this.GirlsSeatsSpinEdit.TabIndex = 4;
			this.GirlsSeatsSpinEdit.EditValueChanged += new System.EventHandler(this.Edit_EditValueChanged);
			this.GirlsSeatsSpinEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// RowVersionPictureEdit
			// 
			this.RowVersionPictureEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.seatingReservationsBindingSource, "RowVersion", true));
			this.RowVersionPictureEdit.Location = new System.Drawing.Point(0, 0);
			this.RowVersionPictureEdit.Name = "RowVersionPictureEdit";
			this.RowVersionPictureEdit.Size = new System.Drawing.Size(0, 0);
			this.RowVersionPictureEdit.StyleController = this.layoutControl;
			this.RowVersionPictureEdit.TabIndex = 13;
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
			this.layoutControlGroup1.Size = new System.Drawing.Size(647, 68);
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
            this.layoutControlItem2});
			this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup2.Name = "autoGeneratedGroup0";
			this.layoutControlGroup2.Size = new System.Drawing.Size(627, 48);
			this.layoutControlGroup2.Text = "autoGeneratedGroup0";
			// 
			// ItemForMensSeats
			// 
			this.ItemForMensSeats.Control = this.MensSeatsSpinEdit;
			this.ItemForMensSeats.CustomizationFormText = "Mens Seats";
			this.ItemForMensSeats.Location = new System.Drawing.Point(200, 0);
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
			this.ItemForWomensSeats.Location = new System.Drawing.Point(200, 24);
			this.ItemForWomensSeats.Name = "ItemForWomensSeats";
			this.ItemForWomensSeats.Size = new System.Drawing.Size(145, 24);
			this.ItemForWomensSeats.Text = "Women\'s Seats";
			this.ItemForWomensSeats.TextSize = new System.Drawing.Size(73, 13);
			// 
			// ItemForBoysSeats
			// 
			this.ItemForBoysSeats.Control = this.BoysSeatsSpinEdit;
			this.ItemForBoysSeats.CustomizationFormText = "Boys\' Seats";
			this.ItemForBoysSeats.Location = new System.Drawing.Point(345, 0);
			this.ItemForBoysSeats.Name = "ItemForBoysSeats";
			this.ItemForBoysSeats.Size = new System.Drawing.Size(131, 24);
			this.ItemForBoysSeats.Text = "Boys\' Seats";
			this.ItemForBoysSeats.TextSize = new System.Drawing.Size(73, 13);
			// 
			// ItemForGirlsSeats
			// 
			this.ItemForGirlsSeats.Control = this.GirlsSeatsSpinEdit;
			this.ItemForGirlsSeats.CustomizationFormText = "Girls\' Seats";
			this.ItemForGirlsSeats.Location = new System.Drawing.Point(345, 24);
			this.ItemForGirlsSeats.MaxSize = new System.Drawing.Size(129, 24);
			this.ItemForGirlsSeats.MinSize = new System.Drawing.Size(129, 24);
			this.ItemForGirlsSeats.Name = "ItemForGirlsSeats";
			this.ItemForGirlsSeats.Size = new System.Drawing.Size(131, 24);
			this.ItemForGirlsSeats.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.ItemForGirlsSeats.Text = "Girls\' Seats";
			this.ItemForGirlsSeats.TextSize = new System.Drawing.Size(73, 13);
			// 
			// ItemForNotes
			// 
			this.ItemForNotes.Control = this.NotesTextEdit;
			this.ItemForNotes.CustomizationFormText = "Notes";
			this.ItemForNotes.Location = new System.Drawing.Point(476, 0);
			this.ItemForNotes.Name = "ItemForNotes";
			this.ItemForNotes.Size = new System.Drawing.Size(151, 48);
			this.ItemForNotes.Text = "Notes";
			this.ItemForNotes.TextSize = new System.Drawing.Size(0, 0);
			this.ItemForNotes.TextToControlDistance = 0;
			this.ItemForNotes.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.pledgeTypeEditor;
			this.layoutControlItem1.CustomizationFormText = "Pledge Type";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.MaxSize = new System.Drawing.Size(200, 24);
			this.layoutControlItem1.MinSize = new System.Drawing.Size(200, 24);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(200, 24);
			this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem1.Text = "Pledge Type";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 13);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.amountEditor;
			this.layoutControlItem2.CustomizationFormText = "Amount";
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(200, 24);
			this.layoutControlItem2.Text = "Amount";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(73, 13);
			// 
			// SeatingReservationEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.layoutControl);
			this.Name = "SeatingReservationEdit";
			this.Size = new System.Drawing.Size(647, 68);
			((System.ComponentModel.ISupportInitialize)(this.billingData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.seatingReservationsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NotesTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
			this.layoutControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.amountEditor.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeTypeEditor.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.IdTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeIdTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MensSeatsSpinEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WomensSeatsSpinEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoysSeatsSpinEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GirlsSeatsSpinEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RowVersionPictureEdit.Properties)).EndInit();
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
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource seatingReservationsBindingSource;
		private ShomreiTorah.Data.UI.FrameworkBindingSource billingData;
		private DevExpress.XtraEditors.MemoEdit NotesTextEdit;
		private DevExpress.XtraDataLayout.DataLayoutControl layoutControl;
		private DevExpress.XtraEditors.TextEdit IdTextEdit;
		private DevExpress.XtraEditors.TextEdit PledgeIdTextEdit;
		private DevExpress.XtraEditors.SpinEdit MensSeatsSpinEdit;
		private DevExpress.XtraEditors.SpinEdit WomensSeatsSpinEdit;
		private DevExpress.XtraEditors.SpinEdit BoysSeatsSpinEdit;
		private DevExpress.XtraEditors.SpinEdit GirlsSeatsSpinEdit;
		private DevExpress.XtraEditors.PictureEdit RowVersionPictureEdit;
		private DevExpress.XtraLayout.LayoutControlItem ItemForId;
		private DevExpress.XtraLayout.LayoutControlItem ItemForPledgeId;
		private DevExpress.XtraLayout.LayoutControlItem ItemForRowVersion;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
		private DevExpress.XtraLayout.LayoutControlItem ItemForMensSeats;
		private DevExpress.XtraLayout.LayoutControlItem ItemForWomensSeats;
		private DevExpress.XtraLayout.LayoutControlItem ItemForNotes;
		private DevExpress.XtraLayout.LayoutControlItem ItemForBoysSeats;
		private DevExpress.XtraLayout.LayoutControlItem ItemForGirlsSeats;
		private DevExpress.XtraEditors.SpinEdit amountEditor;
		private System.Windows.Forms.BindingSource pledgesBindingSource;
		private DevExpress.XtraEditors.ComboBoxEdit pledgeTypeEditor;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
	}
}

namespace AD_CW_1.Forms.Admin
{
    partial class ManageJobModal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCustomerPhone = new MaterialSkin.Controls.MaterialTextBox();
            this.jobInformations = new System.Windows.Forms.GroupBox();
            this.lblDeliveryLocation = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.lblPickupLocation = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.lblDate = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.lblJobStatus = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.lblJobNumber = new MaterialSkin.Controls.MaterialLabel();
            this.JobNumber = new MaterialSkin.Controls.MaterialLabel();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustomerPhone = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            this.lblCustomerEmail = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.lblCustomerName = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbTruck = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbTransportUnit = new MaterialSkin.Controls.MaterialComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.materialButton5 = new MaterialSkin.Controls.MaterialButton();
            this.txtVolume = new MaterialSkin.Controls.MaterialTextBox();
            this.txtWeight = new MaterialSkin.Controls.MaterialTextBox();
            this.mlvLoads = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton4 = new MaterialSkin.Controls.MaterialButton();
            this.materialComboBox2 = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.mlvProducts = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblEstimatedCost = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotalVolume = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel18 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotalWeight = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel20 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton6 = new MaterialSkin.Controls.MaterialButton();
            this.materialComboBox4 = new MaterialSkin.Controls.MaterialComboBox();
            this.jobInformations.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.AnimateReadOnly = false;
            this.txtCustomerPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerPhone.Depth = 0;
            this.txtCustomerPhone.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerPhone.Hint = "Customer Phone";
            this.txtCustomerPhone.LeadingIcon = null;
            this.txtCustomerPhone.Location = new System.Drawing.Point(844, 162);
            this.txtCustomerPhone.MaxLength = 50;
            this.txtCustomerPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerPhone.Multiline = false;
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(288, 50);
            this.txtCustomerPhone.TabIndex = 6;
            this.txtCustomerPhone.Text = "";
            this.txtCustomerPhone.TrailingIcon = null;
            // 
            // jobInformations
            // 
            this.jobInformations.Controls.Add(this.lblDeliveryLocation);
            this.jobInformations.Controls.Add(this.materialLabel8);
            this.jobInformations.Controls.Add(this.lblPickupLocation);
            this.jobInformations.Controls.Add(this.materialLabel6);
            this.jobInformations.Controls.Add(this.lblDate);
            this.jobInformations.Controls.Add(this.materialLabel4);
            this.jobInformations.Controls.Add(this.lblJobStatus);
            this.jobInformations.Controls.Add(this.materialLabel2);
            this.jobInformations.Controls.Add(this.lblJobNumber);
            this.jobInformations.Controls.Add(this.JobNumber);
            this.jobInformations.Controls.Add(this.txtCustomerPhone);
            this.jobInformations.Location = new System.Drawing.Point(25, 92);
            this.jobInformations.Name = "jobInformations";
            this.jobInformations.Size = new System.Drawing.Size(409, 208);
            this.jobInformations.TabIndex = 8;
            this.jobInformations.TabStop = false;
            this.jobInformations.Text = "Job Informations";
            // 
            // lblDeliveryLocation
            // 
            this.lblDeliveryLocation.AutoSize = true;
            this.lblDeliveryLocation.Depth = 0;
            this.lblDeliveryLocation.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDeliveryLocation.Location = new System.Drawing.Point(160, 164);
            this.lblDeliveryLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDeliveryLocation.Name = "lblDeliveryLocation";
            this.lblDeliveryLocation.Size = new System.Drawing.Size(52, 19);
            this.lblDeliveryLocation.TabIndex = 16;
            this.lblDeliveryLocation.Text = "Matara";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.Location = new System.Drawing.Point(9, 164);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(131, 19);
            this.materialLabel8.TabIndex = 15;
            this.materialLabel8.Text = "Delivery Location :";
            // 
            // lblPickupLocation
            // 
            this.lblPickupLocation.AutoSize = true;
            this.lblPickupLocation.Depth = 0;
            this.lblPickupLocation.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPickupLocation.Location = new System.Drawing.Point(160, 135);
            this.lblPickupLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPickupLocation.Name = "lblPickupLocation";
            this.lblPickupLocation.Size = new System.Drawing.Size(37, 19);
            this.lblPickupLocation.TabIndex = 14;
            this.lblPickupLocation.Text = "Galle";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(9, 135);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(123, 19);
            this.materialLabel6.TabIndex = 13;
            this.materialLabel6.Text = "Pickup Location :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Depth = 0;
            this.lblDate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDate.Location = new System.Drawing.Point(160, 102);
            this.lblDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(87, 19);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "02/12/2025";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(9, 102);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(42, 19);
            this.materialLabel4.TabIndex = 11;
            this.materialLabel4.Text = "Date :";
            // 
            // lblJobStatus
            // 
            this.lblJobStatus.AutoSize = true;
            this.lblJobStatus.Depth = 0;
            this.lblJobStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblJobStatus.Location = new System.Drawing.Point(160, 68);
            this.lblJobStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblJobStatus.Name = "lblJobStatus";
            this.lblJobStatus.Size = new System.Drawing.Size(75, 19);
            this.lblJobStatus.TabIndex = 10;
            this.lblJobStatus.Text = "Confirmed";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(9, 68);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(86, 19);
            this.materialLabel2.TabIndex = 9;
            this.materialLabel2.Text = "Job Status :";
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.AutoSize = true;
            this.lblJobNumber.Depth = 0;
            this.lblJobNumber.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblJobNumber.Location = new System.Drawing.Point(160, 35);
            this.lblJobNumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Size = new System.Drawing.Size(64, 19);
            this.lblJobNumber.TabIndex = 8;
            this.lblJobNumber.Text = "J784545";
            // 
            // JobNumber
            // 
            this.JobNumber.AutoSize = true;
            this.JobNumber.Depth = 0;
            this.JobNumber.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.JobNumber.Location = new System.Drawing.Point(9, 35);
            this.JobNumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.JobNumber.Name = "JobNumber";
            this.JobNumber.Size = new System.Drawing.Size(96, 19);
            this.JobNumber.TabIndex = 7;
            this.JobNumber.Text = "Job Number :";
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(805, 120);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(199, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Assign Transport Unit";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCustomerPhone);
            this.groupBox1.Controls.Add(this.materialLabel16);
            this.groupBox1.Controls.Add(this.lblCustomerEmail);
            this.groupBox1.Controls.Add(this.materialLabel14);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Controls.Add(this.materialLabel10);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cmbTruck);
            this.groupBox1.Location = new System.Drawing.Point(25, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 137);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Informations";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Depth = 0;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCustomerPhone.Location = new System.Drawing.Point(160, 91);
            this.lblCustomerPhone.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(91, 19);
            this.lblCustomerPhone.TabIndex = 22;
            this.lblCustomerPhone.Text = "0774544965";
            // 
            // materialLabel16
            // 
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.Depth = 0;
            this.materialLabel16.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel16.Location = new System.Drawing.Point(9, 91);
            this.materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(54, 19);
            this.materialLabel16.TabIndex = 21;
            this.materialLabel16.Text = "Phone :";
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Depth = 0;
            this.lblCustomerEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCustomerEmail.Location = new System.Drawing.Point(160, 62);
            this.lblCustomerEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(115, 19);
            this.lblCustomerEmail.TabIndex = 20;
            this.lblCustomerEmail.Text = "Nadun@na.com";
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel14.Location = new System.Drawing.Point(9, 62);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(49, 19);
            this.materialLabel14.TabIndex = 19;
            this.materialLabel14.Text = "Email :";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Depth = 0;
            this.lblCustomerName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCustomerName.Location = new System.Drawing.Point(160, 32);
            this.lblCustomerName.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(48, 19);
            this.lblCustomerName.TabIndex = 18;
            this.lblCustomerName.Text = "Nadun";
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel10.Location = new System.Drawing.Point(9, 32);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(51, 19);
            this.materialLabel10.TabIndex = 17;
            this.materialLabel10.Text = "Name :";
            // 
            // cmbTruck
            // 
            this.cmbTruck.AutoResize = false;
            this.cmbTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbTruck.Depth = 0;
            this.cmbTruck.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTruck.DropDownHeight = 174;
            this.cmbTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTruck.DropDownWidth = 121;
            this.cmbTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbTruck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbTruck.FormattingEnabled = true;
            this.cmbTruck.Hint = "Transport Unit";
            this.cmbTruck.IntegralHeight = false;
            this.cmbTruck.ItemHeight = 43;
            this.cmbTruck.Location = new System.Drawing.Point(733, 41);
            this.cmbTruck.MaxDropDownItems = 4;
            this.cmbTruck.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbTruck.Name = "cmbTruck";
            this.cmbTruck.Size = new System.Drawing.Size(271, 49);
            this.cmbTruck.StartIndex = 0;
            this.cmbTruck.TabIndex = 11;
            // 
            // cmbTransportUnit
            // 
            this.cmbTransportUnit.AutoResize = false;
            this.cmbTransportUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbTransportUnit.Depth = 0;
            this.cmbTransportUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTransportUnit.DropDownHeight = 174;
            this.cmbTransportUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransportUnit.DropDownWidth = 121;
            this.cmbTransportUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbTransportUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbTransportUnit.FormattingEnabled = true;
            this.cmbTransportUnit.Hint = "Transport Unit";
            this.cmbTransportUnit.IntegralHeight = false;
            this.cmbTransportUnit.ItemHeight = 43;
            this.cmbTransportUnit.Location = new System.Drawing.Point(39, 41);
            this.cmbTransportUnit.MaxDropDownItems = 4;
            this.cmbTransportUnit.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbTransportUnit.Name = "cmbTransportUnit";
            this.cmbTransportUnit.Size = new System.Drawing.Size(329, 49);
            this.cmbTransportUnit.StartIndex = 0;
            this.cmbTransportUnit.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.materialButton5);
            this.groupBox2.Controls.Add(this.txtVolume);
            this.groupBox2.Controls.Add(this.txtWeight);
            this.groupBox2.Controls.Add(this.mlvLoads);
            this.groupBox2.Location = new System.Drawing.Point(460, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(738, 253);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Load Informations";
            // 
            // materialButton5
            // 
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton5.Depth = 0;
            this.materialButton5.HighEmphasis = true;
            this.materialButton5.Icon = null;
            this.materialButton5.Location = new System.Drawing.Point(647, 52);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton5.Size = new System.Drawing.Size(64, 36);
            this.materialButton5.TabIndex = 14;
            this.materialButton5.Text = "Load";
            this.materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton5.UseAccentColor = false;
            this.materialButton5.UseVisualStyleBackColor = true;
            this.materialButton5.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtVolume
            // 
            this.txtVolume.AnimateReadOnly = false;
            this.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVolume.Depth = 0;
            this.txtVolume.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtVolume.Hint = "Volume";
            this.txtVolume.LeadingIcon = null;
            this.txtVolume.Location = new System.Drawing.Point(477, 43);
            this.txtVolume.MaxLength = 50;
            this.txtVolume.MouseState = MaterialSkin.MouseState.OUT;
            this.txtVolume.Multiline = false;
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(154, 50);
            this.txtVolume.TabIndex = 2;
            this.txtVolume.Text = "";
            this.txtVolume.TrailingIcon = null;
            // 
            // txtWeight
            // 
            this.txtWeight.AnimateReadOnly = false;
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWeight.Depth = 0;
            this.txtWeight.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtWeight.Hint = "Weight";
            this.txtWeight.LeadingIcon = null;
            this.txtWeight.Location = new System.Drawing.Point(302, 43);
            this.txtWeight.MaxLength = 50;
            this.txtWeight.MouseState = MaterialSkin.MouseState.OUT;
            this.txtWeight.Multiline = false;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(154, 50);
            this.txtWeight.TabIndex = 1;
            this.txtWeight.Text = "";
            this.txtWeight.TrailingIcon = null;
            // 
            // mlvLoads
            // 
            this.mlvLoads.AutoSizeTable = false;
            this.mlvLoads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mlvLoads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mlvLoads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.mlvLoads.Depth = 0;
            this.mlvLoads.FullRowSelect = true;
            this.mlvLoads.HideSelection = false;
            this.mlvLoads.Location = new System.Drawing.Point(15, 126);
            this.mlvLoads.MinimumSize = new System.Drawing.Size(200, 100);
            this.mlvLoads.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mlvLoads.MouseState = MaterialSkin.MouseState.OUT;
            this.mlvLoads.Name = "mlvLoads";
            this.mlvLoads.OwnerDraw = true;
            this.mlvLoads.Size = new System.Drawing.Size(709, 100);
            this.mlvLoads.TabIndex = 0;
            this.mlvLoads.UseCompatibleStateImageBehavior = false;
            this.mlvLoads.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Id";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Load Number ";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Weight";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Volume";
            this.columnHeader3.Width = 160;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.materialButton2);
            this.groupBox3.Controls.Add(this.materialButton1);
            this.groupBox3.Controls.Add(this.materialComboBox1);
            this.groupBox3.Controls.Add(this.cmbTransportUnit);
            this.groupBox3.Location = new System.Drawing.Point(25, 483);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(409, 173);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transport Unit Informations";
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(169, 112);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(199, 36);
            this.materialButton2.TabIndex = 13;
            this.materialButton2.Text = "Assign Transport Unit";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.btnAssignTransportUnit_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(805, 120);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(199, 36);
            this.materialButton1.TabIndex = 1;
            this.materialButton1.Text = "Assign Transport Unit";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialComboBox1
            // 
            this.materialComboBox1.AutoResize = false;
            this.materialComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialComboBox1.Depth = 0;
            this.materialComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.materialComboBox1.DropDownHeight = 174;
            this.materialComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox1.DropDownWidth = 121;
            this.materialComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialComboBox1.FormattingEnabled = true;
            this.materialComboBox1.Hint = "Transport Unit";
            this.materialComboBox1.IntegralHeight = false;
            this.materialComboBox1.ItemHeight = 43;
            this.materialComboBox1.Location = new System.Drawing.Point(733, 41);
            this.materialComboBox1.MaxDropDownItems = 4;
            this.materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialComboBox1.Name = "materialComboBox1";
            this.materialComboBox1.Size = new System.Drawing.Size(271, 49);
            this.materialComboBox1.StartIndex = 0;
            this.materialComboBox1.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.materialButton3);
            this.groupBox4.Controls.Add(this.materialButton4);
            this.groupBox4.Controls.Add(this.materialComboBox2);
            this.groupBox4.Controls.Add(this.cmbStatus);
            this.groupBox4.Location = new System.Drawing.Point(25, 673);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(409, 169);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Update Status";
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(288, 111);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(77, 36);
            this.materialButton3.TabIndex = 13;
            this.materialButton3.Text = "Update";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = null;
            this.materialButton4.Location = new System.Drawing.Point(805, 120);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(199, 36);
            this.materialButton4.TabIndex = 1;
            this.materialButton4.Text = "Assign Transport Unit";
            this.materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            // 
            // materialComboBox2
            // 
            this.materialComboBox2.AutoResize = false;
            this.materialComboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialComboBox2.Depth = 0;
            this.materialComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.materialComboBox2.DropDownHeight = 174;
            this.materialComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox2.DropDownWidth = 121;
            this.materialComboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialComboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialComboBox2.FormattingEnabled = true;
            this.materialComboBox2.Hint = "Transport Unit";
            this.materialComboBox2.IntegralHeight = false;
            this.materialComboBox2.ItemHeight = 43;
            this.materialComboBox2.Location = new System.Drawing.Point(733, 41);
            this.materialComboBox2.MaxDropDownItems = 4;
            this.materialComboBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.materialComboBox2.Name = "materialComboBox2";
            this.materialComboBox2.Size = new System.Drawing.Size(271, 49);
            this.materialComboBox2.StartIndex = 0;
            this.materialComboBox2.TabIndex = 11;
            // 
            // cmbStatus
            // 
            this.cmbStatus.AutoResize = false;
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbStatus.Depth = 0;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbStatus.DropDownHeight = 174;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.DropDownWidth = 121;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Hint = "Status";
            this.cmbStatus.IntegralHeight = false;
            this.cmbStatus.ItemHeight = 43;
            this.cmbStatus.Location = new System.Drawing.Point(36, 41);
            this.cmbStatus.MaxDropDownItems = 4;
            this.cmbStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(329, 49);
            this.cmbStatus.StartIndex = 0;
            this.cmbStatus.TabIndex = 12;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.mlvProducts);
            this.groupBox5.Location = new System.Drawing.Point(460, 100);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(738, 175);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Product Informations";
            // 
            // mlvProducts
            // 
            this.mlvProducts.AutoSizeTable = false;
            this.mlvProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mlvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mlvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader4,
            this.columnHeader5});
            this.mlvProducts.Depth = 0;
            this.mlvProducts.FullRowSelect = true;
            this.mlvProducts.HideSelection = false;
            this.mlvProducts.Location = new System.Drawing.Point(15, 38);
            this.mlvProducts.MinimumSize = new System.Drawing.Size(200, 100);
            this.mlvProducts.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mlvProducts.MouseState = MaterialSkin.MouseState.OUT;
            this.mlvProducts.Name = "mlvProducts";
            this.mlvProducts.OwnerDraw = true;
            this.mlvProducts.Size = new System.Drawing.Size(709, 121);
            this.mlvProducts.TabIndex = 0;
            this.mlvProducts.UseCompatibleStateImageBehavior = false;
            this.mlvProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Id";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Product Name";
            this.columnHeader4.Width = 250;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Quantity";
            this.columnHeader5.Width = 160;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblEstimatedCost);
            this.groupBox6.Controls.Add(this.materialLabel12);
            this.groupBox6.Controls.Add(this.lblTotalVolume);
            this.groupBox6.Controls.Add(this.materialLabel18);
            this.groupBox6.Controls.Add(this.lblTotalWeight);
            this.groupBox6.Controls.Add(this.materialLabel20);
            this.groupBox6.Controls.Add(this.materialButton6);
            this.groupBox6.Controls.Add(this.materialComboBox4);
            this.groupBox6.Location = new System.Drawing.Point(460, 626);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(738, 137);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Cost Informations";
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.AutoSize = true;
            this.lblEstimatedCost.Depth = 0;
            this.lblEstimatedCost.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblEstimatedCost.Location = new System.Drawing.Point(160, 91);
            this.lblEstimatedCost.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(37, 19);
            this.lblEstimatedCost.TabIndex = 22;
            this.lblEstimatedCost.Text = "$454";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel12.Location = new System.Drawing.Point(9, 91);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(116, 19);
            this.materialLabel12.TabIndex = 21;
            this.materialLabel12.Text = "Estimated Cost :";
            // 
            // lblTotalVolume
            // 
            this.lblTotalVolume.AutoSize = true;
            this.lblTotalVolume.Depth = 0;
            this.lblTotalVolume.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalVolume.Location = new System.Drawing.Point(160, 62);
            this.lblTotalVolume.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalVolume.Name = "lblTotalVolume";
            this.lblTotalVolume.Size = new System.Drawing.Size(19, 19);
            this.lblTotalVolume.TabIndex = 20;
            this.lblTotalVolume.Text = "45";
            // 
            // materialLabel18
            // 
            this.materialLabel18.AutoSize = true;
            this.materialLabel18.Depth = 0;
            this.materialLabel18.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel18.Location = new System.Drawing.Point(9, 62);
            this.materialLabel18.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel18.Name = "materialLabel18";
            this.materialLabel18.Size = new System.Drawing.Size(104, 19);
            this.materialLabel18.TabIndex = 19;
            this.materialLabel18.Text = "Total Volume :";
            // 
            // lblTotalWeight
            // 
            this.lblTotalWeight.AutoSize = true;
            this.lblTotalWeight.Depth = 0;
            this.lblTotalWeight.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalWeight.Location = new System.Drawing.Point(160, 32);
            this.lblTotalWeight.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalWeight.Name = "lblTotalWeight";
            this.lblTotalWeight.Size = new System.Drawing.Size(36, 19);
            this.lblTotalWeight.TabIndex = 18;
            this.lblTotalWeight.Text = "54kg";
            // 
            // materialLabel20
            // 
            this.materialLabel20.AutoSize = true;
            this.materialLabel20.Depth = 0;
            this.materialLabel20.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel20.Location = new System.Drawing.Point(9, 32);
            this.materialLabel20.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel20.Name = "materialLabel20";
            this.materialLabel20.Size = new System.Drawing.Size(99, 19);
            this.materialLabel20.TabIndex = 17;
            this.materialLabel20.Text = "Total Weight :";
            // 
            // materialButton6
            // 
            this.materialButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton6.Depth = 0;
            this.materialButton6.HighEmphasis = true;
            this.materialButton6.Icon = null;
            this.materialButton6.Location = new System.Drawing.Point(805, 120);
            this.materialButton6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton6.Name = "materialButton6";
            this.materialButton6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton6.Size = new System.Drawing.Size(199, 36);
            this.materialButton6.TabIndex = 1;
            this.materialButton6.Text = "Assign Transport Unit";
            this.materialButton6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton6.UseAccentColor = false;
            this.materialButton6.UseVisualStyleBackColor = true;
            // 
            // materialComboBox4
            // 
            this.materialComboBox4.AutoResize = false;
            this.materialComboBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialComboBox4.Depth = 0;
            this.materialComboBox4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.materialComboBox4.DropDownHeight = 174;
            this.materialComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox4.DropDownWidth = 121;
            this.materialComboBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialComboBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialComboBox4.FormattingEnabled = true;
            this.materialComboBox4.Hint = "Transport Unit";
            this.materialComboBox4.IntegralHeight = false;
            this.materialComboBox4.ItemHeight = 43;
            this.materialComboBox4.Location = new System.Drawing.Point(733, 41);
            this.materialComboBox4.MaxDropDownItems = 4;
            this.materialComboBox4.MouseState = MaterialSkin.MouseState.OUT;
            this.materialComboBox4.Name = "materialComboBox4";
            this.materialComboBox4.Size = new System.Drawing.Size(271, 49);
            this.materialComboBox4.StartIndex = 0;
            this.materialComboBox4.TabIndex = 11;
            // 
            // ManageJobModal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1308, 932);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.jobInformations);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageJobModal";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Job";
            this.jobInformations.ResumeLayout(false);
            this.jobInformations.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox txtCustomerPhone;
        private System.Windows.Forms.GroupBox jobInformations;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialComboBox cmbTransportUnit;
        private MaterialSkin.Controls.MaterialComboBox cmbTruck;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialListView mlvLoads;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MaterialSkin.Controls.MaterialLabel JobNumber;
        private MaterialSkin.Controls.MaterialLabel lblPickupLocation;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel lblDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel lblJobStatus;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel lblJobNumber;
        private MaterialSkin.Controls.MaterialLabel lblDeliveryLocation;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel lblCustomerName;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private System.Windows.Forms.GroupBox groupBox3;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialLabel lblCustomerEmail;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private MaterialSkin.Controls.MaterialLabel lblCustomerPhone;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private System.Windows.Forms.GroupBox groupBox4;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton materialButton4;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox2;
        private MaterialSkin.Controls.MaterialComboBox cmbStatus;
        private System.Windows.Forms.GroupBox groupBox5;
        private MaterialSkin.Controls.MaterialListView mlvProducts;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private MaterialSkin.Controls.MaterialButton materialButton5;
        private MaterialSkin.Controls.MaterialTextBox txtVolume;
        private MaterialSkin.Controls.MaterialTextBox txtWeight;
        private System.Windows.Forms.GroupBox groupBox6;
        private MaterialSkin.Controls.MaterialLabel lblEstimatedCost;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel lblTotalVolume;
        private MaterialSkin.Controls.MaterialLabel materialLabel18;
        private MaterialSkin.Controls.MaterialLabel lblTotalWeight;
        private MaterialSkin.Controls.MaterialLabel materialLabel20;
        private MaterialSkin.Controls.MaterialButton materialButton6;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}
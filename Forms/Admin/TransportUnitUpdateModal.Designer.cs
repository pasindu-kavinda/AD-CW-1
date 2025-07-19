namespace AD_CW_1.Forms.Admin
{
    partial class TransportUnitUpdateModal
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
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.txtUnitNumber = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbTruck = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbDriver = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbAssistant = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(574, 402);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(64, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(464, 402);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(77, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtUnitNumber
            // 
            this.txtUnitNumber.AnimateReadOnly = false;
            this.txtUnitNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnitNumber.Depth = 0;
            this.txtUnitNumber.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUnitNumber.Hint = "Unit Number";
            this.txtUnitNumber.LeadingIcon = null;
            this.txtUnitNumber.Location = new System.Drawing.Point(29, 101);
            this.txtUnitNumber.MaxLength = 50;
            this.txtUnitNumber.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUnitNumber.Multiline = false;
            this.txtUnitNumber.Name = "txtUnitNumber";
            this.txtUnitNumber.Size = new System.Drawing.Size(288, 50);
            this.txtUnitNumber.TabIndex = 3;
            this.txtUnitNumber.Text = "";
            this.txtUnitNumber.TrailingIcon = null;
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
            this.cmbTruck.Hint = "Truck";
            this.cmbTruck.IntegralHeight = false;
            this.cmbTruck.ItemHeight = 43;
            this.cmbTruck.Location = new System.Drawing.Point(368, 102);
            this.cmbTruck.MaxDropDownItems = 4;
            this.cmbTruck.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbTruck.Name = "cmbTruck";
            this.cmbTruck.Size = new System.Drawing.Size(288, 49);
            this.cmbTruck.StartIndex = 0;
            this.cmbTruck.TabIndex = 4;
            // 
            // cmbDriver
            // 
            this.cmbDriver.AutoResize = false;
            this.cmbDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbDriver.Depth = 0;
            this.cmbDriver.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbDriver.DropDownHeight = 174;
            this.cmbDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriver.DropDownWidth = 121;
            this.cmbDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbDriver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbDriver.FormattingEnabled = true;
            this.cmbDriver.Hint = "Driver";
            this.cmbDriver.IntegralHeight = false;
            this.cmbDriver.ItemHeight = 43;
            this.cmbDriver.Location = new System.Drawing.Point(29, 201);
            this.cmbDriver.MaxDropDownItems = 4;
            this.cmbDriver.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbDriver.Name = "cmbDriver";
            this.cmbDriver.Size = new System.Drawing.Size(288, 49);
            this.cmbDriver.StartIndex = 0;
            this.cmbDriver.TabIndex = 5;
            // 
            // cmbAssistant
            // 
            this.cmbAssistant.AutoResize = false;
            this.cmbAssistant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbAssistant.Depth = 0;
            this.cmbAssistant.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbAssistant.DropDownHeight = 174;
            this.cmbAssistant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssistant.DropDownWidth = 121;
            this.cmbAssistant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbAssistant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbAssistant.FormattingEnabled = true;
            this.cmbAssistant.Hint = "Assistant";
            this.cmbAssistant.IntegralHeight = false;
            this.cmbAssistant.ItemHeight = 43;
            this.cmbAssistant.Location = new System.Drawing.Point(368, 201);
            this.cmbAssistant.MaxDropDownItems = 4;
            this.cmbAssistant.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbAssistant.Name = "cmbAssistant";
            this.cmbAssistant.Size = new System.Drawing.Size(288, 49);
            this.cmbAssistant.StartIndex = 0;
            this.cmbAssistant.TabIndex = 6;
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
            this.cmbStatus.IntegralHeight = false;
            this.cmbStatus.ItemHeight = 43;
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(29, 303);
            this.cmbStatus.MaxDropDownItems = 4;
            this.cmbStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(288, 49);
            this.cmbStatus.StartIndex = 0;
            this.cmbStatus.TabIndex = 7;
            // 
            // TransportUnitUpdateModal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(701, 479);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbAssistant);
            this.Controls.Add(this.cmbDriver);
            this.Controls.Add(this.cmbTruck);
            this.Controls.Add(this.txtUnitNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransportUnitUpdateModal";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transport Unit Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialTextBox txtUnitNumber;
        private MaterialSkin.Controls.MaterialComboBox cmbTruck;
        private MaterialSkin.Controls.MaterialComboBox cmbDriver;
        private MaterialSkin.Controls.MaterialComboBox cmbAssistant;
        private MaterialSkin.Controls.MaterialComboBox cmbStatus;
    }
}
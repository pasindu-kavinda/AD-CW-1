namespace AD_CW_1.Forms.Admin
{
    partial class TruckCreateModal
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
            this.txtTruckNumber = new MaterialSkin.Controls.MaterialTextBox();
            this.txtLicensePlate = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCapacity = new MaterialSkin.Controls.MaterialTextBox();
            this.txtModel = new MaterialSkin.Controls.MaterialComboBox();
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
            // txtTruckNumber
            // 
            this.txtTruckNumber.AnimateReadOnly = false;
            this.txtTruckNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTruckNumber.Depth = 0;
            this.txtTruckNumber.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTruckNumber.Hint = "Truck Number";
            this.txtTruckNumber.LeadingIcon = null;
            this.txtTruckNumber.Location = new System.Drawing.Point(29, 101);
            this.txtTruckNumber.MaxLength = 50;
            this.txtTruckNumber.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTruckNumber.Multiline = false;
            this.txtTruckNumber.Name = "txtTruckNumber";
            this.txtTruckNumber.Size = new System.Drawing.Size(288, 50);
            this.txtTruckNumber.TabIndex = 3;
            this.txtTruckNumber.Text = "";
            this.txtTruckNumber.TrailingIcon = null;
            // 
            // txtLicensePlate
            // 
            this.txtLicensePlate.AnimateReadOnly = false;
            this.txtLicensePlate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLicensePlate.Depth = 0;
            this.txtLicensePlate.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLicensePlate.Hint = "License Plate";
            this.txtLicensePlate.LeadingIcon = null;
            this.txtLicensePlate.Location = new System.Drawing.Point(350, 101);
            this.txtLicensePlate.MaxLength = 50;
            this.txtLicensePlate.MouseState = MaterialSkin.MouseState.OUT;
            this.txtLicensePlate.Multiline = false;
            this.txtLicensePlate.Name = "txtLicensePlate";
            this.txtLicensePlate.Size = new System.Drawing.Size(288, 50);
            this.txtLicensePlate.TabIndex = 4;
            this.txtLicensePlate.Text = "";
            this.txtLicensePlate.TrailingIcon = null;
            // 
            // txtCapacity
            // 
            this.txtCapacity.AnimateReadOnly = false;
            this.txtCapacity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCapacity.Depth = 0;
            this.txtCapacity.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCapacity.Hint = "Capacity";
            this.txtCapacity.LeadingIcon = null;
            this.txtCapacity.Location = new System.Drawing.Point(350, 184);
            this.txtCapacity.MaxLength = 50;
            this.txtCapacity.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCapacity.Multiline = false;
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(288, 50);
            this.txtCapacity.TabIndex = 6;
            this.txtCapacity.Text = "";
            this.txtCapacity.TrailingIcon = null;
            // 
            // txtModel
            // 
            this.txtModel.AutoResize = false;
            this.txtModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtModel.Depth = 0;
            this.txtModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.txtModel.DropDownHeight = 174;
            this.txtModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtModel.DropDownWidth = 121;
            this.txtModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtModel.FormattingEnabled = true;
            this.txtModel.Hint = "Model";
            this.txtModel.IntegralHeight = false;
            this.txtModel.ItemHeight = 43;
            this.txtModel.Items.AddRange(new object[] {
            "Dyna 150 / 200",
            "Canter FE71 / FE8",
            "NHR / NPR / NQR",
            "Jayo / Loadking",
            "Xenon / Yodha",
            "D-MAX",
            "Ranger / F-150"});
            this.txtModel.Location = new System.Drawing.Point(29, 185);
            this.txtModel.MaxDropDownItems = 4;
            this.txtModel.MouseState = MaterialSkin.MouseState.OUT;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(288, 49);
            this.txtModel.StartIndex = 0;
            this.txtModel.TabIndex = 7;
            // 
            // TruckCreateModal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(701, 479);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtCapacity);
            this.Controls.Add(this.txtLicensePlate);
            this.Controls.Add(this.txtTruckNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TruckCreateModal";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Truck Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialTextBox txtTruckNumber;
        private MaterialSkin.Controls.MaterialTextBox txtLicensePlate;
        private MaterialSkin.Controls.MaterialTextBox txtCapacity;
        private MaterialSkin.Controls.MaterialComboBox txtModel;
    }
}
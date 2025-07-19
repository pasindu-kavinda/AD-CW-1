namespace AD_CW_1.Forms.Admin
{
    partial class DriverCreateModal
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
            this.txtDriverName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtLicenseNumber = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDriverPhone = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDriverAddress = new MaterialSkin.Controls.MaterialTextBox();
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
            // txtDriverName
            // 
            this.txtDriverName.AnimateReadOnly = false;
            this.txtDriverName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDriverName.Depth = 0;
            this.txtDriverName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDriverName.Hint = "Driver Name";
            this.txtDriverName.LeadingIcon = null;
            this.txtDriverName.Location = new System.Drawing.Point(29, 101);
            this.txtDriverName.MaxLength = 50;
            this.txtDriverName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDriverName.Multiline = false;
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.Size = new System.Drawing.Size(288, 50);
            this.txtDriverName.TabIndex = 3;
            this.txtDriverName.Text = "";
            this.txtDriverName.TrailingIcon = null;
            // 
            // txtLicenseNumber
            // 
            this.txtLicenseNumber.AnimateReadOnly = false;
            this.txtLicenseNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLicenseNumber.Depth = 0;
            this.txtLicenseNumber.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLicenseNumber.Hint = "License Number";
            this.txtLicenseNumber.LeadingIcon = null;
            this.txtLicenseNumber.Location = new System.Drawing.Point(350, 101);
            this.txtLicenseNumber.MaxLength = 50;
            this.txtLicenseNumber.MouseState = MaterialSkin.MouseState.OUT;
            this.txtLicenseNumber.Multiline = false;
            this.txtLicenseNumber.Name = "txtLicenseNumber";
            this.txtLicenseNumber.Size = new System.Drawing.Size(288, 50);
            this.txtLicenseNumber.TabIndex = 4;
            this.txtLicenseNumber.Text = "";
            this.txtLicenseNumber.TrailingIcon = null;
            // 
            // txtDriverPhone
            // 
            this.txtDriverPhone.AnimateReadOnly = false;
            this.txtDriverPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDriverPhone.Depth = 0;
            this.txtDriverPhone.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDriverPhone.Hint = "Driver Phone";
            this.txtDriverPhone.LeadingIcon = null;
            this.txtDriverPhone.Location = new System.Drawing.Point(29, 183);
            this.txtDriverPhone.MaxLength = 50;
            this.txtDriverPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDriverPhone.Multiline = false;
            this.txtDriverPhone.Name = "txtDriverPhone";
            this.txtDriverPhone.Size = new System.Drawing.Size(288, 50);
            this.txtDriverPhone.TabIndex = 6;
            this.txtDriverPhone.Text = "";
            this.txtDriverPhone.TrailingIcon = null;
            // 
            // txtDriverAddress
            // 
            this.txtDriverAddress.AnimateReadOnly = false;
            this.txtDriverAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDriverAddress.Depth = 0;
            this.txtDriverAddress.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDriverAddress.Hint = "Driver Address";
            this.txtDriverAddress.LeadingIcon = null;
            this.txtDriverAddress.Location = new System.Drawing.Point(29, 271);
            this.txtDriverAddress.MaxLength = 50;
            this.txtDriverAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDriverAddress.Multiline = false;
            this.txtDriverAddress.Name = "txtDriverAddress";
            this.txtDriverAddress.Size = new System.Drawing.Size(609, 50);
            this.txtDriverAddress.TabIndex = 7;
            this.txtDriverAddress.Text = "";
            this.txtDriverAddress.TrailingIcon = null;
            // 
            // DriverCreateModal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(701, 479);
            this.Controls.Add(this.txtDriverAddress);
            this.Controls.Add(this.txtDriverPhone);
            this.Controls.Add(this.txtLicenseNumber);
            this.Controls.Add(this.txtDriverName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverCreateModal";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Driver Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialTextBox txtDriverName;
        private MaterialSkin.Controls.MaterialTextBox txtLicenseNumber;
        private MaterialSkin.Controls.MaterialTextBox txtDriverPhone;
        private MaterialSkin.Controls.MaterialTextBox txtDriverAddress;
    }
}
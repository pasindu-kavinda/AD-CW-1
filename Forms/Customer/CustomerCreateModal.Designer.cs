namespace AD_CW_1.Forms.Customer
{
    partial class CustomerCreateModal
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
            this.txtCustomerName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCustomerNumber = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCustomerEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCustomerPhone = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCustomerAddress = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCustomerPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.txtCustomerConfirmPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(574, 531);
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
            this.btnCancel.Location = new System.Drawing.Point(464, 531);
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
            // txtCustomerName
            // 
            this.txtCustomerName.AnimateReadOnly = false;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerName.Depth = 0;
            this.txtCustomerName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerName.Hint = "Customer Name";
            this.txtCustomerName.LeadingIcon = null;
            this.txtCustomerName.Location = new System.Drawing.Point(29, 101);
            this.txtCustomerName.MaxLength = 50;
            this.txtCustomerName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerName.Multiline = false;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(288, 50);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.Text = "";
            this.txtCustomerName.TrailingIcon = null;
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.AnimateReadOnly = false;
            this.txtCustomerNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerNumber.Depth = 0;
            this.txtCustomerNumber.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerNumber.Hint = "Customer Number";
            this.txtCustomerNumber.LeadingIcon = null;
            this.txtCustomerNumber.Location = new System.Drawing.Point(350, 101);
            this.txtCustomerNumber.MaxLength = 50;
            this.txtCustomerNumber.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerNumber.Multiline = false;
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Size = new System.Drawing.Size(288, 50);
            this.txtCustomerNumber.TabIndex = 4;
            this.txtCustomerNumber.Text = "";
            this.txtCustomerNumber.TrailingIcon = null;
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.AnimateReadOnly = false;
            this.txtCustomerEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerEmail.Depth = 0;
            this.txtCustomerEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerEmail.Hint = "Customer Email";
            this.txtCustomerEmail.LeadingIcon = null;
            this.txtCustomerEmail.Location = new System.Drawing.Point(29, 184);
            this.txtCustomerEmail.MaxLength = 50;
            this.txtCustomerEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerEmail.Multiline = false;
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(288, 50);
            this.txtCustomerEmail.TabIndex = 5;
            this.txtCustomerEmail.Text = "";
            this.txtCustomerEmail.TrailingIcon = null;
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.AnimateReadOnly = false;
            this.txtCustomerPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerPhone.Depth = 0;
            this.txtCustomerPhone.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerPhone.Hint = "Customer Phone";
            this.txtCustomerPhone.LeadingIcon = null;
            this.txtCustomerPhone.Location = new System.Drawing.Point(350, 184);
            this.txtCustomerPhone.MaxLength = 50;
            this.txtCustomerPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerPhone.Multiline = false;
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(288, 50);
            this.txtCustomerPhone.TabIndex = 6;
            this.txtCustomerPhone.Text = "";
            this.txtCustomerPhone.TrailingIcon = null;
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.AnimateReadOnly = false;
            this.txtCustomerAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerAddress.Depth = 0;
            this.txtCustomerAddress.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerAddress.Hint = "Customer Address";
            this.txtCustomerAddress.LeadingIcon = null;
            this.txtCustomerAddress.Location = new System.Drawing.Point(29, 271);
            this.txtCustomerAddress.MaxLength = 50;
            this.txtCustomerAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerAddress.Multiline = false;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(609, 50);
            this.txtCustomerAddress.TabIndex = 7;
            this.txtCustomerAddress.Text = "";
            this.txtCustomerAddress.TrailingIcon = null;
            // 
            // txtCustomerPassword
            // 
            this.txtCustomerPassword.AnimateReadOnly = false;
            this.txtCustomerPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerPassword.Depth = 0;
            this.txtCustomerPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerPassword.Hint = "Customer Password";
            this.txtCustomerPassword.LeadingIcon = null;
            this.txtCustomerPassword.Location = new System.Drawing.Point(29, 354);
            this.txtCustomerPassword.MaxLength = 50;
            this.txtCustomerPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerPassword.Multiline = false;
            this.txtCustomerPassword.Name = "txtCustomerPassword";
            this.txtCustomerPassword.Size = new System.Drawing.Size(288, 50);
            this.txtCustomerPassword.TabIndex = 8;
            this.txtCustomerPassword.Text = "";
            this.txtCustomerPassword.TrailingIcon = null;
            // 
            // txtCustomerConfirmPassword
            // 
            this.txtCustomerConfirmPassword.AnimateReadOnly = false;
            this.txtCustomerConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerConfirmPassword.Depth = 0;
            this.txtCustomerConfirmPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCustomerConfirmPassword.Hint = "Customer Confirm Password";
            this.txtCustomerConfirmPassword.LeadingIcon = null;
            this.txtCustomerConfirmPassword.Location = new System.Drawing.Point(350, 354);
            this.txtCustomerConfirmPassword.MaxLength = 50;
            this.txtCustomerConfirmPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtCustomerConfirmPassword.Multiline = false;
            this.txtCustomerConfirmPassword.Name = "txtCustomerConfirmPassword";
            this.txtCustomerConfirmPassword.Size = new System.Drawing.Size(288, 50);
            this.txtCustomerConfirmPassword.TabIndex = 9;
            this.txtCustomerConfirmPassword.Text = "";
            this.txtCustomerConfirmPassword.TrailingIcon = null;
            // 
            // CustomerCreateModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 618);
            this.Controls.Add(this.txtCustomerConfirmPassword);
            this.Controls.Add(this.txtCustomerPassword);
            this.Controls.Add(this.txtCustomerAddress);
            this.Controls.Add(this.txtCustomerPhone);
            this.Controls.Add(this.txtCustomerEmail);
            this.Controls.Add(this.txtCustomerNumber);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerCreateModal";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialTextBox txtCustomerName;
        private MaterialSkin.Controls.MaterialTextBox txtCustomerNumber;
        private MaterialSkin.Controls.MaterialTextBox txtCustomerEmail;
        private MaterialSkin.Controls.MaterialTextBox txtCustomerPhone;
        private MaterialSkin.Controls.MaterialTextBox txtCustomerAddress;
        private MaterialSkin.Controls.MaterialTextBox txtCustomerPassword;
        private MaterialSkin.Controls.MaterialTextBox txtCustomerConfirmPassword;
    }
}
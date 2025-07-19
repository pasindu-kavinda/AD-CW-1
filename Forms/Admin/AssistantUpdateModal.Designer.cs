namespace AD_CW_1.Forms.Admin
{
    partial class AssistantUpdateModal
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
            this.txtAssistantName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAssistantPhone = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAssistantAddress = new MaterialSkin.Controls.MaterialTextBox();
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
            // txtAssistantName
            // 
            this.txtAssistantName.AnimateReadOnly = false;
            this.txtAssistantName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAssistantName.Depth = 0;
            this.txtAssistantName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAssistantName.Hint = "Assistant Name";
            this.txtAssistantName.LeadingIcon = null;
            this.txtAssistantName.Location = new System.Drawing.Point(29, 101);
            this.txtAssistantName.MaxLength = 50;
            this.txtAssistantName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAssistantName.Multiline = false;
            this.txtAssistantName.Name = "txtAssistantName";
            this.txtAssistantName.Size = new System.Drawing.Size(288, 50);
            this.txtAssistantName.TabIndex = 3;
            this.txtAssistantName.Text = "";
            this.txtAssistantName.TrailingIcon = null;
            // 
            // txtAssistantPhone
            // 
            this.txtAssistantPhone.AnimateReadOnly = false;
            this.txtAssistantPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAssistantPhone.Depth = 0;
            this.txtAssistantPhone.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAssistantPhone.Hint = "Assistant Phone";
            this.txtAssistantPhone.LeadingIcon = null;
            this.txtAssistantPhone.Location = new System.Drawing.Point(350, 101);
            this.txtAssistantPhone.MaxLength = 50;
            this.txtAssistantPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAssistantPhone.Multiline = false;
            this.txtAssistantPhone.Name = "txtAssistantPhone";
            this.txtAssistantPhone.Size = new System.Drawing.Size(288, 50);
            this.txtAssistantPhone.TabIndex = 6;
            this.txtAssistantPhone.Text = "";
            this.txtAssistantPhone.TrailingIcon = null;
            // 
            // txtAssistantAddress
            // 
            this.txtAssistantAddress.AnimateReadOnly = false;
            this.txtAssistantAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAssistantAddress.Depth = 0;
            this.txtAssistantAddress.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAssistantAddress.Hint = "Assistant Address";
            this.txtAssistantAddress.LeadingIcon = null;
            this.txtAssistantAddress.Location = new System.Drawing.Point(29, 185);
            this.txtAssistantAddress.MaxLength = 50;
            this.txtAssistantAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAssistantAddress.Multiline = false;
            this.txtAssistantAddress.Name = "txtAssistantAddress";
            this.txtAssistantAddress.Size = new System.Drawing.Size(609, 50);
            this.txtAssistantAddress.TabIndex = 7;
            this.txtAssistantAddress.Text = "";
            this.txtAssistantAddress.TrailingIcon = null;
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
            this.cmbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cmbStatus.Location = new System.Drawing.Point(29, 262);
            this.cmbStatus.MaxDropDownItems = 4;
            this.cmbStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(288, 49);
            this.cmbStatus.StartIndex = 0;
            this.cmbStatus.TabIndex = 9;
            // 
            // AssistantUpdateModal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(701, 479);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtAssistantAddress);
            this.Controls.Add(this.txtAssistantPhone);
            this.Controls.Add(this.txtAssistantName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssistantUpdateModal";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assistant Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialTextBox txtAssistantName;
        private MaterialSkin.Controls.MaterialTextBox txtAssistantPhone;
        private MaterialSkin.Controls.MaterialTextBox txtAssistantAddress;
        private MaterialSkin.Controls.MaterialComboBox cmbStatus;
    }
}
namespace AD_CW_1.Forms.Admin
{
    partial class ProductUpdateModal
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
            this.txtProductName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtWeight = new MaterialSkin.Controls.MaterialTextBox();
            this.txtDimensions = new MaterialSkin.Controls.MaterialTextBox();
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
            // txtProductName
            // 
            this.txtProductName.AnimateReadOnly = false;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.Depth = 0;
            this.txtProductName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtProductName.Hint = "Product Name";
            this.txtProductName.LeadingIcon = null;
            this.txtProductName.Location = new System.Drawing.Point(29, 101);
            this.txtProductName.MaxLength = 50;
            this.txtProductName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtProductName.Multiline = false;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(288, 50);
            this.txtProductName.TabIndex = 3;
            this.txtProductName.Text = "";
            this.txtProductName.TrailingIcon = null;
            // 
            // txtWeight
            // 
            this.txtWeight.AnimateReadOnly = false;
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWeight.Depth = 0;
            this.txtWeight.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtWeight.Hint = "Weight";
            this.txtWeight.LeadingIcon = null;
            this.txtWeight.Location = new System.Drawing.Point(350, 101);
            this.txtWeight.MaxLength = 50;
            this.txtWeight.MouseState = MaterialSkin.MouseState.OUT;
            this.txtWeight.Multiline = false;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(288, 50);
            this.txtWeight.TabIndex = 4;
            this.txtWeight.Text = "";
            this.txtWeight.TrailingIcon = null;
            // 
            // txtDimensions
            // 
            this.txtDimensions.AnimateReadOnly = false;
            this.txtDimensions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDimensions.Depth = 0;
            this.txtDimensions.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDimensions.Hint = "Dimensions";
            this.txtDimensions.LeadingIcon = null;
            this.txtDimensions.Location = new System.Drawing.Point(29, 184);
            this.txtDimensions.MaxLength = 50;
            this.txtDimensions.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDimensions.Multiline = false;
            this.txtDimensions.Name = "txtDimensions";
            this.txtDimensions.Size = new System.Drawing.Size(288, 50);
            this.txtDimensions.TabIndex = 5;
            this.txtDimensions.Text = "";
            this.txtDimensions.TrailingIcon = null;
            // 
            // ProductUpdateModal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(701, 479);
            this.Controls.Add(this.txtDimensions);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductUpdateModal";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Create";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialTextBox txtProductName;
        private MaterialSkin.Controls.MaterialTextBox txtWeight;
        private MaterialSkin.Controls.MaterialTextBox txtDimensions;
    }
}
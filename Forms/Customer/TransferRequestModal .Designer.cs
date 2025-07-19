namespace AD_CW_1.Forms.Admin
{
    partial class TransferRequestModal
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
            this.jobInformations = new System.Windows.Forms.GroupBox();
            this.txtDeliveryLocation = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPickupLocation = new MaterialSkin.Controls.MaterialTextBox();
            this.btnSubmit = new MaterialSkin.Controls.MaterialButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAddProduct = new MaterialSkin.Controls.MaterialButton();
            this.txtQuantity = new MaterialSkin.Controls.MaterialTextBox();
            this.cmbProduct = new MaterialSkin.Controls.MaterialComboBox();
            this.mlvProducts = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNote = new MaterialSkin.Controls.MaterialTextBox();
            this.jobInformations.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // jobInformations
            // 
            this.jobInformations.Controls.Add(this.txtDeliveryLocation);
            this.jobInformations.Controls.Add(this.txtPickupLocation);
            this.jobInformations.Location = new System.Drawing.Point(25, 92);
            this.jobInformations.Name = "jobInformations";
            this.jobInformations.Size = new System.Drawing.Size(914, 153);
            this.jobInformations.TabIndex = 8;
            this.jobInformations.TabStop = false;
            this.jobInformations.Text = "Transfer Request Informations";
            // 
            // txtDeliveryLocation
            // 
            this.txtDeliveryLocation.AnimateReadOnly = false;
            this.txtDeliveryLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeliveryLocation.Depth = 0;
            this.txtDeliveryLocation.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDeliveryLocation.Hint = "Delivery Location";
            this.txtDeliveryLocation.LeadingIcon = null;
            this.txtDeliveryLocation.Location = new System.Drawing.Point(474, 44);
            this.txtDeliveryLocation.MaxLength = 50;
            this.txtDeliveryLocation.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDeliveryLocation.Multiline = false;
            this.txtDeliveryLocation.Name = "txtDeliveryLocation";
            this.txtDeliveryLocation.Size = new System.Drawing.Size(410, 50);
            this.txtDeliveryLocation.TabIndex = 8;
            this.txtDeliveryLocation.Text = "";
            this.txtDeliveryLocation.TrailingIcon = null;
            // 
            // txtPickupLocation
            // 
            this.txtPickupLocation.AnimateReadOnly = false;
            this.txtPickupLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPickupLocation.Depth = 0;
            this.txtPickupLocation.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPickupLocation.Hint = "Pickup Location";
            this.txtPickupLocation.LeadingIcon = null;
            this.txtPickupLocation.Location = new System.Drawing.Point(17, 44);
            this.txtPickupLocation.MaxLength = 50;
            this.txtPickupLocation.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPickupLocation.Multiline = false;
            this.txtPickupLocation.Name = "txtPickupLocation";
            this.txtPickupLocation.Size = new System.Drawing.Size(406, 50);
            this.txtPickupLocation.TabIndex = 7;
            this.txtPickupLocation.Text = "";
            this.txtPickupLocation.TrailingIcon = null;
            // 
            // btnSubmit
            // 
            this.btnSubmit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSubmit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSubmit.Depth = 0;
            this.btnSubmit.HighEmphasis = true;
            this.btnSubmit.Icon = null;
            this.btnSubmit.Location = new System.Drawing.Point(797, 650);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSubmit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSubmit.Size = new System.Drawing.Size(142, 36);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Submit Request";
            this.btnSubmit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSubmit.UseAccentColor = false;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmitRequest_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAddProduct);
            this.groupBox5.Controls.Add(this.txtQuantity);
            this.groupBox5.Controls.Add(this.cmbProduct);
            this.groupBox5.Controls.Add(this.mlvProducts);
            this.groupBox5.Location = new System.Drawing.Point(25, 268);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(914, 214);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Product Informations";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddProduct.Depth = 0;
            this.btnAddProduct.HighEmphasis = true;
            this.btnAddProduct.Icon = null;
            this.btnAddProduct.Location = new System.Drawing.Point(742, 34);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddProduct.Size = new System.Drawing.Size(121, 36);
            this.btnAddProduct.TabIndex = 14;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddProduct.UseAccentColor = false;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.AnimateReadOnly = false;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Depth = 0;
            this.txtQuantity.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtQuantity.Hint = "Quantity";
            this.txtQuantity.LeadingIcon = null;
            this.txtQuantity.Location = new System.Drawing.Point(493, 22);
            this.txtQuantity.MaxLength = 50;
            this.txtQuantity.MouseState = MaterialSkin.MouseState.OUT;
            this.txtQuantity.Multiline = false;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(200, 50);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.Text = "";
            this.txtQuantity.TrailingIcon = null;
            // 
            // cmbProduct
            // 
            this.cmbProduct.AutoResize = false;
            this.cmbProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbProduct.Depth = 0;
            this.cmbProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbProduct.DropDownHeight = 174;
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.DropDownWidth = 121;
            this.cmbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Hint = "Product";
            this.cmbProduct.IntegralHeight = false;
            this.cmbProduct.ItemHeight = 43;
            this.cmbProduct.Location = new System.Drawing.Point(265, 21);
            this.cmbProduct.MaxDropDownItems = 4;
            this.cmbProduct.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(179, 49);
            this.cmbProduct.StartIndex = 0;
            this.cmbProduct.TabIndex = 1;
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
            this.mlvProducts.Location = new System.Drawing.Point(15, 87);
            this.mlvProducts.MinimumSize = new System.Drawing.Size(200, 100);
            this.mlvProducts.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mlvProducts.MouseState = MaterialSkin.MouseState.OUT;
            this.mlvProducts.Name = "mlvProducts";
            this.mlvProducts.OwnerDraw = true;
            this.mlvProducts.Size = new System.Drawing.Size(869, 103);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Location = new System.Drawing.Point(25, 501);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 132);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.AnimateReadOnly = false;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.Depth = 0;
            this.txtNote.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtNote.Hint = "Note";
            this.txtNote.LeadingIcon = null;
            this.txtNote.Location = new System.Drawing.Point(17, 44);
            this.txtNote.MaxLength = 50;
            this.txtNote.MouseState = MaterialSkin.MouseState.OUT;
            this.txtNote.Multiline = false;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(867, 50);
            this.txtNote.TabIndex = 7;
            this.txtNote.Text = "";
            this.txtNote.TrailingIcon = null;
            // 
            // TransferRequestModal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(977, 735);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.jobInformations);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferRequestModal";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer Request";
            this.jobInformations.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox jobInformations;
        private MaterialSkin.Controls.MaterialButton btnSubmit;
        private System.Windows.Forms.GroupBox groupBox5;
        private MaterialSkin.Controls.MaterialListView mlvProducts;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private MaterialSkin.Controls.MaterialTextBox txtDeliveryLocation;
        private MaterialSkin.Controls.MaterialTextBox txtPickupLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox txtNote;
        private MaterialSkin.Controls.MaterialButton btnAddProduct;
        private MaterialSkin.Controls.MaterialTextBox txtQuantity;
        private MaterialSkin.Controls.MaterialComboBox cmbProduct;
    }
}
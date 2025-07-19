namespace AD_CW_1.Forms
{
    partial class CustomerDashboardPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDashboardPage));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.dashboardTab = new System.Windows.Forms.TabPage();
            this.materialCard4 = new MaterialSkin.Controls.MaterialCard();
            this.materialProgressBar3 = new MaterialSkin.Controls.MaterialProgressBar();
            this.lblTotalCompletedJobs = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.materialProgressBar2 = new MaterialSkin.Controls.MaterialProgressBar();
            this.lblTotalTransportUnits = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.lblCustomerIncrease = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.materialCard5 = new MaterialSkin.Controls.MaterialCard();
            this.label11 = new System.Windows.Forms.Label();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.label10 = new System.Windows.Forms.Label();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.customersTab = new System.Windows.Forms.TabPage();
            this.jobsListView = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCreateRequest = new MaterialSkin.Controls.MaterialButton();
            this.label12 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnLogout = new MaterialSkin.Controls.MaterialButton();
            this.materialTabControl1.SuspendLayout();
            this.dashboardTab.SuspendLayout();
            this.materialCard4.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.materialCard5.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.customersTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.dashboardTab);
            this.materialTabControl1.Controls.Add(this.customersTab);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.imageList1;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1510, 937);
            this.materialTabControl1.TabIndex = 0;
            // 
            // dashboardTab
            // 
            this.dashboardTab.Controls.Add(this.btnLogout);
            this.dashboardTab.Controls.Add(this.materialCard4);
            this.dashboardTab.Controls.Add(this.materialCard3);
            this.dashboardTab.Controls.Add(this.materialCard1);
            this.dashboardTab.Controls.Add(this.materialCard5);
            this.dashboardTab.Controls.Add(this.materialCard2);
            this.dashboardTab.ImageKey = "icons8-dashboard-50.png";
            this.dashboardTab.Location = new System.Drawing.Point(4, 31);
            this.dashboardTab.Name = "dashboardTab";
            this.dashboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.dashboardTab.Size = new System.Drawing.Size(1502, 902);
            this.dashboardTab.TabIndex = 0;
            this.dashboardTab.Text = "Dashboard";
            this.dashboardTab.UseVisualStyleBackColor = true;
            // 
            // materialCard4
            // 
            this.materialCard4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard4.Controls.Add(this.materialProgressBar3);
            this.materialCard4.Controls.Add(this.lblTotalCompletedJobs);
            this.materialCard4.Controls.Add(this.label9);
            this.materialCard4.Depth = 0;
            this.materialCard4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard4.Location = new System.Drawing.Point(852, 17);
            this.materialCard4.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard4.Name = "materialCard4";
            this.materialCard4.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard4.Size = new System.Drawing.Size(396, 147);
            this.materialCard4.TabIndex = 8;
            // 
            // materialProgressBar3
            // 
            this.materialProgressBar3.Depth = 0;
            this.materialProgressBar3.Location = new System.Drawing.Point(33, 94);
            this.materialProgressBar3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar3.Name = "materialProgressBar3";
            this.materialProgressBar3.Size = new System.Drawing.Size(244, 5);
            this.materialProgressBar3.TabIndex = 3;
            this.materialProgressBar3.Value = 76;
            // 
            // lblTotalCompletedJobs
            // 
            this.lblTotalCompletedJobs.AutoSize = true;
            this.lblTotalCompletedJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCompletedJobs.Location = new System.Drawing.Point(27, 49);
            this.lblTotalCompletedJobs.Name = "lblTotalCompletedJobs";
            this.lblTotalCompletedJobs.Size = new System.Drawing.Size(69, 36);
            this.lblTotalCompletedJobs.TabIndex = 1;
            this.lblTotalCompletedJobs.Text = "569";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(27, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "Completed Jobs";
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.materialProgressBar2);
            this.materialCard3.Controls.Add(this.lblTotalTransportUnits);
            this.materialCard3.Controls.Add(this.label6);
            this.materialCard3.Depth = 0;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(437, 17);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard3.Size = new System.Drawing.Size(396, 147);
            this.materialCard3.TabIndex = 7;
            // 
            // materialProgressBar2
            // 
            this.materialProgressBar2.Depth = 0;
            this.materialProgressBar2.Location = new System.Drawing.Point(33, 94);
            this.materialProgressBar2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar2.Name = "materialProgressBar2";
            this.materialProgressBar2.Size = new System.Drawing.Size(244, 5);
            this.materialProgressBar2.TabIndex = 3;
            this.materialProgressBar2.Value = 60;
            // 
            // lblTotalTransportUnits
            // 
            this.lblTotalTransportUnits.AutoSize = true;
            this.lblTotalTransportUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTransportUnits.Location = new System.Drawing.Point(27, 49);
            this.lblTotalTransportUnits.Name = "lblTotalTransportUnits";
            this.lblTotalTransportUnits.Size = new System.Drawing.Size(69, 36);
            this.lblTotalTransportUnits.TabIndex = 1;
            this.lblTotalTransportUnits.Text = "125";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "Transport Units";
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.materialProgressBar1);
            this.materialCard1.Controls.Add(this.lblCustomerIncrease);
            this.materialCard1.Controls.Add(this.lblTotalCustomers);
            this.materialCard1.Controls.Add(this.label1);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(22, 17);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(396, 147);
            this.materialCard1.TabIndex = 6;
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Location = new System.Drawing.Point(33, 94);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(244, 5);
            this.materialProgressBar1.TabIndex = 3;
            this.materialProgressBar1.Value = 45;
            // 
            // lblCustomerIncrease
            // 
            this.lblCustomerIncrease.AutoSize = true;
            this.lblCustomerIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerIncrease.Location = new System.Drawing.Point(27, 114);
            this.lblCustomerIncrease.Name = "lblCustomerIncrease";
            this.lblCustomerIncrease.Size = new System.Drawing.Size(111, 20);
            this.lblCustomerIncrease.TabIndex = 2;
            this.lblCustomerIncrease.Text = "45% increase";
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.AutoSize = true;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomers.Location = new System.Drawing.Point(27, 49);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(96, 36);
            this.lblTotalCustomers.TabIndex = 1;
            this.lblTotalCustomers.Text = "1,122";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customers";
            // 
            // materialCard5
            // 
            this.materialCard5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard5.Controls.Add(this.label11);
            this.materialCard5.Controls.Add(this.cartesianChart2);
            this.materialCard5.Depth = 0;
            this.materialCard5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard5.Location = new System.Drawing.Point(724, 188);
            this.materialCard5.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard5.Name = "materialCard5";
            this.materialCard5.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard5.Size = new System.Drawing.Size(522, 415);
            this.materialCard5.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(265, 29);
            this.label11.TabIndex = 5;
            this.label11.Text = "Transport Units by Year";
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Location = new System.Drawing.Point(25, 74);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(480, 323);
            this.cartesianChart2.TabIndex = 0;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.label10);
            this.materialCard2.Controls.Add(this.cartesianChart1);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(20, 188);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(682, 415);
            this.materialCard2.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(278, 29);
            this.label10.TabIndex = 4;
            this.label10.Text = "Completed Jobs by Year";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(17, 65);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(645, 329);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // customersTab
            // 
            this.customersTab.Controls.Add(this.jobsListView);
            this.customersTab.Controls.Add(this.btnCreateRequest);
            this.customersTab.Controls.Add(this.label12);
            this.customersTab.ImageKey = "icons8-report-48.png";
            this.customersTab.Location = new System.Drawing.Point(4, 31);
            this.customersTab.Name = "customersTab";
            this.customersTab.Padding = new System.Windows.Forms.Padding(3);
            this.customersTab.Size = new System.Drawing.Size(1502, 902);
            this.customersTab.TabIndex = 1;
            this.customersTab.Text = "Customers";
            this.customersTab.UseVisualStyleBackColor = true;
            // 
            // jobsListView
            // 
            this.jobsListView.AutoSizeTable = false;
            this.jobsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.jobsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.jobsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader48,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader49});
            this.jobsListView.Depth = 0;
            this.jobsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.jobsListView.FullRowSelect = true;
            this.jobsListView.HideSelection = false;
            this.jobsListView.Location = new System.Drawing.Point(24, 82);
            this.jobsListView.MinimumSize = new System.Drawing.Size(200, 100);
            this.jobsListView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.jobsListView.MouseState = MaterialSkin.MouseState.OUT;
            this.jobsListView.Name = "jobsListView";
            this.jobsListView.OwnerDraw = true;
            this.jobsListView.Size = new System.Drawing.Size(1188, 576);
            this.jobsListView.TabIndex = 4;
            this.jobsListView.UseCompatibleStateImageBehavior = false;
            this.jobsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Job Number";
            this.columnHeader2.Width = 157;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "Customer Name";
            this.columnHeader48.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Pickup Location";
            this.columnHeader3.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Delivery Location";
            this.columnHeader5.Width = 180;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Status";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Estimated Cost";
            this.columnHeader7.Width = 160;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "Request Date";
            this.columnHeader49.Width = 160;
            // 
            // btnCreateRequest
            // 
            this.btnCreateRequest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreateRequest.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCreateRequest.Depth = 0;
            this.btnCreateRequest.HighEmphasis = true;
            this.btnCreateRequest.Icon = null;
            this.btnCreateRequest.Location = new System.Drawing.Point(1140, 16);
            this.btnCreateRequest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCreateRequest.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreateRequest.Name = "btnCreateRequest";
            this.btnCreateRequest.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCreateRequest.Size = new System.Drawing.Size(76, 36);
            this.btnCreateRequest.TabIndex = 2;
            this.btnCreateRequest.Text = "Create";
            this.btnCreateRequest.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCreateRequest.UseAccentColor = false;
            this.btnCreateRequest.UseVisualStyleBackColor = true;
            this.btnCreateRequest.Click += new System.EventHandler(this.btnCreateRequest_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(216, 29);
            this.label12.TabIndex = 1;
            this.label12.Text = "Transport requests";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-dashboard-50.png");
            this.imageList1.Images.SetKeyName(1, "icons8-report-48.png");
            this.imageList1.Images.SetKeyName(2, "icons8-add-50.png");
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogout.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogout.Depth = 0;
            this.btnLogout.HighEmphasis = true;
            this.btnLogout.Icon = null;
            this.btnLogout.Location = new System.Drawing.Point(22, 622);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogout.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogout.Size = new System.Drawing.Size(78, 36);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogout.UseAccentColor = false;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // CustomerDashboardPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1516, 1004);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Name = "CustomerDashboardPage";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " E-Shift Household Goods";
            this.materialTabControl1.ResumeLayout(false);
            this.dashboardTab.ResumeLayout(false);
            this.dashboardTab.PerformLayout();
            this.materialCard4.ResumeLayout(false);
            this.materialCard4.PerformLayout();
            this.materialCard3.ResumeLayout(false);
            this.materialCard3.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.materialCard5.ResumeLayout(false);
            this.materialCard5.PerformLayout();
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.customersTab.ResumeLayout(false);
            this.customersTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage dashboardTab;
        private System.Windows.Forms.TabPage customersTab;
        private System.Windows.Forms.ImageList imageList1;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private MaterialSkin.Controls.MaterialCard materialCard5;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private MaterialSkin.Controls.MaterialButton btnCreateRequest;
        private MaterialSkin.Controls.MaterialListView jobsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader48;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader49;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar3;
        private System.Windows.Forms.Label lblTotalCompletedJobs;
        private System.Windows.Forms.Label label9;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar2;
        private System.Windows.Forms.Label lblTotalTransportUnits;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private System.Windows.Forms.Label lblCustomerIncrease;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialButton btnLogout;
    }
}


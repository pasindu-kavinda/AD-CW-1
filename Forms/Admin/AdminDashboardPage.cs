using LiveCharts.Wpf;
using LiveCharts;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AD_CW_1.Repositories;
using AD_CW_1.Forms.Admin;
using AD_CW_1.Business.Interface;
using AD_CW_1.Business.Services;
using AD_CW_1.Repositories.Interface;
using FluentValidation;
using AD_CW_1.Repositories.Services;
using Google.Protobuf.WellKnownTypes;
using AD_CW_1.Constants;
using AD_CW_1.Models.Reports;
using System.IO;
using AD_CW_1.Models.Dashboard;

namespace AD_CW_1.Forms
{
    public partial class AdminDashboardPage : MaterialForm
    {
        private ICustomerService customerService;
        private ITruckService truckService;
        private IDriverService driverService;
        private IAssistantService assistantService;
        private IJobService jobService;
        private ITransportUnitService transportUnitService;
        private IProductService productService;

        private IReportService reportService;
        private List<object> _currentReportData;
        private string _currentReportTitle;

        private IDashboardService dashboardService;

        public AdminDashboardPage()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);
            InitializeComponent();

            InitializeDashboardTab();
            InitializedCustomersTab();
            InitializedJobsTab();
            InitializedUnitsTab();
            InitializedProductsTab();
            InitializedReportsTab();
        }

        #region DashboardTab
        private void InitializeDashboardTab()
        {
            dashboardService = new DashboardService();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                var metrics = dashboardService.GetDashboardMetrics();
                if (metrics != null)
                {
                    UpdateMetricsCards(metrics);
                }

                int currentYear = DateTime.Now.Year;
                var monthlyJobs = dashboardService.GetMonthlyJobsData(currentYear);
                var monthlyUnits = dashboardService.GetMonthlyTransportUnitsData(currentYear);
                var salesPerformance = dashboardService.GetSalesPersonPerformance();

                if (monthlyJobs != null && monthlyJobs.Any())
                {
                    UpdateJobsChart(monthlyJobs);
                }

                if (monthlyUnits != null && monthlyUnits.Any())
                {
                    UpdateTransportUnitsChart(monthlyUnits);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMetricsCards(DashboardMetricsModel metrics)
        {
            lblTotalCustomers.Text = metrics.TotalCustomers.ToString("N0");
            lblCustomerIncrease.Text = $"{metrics.CustomerIncreasePercentage:F1}% increase";

            lblTotalTransportUnits.Text = metrics.TotalTransportUnits.ToString("N0");

            lblTotalCompletedJobs.Text = metrics.TotalCompletedJobs.ToString("N0");
        }

        private void UpdateJobsChart(List<MonthlyJobsModel> monthlyJobs)
        {
            try
            {
                cartesianChart1.Series.Clear();
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();

                var completedJobsValues = new ChartValues<double>();
                var totalJobsValues = new ChartValues<double>();
                var labels = new List<string>();

                foreach (var month in monthlyJobs)
                {
                    completedJobsValues.Add(Convert.ToDouble(month.CompletedJobs));
                    totalJobsValues.Add(Convert.ToDouble(month.TotalJobs));
                    labels.Add(month.Month ?? "Unknown");
                }

                cartesianChart1.Series.Add(new ColumnSeries
                {
                    Title = $"Completed Jobs {DateTime.Now.Year}",
                    Values = completedJobsValues,
                    Fill = System.Windows.Media.Brushes.DodgerBlue
                });

                cartesianChart1.Series.Add(new ColumnSeries
                {
                    Title = $"Total Jobs {DateTime.Now.Year}",
                    Values = totalJobsValues,
                    Fill = System.Windows.Media.Brushes.Tomato
                });

                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Month",
                    Labels = labels.ToArray()
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Number of Jobs",
                    LabelFormatter = value => value.ToString("N0")
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating jobs chart: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateTransportUnitsChart(List<MonthlyTransportUnitsModel> monthlyUnits)
        {
            try
            {
                cartesianChart2.Series.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();

                var utilizationValues = new ChartValues<double>();
                var activeUnitsValues = new ChartValues<double>();
                var labels = new List<string>();

                foreach (var month in monthlyUnits)
                {
                    utilizationValues.Add(Convert.ToDouble(month.Utilization));
                    activeUnitsValues.Add((double)month.ActiveUnits);
                    labels.Add(month.Month ?? "Unknown");
                }

                cartesianChart2.Series.Add(new LineSeries
                {
                    Title = "Utilization %",
                    Values = utilizationValues,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    Stroke = System.Windows.Media.Brushes.Red,
                    Fill = System.Windows.Media.Brushes.Transparent
                });

                cartesianChart2.Series.Add(new LineSeries
                {
                    Title = "Active Units",
                    Values = activeUnitsValues,
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 8,
                    Stroke = System.Windows.Media.Brushes.Blue,
                    Fill = System.Windows.Media.Brushes.Transparent
                });

                cartesianChart2.AxisX.Add(new Axis
                {
                    Title = "Month",
                    Labels = labels.ToArray()
                });

                cartesianChart2.AxisY.Add(new Axis
                {
                    Title = "Units / Percentage",
                    LabelFormatter = value => value.ToString("F1")
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating transport units chart: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static class DbNullHelper
        {
            public static T SafeConvert<T>(object value, T defaultValue = default(T))
            {
                if (value == null || value == DBNull.Value)
                    return defaultValue;

                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch
                {
                    return defaultValue;
                }
            }

            public static int SafeInt(object value, int defaultValue = 0)
            {
                return SafeConvert(value, defaultValue);
            }

            public static double SafeDouble(object value, double defaultValue = 0.0)
            {
                return SafeConvert(value, defaultValue);
            }

            public static decimal SafeDecimal(object value, decimal defaultValue = 0m)
            {
                return SafeConvert(value, defaultValue);
            }

            public static string SafeString(object value, string defaultValue = "")
            {
                return SafeConvert(value, defaultValue);
            }
        }
        #endregion


        #region CustomerTab
        private void InitializedCustomersTab()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            customerService = new CustomerService(customerRepository);

            LoadCustomers();
            addCustomerContextMenu();
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = customerService.GetAllCustomers();
                customersListView.Items.Clear();
                foreach (var customer in customers)
                {
                    var item = new ListViewItem(customer.Id.ToString());
                    item.SubItems.Add(customer.Name);
                    item.SubItems.Add(customer.CustomerNumber);
                    item.SubItems.Add(customer.Email);
                    item.SubItems.Add(customer.Phone);
                    item.SubItems.Add(customer.Address);
                    item.SubItems.Add(customer.CreatedAt.ToString("yyyy-MM-dd"));
                    customersListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addCustomerContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit Customer");
            editItem.Click += EditCustomer_Click;
            contextMenu.Items.Add(editItem);

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Customer");
            deleteItem.Click += DeleteCustomer_Click;
            contextMenu.Items.Add(deleteItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            customersListView.ContextMenuStrip = contextMenu;
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            CustomerCreateModal customerCreateModal = new CustomerCreateModal();
            customerCreateModal.ShowDialog();

            LoadCustomers();
        }

        private void EditCustomer_Click(object sender, EventArgs e)
        {
            if (customersListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = customersListView.SelectedItems[0];
                int customerId = int.Parse(selectedItem.Text);

                CustomerUpdateModal customerCreateModal = new CustomerUpdateModal(customerId);
                customerCreateModal.ShowDialog();

                LoadCustomers();
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteCustomer_Click(object sender, EventArgs e)
        {
            if (customersListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = customersListView.SelectedItems[0];
                int customerId = int.Parse(selectedItem.Text);
                string customerName = selectedItem.SubItems[1].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete customer '{customerName}'?\n\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool deleted = customerService.DeleteCustomer(customerId);

                        if (deleted)
                        {
                            LoadCustomers();
                            MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (ValidationException vex)
                    {
                        MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtCustomerSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadCustomers();
                    return;
                }
                var customers = customerService.GetAllCustomers()
                    .Where(c => c.Name.ToLower().Contains(searchText) ||
                                c.CustomerNumber.ToLower().Contains(searchText) ||
                                c.Email.ToLower().Contains(searchText) ||
                                c.Phone.ToLower().Contains(searchText) ||
                                c.Address.ToLower().Contains(searchText))
                    .ToList();
                customersListView.Items.Clear();
                foreach (var customer in customers)
                {
                    var item = new ListViewItem(customer.Id.ToString());
                    item.SubItems.Add(customer.Name);
                    item.SubItems.Add(customer.CustomerNumber);
                    item.SubItems.Add(customer.Email);
                    item.SubItems.Add(customer.Phone);
                    item.SubItems.Add(customer.Address);
                    item.SubItems.Add(customer.CreatedAt.ToString("yyyy-MM-dd"));
                    customersListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region Jobs Tab
        private void InitializedJobsTab()
        {
            IJobRepository jobRepository = new JobRepository();
            jobService = new JobService(jobRepository);

            LoadJobs();
            addJobsContextMenu();

            searchStartDate.Value = DateTime.Now.AddMonths(-1);
            searchEndDate.Value = DateTime.Now;
        }

        private void LoadJobs()
        {
            try
            {
                var jobs = jobService.GetAllJobs();
                jobsListView.Items.Clear();
                foreach (var job in jobs)
                {
                    var item = new ListViewItem(job.Id.ToString());
                    item.SubItems.Add(job.JobNumber);
                    item.SubItems.Add(job.CustomerName ?? "");
                    item.SubItems.Add(job.PickupLocation);
                    item.SubItems.Add(job.DeliveryLocation);
                    item.SubItems.Add(job.Status);
                    item.SubItems.Add(job.EstimatedCost.ToString("C"));
                    item.SubItems.Add(job.RequestDate.ToString("yyyy-MM-dd"));
                    jobsListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading jobs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addJobsContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem manageItem = new ToolStripMenuItem("Manage Job");
            manageItem.Click += ManageJob_Click;
            contextMenu.Items.Add(manageItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            jobsListView.ContextMenuStrip = contextMenu;
        }

        private void EditJob_Click(object sender, EventArgs e)
        {
            if (jobsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = jobsListView.SelectedItems[0];
                int jobId = int.Parse(selectedItem.Text);

                LoadJobs();
            }
            else
            {
                MessageBox.Show("Please select a job to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteJob_Click(object sender, EventArgs e)
        {
            if (jobsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = jobsListView.SelectedItems[0];
                int jobId = int.Parse(selectedItem.Text);
                string jobNumber = selectedItem.SubItems[1].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete job '{jobNumber}'?\n\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool deleted = jobService.DeleteJob(jobId);

                        if (deleted)
                        {
                            LoadJobs();
                            MessageBox.Show("Job deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete job.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (ValidationException vex)
                    {
                        MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a job to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ManageJob_Click(object sender, EventArgs e)
        {
            if (jobsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = jobsListView.SelectedItems[0];
                int jobId = int.Parse(selectedItem.Text);

                ManageJobModal manageJobModal = new ManageJobModal(jobId);
                manageJobModal.ShowDialog();

                LoadJobs();
            }
            else
            {
                MessageBox.Show("Please select a job to manage.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreateJob_Click(object sender, EventArgs e)
        {
            LoadJobs();
        }
        #endregion


        #region Units Tab
        private void InitializedUnitsTab()
        {
            ITruckRepository truckRepository = new TruckRepository();
            truckService = new TruckService(truckRepository);

            IDriverRepository driverRepository = new DriverRepository();
            driverService = new DriverService(driverRepository);

            IAssistantRepository assistantRepository = new AssistantRepository();
            assistantService = new AssistantService(assistantRepository);

            ITransportUnitRepository transportUnitRepository = new TransportUnitRepository();
            transportUnitService = new TransportUnitService(transportUnitRepository);

            LoadTrucks();
            LoadDrivers();
            LoadAssistants();
            LoadTransportUnits();

            addTrucksContextMenu();
            addDriversContextMenu();
            addAssistantsContextMenu();
            addTransportUnitsContextMenu();
        }

        private void addTrucksContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit Truck");
            editItem.Click += EditTruck_Click;
            contextMenu.Items.Add(editItem);

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Truck");
            deleteItem.Click += DeleteTruck_Click;
            contextMenu.Items.Add(deleteItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            trucksListView.ContextMenuStrip = contextMenu;
        }

        private void EditTruck_Click(object sender, EventArgs e)
        {
            if (trucksListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = trucksListView.SelectedItems[0];
                int truckId = int.Parse(selectedItem.Text);

                TruckUpdateModal truckUpdateModal = new TruckUpdateModal(truckId);
                truckUpdateModal.ShowDialog();

                LoadTrucks();
            }
            else
            {
                MessageBox.Show("Please select a truck to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteTruck_Click(object sender, EventArgs e)
        {
            if (trucksListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = trucksListView.SelectedItems[0];
                int truckId = int.Parse(selectedItem.Text);
                string truckNumber = selectedItem.SubItems[1].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete truck '{truckNumber}'?\n\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool deleted = truckService.DeleteTruck(truckId);

                        if (deleted)
                        {
                            LoadTrucks();
                            MessageBox.Show("Truck deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete truck.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (ValidationException vex)
                    {
                        MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting truck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a truck to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Trucks 
        private void LoadTrucks()
        {
            try
            {
                var trucks = truckService.GetAllTrucks();
                trucksListView.Items.Clear();
                foreach (var truck in trucks)
                {
                    var item = new ListViewItem(truck.Id.ToString());
                    item.SubItems.Add(truck.TruckNumber);
                    item.SubItems.Add(truck.Model);
                    item.SubItems.Add(truck.LicensePlate);
                    item.SubItems.Add(truck.Status);
                    item.SubItems.Add(truck.Capacity.ToString());
                    item.SubItems.Add(truck.CreatedAt.ToString("yyyy-MM-dd"));
                    trucksListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading trucks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateTruck_Click(object sender, EventArgs e)
        {
            TruckCreateModal truckCreateModal = new TruckCreateModal();
            truckCreateModal.ShowDialog();

            LoadTrucks();
        }
        #endregion

        #region Drivers 
        private void LoadDrivers()
        {
            try
            {
                var drivers = driverService.GetAllDrivers();
                driversListView.Items.Clear();
                foreach (var driver in drivers)
                {
                    var item = new ListViewItem(driver.Id.ToString());
                    item.SubItems.Add(driver.Name);
                    item.SubItems.Add(driver.LicenseNumber);
                    item.SubItems.Add(driver.Phone ?? "");
                    item.SubItems.Add(driver.Status);
                    item.SubItems.Add(driver.CreatedAt.ToString("yyyy-MM-dd"));
                    driversListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading drivers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addDriversContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit Driver");
            editItem.Click += EditDriver_Click;
            contextMenu.Items.Add(editItem);

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Driver");
            deleteItem.Click += DeleteDriver_Click;
            contextMenu.Items.Add(deleteItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            driversListView.ContextMenuStrip = contextMenu;
        }

        private void EditDriver_Click(object sender, EventArgs e)
        {
            if (driversListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = driversListView.SelectedItems[0];
                int driverId = int.Parse(selectedItem.Text);

                DriverUpdateModal driverUpdateModal = new DriverUpdateModal(driverId);
                driverUpdateModal.ShowDialog();

                LoadDrivers();
            }
            else
            {
                MessageBox.Show("Please select a driver to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteDriver_Click(object sender, EventArgs e)
        {
            if (driversListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = driversListView.SelectedItems[0];
                int driverId = int.Parse(selectedItem.Text);
                string driverName = selectedItem.SubItems[1].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete driver '{driverName}'?\n\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool deleted = driverService.DeleteDriver(driverId);

                        if (deleted)
                        {
                            LoadDrivers();
                            MessageBox.Show("Driver deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete driver.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (ValidationException vex)
                    {
                        MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting driver: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a driver to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreateDriver_Click(object sender, EventArgs e)
        {
            DriverCreateModal driverCreateModal = new DriverCreateModal();
            driverCreateModal.ShowDialog();

            LoadDrivers();
        }
        #endregion

        #region Assistants 
        private void LoadAssistants()
        {
            try
            {
                var assistants = assistantService.GetAllAssistants();
                assistantsListView.Items.Clear();
                foreach (var assistant in assistants)
                {
                    var item = new ListViewItem(assistant.Id.ToString());
                    item.SubItems.Add(assistant.Name);
                    item.SubItems.Add(assistant.Phone ?? "");
                    item.SubItems.Add(assistant.Status.ToString());
                    item.SubItems.Add(assistant.CreatedAt.ToString("yyyy-MM-dd"));
                    assistantsListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading assistants: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addAssistantsContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit Assistant");
            editItem.Click += EditAssistant_Click;
            contextMenu.Items.Add(editItem);

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Assistant");
            deleteItem.Click += DeleteAssistant_Click;
            contextMenu.Items.Add(deleteItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            assistantsListView.ContextMenuStrip = contextMenu;
        }

        private void EditAssistant_Click(object sender, EventArgs e)
        {
            if (assistantsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = assistantsListView.SelectedItems[0];
                int assistantId = int.Parse(selectedItem.Text);

                AssistantUpdateModal assistantUpdateModal = new AssistantUpdateModal(assistantId);
                assistantUpdateModal.ShowDialog();

                LoadAssistants();
            }
            else
            {
                MessageBox.Show("Please select an assistant to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteAssistant_Click(object sender, EventArgs e)
        {
            if (assistantsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = assistantsListView.SelectedItems[0];
                int assistantId = int.Parse(selectedItem.Text);
                string assistantName = selectedItem.SubItems[1].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete assistant '{assistantName}'?\n\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool deleted = assistantService.DeleteAssistant(assistantId);

                        if (deleted)
                        {
                            LoadAssistants();
                            MessageBox.Show("Assistant deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete assistant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (ValidationException vex)
                    {
                        MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting assistant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an assistant to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreateAssistant_Click(object sender, EventArgs e)
        {
            AssistantCreateModal assistantCreateModal = new AssistantCreateModal();
            assistantCreateModal.ShowDialog();

            LoadAssistants();
        }
        #endregion

        #region Transport Units
        private void LoadTransportUnits()
        {
            try
            {
                var units = transportUnitService.GetAllTransportUnits();
                transportUnitsListView.Items.Clear();
                foreach (var unit in units)
                {
                    var item = new ListViewItem(unit.Id.ToString());
                    item.SubItems.Add(unit.UnitNumber);
                    item.SubItems.Add(unit.TruckNumber ?? "");
                    item.SubItems.Add(unit.DriverName ?? "");
                    item.SubItems.Add(unit.AssistantName ?? "N/A");
                    item.SubItems.Add(unit.Status);
                    item.SubItems.Add(unit.CreatedAt.ToString("yyyy-MM-dd"));
                    transportUnitsListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transport units: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addTransportUnitsContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit Transport Unit");
            editItem.Click += EditTransportUnit_Click;
            contextMenu.Items.Add(editItem);

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Transport Unit");
            deleteItem.Click += DeleteTransportUnit_Click;
            contextMenu.Items.Add(deleteItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            transportUnitsListView.ContextMenuStrip = contextMenu;
        }

        private void EditTransportUnit_Click(object sender, EventArgs e)
        {
            if (transportUnitsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = transportUnitsListView.SelectedItems[0];
                int unitId = int.Parse(selectedItem.Text);

                TransportUnitUpdateModal unitUpdateModal = new TransportUnitUpdateModal(unitId);
                unitUpdateModal.ShowDialog();

                LoadTransportUnits();
            }
            else
            {
                MessageBox.Show("Please select a transport unit to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteTransportUnit_Click(object sender, EventArgs e)
        {
            if (transportUnitsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = transportUnitsListView.SelectedItems[0];
                int unitId = int.Parse(selectedItem.Text);
                string unitNumber = selectedItem.SubItems[1].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete transport unit '{unitNumber}'?\n\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool deleted = transportUnitService.DeleteTransportUnit(unitId);

                        if (deleted)
                        {
                            LoadTransportUnits();
                            MessageBox.Show("Transport unit deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete transport unit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (ValidationException vex)
                    {
                        MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting transport unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a transport unit to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreateTransportUnit_Click(object sender, EventArgs e)
        {
            TransportUnitCreateModal transportUnitCreateModal = new TransportUnitCreateModal();
            transportUnitCreateModal.ShowDialog();

            LoadTransportUnits();
        }
        #endregion

        #region Containers 
        private void btnCreateContainer_Click(object sender, EventArgs e)
        {
            ContainerCreateModal containerCreateModal = new ContainerCreateModal();
            containerCreateModal.ShowDialog();
        }
        #endregion


        #region Products Tab
        private void InitializedProductsTab()
        {
            IProductRepository productRepository = new ProductRepository();
            productService = new ProductService(productRepository);

            LoadProducts();
            addProductsContextMenu();
        }

        private void LoadProducts()
        {
            try
            {
                var products = productService.GetAllProducts();
                productsListView.Items.Clear();
                foreach (var product in products)
                {
                    var item = new ListViewItem(product.Id.ToString());
                    item.SubItems.Add(product.Name);
                    item.SubItems.Add(product.Weight?.ToString("F2") ?? "");
                    item.SubItems.Add(product.Dimensions?.ToString() ?? "");
                    item.SubItems.Add(product.CreatedAt.ToString("yyyy-MM-dd"));
                    productsListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addProductsContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit Product");
            editItem.Click += EditProduct_Click;
            contextMenu.Items.Add(editItem);

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Product");
            deleteItem.Click += DeleteProduct_Click;
            contextMenu.Items.Add(deleteItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            productsListView.ContextMenuStrip = contextMenu;
        }

        private void EditProduct_Click(object sender, EventArgs e)
        {
            if (productsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = productsListView.SelectedItems[0];
                int productId = int.Parse(selectedItem.Text);

                ProductUpdateModal productUpdateModal = new ProductUpdateModal(productId);
                productUpdateModal.ShowDialog();

                LoadProducts();
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteProduct_Click(object sender, EventArgs e)
        {
            if (productsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = productsListView.SelectedItems[0];
                int productId = int.Parse(selectedItem.Text);
                string productName = selectedItem.SubItems[1].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete product '{productName}'?\n\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool deleted = productService.DeleteProduct(productId);

                        if (deleted)
                        {
                            LoadProducts();
                            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (ValidationException vex)
                    {
                        MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            ProductCreateModal productCreateModal = new ProductCreateModal();
            productCreateModal.ShowDialog();

            LoadProducts();
        }
        #endregion

        #region Reports
        private void InitializedReportsTab()
        {
            reportService = new ReportService();
            InitializeReportTypes();
        }

        private void InitializeReportTypes()
        {
            cmbReportType.Items.Clear();
            cmbReportType.Items.Add(new { Text = "Customer Activity", Value = ReportType.CustomerActivity });
            cmbReportType.Items.Add(new { Text = "Job Summary", Value = ReportType.JobSummary });
            cmbReportType.Items.Add(new { Text = "Transport Unit Utilization", Value = ReportType.TransportUnitUtilization });
            cmbReportType.Items.Add(new { Text = "Driver Performance", Value = ReportType.DriverPerformance });
            cmbReportType.Items.Add(new { Text = "Revenue Analysis", Value = ReportType.RevenueAnalysis });

            cmbReportType.DisplayMember = "Text";
            cmbReportType.ValueMember = "Value";
            cmbReportType.SelectedIndex = 0;

            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbReportType.SelectedItem == null)
                {
                    MessageBox.Show("Please select a report type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);

                if (startDate > endDate)
                {
                    MessageBox.Show("Start date cannot be later than end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedReport = (dynamic)cmbReportType.SelectedItem;
                ReportType reportType = selectedReport.Value;

                this.Cursor = Cursors.WaitCursor;
                btnGenerate.Enabled = false;

                GenerateReport(reportType, startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGenerate.Enabled = true;
            }
        }

        private void GenerateReport(ReportType reportType, DateTime startDate, DateTime endDate)
        {
            try
            {
                switch (reportType)
                {
                    case ReportType.CustomerActivity:
                        var customerData = reportService.GetCustomerActivityReport(startDate, endDate);
                        DisplayCustomerActivityReport(customerData);
                        _currentReportData = new List<object>(customerData);
                        _currentReportTitle = "Customer Activity Report";
                        break;

                    case ReportType.JobSummary:
                        var jobData = reportService.GetJobSummaryReport(startDate, endDate);
                        DisplayJobSummaryReport(jobData);
                        _currentReportData = new List<object>(jobData);
                        _currentReportTitle = "Job Summary Report";
                        break;

                    case ReportType.TransportUnitUtilization:
                        var unitData = reportService.GetTransportUnitUtilizationReport(startDate, endDate);
                        DisplayTransportUnitReport(unitData);
                        _currentReportData = new List<object>(unitData);
                        _currentReportTitle = "Transport Unit Utilization Report";
                        break;

                    case ReportType.DriverPerformance:
                        var driverData = reportService.GetDriverPerformanceReport(startDate, endDate);
                        DisplayDriverPerformanceReport(driverData);
                        _currentReportData = new List<object>(driverData);
                        _currentReportTitle = "Driver Performance Report";
                        break;

                    case ReportType.RevenueAnalysis:
                        var revenueData = reportService.GetRevenueAnalysisReport(startDate, endDate, "month");
                        DisplayRevenueAnalysisReport(revenueData);
                        _currentReportData = new List<object>(revenueData);
                        _currentReportTitle = "Revenue Analysis Report";
                        break;

                    default:
                        MessageBox.Show("Report type not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                // Enable export buttons if data is available
                btnExportPDF.Enabled = _currentReportData != null && _currentReportData.Count > 0;
                btnExportExcel.Enabled = _currentReportData != null && _currentReportData.Count > 0;

                if (_currentReportData == null || _currentReportData.Count == 0)
                {
                    MessageBox.Show("No data found for the selected criteria.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCustomerActivityReport(List<CustomerActivityReportModel> data)
        {
            dgvReportData.DataSource = null;
            dgvReportData.DataSource = data;

            // Customize column headers and formatting
            if (dgvReportData.Columns.Count > 0)
            {
                dgvReportData.Columns["CustomerNumber"].HeaderText = "Customer #";
                dgvReportData.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvReportData.Columns["TotalJobs"].HeaderText = "Total Jobs";
                dgvReportData.Columns["CompletedJobs"].HeaderText = "Completed";
                dgvReportData.Columns["PendingJobs"].HeaderText = "Pending";
                dgvReportData.Columns["CancelledJobs"].HeaderText = "Cancelled";
                dgvReportData.Columns["TotalRevenue"].HeaderText = "Total Revenue";
                dgvReportData.Columns["AverageJobValue"].HeaderText = "Avg Job Value";
                dgvReportData.Columns["LastJobDate"].HeaderText = "Last Job Date";

                // Format currency columns
                dgvReportData.Columns["TotalRevenue"].DefaultCellStyle.Format = "C2";
                dgvReportData.Columns["AverageJobValue"].DefaultCellStyle.Format = "C2";
                dgvReportData.Columns["LastJobDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }

            dgvReportData.AutoResizeColumns();
        }

        private void DisplayJobSummaryReport(List<JobSummaryReportModel> data)
        {
            dgvReportData.DataSource = null;
            dgvReportData.DataSource = data;

            if (dgvReportData.Columns.Count > 0)
            {
                dgvReportData.Columns["JobNumber"].HeaderText = "Job #";
                dgvReportData.Columns["CustomerName"].HeaderText = "Customer";
                dgvReportData.Columns["PickupLocation"].HeaderText = "Pickup";
                dgvReportData.Columns["DeliveryLocation"].HeaderText = "Delivery";
                dgvReportData.Columns["RequestDate"].HeaderText = "Request Date";
                dgvReportData.Columns["ScheduledDate"].HeaderText = "Scheduled";
                dgvReportData.Columns["CompletionDate"].HeaderText = "Completed";
                dgvReportData.Columns["EstimatedCost"].HeaderText = "Est. Cost";
                dgvReportData.Columns["ActualCost"].HeaderText = "Actual Cost";
                dgvReportData.Columns["TransportUnit"].HeaderText = "Transport Unit";
                dgvReportData.Columns["DriverName"].HeaderText = "Driver";
                dgvReportData.Columns["TotalWeight"].HeaderText = "Weight (kg)";
                dgvReportData.Columns["TotalVolume"].HeaderText = "Volume";
                dgvReportData.Columns["DaysToComplete"].HeaderText = "Days";

                // Format columns
                dgvReportData.Columns["EstimatedCost"].DefaultCellStyle.Format = "C2";
                dgvReportData.Columns["ActualCost"].DefaultCellStyle.Format = "C2";
                dgvReportData.Columns["RequestDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvReportData.Columns["ScheduledDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvReportData.Columns["CompletionDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvReportData.Columns["TotalWeight"].DefaultCellStyle.Format = "F2";
                dgvReportData.Columns["TotalVolume"].DefaultCellStyle.Format = "F2";
            }

            dgvReportData.AutoResizeColumns();
        }

        private void DisplayTransportUnitReport(List<TransportUnitUtilizationReportModel> data)
        {
            dgvReportData.DataSource = null;
            dgvReportData.DataSource = data;

            if (dgvReportData.Columns.Count > 0)
            {
                dgvReportData.Columns["UnitNumber"].HeaderText = "Unit #";
                dgvReportData.Columns["TruckNumber"].HeaderText = "Truck #";
                dgvReportData.Columns["TruckModel"].HeaderText = "Model";
                dgvReportData.Columns["DriverName"].HeaderText = "Driver";
                dgvReportData.Columns["AssistantName"].HeaderText = "Assistant";
                dgvReportData.Columns["TotalJobs"].HeaderText = "Total Jobs";
                dgvReportData.Columns["CompletedJobs"].HeaderText = "Completed";
                dgvReportData.Columns["TotalRevenue"].HeaderText = "Revenue";
                dgvReportData.Columns["TotalWeight"].HeaderText = "Weight (kg)";
                dgvReportData.Columns["TotalVolume"].HeaderText = "Volume";
                dgvReportData.Columns["UtilizationPercentage"].HeaderText = "Utilization %";

                // Format columns
                dgvReportData.Columns["TotalRevenue"].DefaultCellStyle.Format = "C2";
                dgvReportData.Columns["TotalWeight"].DefaultCellStyle.Format = "F2";
                dgvReportData.Columns["TotalVolume"].DefaultCellStyle.Format = "F2";
                dgvReportData.Columns["UtilizationPercentage"].DefaultCellStyle.Format = "F1";
            }

            dgvReportData.AutoResizeColumns();
        }

        private void DisplayDriverPerformanceReport(List<DriverPerformanceReportModel> data)
        {
            dgvReportData.DataSource = null;
            dgvReportData.DataSource = data;

            if (dgvReportData.Columns.Count > 0)
            {
                dgvReportData.Columns["DriverName"].HeaderText = "Driver Name";
                dgvReportData.Columns["LicenseNumber"].HeaderText = "License #";
                dgvReportData.Columns["TotalJobs"].HeaderText = "Total Jobs";
                dgvReportData.Columns["CompletedJobs"].HeaderText = "Completed";
                dgvReportData.Columns["OnTimeJobs"].HeaderText = "On Time";
                dgvReportData.Columns["CompletionRate"].HeaderText = "Completion %";
                dgvReportData.Columns["OnTimeRate"].HeaderText = "On Time %";
                dgvReportData.Columns["TotalRevenue"].HeaderText = "Revenue";
                dgvReportData.Columns["AverageJobValue"].HeaderText = "Avg Job Value";
                dgvReportData.Columns["ActiveDays"].HeaderText = "Active Days";

                // Format columns
                dgvReportData.Columns["CompletionRate"].DefaultCellStyle.Format = "F1";
                dgvReportData.Columns["OnTimeRate"].DefaultCellStyle.Format = "F1";
                dgvReportData.Columns["TotalRevenue"].DefaultCellStyle.Format = "C2";
                dgvReportData.Columns["AverageJobValue"].DefaultCellStyle.Format = "C2";
            }

            dgvReportData.AutoResizeColumns();
        }

        private void DisplayRevenueAnalysisReport(List<RevenueAnalysisReportModel> data)
        {
            dgvReportData.DataSource = null;
            dgvReportData.DataSource = data;

            if (dgvReportData.Columns.Count > 0)
            {
                dgvReportData.Columns["Period"].HeaderText = "Period";
                dgvReportData.Columns["TotalJobs"].HeaderText = "Jobs";
                dgvReportData.Columns["EstimatedRevenue"].HeaderText = "Est. Revenue";
                dgvReportData.Columns["ActualRevenue"].HeaderText = "Actual Revenue";
                dgvReportData.Columns["RevenueVariance"].HeaderText = "Variance";
                dgvReportData.Columns["AverageJobValue"].HeaderText = "Avg Job Value";
                dgvReportData.Columns["NewCustomers"].HeaderText = "New Customers";
                dgvReportData.Columns["RepeatCustomers"].HeaderText = "Repeat Customers";

                // Format columns
                dgvReportData.Columns["Period"].DefaultCellStyle.Format = "yyyy-MM";
                dgvReportData.Columns["EstimatedRevenue"].DefaultCellStyle.Format = "C2";
                dgvReportData.Columns["ActualRevenue"].DefaultCellStyle.Format = "C2";
                dgvReportData.Columns["RevenueVariance"].DefaultCellStyle.Format = "C2";
                dgvReportData.Columns["AverageJobValue"].DefaultCellStyle.Format = "C2";
            }

            dgvReportData.AutoResizeColumns();
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentReportData == null || _currentReportData.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.FileName = $"{_currentReportTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    bool success = ExportCurrentReportToPDF(saveDialog.FileName);

                    if (success)
                    {
                        MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ask if user wants to open the file
                        DialogResult openResult = MessageBox.Show("Would you like to open the exported file?",
                            "Export Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (openResult == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to export report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentReportData == null || _currentReportData.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FileName = $"{_currentReportTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    bool success = ExportCurrentReportToExcel(saveDialog.FileName);

                    if (success)
                    {
                        MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ask if user wants to open the file
                        DialogResult openResult = MessageBox.Show("Would you like to open the exported file?",
                            "Export Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (openResult == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to export report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ExportCurrentReportToPDF(string filePath)
        {
            var selectedReport = (dynamic)cmbReportType.SelectedItem;
            ReportType reportType = selectedReport.Value;

            switch (reportType)
            {
                case ReportType.CustomerActivity:
                    return reportService.ExportToPDF(
                        _currentReportData.Cast<CustomerActivityReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                case ReportType.JobSummary:
                    return reportService.ExportToPDF(
                        _currentReportData.Cast<JobSummaryReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                case ReportType.TransportUnitUtilization:
                    return reportService.ExportToPDF(
                        _currentReportData.Cast<TransportUnitUtilizationReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                case ReportType.DriverPerformance:
                    return reportService.ExportToPDF(
                        _currentReportData.Cast<DriverPerformanceReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                case ReportType.RevenueAnalysis:
                    return reportService.ExportToPDF(
                        _currentReportData.Cast<RevenueAnalysisReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                default:
                    return false;
            }
        }

        private bool ExportCurrentReportToExcel(string filePath)
        {
            var selectedReport = (dynamic)cmbReportType.SelectedItem;
            ReportType reportType = selectedReport.Value;

            switch (reportType)
            {
                case ReportType.CustomerActivity:
                    return reportService.ExportToExcelWithClosedXML(
                        _currentReportData.Cast<CustomerActivityReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                case ReportType.JobSummary:
                    return reportService.ExportToExcelWithClosedXML(
                        _currentReportData.Cast<JobSummaryReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                case ReportType.TransportUnitUtilization:
                    return reportService.ExportToExcelWithClosedXML(
                        _currentReportData.Cast<TransportUnitUtilizationReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                case ReportType.DriverPerformance:
                    return reportService.ExportToExcelWithClosedXML(
                        _currentReportData.Cast<DriverPerformanceReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                case ReportType.RevenueAnalysis:
                    return reportService.ExportToExcelWithClosedXML(
                        _currentReportData.Cast<RevenueAnalysisReportModel>().ToList(),
                        _currentReportTitle,
                        filePath
                    );
                default:
                    return false;
            }
        }

        // Optional: Add refresh functionality
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem != null)
            {
                btnGenerate_Click(sender, e);
            }
        }

        // Optional: Add print functionality
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentReportData == null || _currentReportData.Count == 0)
                {
                    MessageBox.Show("No data to print.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a temporary PDF file for printing
                string tempPath = Path.Combine(Path.GetTempPath(), $"TempReport_{DateTime.Now:yyyyMMddHHmmss}.pdf");

                if (ExportCurrentReportToPDF(tempPath))
                {
                    System.Diagnostics.Process.Start(tempPath);
                }
                else
                {
                    MessageBox.Show("Failed to generate print preview.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Search Methods
        private void btnTruckSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTruckSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadTrucks();
                    return;
                }
                var trucks = truckService.GetAllTrucks()
                    .Where(t => t.TruckNumber.ToLower().Contains(searchText) ||
                                t.Model.ToLower().Contains(searchText) ||
                                t.LicensePlate.ToLower().Contains(searchText) ||
                                t.Status.ToLower().Contains(searchText))
                    .ToList();
                trucksListView.Items.Clear();
                foreach (var truck in trucks)
                {
                    var item = new ListViewItem(truck.Id.ToString());
                    item.SubItems.Add(truck.TruckNumber);
                    item.SubItems.Add(truck.Model);
                    item.SubItems.Add(truck.LicensePlate);
                    item.SubItems.Add(truck.Status);
                    item.SubItems.Add(truck.Capacity.ToString());
                    item.SubItems.Add(truck.CreatedAt.ToString("yyyy-MM-dd"));
                    trucksListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching trucks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnDriverSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtDriverSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadDrivers();
                    return;
                }
                var drivers = driverService.GetAllDrivers()
                    .Where(d => d.Name.ToLower().Contains(searchText) ||
                                d.LicenseNumber.ToLower().Contains(searchText) ||
                                (d.Phone ?? "").ToLower().Contains(searchText) ||
                                (d.Address ?? "").ToLower().Contains(searchText))
                    .ToList();
                driversListView.Items.Clear();
                foreach (var driver in drivers)
                {
                    var item = new ListViewItem(driver.Id.ToString());
                    item.SubItems.Add(driver.Name);
                    item.SubItems.Add(driver.LicenseNumber);
                    item.SubItems.Add(driver.Phone ?? "");
                    item.SubItems.Add(driver.Status);
                    item.SubItems.Add(driver.CreatedAt.ToString("yyyy-MM-dd"));
                    driversListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching drivers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssistantSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtAssistantSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadAssistants();
                    return;
                }
                var assistants = assistantService.GetAllAssistants()
                    .Where(a => a.Name.ToLower().Contains(searchText) ||
                                (a.Phone ?? "").ToLower().Contains(searchText) ||
                                (a.Address ?? "").ToLower().Contains(searchText))
                    .ToList();
                assistantsListView.Items.Clear();
                foreach (var assistant in assistants)
                {
                    var item = new ListViewItem(assistant.Id.ToString());
                    item.SubItems.Add(assistant.Name);
                    item.SubItems.Add(assistant.Phone ?? "");
                    item.SubItems.Add(assistant.Status.ToString());
                    item.SubItems.Add(assistant.CreatedAt.ToString("yyyy-MM-dd"));
                    assistantsListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching assistants: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnJobSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtJobSearch.Text.Trim().ToLower();

                var startDateEnabled = searchStartDate.Checked;
                var endDateEnabled = searchEndDate.Checked;

                var startDate = searchStartDate.Value.Date;
                var endDate = searchEndDate.Value.Date;

                var jobs = jobService.GetAllJobs()
                    .Where(j =>
                        (string.IsNullOrEmpty(searchText) ||
                            j.JobNumber.ToLower().Contains(searchText) ||
                            (j.CustomerName ?? "").ToLower().Contains(searchText) ||
                            j.PickupLocation.ToLower().Contains(searchText) ||
                            j.DeliveryLocation.ToLower().Contains(searchText) ||
                            j.Status.ToLower().Contains(searchText)) &&
                        (!startDateEnabled || j.RequestDate.Date >= startDate) &&
                        (!endDateEnabled || j.RequestDate.Date <= endDate)
                    )
                    .ToList();

                jobsListView.Items.Clear();
                foreach (var job in jobs)
                {
                    var item = new ListViewItem(job.Id.ToString());
                    item.SubItems.Add(job.JobNumber);
                    item.SubItems.Add(job.CustomerName ?? "");
                    item.SubItems.Add(job.PickupLocation);
                    item.SubItems.Add(job.DeliveryLocation);
                    item.SubItems.Add(job.Status);
                    item.SubItems.Add(job.EstimatedCost.ToString("C"));
                    item.SubItems.Add(job.RequestDate.ToString("yyyy-MM-dd"));
                    jobsListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching jobs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransportUnitSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTransportUnitSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadTransportUnits();
                    return;
                }
                var units = transportUnitService.GetAllTransportUnits()
                    .Where(tu => tu.UnitNumber.ToLower().Contains(searchText) ||
                                 (tu.TruckNumber ?? "").ToLower().Contains(searchText) ||
                                 (tu.DriverName ?? "").ToLower().Contains(searchText) ||
                                 (tu.AssistantName ?? "").ToLower().Contains(searchText) ||
                                 tu.Status.ToLower().Contains(searchText))
                    .ToList();
                transportUnitsListView.Items.Clear();
                foreach (var unit in units)
                {
                    var item = new ListViewItem(unit.Id.ToString());
                    item.SubItems.Add(unit.UnitNumber);
                    item.SubItems.Add(unit.TruckNumber ?? "");
                    item.SubItems.Add(unit.DriverName ?? "");
                    item.SubItems.Add(unit.AssistantName ?? "N/A");
                    item.SubItems.Add(unit.Status);
                    item.SubItems.Add(unit.CreatedAt.ToString("yyyy-MM-dd"));
                    transportUnitsListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching transport units: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtProductSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(searchText))
                {
                    LoadProducts();
                    return;
                }
                var products = productService.GetAllProducts()
                    .Where(p => p.Name.ToLower().Contains(searchText))
                    .ToList();
                productsListView.Items.Clear();
                foreach (var product in products)
                {
                    var item = new ListViewItem(product.Id.ToString());
                    item.SubItems.Add(product.Name);
                    item.SubItems.Add(product.Weight?.ToString("F2") ?? "");
                    item.SubItems.Add(product.Dimensions?.ToString() ?? "");
                    item.SubItems.Add(product.CreatedAt.ToString("yyyy-MM-dd"));
                    productsListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        

        #region Refresh Methods
        private void btnRefreshCustomers_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void btnRefreshJobs_Click(object sender, EventArgs e)
        {
            LoadJobs();
        }

        private void btnRefreshTrucks_Click(object sender, EventArgs e)
        {
            LoadTrucks();
        }

        private void btnRefreshDrivers_Click(object sender, EventArgs e)
        {
            LoadDrivers();
        }

        private void btnRefreshAssistants_Click(object sender, EventArgs e)
        {
            LoadAssistants();
        }

        private void btnRefreshTransportUnits_Click(object sender, EventArgs e)
        {
            LoadTransportUnits();
        }

        private void btnRefreshProducts_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
        #endregion


        #region Helper Methods
        private void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string message, string title = "Success")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowWarning(string message, string title = "Warning")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowInfo(string message, string title = "Information")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ConfirmDelete(string itemName, string itemType = "item")
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {itemType} '{itemName}'?\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            return result == DialogResult.Yes;
        }
        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();

            this.Hide();
        }
    }
}
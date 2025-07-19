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
using AD_CW_1.Business.Services;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Repositories.Services;
using AD_CW_1.Business.Interface;
using System.ComponentModel.DataAnnotations;
using AD_CW_1.Helpers;
using AD_CW_1.Models;
using AD_CW_1.Models.Dashboard;

namespace AD_CW_1.Forms
{
    public partial class CustomerDashboardPage : MaterialForm
    {
        private IJobService jobService;
        private ICustomerService customerService;
        private IDashboardService dashboardService;

        UserModel user;
        CustomerModel customer;

        public CustomerDashboardPage(UserModel userData)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);

            user = userData;
            customerService = new CustomerService(new CustomerRepository());
            customer = customerService.GetCustomerByUserId(user.Id);
            if (customer == null)
            {
                MessageBox.Show("Customer not found. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InitializeComponent();

            InitializeDashboardTab();
            InitializedJobsTab();
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

        #region Jobs Tab
        private void InitializedJobsTab()
        {
            IJobRepository jobRepository = new JobRepository();
            jobService = new JobService(jobRepository);

            LoadJobs();
            addJobsContextMenu();
        }

        private void LoadJobs()
        {
            try
            {
                var jobs = jobService.GetJobsByCustomerId(customer.Id);
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

            ToolStripMenuItem manageItem = new ToolStripMenuItem("Job Summery");
            manageItem.Click += JobSummery_Click;
            contextMenu.Items.Add(manageItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            jobsListView.ContextMenuStrip = contextMenu;
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

        private void JobSummery_Click(object sender, EventArgs e)
        {
            if (jobsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = jobsListView.SelectedItems[0];
                int jobId = int.Parse(selectedItem.Text);

                JobSummeryModal jobSummeryModal = new JobSummeryModal(jobId);
                jobSummeryModal.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a job to view Summery.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void btnCreateRequest_Click(object sender, EventArgs e)
        {
            TransferRequestModal requestJobModal = new TransferRequestModal(customer.Id);
            requestJobModal.ShowDialog();

            LoadJobs();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();

            this.Hide();
        }
    }
 }

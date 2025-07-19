using AD_CW_1.Business.Interface;
using AD_CW_1.Business.Services;
using AD_CW_1.Models;
using AD_CW_1.Repositories;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Repositories.Services;
using FluentValidation;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AD_CW_1.Forms.Admin
{
    public partial class ManageJobModal : MaterialForm
    {
        private readonly IJobService _jobService;
        private readonly ICustomerService _customerService;
        private readonly ITransportUnitService _transportUnitService;
        private readonly IProductService _productService;
        private readonly IJobProductService _jobProductService;
        private readonly ILoadService _loadService;

        private JobModel _currentJob;
        private List<JobProductModel> _jobProducts;
        private List<LoadModel> _jobLoads;
        private decimal _totalWeight = 0;
        private decimal _totalVolume = 0;

        public ManageJobModal(int jobId)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);

            IJobRepository jobRepository = new JobRepository();
            _jobService = new JobService(jobRepository);

            ICustomerRepository customerRepository = new CustomerRepository();
            _customerService = new CustomerService(customerRepository);

            ITransportUnitRepository transportUnitRepository = new TransportUnitRepository();
            _transportUnitService = new TransportUnitService(transportUnitRepository);

            IProductRepository productRepository = new ProductRepository();
            _productService = new ProductService(productRepository);

            IJobProductRepository jobProductRepository = new JobProductRepository();
            _jobProductService = new JobProductService(jobProductRepository);

            ILoadRepository loadRepository = new LoadRepository();
            _loadService = new LoadService(loadRepository);

            LoadJobData(jobId);
            LoadDropdownData();
            LoadJobProducts();
            LoadJobLoads();
            CalculateTotals();
        }

        private void LoadJobData(int jobId)
        {
            try
            {
                _currentJob = _jobService.GetJobById(jobId);
                if (_currentJob != null)
                {
                    JobNumber.Text = _currentJob.JobNumber;
                    lblJobStatus.Text = _currentJob.Status;
                    lblDate.Text = _currentJob.RequestDate.ToString("dd/MM/yyyy");
                    lblPickupLocation.Text = _currentJob.PickupLocation;
                    lblDeliveryLocation.Text = _currentJob.DeliveryLocation;
                    lblEstimatedCost.Text = _currentJob.EstimatedCost.ToString("C");

                    var customer = _customerService.GetCustomerById(_currentJob.CustomerId);
                    if (customer != null)
                    {
                        lblCustomerName.Text = customer.Name;
                        lblCustomerEmail.Text = customer.Email;
                        lblCustomerPhone.Text = customer.Phone;
                    }
                }
                else
                {
                    MessageBox.Show("Job not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading job data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void LoadDropdownData()
        {
            try
            {
                var transportUnits = _transportUnitService.GetAllTransportUnits()
                    .Where(tu => tu.Status == "Active") // Only active units
                    .ToList();

                transportUnits.Insert(0, new TransportUnitModel { Id = 0, UnitNumber = "Select Transport Unit" });
                cmbTransportUnit.DataSource = transportUnits;
                cmbTransportUnit.DisplayMember = "UnitNumber";
                cmbTransportUnit.ValueMember = "Id";
                cmbTransportUnit.SelectedValue = _currentJob.TransportUnitId ?? 0;

                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new[] { "Pending", "Confirmed", "In Progress", "Completed", "Cancelled" });
                cmbStatus.SelectedItem = _currentJob.Status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dropdown data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadJobProducts()
        {
            try
            {
                _jobProducts = _jobProductService.GetJobProductsByJobId(_currentJob.Id);
                mlvProducts.Items.Clear();

                foreach (var jobProduct in _jobProducts)
                {
                    var product = _productService.GetProductById(jobProduct.ProductId.Value);
                    if (product != null)
                    {
                        var item = new ListViewItem(jobProduct.Id.ToString());
                        item.SubItems.Add(product.Name);
                        item.SubItems.Add(jobProduct.Quantity?.ToString() ?? "0");
                        item.Tag = jobProduct;
                        mlvProducts.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading job products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadJobLoads()
        {
            try
            {
                _jobLoads = _loadService.GetLoadsByJobId(_currentJob.Id);
                mlvLoads.Items.Clear();

                foreach (var load in _jobLoads)
                {
                    var item = new ListViewItem(load.Id.ToString());
                    item.SubItems.Add(load.LoadNumber);
                    item.SubItems.Add($"{load.Weight}kg");
                    item.SubItems.Add(load.Volume.ToString());
                    item.Tag = load;
                    mlvLoads.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading job loads: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotals()
        {
            _totalWeight = _jobLoads?.Sum(l => l.Weight) ?? 0;
            _totalVolume = _jobLoads?.Sum(l => l.Volume) ?? 0;

            lblTotalWeight.Text = $"{_totalWeight}kg";
            lblTotalVolume.Text = _totalVolume.ToString();
        }

        private void btnAssignTransportUnit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTransportUnit.SelectedValue == null || Convert.ToInt32(cmbTransportUnit.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select a transport unit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _currentJob.TransportUnitId = Convert.ToInt32(cmbTransportUnit.SelectedValue);
                bool updated = _jobService.UpdateJob(_currentJob);

                if (updated)
                {
                    MessageBox.Show("Transport unit assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var selectedUnit = _transportUnitService.GetTransportUnitById(_currentJob.TransportUnitId.Value);
                    
                }
                else
                {
                    MessageBox.Show("Failed to assign transport unit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning transport unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtWeight.Text) || string.IsNullOrWhiteSpace(txtVolume.Text))
                {
                    MessageBox.Show("Please enter weight and volume.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtWeight.Text, out decimal weight) || !decimal.TryParse(txtVolume.Text, out decimal volume))
                {
                    MessageBox.Show("Please enter valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (weight <= 0 || volume <= 0)
                {
                    MessageBox.Show("Weight and volume must be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newLoad = new LoadModel
                {
                    LoadNumber = GenerateLoadNumber(),
                    JobId = _currentJob.Id,
                    Description = "Manual Load Entry",
                    Weight = weight,
                    Volume = volume,
                    Instructions = "Added via Manage Job Modal",
                    CreatedAt = DateTime.Now
                };

                bool created = _loadService.AddLoad(newLoad);
                if (created)
                {
                    txtWeight.Clear();
                    txtVolume.Clear();

                    LoadJobLoads();
                    CalculateTotals();

                    MessageBox.Show("Load added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStatus.SelectedItem == null)
                {
                    MessageBox.Show("Please select a status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string newStatus = cmbStatus.SelectedItem.ToString();
                string oldStatus = _currentJob.Status;

                _currentJob.Status = newStatus;

                if (newStatus == "Completed" && oldStatus != "Completed")
                {
                    _currentJob.CompletionDate = DateTime.Now;
                }

                if (newStatus == "Confirmed")
                {
                    _currentJob.EstimatedCost = _totalWeight * 10;
                }

                bool updated = _jobService.UpdateJob(_currentJob);

                if (updated)
                {
                    lblJobStatus.Text = _currentJob.Status;

                    LogStatusChange(oldStatus, newStatus);

                    MessageBox.Show("Job status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update job status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating job status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateLoadNumber()
        {
            return $"LD{_currentJob.JobNumber}{DateTime.Now:yyyyMMddHHmmss}";
        }

        private void LogStatusChange(string oldStatus, string newStatus)
        {
            try
            {
                // var statusLog = new JobStatusLogModel
                // {
                //     JobId = _currentJob.Id,
                //     Status = newStatus,
                //     Note = $"Status changed from {oldStatus} to {newStatus}",
                //     UpdatedBy = CurrentUser.Id,
                //     CreatedAt = DateTime.Now
                // };
                // _jobStatusLogService.AddStatusLog(statusLog);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error logging status change: {ex.Message}");
            }
        }

        private void RefreshAllData()
        {
            try
            {
                LoadJobProducts();
                LoadJobLoads();
                CalculateTotals();
                LoadDropdownData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveSelectedLoad()
        {
            try
            {
                if (mlvLoads.SelectedItems.Count > 0)
                {
                    var selectedItem = mlvLoads.SelectedItems[0];
                    var loadToRemove = (LoadModel)selectedItem.Tag;

                    if (loadToRemove != null)
                    {
                        DialogResult result = MessageBox.Show(
                            $"Are you sure you want to remove load '{loadToRemove.LoadNumber}'?",
                            "Confirm Removal",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            bool removed = _loadService.DeleteLoad(loadToRemove.Id);
                            if (removed)
                            {
                                LoadJobLoads();
                                CalculateTotals();
                                MessageBox.Show("Load removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to remove load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a load to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateTransportUnitAssignment(int transportUnitId)
        {
            try
            {
                var transportUnit = _transportUnitService.GetTransportUnitById(transportUnitId);
                if (transportUnit == null)
                {
                    MessageBox.Show("Selected transport unit not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (transportUnit.Status != "1")
                {
                    MessageBox.Show("Selected transport unit is not active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error validating transport unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
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
    public partial class JobSummeryModal : MaterialForm
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

        public JobSummeryModal(int jobId)
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
            LoadJobProducts();
            LoadJobLoads();
            CalculateTotals();
            LoadTransportUnit();
        }

        private void LoadTransportUnit()
        {
            try
            {
                if (_currentJob.TransportUnitId.HasValue)
                {
                    var transportUnit = _transportUnitService.GetTransportUnitById(_currentJob.TransportUnitId.Value);
                    if (transportUnit != null)
                    {
                        lblTransportUnit.Text = transportUnit.UnitNumber;
                    }
                    else
                    {
                        lblTransportUnit.Text = "N/A";
                    }
                }
                else
                {
                    lblTransportUnit.Text = "N/A";
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transport unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
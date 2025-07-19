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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_CW_1.Forms.Admin
{
    public partial class TransferRequestModal : MaterialForm
    {
        private IProductService _productService;
        private IJobService _jobService;
        private IJobProductService _jobProductService;

        private JobModel _currentJob;
        private List<JobProductModel> _jobProducts;

        private int CustomerId;

        public TransferRequestModal(int customerId)
        {
            InitializeComponent();
            SetupMaterialSkin();
            InitializeServices();
            LoadDropdownData();
            _jobProducts = new List<JobProductModel>();
            CustomerId = customerId;
        }

        private void SetupMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);
        }

        private void InitializeServices()
        {
            IProductRepository productRepository = new ProductRepository();
            _productService = new ProductService(productRepository);

            IJobRepository jobRepository = new JobRepository();
            _jobService = new JobService(jobRepository);

            IJobProductRepository jobProductRepository = new JobProductRepository();
            _jobProductService = new JobProductService(jobProductRepository);
        }

        private void LoadDropdownData()
        {
            try
            {
                var products = _productService.GetAllProducts().ToList();
                products.Insert(0, new ProductModel { Id = 0, Name = "Select Product" });
                cmbProduct.DataSource = products;
                cmbProduct.DisplayMember = "Name";
                cmbProduct.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProduct.SelectedValue == null || Convert.ToInt32(cmbProduct.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select a product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int productId = Convert.ToInt32(cmbProduct.SelectedValue);
                var product = _productService.GetProductById(productId);

                var jobProduct = new JobProductModel
                {
                    ProductId = productId,
                    Quantity = quantity,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _jobProducts.Add(jobProduct);

                var item = new ListViewItem(_jobProducts.Count.ToString());
                item.SubItems.Add(product.Name);
                item.SubItems.Add(quantity.ToString());
                mlvProducts.Items.Add(item);

                cmbProduct.SelectedIndex = 0;
                txtQuantity.Clear();

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSubmitRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPickupLocation.Text))
                {
                    MessageBox.Show("Please enter pickup location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDeliveryLocation.Text))
                {
                    MessageBox.Show("Please enter delivery location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_jobProducts.Count == 0)
                {
                    MessageBox.Show("Please add at least one product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var job = new JobModel
                {
                    JobNumber = $"JOB{DateTime.Now:yyyyMMddHHmmss}",
                    CustomerId = CustomerId,
                    PickupLocation = txtPickupLocation.Text.Trim(),
                    DeliveryLocation = txtDeliveryLocation.Text.Trim(),
                    RequestDate = DateTime.Now,
                    Description = "Transfer Request",
                    EstimatedCost = 0,
                    Status = "Pending",
                    Notes = txtNote.Text,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                int created = _jobService.AddJob(job);

                if (created > 0)
                {
                    foreach (var product in _jobProducts)
                    {
                        product.JobId = created;
                        _jobProductService.AddJobProduct(product);
                    }

                    MessageBox.Show("Transfer request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to submit transfer request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
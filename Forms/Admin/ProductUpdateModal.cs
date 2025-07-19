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
using System.Windows.Forms;

namespace AD_CW_1.Forms.Admin
{
    public partial class ProductUpdateModal : MaterialForm
    {
        private readonly IProductService _productService;
        private readonly int _productId;
        private ProductModel _currentProduct;

        public ProductUpdateModal(int productId)
        {
            InitializeComponent();
            _productId = productId;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue700, Primary.Blue900, Primary.Blue700,
                Accent.Blue700, TextShade.WHITE);

            IProductRepository productRepository = new ProductRepository();
            _productService = new ProductService(productRepository);

            LoadProductData();
        }

        private void LoadProductData()
        {
            try
            {
                _currentProduct = _productService.GetProductById(_productId);

                if (_currentProduct != null)
                {
                    txtProductName.Text = _currentProduct.Name;
                    txtWeight.Text = _currentProduct.Weight?.ToString() ?? "0";
                    txtDimensions.Text = _currentProduct.Dimensions?.ToString() ?? "0";
                }
                else
                {
                    MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal? weight = 0;

                if (decimal.TryParse(txtWeight.Text, out decimal parsedWeight) && parsedWeight > 0)
                    weight = parsedWeight;

                ProductModel productModel = new ProductModel
                {
                    Id = _productId,
                    Name = txtProductName.Text.Trim(),
                    Weight = weight,
                    Dimensions = txtDimensions.Text.Trim(),
                    CreatedAt = _currentProduct.CreatedAt,
                    UpdatedAt = DateTime.Now
                };

                bool updated = _productService.UpdateProduct(productModel);
                if (updated)
                {
                    MessageBox.Show("Product Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to update product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

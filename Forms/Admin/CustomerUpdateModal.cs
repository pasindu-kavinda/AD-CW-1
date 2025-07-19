using AD_CW_1.Business.Interface;
using AD_CW_1.Business.Services;
using AD_CW_1.Helpers;
using AD_CW_1.Models;
using AD_CW_1.Repositories;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Repositories.Services;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_CW_1.Forms.Admin
{
    public partial class CustomerUpdateModal : MaterialForm
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private CustomerModel customer;

        public CustomerUpdateModal(int customerId)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);

            ICustomerRepository customerRepository = new CustomerRepository();
            _customerService = new CustomerService(customerRepository);

            IUserRepository userRepository = new UserRepository();
            _userService = new UserService(userRepository);

            try
            {
                customer = _customerService.GetCustomerById(customerId);

                txtCustomerNumber.Text = customer.CustomerNumber;
                txtCustomerName.Text = customer.Name;
                txtCustomerAddress.Text = customer.Address;
                txtCustomerPhone.Text = customer.Phone;
                txtCustomerEmail.Text = customer.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading customer data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerEmail.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerNumber.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!txtCustomerEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            try
            {
                CustomerModel customerModel = new CustomerModel
                {
                    Id = customer.Id,
                    UserId = customer.UserId,
                    CustomerNumber = txtCustomerNumber.Text,
                    Name = txtCustomerName.Text,
                    Address = txtCustomerAddress.Text,
                    Phone = txtCustomerPhone.Text,
                    Email = txtCustomerEmail.Text,
                    CreatedAt = DateTime.Now
                };

                bool customerUpdated = _customerService.UpdateCustomer(customerModel);
                if (customerUpdated)
                {
                    EmailHelper.SendEmail(customerModel.Email, "Your Account Updated",
                    $"Dear {customerModel.Name},\n\n" +
                    $"Your account has been updated successfully.\n" +
                    "Thank you!");

                    MessageBox.Show("Customer Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the customer. Please try again." + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

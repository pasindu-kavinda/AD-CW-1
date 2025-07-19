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
    public partial class CustomerCreateModal : MaterialForm
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;

        public CustomerCreateModal()
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
                if (_customerService.GetCustomerByEmail(txtCustomerEmail.Text) != null)
                {
                    MessageBox.Show("A customer with this email already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string password = PasswordHelper.GeneratePassword();
                UserModel userModel = new UserModel
                {
                    Username = txtCustomerNumber.Text,
                    Password = PasswordHelper.HashPassword(password),
                    Role = "customer",
                    CreatedAt = DateTime.Now
                };

                userModel.Id = _userService.AddUser(userModel);

                if (userModel.Id > 0)
                {
                    CustomerModel customerModel = new CustomerModel
                    {
                        UserId = userModel.Id,
                        CustomerNumber = txtCustomerNumber.Text,
                        Name = txtCustomerName.Text,
                        Address = txtCustomerAddress.Text,
                        Phone = txtCustomerPhone.Text,
                        Email = txtCustomerEmail.Text,
                        CreatedAt = DateTime.Now
                    };

                    bool customerCreated = _customerService.AddCustomer(customerModel);
                    if (customerCreated)
                    {
                        MessageBox.Show("Customer Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        EmailHelper.SendEmail(customerModel.Email, "Your Account Credentials",
                        $"Dear {customerModel.Name},\n\n" +
                        $"Your account has been created successfully.\n" +
                        $"Username: {customerModel.CustomerNumber}\n" +
                        $"Password: {password}\n\n" +
                        "Please change your password after logging in for the first time.\n\n" +
                        "Thank you!");

                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to create customer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the customer. Please try again." + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

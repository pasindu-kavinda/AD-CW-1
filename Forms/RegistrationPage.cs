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

namespace AD_CW_1.Forms
{
    public partial class RegistrationPage : MaterialForm
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;

        public RegistrationPage()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);
            InitializeComponent();

            ICustomerRepository customerRepository = new CustomerRepository();
            _customerService = new CustomerService(customerRepository);

            IUserRepository userRepository = new UserRepository();
            _userService = new UserService(userRepository);
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtEmail.Text.Contains("@") || !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPhoneNumber(txtPhone.Text))
            {
                MessageBox.Show("Please enter a valid phone number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (_customerService.GetCustomerByEmail(txtEmail.Text) != null)
                {
                    MessageBox.Show("A customer with this email already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string customerNumber = GenerateCustomerNumber();

                UserModel userModel = new UserModel
                {
                    Username = customerNumber,
                    Password = PasswordHelper.HashPassword(txtPassword.Text),
                    Role = "customer",
                    CreatedAt = DateTime.Now
                };

                userModel.Id = _userService.AddUser(userModel);

                Console.WriteLine($"============================================== {userModel.Id}");

                if (userModel.Id > 0)
                {
                    CustomerModel customerModel = new CustomerModel
                    {
                        UserId = userModel.Id,
                        CustomerNumber = customerNumber,
                        Name = txtName.Text.Trim(),
                        Address = "",
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim().ToLower(),
                        CreatedAt = DateTime.Now
                    };

                    bool customerCreated = _customerService.AddCustomer(customerModel);

                    if (customerCreated)
                    {
                        MessageBox.Show("Account created successfully! Please check your email for login details.",
                                      "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        try
                        {
                            EmailHelper.SendEmail(customerModel.Email, "Welcome to E-Shift Household Goods",
                            $"Dear {customerModel.Name},\n\n" +
                            $"Welcome to E-Shift Household Goods! Your account has been created successfully.\n\n" +
                            $"Your login credentials:\n" +
                            $"Username: {customerModel.CustomerNumber}\n" +
                            $"Password: {txtPassword.Text}\n\n" +
                            "You can now log in to your account and start using our services.\n" +
                            "For security reasons, we recommend changing your password after your first login.\n\n" +
                            "Thank you for choosing E-Shift Household Goods!\n" +
                            "Shifting Comfort, Delivering Trust.");
                        }
                        catch (Exception emailEx)
                        {
                            Debug.Print("Email sending failed: " + emailEx.Message);
                        }

                        ClearForm();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create customer account. Please try again.",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to create user account. Please try again.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the account. Please try again.\n" + ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.Print("Signup error: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            string cleanPhone = new string(phone.Where(char.IsDigit).ToArray());
            return cleanPhone.Length >= 10 && cleanPhone.Length <= 15;
        }

        private string GenerateCustomerNumber()
        {
            Random random = new Random();
            string prefix = "CUST";
            string timestamp = DateTime.Now.ToString("yyyyMMdd");
            string randomSuffix = random.Next(1000, 9999).ToString();

            return $"{prefix}{timestamp}{randomSuffix}";
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '(' &&
                e.KeyChar != ')' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Invalid Email",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text) &&
                !string.IsNullOrWhiteSpace(txtConfirmPassword.Text) &&
                txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Password Mismatch",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
            }
        }
    }
}
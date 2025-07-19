using AD_CW_1.Business.Interface;
using AD_CW_1.Business.Services;
using AD_CW_1.Helpers;
using AD_CW_1.Models;
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
    public partial class LoginPage: MaterialForm
    {
        private readonly IUserService _userService;

        public LoginPage()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);
            IUserRepository userRepository = new UserRepository();
            _userService = new UserService(userRepository);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login(sender, e);
        }

        private void login(object sender, EventArgs e)
        {
            string username = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserModel user = _userService.GetUserByUsername(username);

            if (user == null) {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Debug.WriteLine($"User: {user?.Username}, Password: {user?.Password}");
            if (PasswordHelper.VerifyPassword(password, user.Password))
            {
                Debug.WriteLine("Login successful");
                AuthSessionHelper.ActiveSesion(user.Id.ToString(), user.Role);
                loginSuccess(sender, user, e);
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginSuccess(object sender, UserModel user, EventArgs e )
        {
            if (user.Role == "admin")
            {

                AdminDashboardPage dashboardPage = new AdminDashboardPage();
                dashboardPage.Show();
            }
            else
            {
                CustomerDashboardPage dashboardPage = new CustomerDashboardPage(user);
                dashboardPage.Show();
            }
                this.Hide();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                login(sender, e);
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                login(sender, e);
            }
        }

        private void createAccount_Click(object sender, EventArgs e)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.Show();
        }
    }
}

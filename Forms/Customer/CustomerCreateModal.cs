using AD_CW_1.Repositories;
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

namespace AD_CW_1.Forms.Customer
{
    public partial class CustomerCreateModal: MaterialForm
    {
        public CustomerCreateModal()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.DeepOrange700, TextShade.WHITE);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerRepository customerRepository = new CustomerRepository();
                customerRepository.AddCustomer(new Models.Customer
                {
                    CustomerNumber = txtCustomerNumber.Text,
                    Name = txtCustomerName.Text,
                    Address = txtCustomerAddress.Text,
                    Phone = txtCustomerPhone.Text,
                    Email = txtCustomerEmail.Text,
                    Password = txtCustomerPassword.Text,
                    CreatedDate = DateTime.Now
                });
                MessageBox.Show("Customer Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("An error occurred while creating the customer. Please try again." + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

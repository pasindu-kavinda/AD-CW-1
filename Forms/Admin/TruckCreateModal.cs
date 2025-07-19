using AD_CW_1.Business.Interface;
using AD_CW_1.Business.Services;
using AD_CW_1.Helpers;
using AD_CW_1.Models;
using AD_CW_1.Repositories;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Repositories.Services;
using FluentValidation;
using MaterialSkin;
using MaterialSkin.Controls;
using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class TruckCreateModal : MaterialForm
    {
        private readonly ITruckService _truckService;

        public TruckCreateModal()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);

            ITruckRepository truckRepository = new TruckRepository();
            _truckService = new TruckService(truckRepository);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int capacity = 0;
                if (!string.IsNullOrWhiteSpace(txtCapacity.Text)){
                    int.TryParse(txtCapacity.Text.Trim(), out capacity);
                }

                TruckModel truckModel = new TruckModel
                {
                    TruckNumber = txtTruckNumber.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    LicensePlate = txtLicensePlate.Text.Trim(),
                    Status = "Active",
                    Capacity = capacity,
                    CreatedAt = DateTime.Now
                };

                bool truckCreated = _truckService.AddTruck(truckModel);
                if (truckCreated)
                {
                    MessageBox.Show("Truck Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to create truck. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while creating the truck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

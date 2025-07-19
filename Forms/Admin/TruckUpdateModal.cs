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
    public partial class TruckUpdateModal : MaterialForm
    {
        private readonly ITruckService _truckService;
        private readonly int _truckId;
        private TruckModel _currentTruck;

        public TruckUpdateModal(int truckId)
        {
            _truckId = truckId;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);

            ITruckRepository truckRepository = new TruckRepository();
            _truckService = new TruckService(truckRepository);

            LoadTruckData();
        }

        private void LoadTruckData()
        {
            try
            {
                _currentTruck = _truckService.GetTruckById(_truckId);
                if (_currentTruck != null)
                {
                    txtTruckNumber.Text = _currentTruck.TruckNumber;
                    txtModel.Text = _currentTruck.Model;
                    txtLicensePlate.Text = _currentTruck.LicensePlate;
                    txtCapacity.Text = _currentTruck.Capacity.ToString();
                    cmbStatus.SelectedItem = _currentTruck.Status;
                }
                else
                {
                    MessageBox.Show("Truck not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading truck data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int capacity = 0;
                if (!string.IsNullOrWhiteSpace(txtCapacity.Text))
                {
                    int.TryParse(txtCapacity.Text.Trim(), out capacity);
                }

                _currentTruck.TruckNumber = txtTruckNumber.Text.Trim();
                _currentTruck.Model = txtModel.Text.Trim();
                _currentTruck.LicensePlate = txtLicensePlate.Text.Trim();
                _currentTruck.Status = cmbStatus.SelectedItem?.ToString() ?? "Active";
                _currentTruck.Capacity = capacity;

                bool truckUpdated = _truckService.UpdateTruck(_currentTruck);
                if (truckUpdated)
                {
                    MessageBox.Show("Truck Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to update truck. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the truck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

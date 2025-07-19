using AD_CW_1.Business.Interface;
using AD_CW_1.Business.Services;
using AD_CW_1.Models;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Repositories.Services;
using FluentValidation;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace AD_CW_1.Forms.Admin
{
    public partial class DriverUpdateModal : MaterialForm
    {
        private readonly IDriverService _driverService;
        private readonly int _driverId;
        private DriverModel _currentDriver;

        public DriverUpdateModal(int driverId)
        {
            _driverId = driverId;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);

            IDriverRepository driverRepository = new DriverRepository();
            _driverService = new DriverService(driverRepository);

            LoadDriverData();
        }

        private void LoadDriverData()
        {
            try
            {
                _currentDriver = _driverService.GetDriverById(_driverId);
                if (_currentDriver != null)
                {
                    txtDriverName.Text = _currentDriver.Name;
                    txtLicenseNumber.Text = _currentDriver.LicenseNumber;
                    txtDriverPhone.Text = _currentDriver.Phone ?? "";
                    txtDriverAddress.Text = _currentDriver.Address ?? "";
                    cmbStatus.SelectedItem = _currentDriver.Status;
                }
                else
                {
                    MessageBox.Show("Driver not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading driver data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _currentDriver.Name = txtDriverName.Text.Trim();
                _currentDriver.LicenseNumber = txtLicenseNumber.Text.Trim();
                _currentDriver.Phone = txtDriverPhone.Text.Trim();
                _currentDriver.Address = txtDriverAddress.Text.Trim();
                _currentDriver.Status = cmbStatus.SelectedItem?.ToString() ?? "Active";

                bool driverUpdated = _driverService.UpdateDriver(_currentDriver);
                if (driverUpdated)
                {
                    MessageBox.Show("Driver Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to update driver. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the driver: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

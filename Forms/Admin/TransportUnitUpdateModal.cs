using AD_CW_1.Business.Interface;
using AD_CW_1.Business.Services;
using AD_CW_1.Models;
using AD_CW_1.Repositories;
using AD_CW_1.Repositories.Interface;
using AD_CW_1.Repositories.Services;
using FluentValidation;
using MaterialSkin;
using MaterialSkin.Controls;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Windows.Forms;

namespace AD_CW_1.Forms.Admin
{
    public partial class TransportUnitUpdateModal : MaterialForm
    {
        private readonly ITransportUnitService _transportUnitService;
        private readonly ITruckService _truckService;
        private readonly IDriverService _driverService;
        private readonly IAssistantService _assistantService;

        private readonly int _transportUnitId;
        private TransportUnitModel _currentTransportUnit;

        public TransportUnitUpdateModal(int transportUnitId)
        {
            InitializeComponent();
            _transportUnitId = transportUnitId;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue700, Primary.Blue900, Primary.Blue700,
                Accent.Blue700, TextShade.WHITE);

            ITransportUnitRepository transportUnitRepository = new TransportUnitRepository();
            _transportUnitService = new TransportUnitService(transportUnitRepository);

            ITruckRepository truckRepository = new TruckRepository();
            _truckService = new TruckService(truckRepository);

            IDriverRepository driverRepository = new DriverRepository();
            _driverService = new DriverService(driverRepository);

            IAssistantRepository assistantRepository = new AssistantRepository();
            _assistantService = new AssistantService(assistantRepository);

            LoadDropdownData();
            LoadTransportUnitData();
        }

        private void LoadDropdownData()
        {
            try
            {
                cmbTruck.DataSource = _truckService.GetAllTrucks();
                cmbTruck.DisplayMember = "TruckNumber";
                cmbTruck.ValueMember = "Id";
                cmbTruck.SelectedIndex = -1;

                cmbDriver.DataSource = _driverService.GetAllDrivers();
                cmbDriver.DisplayMember = "Name";
                cmbDriver.ValueMember = "Id";
                cmbDriver.SelectedIndex = -1;

                cmbAssistant.DataSource = _assistantService.GetAllAssistants();
                cmbAssistant.DisplayMember = "Name";
                cmbAssistant.ValueMember = "Id";
                cmbAssistant.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dropdown data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransportUnitData()
        {
            try
            {
                _currentTransportUnit = _transportUnitService.GetTransportUnitById(_transportUnitId);
                if (_currentTransportUnit != null)
                {
                    txtUnitNumber.Text = _currentTransportUnit.UnitNumber;
                    cmbTruck.SelectedValue = _currentTransportUnit.TruckId;
                    cmbDriver.SelectedValue = _currentTransportUnit.DriverId;
                    cmbAssistant.SelectedValue = _currentTransportUnit.AssistantId ?? -1;
                    cmbStatus.SelectedItem = _currentTransportUnit.Status ?? "Active";
                }
                else
                {
                    MessageBox.Show("Transport Unit not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transport unit data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUnitNumber.Text) ||
                cmbTruck.SelectedValue == null ||
                cmbDriver.SelectedValue == null)
            {
                MessageBox.Show("Please fill all required fields", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var model = new TransportUnitModel
                {
                    Id = _transportUnitId,
                    UnitNumber = txtUnitNumber.Text.Trim(),
                    TruckId = Convert.ToInt32(cmbTruck.SelectedValue),
                    DriverId = Convert.ToInt32(cmbDriver.SelectedValue),
                    AssistantId = cmbAssistant.SelectedValue != null ? Convert.ToInt32(cmbAssistant.SelectedValue) : (int?)null,
                    Status = cmbStatus.SelectedItem?.ToString() ?? "Active"
                };

                bool success = _transportUnitService.UpdateTransportUnit(model);
                if (success)
                {
                    MessageBox.Show("Transport Unit Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to update transport unit. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the transport unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

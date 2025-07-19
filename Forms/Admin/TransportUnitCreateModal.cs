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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AD_CW_1.Forms.Admin
{
    public partial class TransportUnitCreateModal : MaterialForm
    {
        private readonly ITransportUnitService _transportUnitService;
        private readonly ITruckService _truckService;
        private readonly IDriverService _driverService;
        private readonly IAssistantService _assistantService;

        private TransportUnitModel _currentTransportUnit;
        private int _transportUnitId;

        public TransportUnitCreateModal()
        {
            InitializeComponent();

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
        }

        private void LoadDropdownData()
        {
            try
            {
                var trucks = _truckService.GetAllTrucks();
                cmbTruck.DataSource = trucks;
                cmbTruck.DisplayMember = "TruckNumber";
                cmbTruck.ValueMember = "Id";
                cmbTruck.SelectedIndex = -1;

                var drivers = _driverService.GetAllDrivers();
                cmbDriver.DataSource = drivers;
                cmbDriver.DisplayMember = "Name";
                cmbDriver.ValueMember = "Id";
                cmbDriver.SelectedIndex = -1;

                var assistants = _assistantService.GetAllAssistants();
                cmbAssistant.DataSource = assistants;
                cmbAssistant.DisplayMember = "Name";
                cmbAssistant.ValueMember = "Id";
                cmbAssistant.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dropdown data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var transportUnitModel = new TransportUnitModel
                {
                    UnitNumber = txtUnitNumber.Text.Trim(),
                    TruckId = Convert.ToInt32(cmbTruck.SelectedValue),
                    DriverId = Convert.ToInt32(cmbDriver.SelectedValue),
                    AssistantId = cmbAssistant.SelectedValue != null ? Convert.ToInt32(cmbAssistant.SelectedValue) : (int?)null,
                    Status = "Active",
                    CreatedAt = DateTime.Now
                };

                bool success = _transportUnitService.AddTransportUnit(transportUnitModel);
                if (success)
                {
                    MessageBox.Show("Transport Unit Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to create transport unit. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while creating the transport unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

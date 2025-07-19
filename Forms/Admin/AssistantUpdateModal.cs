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
    public partial class AssistantUpdateModal : MaterialForm
    {
        private readonly IAssistantService _assistantService;
        private readonly int _assistantId;
        private AssistantModel _currentAssistant;

        public AssistantUpdateModal(int assistantId)
        {
            _assistantId = assistantId;
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);

            IAssistantRepository assistantRepository = new AssistantRepository();
            _assistantService = new AssistantService(assistantRepository);

            LoadAssistantData();
        }

        private void LoadAssistantData()
        {
            try
            {
                _currentAssistant = _assistantService.GetAssistantById(_assistantId);
                if (_currentAssistant != null)
                {
                    txtAssistantName.Text = _currentAssistant.Name;
                    txtAssistantPhone.Text = _currentAssistant.Phone ?? "";
                    txtAssistantAddress.Text = _currentAssistant.Address ?? "";
                    cmbStatus.SelectedItem = _currentAssistant.Status;
                }
                else
                {
                    MessageBox.Show("Assistant not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading assistant data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _currentAssistant.Name = txtAssistantName.Text.Trim();
                _currentAssistant.Phone = txtAssistantPhone.Text.Trim();
                _currentAssistant.Address = txtAssistantAddress.Text.Trim();
                _currentAssistant.Status = cmbStatus.SelectedItem?.ToString() ?? "Active";

                bool assistantUpdated = _assistantService.UpdateAssistant(_currentAssistant);
                if (assistantUpdated)
                {
                    MessageBox.Show("Assistant Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to update assistant. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the assistant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

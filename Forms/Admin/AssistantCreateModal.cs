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
    public partial class AssistantCreateModal : MaterialForm
    {
        private readonly IAssistantService _assistantService;

        public AssistantCreateModal()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue700, Primary.Blue900, Primary.Blue700, Accent.Blue700, TextShade.WHITE);

            IAssistantRepository assistantRepository = new AssistantRepository();
            _assistantService = new AssistantService(assistantRepository);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AssistantModel assistantModel = new AssistantModel
                {
                    Name = txtAssistantName.Text.Trim(),
                    Phone = txtAssistantPhone.Text.Trim(),
                    Address = txtAssistantAddress.Text.Trim(),
                    Status = "Active",
                    CreatedAt = DateTime.Now
                };

                bool assistantCreated = _assistantService.AddAssistant(assistantModel);
                if (assistantCreated)
                {
                    MessageBox.Show("Assistant Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to create assistant. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ValidationException vex)
            {
                MessageBox.Show($"Validation Error:\n{vex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while creating the assistant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

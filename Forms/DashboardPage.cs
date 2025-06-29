using LiveCharts.Wpf;
using LiveCharts;
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
using AD_CW_1.Repositories;
using AD_CW_1.Forms.Customer;

namespace AD_CW_1
{
    public partial class DashboardPage: MaterialForm
    {
        private CustomerRepository customerRepository;

        public DashboardPage()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.DeepOrange700, TextShade.WHITE);

            InitializeDashboardTab();
            InitializedCustomersTab();


        }


        #region DashboardTab
        private void InitializeDashboardTab()
        {
            //Bar Chart
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            cartesianChart1.Series[1].Values.Add(48d);

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Sales Man",
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sold Apps",
                LabelFormatter = value => value.ToString("N")
            });


            //Line Chart
            cartesianChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7}
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {6, 7, 3, 4, 6},
                    PointGeometry = null
                },

            };

            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C")
            });

            cartesianChart2.LegendLocation = LegendLocation.None;
        }
        #endregion


        #region CustomerTab
        private void InitializedCustomersTab()
        {
            LoadCustomers();
            addCustomerContextMenu();
        }
        private void LoadCustomers()
        {
            var customers = customerRepository.GetAllCustomers();
            customersListView.Items.Clear();
            foreach (var customer in customers)
            {
                var item = new ListViewItem(customer.Id.ToString());
                item.SubItems.Add(customer.Name);
                item.SubItems.Add(customer.CustomerNumber);
                item.SubItems.Add(customer.Email);
                item.SubItems.Add(customer.Phone);
                item.SubItems.Add(customer.Address);
                item.SubItems.Add(customer.CreatedDate.ToString("yyyy-MM-dd"));
                customersListView.Items.Add(item);
            }
        }

        private void addCustomerContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit Customer");
            editItem.Click += EditCustomer_Click;
            contextMenu.Items.Add(editItem);

            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Customer");
            deleteItem.Click += DeleteCustomer_Click;
            contextMenu.Items.Add(deleteItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            customersListView.ContextMenuStrip = contextMenu;
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            CustomerCreateModal customerCreateModal = new CustomerCreateModal();
            customerCreateModal.ShowDialog();

            LoadCustomers();
        }

        private void EditCustomer_Click(object sender, EventArgs e)
        {
            if (customersListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = customersListView.SelectedItems[0];
                int customerId = int.Parse(selectedItem.Text);

                MessageBox.Show("Customer updated successfully!" + customerId, "Success");
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection");
            }
        }

        private void DeleteCustomer_Click(object sender, EventArgs e)
        {
            if (customersListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = customersListView.SelectedItems[0];
                int customerId = int.Parse(selectedItem.Text);
                string customerName = selectedItem.SubItems[1].Text;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete customer '{customerName}'?\n\nThis action cannot be undone.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        CustomerRepository customerRepository = new CustomerRepository();
                        bool deleted = customerRepository.DeleteCustomer(customerId);

                        if (deleted)
                        {
                            LoadCustomers();
                            MessageBox.Show("Customer deleted successfully!", "Success");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete customer.", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}", "Error");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection");
            }
        }
        #endregion
    }
}

using System;
using System.Windows.Forms;

namespace Products_and_Parts
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();

            // Loads test data into the Products and Parts data grids
            dgvProducts.DataSource = Inventory.Product;
            dgvParts.DataSource = Inventory.AllParts;

            // Data Grid settings
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.ReadOnly = true;
            dgvProducts.MultiSelect = false;

            dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParts.ReadOnly = true;
            dgvParts.MultiSelect = false;
        }

        // Removes the default selection of the first row of the Data Grids
        private void OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProducts.ClearSelection();
            dgvParts.ClearSelection();
        }

        // The following methods handle exiting the program, closing forms, and navigating between forms

        private void btnAddParts_Main_Click(object sender, EventArgs e)
        {
            // Opens the Add Parts form when the "Add" button is clicked
            FormAddPart addPartForm = new FormAddPart();
            addPartForm.Show();
        }

        private void btnModifyParts_Main_Click(object sender, EventArgs e)
        {
            // Opens the Modify Parts form when the "Modify" button is clicked
            FormModifyPart modifyPartForm = new FormModifyPart();
            modifyPartForm.Show();
        }

        private void btnAddProducts_Main_Click(object sender, EventArgs e)
        {
            // Opens the Add Products form when the "Add" button is clicked
            FormAddProduct addProductForm = new FormAddProduct();
            addProductForm.Show();
        }

        private void btnModifyProducts_Main_Click(object sender, EventArgs e)
        {
            // Opens the Modify Product form when the "Modify" button is clicked
            FormModifyProduct modifyProductForm = new FormModifyProduct();
            modifyProductForm.Show();
        }

        private void btnExit_Main_Click(object sender, EventArgs e)
        {
            // Closes the program when the "Exit" button is clicked
            Application.Exit();
        }
    }
}

// This script handles the logic for the main inventory form and its event handlers

using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Products_and_Parts
{
    // The MainScreen form only runs in instances.
    // Therefore, to access the current instance and its objects,
    // the instance is made static and public and the dgv's are made public.
    // To access them, use MainScreen.Instance.DgvProducts. ....
    public partial class MainScreen : Form
    {
        public static MainScreen Instance { get; private set; }
        public DataGridView DgvProducts => dgvProducts;
        public DataGridView DgvParts => dgvParts;

        public MainScreen()
        {
            InitializeComponent();
            Instance = this;

            // Loads test data into the Products and Parts data grids
            dgvProducts.DataSource = Inventory.Products;
            dgvParts.DataSource = Inventory.AllParts;

            // Data Grid View settings
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.ReadOnly = true;
            dgvProducts.MultiSelect = false;

            dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParts.ReadOnly = true;
            dgvParts.MultiSelect = false;

            // Keeps a running List of taken productID's every time the Add Products form is open
            for (int i = 0; i < Inventory.Products.Count; i++)
                Inventory.takenProductIds.Add(i);

            // Keeps a running List of taken partID's every time the Add Parts form is open
            for (int i = 0; i < Inventory.AllParts.Count; i++)
                Inventory.takenPartIds.Add(i);
        }

        // Removes the default selection of the first row of the Data Grids
        private void OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvProducts.ClearSelection();
            dgvParts.ClearSelection();
        }

        // EVENTS RELATED TO PRODUCTS

        // Opens the Add Product form
        private void btnAddProducts_Main_Click(object sender, EventArgs e)
        {
            FormAddProduct addProductForm = new FormAddProduct();
            addProductForm.Show();
        }

        // Opens the Modify Product form
        private void btnModifyProducts_Main_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                FormModifyProduct modifyProductForm = new FormModifyProduct();
                modifyProductForm.Show();
            }
                
            else
                MessageBox.Show("Please select a Product to modify.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Handles the delete Product click event
        private void btnDeleteProducts_Main_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Retrieves the selected row's data
                DataGridViewRow row = dgvProducts.SelectedRows[0];
                // Retrieves the value of the selected row's Product ID to pass to the RemoveProduct method
                int selectedID = (int)row.Cells["ProductID"].Value;

                // Checks if the part is allowed to be deleted
                bool canBeDeleted = Inventory.RemoveProduct(selectedID);

                // Warns the user and allows them to delete the selected part
                if (canBeDeleted)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this Product?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        // Checks for the first "product" instance where the product.ProductID == selected ID
                        Product productToDelete = Inventory.Products.FirstOrDefault(product => product.ProductID == selectedID);
                        // Removes the selected Product from the Products Binding List
                        Inventory.Products.Remove(productToDelete);
                        // Refreshes and displays the Data Grid View data
                        dgvProducts.DataSource = null;
                        dgvProducts.DataSource = Inventory.Products;
                    }
                   
                    else
                        return;
                }
                else
                    MessageBox.Show("An invalid Product has been selected for deletion. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
                MessageBox.Show("Please select a Product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        // Searches the Products Inventory list. Highlights the first partial name match if found.
        // Returns a warning message if a partial match for a product cannnot be found
        private void btnSearchProducts_Main_Click(Object sender, EventArgs e)
        {
            string userInput = textBoxSearchProducts_Main.Text;
            // Converts userInput to lowercase
            userInput = userInput.ToLower();
            bool matchFound = false;

            for (int i = 0; i < Inventory.Products.Count; i++)
            {
                var product = Inventory.Products[i];
                // Converts product name to lowercase
                string lowerCaseProductName = product.Name.ToLower();

                if (lowerCaseProductName.Contains(userInput))
                {
                    dgvProducts.ClearSelection();
                    dgvProducts.Rows[i].Selected = true;
                    matchFound = true;
                    break;
                }
            }
            if (!matchFound)
                MessageBox.Show("No Products matching the search criteria could be found.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
        }

        // EVENTS RELATED TO PARTS

        // Opens the Add Part form
        private void btnAddParts_Main_Click(object sender, EventArgs e)
        {
            FormAddPart addPartForm = new FormAddPart();
            addPartForm.Show();
        }

        // Opens the Modify Part form
        public void btnModifyParts_Main_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count > 0)
            {
                FormModifyPart modifyPartForm = new FormModifyPart();
                modifyPartForm.Show();
            }

            else
                MessageBox.Show("Please select a Product to modify.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Handles the delete Part click event
        private void btnDeleteParts_Main_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvParts.SelectedRows[0];
                int selectedID = (int)row.Cells["PartID"].Value;

                // Locate the part by PartID
                // Iterates through every "part" in AllParts
                // If part.PartID == selectedID, the part reference in AllParts is returned
                Part selectedPart = Inventory.AllParts.FirstOrDefault(part => part.PartID == selectedID);

                if (selectedPart == null)
                {
                    MessageBox.Show("The selected part was not found in the All Parts list.");
                    return;
                }

                bool isPartAssociatedWithProducts = Inventory.DeletePart(selectedPart);

                if (!isPartAssociatedWithProducts)
                {
                    MessageBox.Show("This Part cannot be deleted because it is associated with a Product.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this Part?",
                                                      "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    // Removes the selected Product from the Products Binding List
                    Inventory.AllParts.Remove(selectedPart);
                    // Refreshes and displays the Data Grid View data
                    dgvParts.DataSource = null;
                    dgvParts.DataSource = Inventory.AllParts;
                }
            }
            else
            {
                MessageBox.Show("Please select a Part to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Searches the Parts Inventory list. Highlights the first partial name match if found.
        // Returns a warning message if a partial match for a part cannot found
        private void btnSearchParts_Main_Click(object sender, EventArgs e)
        {
            string userInput = textBoxSearchParts_Main.Text;
            // converts userInput to lower case
            userInput = userInput.ToLower();
            bool matchFound = false;

            for (int i = 0; i < Inventory.AllParts.Count; i++)
            {
                var part = Inventory.AllParts[i];

                // Converts part name to lowercase
                string lowerCasePartName = part.Name.ToLower();

                if (lowerCasePartName.Contains(userInput))
                {
                    dgvParts.ClearSelection();
                    dgvParts.Rows[i].Selected = true;
                    matchFound = true;
                    break;
                }
            }

            if (!matchFound)
                MessageBox.Show("No Parts matching the search criteria could be found.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
        }

        // GENERAL EVENTS

        private void btnExit_Main_Click(object sender, EventArgs e)
        {
            Inventory.CloseInventoryForm();
        }

    }
}

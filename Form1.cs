﻿// This script handles the logic for the main inventory form and its event handlers

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

namespace Products_and_Parts
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();

            // Loads test data into the Products and Parts data grids
            dgvProducts.DataSource = Inventory.Products;
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
            Inventory.OpenAddPartsForm();
        }

        private void btnModifyParts_Main_Click(object sender, EventArgs e)
        {
            Inventory.OpenModifyPartsForm();
        }

        private void btnAddProducts_Main_Click(object sender, EventArgs e)
        {
            Inventory.OpenAddProductsForm();
        }

        private void btnModifyProducts_Main_Click(object sender, EventArgs e)
        {
            Inventory.OpenModifyProductsForm();
        }

        private void btnExit_Main_Click(object sender, EventArgs e)
        {
            Inventory.CloseInventoryForm();
        }

        // Handles the Delete Parts click event
        private void btnDeleteParts_Main_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieves the selected row's data
                DataGridViewRow row = dgvParts.SelectedRows[0];
                // Retrieves the values of each cell in the row to be able to create a "partToDelete" Part object
                int selectedID = (int)row.Cells["PartID"].Value;
                string selectedName = (string)row.Cells["Name"].Value;
                decimal selectedPrice = (decimal)row.Cells["Price"].Value;
                int selectedInStock = (int)row.Cells["InStock"].Value;
                int selectedMin = (int)row.Cells["Min"].Value;
                int selectedMax = (int)row.Cells["Max"].Value;
                int selectedMachineID;
                string selectedCompanyName;

                // Determines if the part selected is InHouse or Outsourced
                if (Inventory.AllParts[selectedID] is InHouse inHousePart)
                {
                    selectedMachineID = inHousePart.MachineID;
                    Part partToDelete = new InHouse(selectedID, selectedName, selectedPrice, selectedInStock, selectedMin,
                         selectedMax, selectedMachineID);
                    // Checks if the part is allowed to be deleted
                    bool canBeDeleted = Inventory.DeletePart(partToDelete);

                    // Warns the user and allows them to delete the selected part
                    if (canBeDeleted)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this Part?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                            dgvParts.Rows.RemoveAt(selectedID);
                        else
                            return;
                    }
                }

                // Determines if the part selected is InHouse or Outsourced
                else if (Inventory.AllParts[selectedID] is Outsourced outsourcedPart)
                {
                    selectedCompanyName = outsourcedPart.CompanyName;
                    Part partToDelete = new Outsourced(selectedID, selectedName, selectedPrice, selectedInStock, selectedMin,
                         selectedMax, selectedCompanyName);
                    // checks if the part is allowed to be deleted
                    bool canBeDeleted = Inventory.DeletePart(partToDelete);

                    // Warns the user and allows them to delete the selected part
                    if (canBeDeleted)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this Part?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                            dgvParts.Rows.RemoveAt(selectedID);
                        else
                            return;
                    }

                }
            }

            // Occurs when the users tries to delete a part without actually selecting a part to delete
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a Part to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handles the Delete Product click event
        private void btnDeleteProducts_Main_Click(object sender, EventArgs e)
        {
            try
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
                    DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this Product?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                        dgvProducts.Rows.RemoveAt(selectedID);
                    else
                        return;
                }
                else
                    MessageBox.Show("An invalid Product has been selected for deletion. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Occurs when the users tries to delete a product without actually selecting a product to delete
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select a Product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Searches the Products Inventory list. Highlights the first partial name match if found.
        // Returns a warning message if a partial match for a product cannnot be found
        private void btnSearchProducts_Main_Click(Object sender, EventArgs e)
        {
            string userInput = textBoxSearchProducts_Main.Text;
            // Converts userInput to lowercase
            userInput = userInput.ToLower();
            bool matchFound = false;

            for(int i = 0; i < Inventory.Products.Count; i++)
            {
                var product = Inventory.Products[i];
                // Converts product name to lowercase
                string lowerCaseProductName = product.Name.ToLower();

                if(lowerCaseProductName.Contains(userInput))
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
    }
}

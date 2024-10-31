﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Products_and_Parts
{
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();

            // Auto generates a Product ID in the Add Part form & makes the field readonly
            textBoxID_AddProduct.ReadOnly = true;
            int newProductID = Inventory.takenProductIds.Max() + 1;
            textBoxID_AddProduct.Text = newProductID.ToString();

            // Sets the default color of the Add Part text boxes
            textBoxName_AddProduct.BackColor = Color.OrangeRed;
            textBoxInventory_AddProduct.BackColor = Color.OrangeRed;
            textBoxPriceCost_AddProduct.BackColor = Color.OrangeRed;
            textBoxMax_AddProduct.BackColor = Color.OrangeRed;
            textBoxMin_AddProduct.BackColor = Color.OrangeRed;

            // Loads the AllParts Binding List into the All Candidate Parts data grid view
            dgvAllCandidateParts_AddProduct.DataSource = Inventory.AllParts;

            // Data Grid View settings
            dgvAllCandidateParts_AddProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllCandidateParts_AddProduct.ReadOnly = true;
            dgvAllCandidateParts_AddProduct.MultiSelect = false;
        }

        // Removes the default selection of the first row of the Data Grid
        private void OnDataBindingComplete_AddProduct(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAllCandidateParts_AddProduct.ClearSelection();
        }

        // Events that change the Text Box colors based on valid and invalid data
        private void textBoxName_AddProduct_TextChanged(object sender, EventArgs e)
        {
            bool onlyNumbers = textBoxName_AddProduct.Text.All(chr => !char.IsLetter(chr));

            if (String.IsNullOrEmpty(textBoxName_AddProduct.Text))
                textBoxName_AddProduct.BackColor = Color.OrangeRed;
            else if (!onlyNumbers)
                textBoxName_AddProduct.BackColor = default(Color);
            else if (textBoxName_AddProduct.Text.Contains(" "))
                textBoxName_AddProduct.BackColor = default(Color);
            else
                textBoxName_AddProduct.BackColor = Color.OrangeRed;
        }

        private void textBoxInventory_AddProduct_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;

            if (int.TryParse(textBoxInventory_AddProduct.Text, out parsedValue))
                textBoxInventory_AddProduct.BackColor = default(Color);
            else
                textBoxInventory_AddProduct.BackColor = Color.OrangeRed;
        }

        private void textBoxPriceCost_AddProduct_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;

            if (double.TryParse(textBoxPriceCost_AddProduct.Text, out parsedValue))
                textBoxPriceCost_AddProduct.BackColor = default(Color);
            else
                textBoxPriceCost_AddProduct.BackColor = Color.OrangeRed;
        }

        private void textBoxMax_AddProduct_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;

            if (int.TryParse(textBoxMax_AddProduct.Text, out parsedValue))
                textBoxMax_AddProduct.BackColor = default(Color);
            else
                textBoxMax_AddProduct.BackColor = Color.OrangeRed;
        }

        private void textBoxMin_AddProduct_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;

            if (int.TryParse(textBoxMin_AddProduct.Text, out parsedValue))
                textBoxMin_AddProduct.BackColor = default(Color);
            else
                textBoxMin_AddProduct.BackColor = Color.OrangeRed;
        }

        // Searches the Parts Inventory list. Highlights the first partial name match if found.
        // Returns a warning message if a partial match for a Part cannnot be found
        private void btnSearch_AddProduct_Click(object sender, EventArgs e)
        {
            string userInput = textBoxSearch_AddProduct.Text;
            // Converts userInput to lowercase
            userInput = userInput.ToLower();
            bool matchFound = false;

            for (int i = 0; i < Inventory.AllParts.Count; i++)
            {
                var part = Inventory.AllParts[i];
                // Converts part name to lowercase
                string lowerCasePartName = part.Name.ToLower();

                if (lowerCasePartName.Contains(userInput))
                {
                    dgvAllCandidateParts_AddProduct.ClearSelection();
                    dgvAllCandidateParts_AddProduct.Rows[i].Selected = true;
                    matchFound = true;
                    break;
                }
            }
            if (!matchFound)
                MessageBox.Show("No Parts matching the search criteria could be found.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
        }

        // Handles the save button click event
        private void btnSave_AddProduct_Click(object sender, EventArgs e)
        {
            bool onlyNumbers = textBoxName_AddProduct.Text.All(chr => !char.IsLetter(chr));
           
            // Checks to ensure text boxes only use valid data types
            if (onlyNumbers)
            {
                MessageBox.Show("Name must contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBoxPriceCost_AddProduct.Text, out _))
            {
                MessageBox.Show("Price can only contain numbers and decimals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxInventory_AddProduct.Text, out _))
            {
                MessageBox.Show("Inventory can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxMax_AddProduct.Text, out _))
            {
                MessageBox.Show("Max can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxMin_AddProduct.Text, out _))
            {
                MessageBox.Show("Min can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(textBoxMax_AddProduct.Text) < int.Parse(textBoxMin_AddProduct.Text))
            {
                MessageBox.Show("Min cannot be greater than Max.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(textBoxInventory_AddProduct.Text) < int.Parse(textBoxMin_AddProduct.Text) ||
                int.Parse(textBoxInventory_AddProduct.Text) > int.Parse(textBoxMax_AddProduct.Text))
            {
                MessageBox.Show("Inventory cannot be less than Min or greater than Max.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Converts the text box values into strings for the data grid veiw
            int newProductID = Convert.ToInt32(textBoxID_AddProduct.Text);
            string newProductName = textBoxName_AddProduct.Text;
            decimal newPrice = Convert.ToDecimal(textBoxPriceCost_AddProduct.Text);
            int newInventory = Convert.ToInt32(textBoxInventory_AddProduct.Text);
            int newMax = Convert.ToInt32(textBoxMax_AddProduct.Text);
            int newMin = Convert.ToInt32((textBoxMin_AddProduct.Text));

            // Creates a new Product item and passes it to the AddProduct method
            Product newProduct = new Product(newProductID, newProductName, newPrice, newInventory, newMax, newMin);
            Inventory.AddProduct(newProduct);

            // Closes the Add Product form when a new product is added
            this.Close();
        }

        // Handles the close button click event
        private void btnCancel_AddProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

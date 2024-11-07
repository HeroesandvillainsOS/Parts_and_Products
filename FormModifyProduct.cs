// This script handles the logic for the Modify Product form

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Products_and_Parts
{
    public partial class FormModifyProduct : Form
    {
        // Sets the initial values of the Modify Product text boxes
        public FormModifyProduct()
        {
            InitializeComponent();

            // Gets the currently selected row and its values
            var selectedRow = MainScreen.Instance.DgvProducts.SelectedRows[0];
            int selectedProductID = (int)selectedRow.Cells["ProductID"].Value;
            string selectedName = (string)selectedRow.Cells["Name"].Value;
            decimal selectedPrice = (decimal)selectedRow.Cells["Price"].Value;
            int selectedInStock = (int)selectedRow.Cells["InStock"].Value;
            int selectedMin = (int)selectedRow.Cells["Min"].Value;
            int selectedMax = (int)selectedRow.Cells["Max"].Value;

            // Sets the values of the Modify Product text boxes to the currently selected Product
            textBoxID_ModifyProduct.Text = selectedProductID.ToString();
            textBoxName_ModifyProduct.Text = selectedName;
            textBoxPriceCost_ModifyProduct.Text = selectedPrice.ToString();
            textBoxInventory_ModifyProduct.Text = selectedInStock.ToString();
            textBoxMin_ModifyProduct.Text = selectedMin.ToString();
            textBoxMax_ModifyProduct.Text = selectedMax.ToString();

            // Data Grid View settings
            dgvAllCandidateParts_ModifyProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllCandidateParts_ModifyProduct.ReadOnly = true;
            dgvAllCandidateParts_ModifyProduct.MultiSelect = false;

            dgvPartsAssociatedWithProduct_ModifyProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartsAssociatedWithProduct_ModifyProduct.ReadOnly = true;
            dgvPartsAssociatedWithProduct_ModifyProduct.MultiSelect = false;

            // Loads the AllParts Binding List into the All Candidate Parts data grid view
            dgvAllCandidateParts_ModifyProduct.DataSource = Inventory.AllParts;

            // Ensures the "PartsAssociatedWithThisProduct" Binding List is cleared every time the Modify Product form is opened
            Product.PartsAssociatedWithThisProduct.Clear();
            Product.TemporaryAssociatedParts.Clear();

            // Retrieves the currently selected Product ID
            int currentProductID = int.Parse(textBoxID_ModifyProduct.Text);

            // Searches to see if the selected Product has any Parts associated with it
            foreach (var productWithAssociatedParts in Product.ProductsWithAssociatedParts)
            {
                if (productWithAssociatedParts.ProductID == currentProductID)
                {
                    // Finds the Part's information
                    Part partToAdd = Inventory.LookupPart(productWithAssociatedParts.PartID);

                    // Adds the Part to the "PartsAssociatedWithThisProduct" Binding List only if it's not already in the list
                    // Which is used to display the part(s) as being associated with the current product on the Data Grid View
                    if (!Product.PartsAssociatedWithThisProduct.Contains(partToAdd))
                    {
                        Product.PartsAssociatedWithThisProduct.Add(partToAdd);
                    }
                }
            }

            // Displays the Product's complete list of Associated Parts in the data grid view
            dgvPartsAssociatedWithProduct_ModifyProduct.DataSource = Product.PartsAssociatedWithThisProduct;
        }

        // Removes the default selection of the first row of the Data Grid
        private void OnDataBindingComplete_ModifyProduct(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAllCandidateParts_ModifyProduct.ClearSelection();
            dgvPartsAssociatedWithProduct_ModifyProduct.ClearSelection();
        }

        // Events that change the Text Box colors based on valid and invalid data
        private void textBoxName_ModifyProduct_TextChanged(object sender, EventArgs e)
        {
            bool onlyNumbers = textBoxName_ModifyProduct.Text.All(chr => !char.IsLetter(chr));

            if (String.IsNullOrEmpty(textBoxName_ModifyProduct.Text))
                textBoxName_ModifyProduct.BackColor = Color.OrangeRed;
            else if (!onlyNumbers)
                textBoxName_ModifyProduct.BackColor = default(Color);
            else if (textBoxName_ModifyProduct.Text.Contains(" "))
                textBoxName_ModifyProduct.BackColor = default(Color);
            else
                textBoxName_ModifyProduct.BackColor = Color.OrangeRed;
        }

        private void textBoxInventory_ModifyProduct_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInventory_ModifyProduct.Text, out int parsedValue))
                textBoxInventory_ModifyProduct.BackColor = default(Color);
            else
                textBoxInventory_ModifyProduct.BackColor = Color.OrangeRed;
        }

        private void textBoxPriceCost_ModifyProduct_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxPriceCost_ModifyProduct.Text, out double parsedValue))
                textBoxPriceCost_ModifyProduct.BackColor = default(Color);
            else
                textBoxPriceCost_ModifyProduct.BackColor = Color.OrangeRed;
        }

        private void textBoxMax_ModifyProduct_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxMax_ModifyProduct.Text, out int parsedValue))
                textBoxMax_ModifyProduct.BackColor = default(Color);
            else
                textBoxMax_ModifyProduct.BackColor = Color.OrangeRed;
        }

        private void textBoxMin_ModifyProduct_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxMin_ModifyProduct.Text, out int parsedValue))
                textBoxMin_ModifyProduct.BackColor = default(Color);
            else
                textBoxMin_ModifyProduct.BackColor = Color.OrangeRed;
        }

        // Searches the Parts Inventory list. Highlights the first partial name match if found.
        // Returns a warning message if a partial match for a Part cannnot be found
        private void btnSearch_ModifyProduct_Click(object sender, EventArgs e)
        {
            string userInput = textBoxSearch_ModifyProduct.Text;
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
                    dgvAllCandidateParts_ModifyProduct.ClearSelection();
                    dgvAllCandidateParts_ModifyProduct.Rows[i].Selected = true;
                    matchFound = true;
                    break;
                }
            }
            if (!matchFound)
                MessageBox.Show("No Parts matching the search criteria could be found.", "Warning", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
        }

        // Adds a Part to the "Parts Associated With This Product" List
        private void btnAdd_ModifyProduct_Click(object sender, EventArgs e)
        {
            if (dgvAllCandidateParts_ModifyProduct.SelectedRows.Count > 0)
            {
                // Gets the details of the selected Part
                var selectedPart = dgvAllCandidateParts_ModifyProduct.SelectedRows[0];
                int selectedPartID = (int)selectedPart.Cells["PartID"].Value;

                // Adds the "PartsAssociatedWithThisProduct" Binding List items to the "TemporaryAssociatedParts" Binding List
                if (Product.PartsAssociatedWithThisProduct.Count > 0)
                {
                    Product.TemporaryAssociatedParts = Product.PartsAssociatedWithThisProduct;
                }

                // Retrieves the full Part details
                Part returnedPart = Inventory.LookupPart(selectedPartID);

                // Checks to see if the selected Part is already asssociated with the current Product
                foreach (var part in Product.TemporaryAssociatedParts)
                {
                    if (part.PartID == returnedPart.PartID)
                    {
                        MessageBox.Show("This Part is already Associated with the current Product.", "Warning", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Adds the selected Part to the "TemporaryAssociatedParts" Binding List and displays it on the Data Grid View
                Product.TemporaryAssociatedParts.Add(returnedPart);
                dgvPartsAssociatedWithProduct_ModifyProduct.DataSource = Product.TemporaryAssociatedParts;
            }
            else
            {
                MessageBox.Show("Please select a Part from the All Candidate Parts list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        // Removes a Part from the "Parts Associated With This Product" List
        private void btnDelete_ModifyProduct_Click(object sender, EventArgs e)
        {
            if (dgvPartsAssociatedWithProduct_ModifyProduct.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this Part?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                    return;
                
                if (result == DialogResult.OK)
                {
                    // Determines which Part is selected in the Data Grid View
                    var selectedPart = dgvPartsAssociatedWithProduct_ModifyProduct.SelectedRows[0];
                    int selectedPartID = (int)selectedPart.Cells["PartID"].Value;
                    int partIndex;

                    // Adds the "PartsAssociatedWithThisProduct" Binding List items to the "TemporaryAssociatedParts" Binding List
                    if (Product.PartsAssociatedWithThisProduct.Count > 0)
                    {
                        Product.TemporaryAssociatedParts = Product.PartsAssociatedWithThisProduct;
                    }

                    // Iterates through the "TemporaryAssociatedParts" Binding list
                    for (int i = 0; i < Product.TemporaryAssociatedParts.Count; i++)
                    {
                        // Removes the selected part from the "TemporaryAssociatedParts" Binding List
                        if (Product.TemporaryAssociatedParts[i].PartID == selectedPartID)
                        {
                            partIndex = i;
                            Product.TemporaryAssociatedParts.RemoveAt(partIndex);
                        }
                    }
                    // Displays an updated list of associated Parts on the Data Grid View
                    dgvPartsAssociatedWithProduct_ModifyProduct.DataSource = Product.TemporaryAssociatedParts;
                }
                else
                {
                    MessageBox.Show("Please select a Part to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }               
        }

        // Handles the save button click event
        private void btnSave_ModifyProduct_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to save this Product?", "Warning", MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
                return;

            if (result == DialogResult.OK)
            {
                // SAVES THE PRODUCT SIDE OF THE FORM

                bool onlyNumbers = textBoxName_ModifyProduct.Text.All(chr => !char.IsLetter(chr));

                // Checks to ensure text boxes only use valid data types
                if (onlyNumbers)
                {
                    MessageBox.Show("Name must contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(textBoxPriceCost_ModifyProduct.Text, out _))
                {
                    MessageBox.Show("Price can only contain numbers and decimals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBoxInventory_ModifyProduct.Text, out _))
                {
                    MessageBox.Show("Inventory can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (!int.TryParse(textBoxMax_ModifyProduct.Text, out _))
                {
                    MessageBox.Show("Max can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBoxMin_ModifyProduct.Text, out _))
                {
                    MessageBox.Show("Min can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.Parse(textBoxMax_ModifyProduct.Text) < int.Parse(textBoxMin_ModifyProduct.Text))
                {
                    MessageBox.Show("Min cannot be greater than Max.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.Parse(textBoxInventory_ModifyProduct.Text) < int.Parse(textBoxMin_ModifyProduct.Text) ||
                  int.Parse(textBoxInventory_ModifyProduct.Text) > int.Parse(textBoxMax_ModifyProduct.Text))
                {
                    MessageBox.Show("Inventory cannot be less than Min or greater than Max.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Stores the selected Product's new values
                int currentID = int.Parse(textBoxID_ModifyProduct.Text);
                string newName = textBoxName_ModifyProduct.Text;
                decimal newPrice = decimal.Parse(textBoxPriceCost_ModifyProduct.Text);
                int newInventory = int.Parse(textBoxInventory_ModifyProduct.Text);
                int newMax = int.Parse(textBoxMax_ModifyProduct.Text);
                int newMin = int.Parse(textBoxMin_ModifyProduct.Text);

                // Finds the selected Product's index position
                int indexPosition = Inventory.GetIndexPositionWithProductID(Inventory.Products, currentID);
                // Removes the old Product from the Binding List
                Inventory.Products.RemoveAt(currentID);
                // Adds the Product back into the Binding List
                Product updatedProduct = new Product(currentID, newName, newPrice, newInventory, newMin, newMax);
                Inventory.Products.Insert(indexPosition, updatedProduct);

                // SAVES THE PART SIDE OF THE FORM

                // Removes all previous occurrences of the current Product & its associated Parts from the "ProductsWithAssociatedParts" Binding List 
                foreach (var productWithAssociatedPart in Product.ProductsWithAssociatedParts.ToList())
                {
                    if (productWithAssociatedPart.ProductID == currentID)
                        Product.ProductsWithAssociatedParts.Remove(productWithAssociatedPart);
                }

                // Saves all Parts that are currently associated with the Product back into the "ProductsWithAssociatedParts" Binding List
                if (dgvPartsAssociatedWithProduct_ModifyProduct.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvPartsAssociatedWithProduct_ModifyProduct.Rows)
                    {
                        int currentPartID = (int)row.Cells["PartID"].Value;
                        ProductPartAssociation productPartAssociation = new ProductPartAssociation(currentID, currentPartID);
                        Product.ProductsWithAssociatedParts.Add(productPartAssociation);
                    }
                }

                // Closes the window
                this.Close();
            }         
        }

        // Handles the close button click event
        private void btnCancel_ModifyProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

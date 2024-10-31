using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

            // Sets the values of the Add Product text boxes to the currently selected Product
            textBoxID_ModifyProduct.Text = selectedProductID.ToString();
            textBoxName_ModifyProduct.Text = selectedName;
            textBoxPriceCost_ModifyProduct.Text = selectedPrice.ToString();
            textBoxInventory_ModifyProduct.Text = selectedInStock.ToString();
            textBoxMin_ModifyProduct.Text = selectedMin.ToString();
            textBoxMax_ModifyProduct.Text = selectedMax.ToString();

            // Loads the AllParts Binding List into the All Candidate Parts data grid view
            dgvAllCandidateParts_ModifyProduct.DataSource = Inventory.AllParts;

            // Data Grid View settings
            dgvAllCandidateParts_ModifyProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAllCandidateParts_ModifyProduct.ReadOnly = true;
            dgvAllCandidateParts_ModifyProduct.MultiSelect = false;
        }

        // Removes the default selection of the first row of the Data Grid
        private void OnDataBindingComplete_ModifyProduct(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAllCandidateParts_ModifyProduct.ClearSelection();
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

        // Handles the save button click event
        private void btnSave_ModifyProduct_Click(object sender, EventArgs e)
        {
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

            // Closes the window
            this.Close();
        }

        // Handles the close button click event
        private void btnCancel_ModifyProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

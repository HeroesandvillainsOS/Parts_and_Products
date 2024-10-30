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
        }

        // Closes the Modify Product form when the "Close" button is clicked
        private void btnCancel_ModifyProduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Events that change the Text Box colors based on valid and invalid data

        private void textBoxName_ModifyProduct_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName_ModifyProduct.Text))
                textBoxName_ModifyProduct.BackColor = Color.OrangeRed;
            else if (textBoxName_ModifyProduct.Text.All(chr => char.IsLetter(chr)))
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
    }
}

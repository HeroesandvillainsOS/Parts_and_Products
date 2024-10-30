using System;
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
    }
}

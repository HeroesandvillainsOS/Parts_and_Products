using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnSave_AddProduct_Click(object sender, EventArgs e)
        {
            int newProductID = Convert.ToInt32(textBoxID_AddProduct.Text);
            string newProductName = textBoxName_AddProduct.Text;
            decimal newPrice = Convert.ToDecimal(textBoxPriceCost_AddProduct.Text);
            int newInventory = Convert.ToInt32(textBoxInventory_AddProduct.Text);
            int newMax = Convert.ToInt32(textBoxMax_AddProduct.Text);
            int newMin = Convert.ToInt32((textBoxMin_AddProduct.Text)); 

            Product newProduct = new Product(newProductID, newProductName, newPrice, newInventory, newMax, newMin);
            Inventory.AddProduct(newProduct);

            // Closes the Add Product form when a new product is added
            this.Close();
        }

        private void btnCancel_AddProduct_Click(object sender, EventArgs e)
        {
            // Closes the Add Product form when the Cancel button is clicked
            this.Close();
        }

        // Events that change the Text Box colors based on valid and invalid data

        private void textBoxName_AddProduct_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName_AddProduct.Text))
                textBoxName_AddProduct.BackColor = Color.OrangeRed;
            else if (textBoxName_AddProduct.Text.All(chr => char.IsLetter(chr)))
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
    }
}

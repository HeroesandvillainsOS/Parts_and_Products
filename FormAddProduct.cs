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
    }
}

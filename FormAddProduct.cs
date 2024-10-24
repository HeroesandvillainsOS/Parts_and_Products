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
        }

        private void btnCancel_AddProduct_Click(object sender, EventArgs e)
        {
            // Closes the Add Product form when the Cancel button is clicked
            this.Close();
        }
    }
}

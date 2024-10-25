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
    public partial class FormAddPart : Form
    {
        public FormAddPart()
        {
            InitializeComponent();
            textBoxID_AddPart.ReadOnly = true;
            textBoxID_AddPart.Text = Inventory.AllParts.Count.ToString();
        }

        private void radioBtnOutsourced_AddPart_CheckedChanged(object sender, EventArgs e)
        {
            // Handles changing the "Machine ID" lable to "Company Name" when the proper radio button is clicked
            labelMachineID_AddPart.Text = "Company Name";
        }

        private void radioBtnInHouse_AddPart_CheckedChanged(object sender, EventArgs e)
        {
            // Handles changing the "Company Name" lable to "Machine" when the proper radio button is clicked
            labelMachineID_AddPart.Text = "Machine ID";
        }

        private void btnCancel_AddPart_Click(object sender, EventArgs e)
        {
            // Closes the Add Part form when the "Close" button is clicked
           this.Close();
        }
    }
}

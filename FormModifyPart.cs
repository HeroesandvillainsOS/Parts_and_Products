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
    public partial class FormModifyPart : Form
    {
        public FormModifyPart()
        {
            InitializeComponent();
        }

        private void radioBtnInHouse_ModifyPart_CheckedChanged(object sender, EventArgs e)
        {
            // Handles changing the "Company Name" lable to "Machine" when the proper radio button is clicked
            labelMachineID_ModifyPart.Text = "Machine ID";
        }

        private void radioBtnOutsourced_ModifyPart_CheckedChanged(object sender, EventArgs e)
        {
            // Handles changing the "Machine ID" lable to "Company Name" when the proper radio button is clicked
            labelMachineID_ModifyPart.Text = "Company Name";
        }

        private void btnCancel_ModifyPart_Click(object sender, EventArgs e)
        {
            // Closes the Modify Part form when the "Close" button is clicked
            this.Close();
        }
    }
}

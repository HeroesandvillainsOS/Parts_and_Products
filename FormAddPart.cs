// This script handles the logic for the Add Parts form

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

            // Auto generates a Part ID in the Add Part form & makes the field readonly
            textBoxID_AddPart.ReadOnly = true;
            int newPartID = Inventory.takenPartIds.Max() + 1;
            textBoxID_AddPart.Text = newPartID.ToString();
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

        // Handles the Save button click event
        private void btnSave_AddPart_Click(object sender, EventArgs e)
        {
            // Creates a new Part item when the "Save" button is clicked,
            // ... fetching the data the user has entered into the Add Part form

            int newPartID = Convert.ToInt32(textBoxID_AddPart.Text);
            string newName = textBoxName_AddPart.Text;
            decimal newPrice = Convert.ToDecimal(textBoxPriceCost_AddPart.Text);
            int newInstock = Convert.ToInt32(textBoxInventory_AddPart.Text);
            int newMin = Convert.ToInt32(textBoxMin_AddPart.Text);
            int newMax = Convert.ToInt32(textBoxMax_AddPart.Text);

            Part newPart;

            // Checks for whether the "Machine ID" or "Company Name" radio button ticked
  
            if (radioBtnInHouse_AddPart.Checked)
            {
                int newMachineID = Convert.ToInt32(textBoxMachineID_AddPart.Text);
                newPart = new InHouse(newPartID, newName, newPrice, newInstock, newMin, newMax, newMachineID);
            }
            else
            {
                string newCompanyName = textBoxMachineID_AddPart.Text;
                newPart = new Outsourced(newPartID, newName, newPrice, newInstock, newMin, newMax, newCompanyName); 
            }

            // Calls the AddPart method, which adds the new part to the AllParts Binding List
            Inventory.AddPart(newPart);

            // Closes the Add Part form once a part is added
            this.Close();
        }
    }
}

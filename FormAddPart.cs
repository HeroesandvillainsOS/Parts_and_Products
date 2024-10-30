// This script handles the logic for the Add Parts form

using System;
using System.Drawing;
using System.Linq;
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

            // Sets the default color of the Add Part text boxes
            textBoxName_AddPart.BackColor = Color.OrangeRed;
            textBoxInventory_AddPart.BackColor = Color.OrangeRed;
            textBoxPriceCost_AddPart.BackColor = Color.OrangeRed;
            textBoxMax_AddPart.BackColor = Color.OrangeRed;
            textBoxMin_AddPart.BackColor = Color.OrangeRed;
            textBoxMachineID_AddPart.BackColor = Color.OrangeRed;
        }

        // Displays "Company Name" on the Add Part form
        private void radioBtnOutsourced_AddPart_CheckedChanged(object sender, EventArgs e)
        {
            labelMachineID_AddPart.Text = "Company Name";
        }

        // Displays "Machine ID" on the Add Part form
        private void radioBtnInHouse_AddPart_CheckedChanged(object sender, EventArgs e)
        {
            labelMachineID_AddPart.Text = "Machine ID";
        }

        // Closes the Add Part form when the "Close" button is clicked
        private void btnCancel_AddPart_Click(object sender, EventArgs e)
        {
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

        // Events that change the Text Box colors based on valid and invalid data

        private void textBoxName_AddPart_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName_AddPart.Text))
                textBoxName_AddPart.BackColor = Color.OrangeRed;
            else if (textBoxName_AddPart.Text.All(chr => char.IsLetter(chr)))
                textBoxName_AddPart.BackColor = default(Color);
            else if (textBoxName_AddPart.Text.Contains(" "))
                textBoxName_AddPart.BackColor = default(Color);
            else
                textBoxName_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxInventory_AddPart_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;

            if (int.TryParse(textBoxInventory_AddPart.Text, out parsedValue))
                textBoxInventory_AddPart.BackColor = default(Color);
            else
                textBoxInventory_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxPriceCost_AddPart_TextChanged(object sender, EventArgs e)
        {
            double parsedValue;

            if (double.TryParse(textBoxPriceCost_AddPart.Text, out parsedValue))
                textBoxPriceCost_AddPart.BackColor = default(Color);
            else
                textBoxPriceCost_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxMax_AddPart_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;

            if (int.TryParse(textBoxMax_AddPart.Text, out parsedValue))
                textBoxMax_AddPart.BackColor = default(Color);
            else
                textBoxMax_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxMin_AddPart_TextChanged(object sender, EventArgs e)
        {
            int parsedValue;

            if (int.TryParse(textBoxMin_AddPart.Text, out parsedValue))
                textBoxMin_AddPart.BackColor = default(Color);
            else
                textBoxMin_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxMachineID_AddPart_TextChanged(Object sender, EventArgs e)
        {
            if (radioBtnInHouse_AddPart.Checked)
            {
                int parsedValue;

                if (int.TryParse(textBoxMachineID_AddPart.Text, out parsedValue))
                    textBoxMachineID_AddPart.BackColor = default(Color);
                else
                    textBoxMachineID_AddPart.BackColor = Color.OrangeRed;
            }
            else
            {
                if (String.IsNullOrEmpty(textBoxMachineID_AddPart.Text))
                    textBoxMachineID_AddPart.BackColor = Color.OrangeRed;
                else if (textBoxMachineID_AddPart.Text.All(chr => char.IsLetter(chr)))
                    textBoxMachineID_AddPart.BackColor = default(Color);
                else if (textBoxMachineID_AddPart.Text.Contains(" "))
                    textBoxMachineID_AddPart.BackColor = default(Color);
                else
                    textBoxMachineID_AddPart.BackColor = Color.OrangeRed;
            }

        }
    }
}

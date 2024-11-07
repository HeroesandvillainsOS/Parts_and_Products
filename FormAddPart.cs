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

        // Events that change the Text Box colors based on valid and invalid data
        private void textBoxName_AddPart_TextChanged(object sender, EventArgs e)
        {
            bool onlyNumbers = textBoxName_AddPart.Text.All(chr => !char.IsLetter(chr));

            if (String.IsNullOrEmpty(textBoxName_AddPart.Text))
                textBoxName_AddPart.BackColor = Color.OrangeRed;
            else if (!onlyNumbers)
                textBoxName_AddPart.BackColor = default(Color);
            else if (textBoxName_AddPart.Text.Contains(" "))
                textBoxName_AddPart.BackColor = default(Color);
            else
                textBoxName_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxInventory_AddPart_TextChanged(object sender, EventArgs e)
        {         
            if (int.TryParse(textBoxInventory_AddPart.Text, out int parsedValue))
                textBoxInventory_AddPart.BackColor = default(Color);
            else
                textBoxInventory_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxPriceCost_AddPart_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxPriceCost_AddPart.Text, out double parsedValue))
                textBoxPriceCost_AddPart.BackColor = default(Color);
            else
                textBoxPriceCost_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxMax_AddPart_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxMax_AddPart.Text, out int parsedValue))
                textBoxMax_AddPart.BackColor = default(Color);
            else
                textBoxMax_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxMin_AddPart_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxMin_AddPart.Text, out int parsedValue))
                textBoxMin_AddPart.BackColor = default(Color);
            else
                textBoxMin_AddPart.BackColor = Color.OrangeRed;
        }

        private void textBoxMachineID_AddPart_TextChanged(Object sender, EventArgs e)
        {
            if (radioBtnInHouse_AddPart.Checked)
            {
                if (int.TryParse(textBoxMachineID_AddPart.Text, out int parsedValue))
                    textBoxMachineID_AddPart.BackColor = default(Color);
                else
                    textBoxMachineID_AddPart.BackColor = Color.OrangeRed;
            }
            else
            {
                bool onlyNumbers = textBoxMachineID_AddPart.Text.All(chr => !char.IsLetter(chr));

                if (String.IsNullOrEmpty(textBoxMachineID_AddPart.Text))
                    textBoxMachineID_AddPart.BackColor = Color.OrangeRed;
                else if (!onlyNumbers)
                    textBoxMachineID_AddPart.BackColor = default(Color);
                else if (textBoxMachineID_AddPart.Text.Contains(" "))
                    textBoxMachineID_AddPart.BackColor = default(Color);
                else
                    textBoxMachineID_AddPart.BackColor = Color.OrangeRed;
            }
        }

        // Handles the Save button click event
        private void btnSave_AddPart_Click(object sender, EventArgs e)
        {
            bool onlyNumbersName = textBoxName_AddPart.Text.All(chr => !char.IsLetter(chr));
            bool onlyNumbersMachineID = textBoxMachineID_AddPart.Text.All(chr => !char.IsLetter(chr));

            // Checks to ensure text boxes only use valid data types
            if (onlyNumbersName)
            {
                MessageBox.Show("Name must contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxInventory_AddPart.Text, out _))
            {
                MessageBox.Show("Inventory can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBoxPriceCost_AddPart.Text, out _))
            {
                MessageBox.Show("Price can only contain numbers and decimals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxMax_AddPart.Text, out _))
            {
                MessageBox.Show("Max can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxMin_AddPart.Text, out _))
            {
                MessageBox.Show("Min can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(textBoxMax_AddPart.Text) < int.Parse(textBoxMin_AddPart.Text))
            {
                MessageBox.Show("Min cannot be greater than Max.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(textBoxInventory_AddPart.Text) < int.Parse(textBoxMin_AddPart.Text) ||
                int.Parse(textBoxInventory_AddPart.Text) > int.Parse(textBoxMax_AddPart.Text))
            {
                MessageBox.Show("Inventory cannot be less than Min or greater than Max.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioBtnInHouse_AddPart.Checked == true)
            {
                if (!onlyNumbersMachineID)
                {
                    MessageBox.Show("Machine ID can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (radioBtnOutsourced_AddPart.Checked == true)
            {
                if (onlyNumbersMachineID)
                {
                    MessageBox.Show("Company Name must contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

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

            // Adds the new Product ID to the takenProductIDs Binding List
            Inventory.takenPartIds.Add(newPartID);

            // Closes the Add Part form once a part is added
            this.Close();
        }

        // Handles the Close button click event
        private void btnCancel_AddPart_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

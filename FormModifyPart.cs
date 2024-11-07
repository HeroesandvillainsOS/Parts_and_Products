// This script handles the logic for the Modify Part form

using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Products_and_Parts
{
    public partial class FormModifyPart : Form
    {
        // Sets the inital values of the Modify Parts text boxes
        public FormModifyPart()
        {
            InitializeComponent();
            
            // Gets the currently selected row and its values
            var selectedRow = MainScreen.Instance.DgvParts.SelectedRows[0];
            int selectedPartID = (int)selectedRow.Cells["PartID"].Value;
            string selectedName = (string)selectedRow.Cells["Name"].Value;
            decimal selectedPrice = (decimal)selectedRow.Cells["Price"].Value;
            int selectedInStock = (int)selectedRow.Cells["InStock"].Value;
            int selectedMin = (int)selectedRow.Cells["Min"].Value;
            int selectedMax = (int)selectedRow.Cells["Max"].Value;
            int selectedMachineID;
            string selectedCompanyName;

            // Uses the Part LookUp method to determine if the Part is InHouse or Outsourced
            Part part = Inventory.LookupPart(selectedPartID);

            if (part is InHouse inHousePart)
            {
                // Sets the selectedMachineID variable to the Part's Machine ID
                selectedMachineID = inHousePart.MachineID;
                // Ticks the InHouse radio button
                radioBtnInHouse_ModifyPart.Enabled = true;             
                // Sets the Modify Part text boxes to the values of the currently selected Part
                textBoxID_ModifyPart.Text = selectedPartID.ToString();
                textBoxName_ModifyPart.Text = selectedName;
                textBoxPriceCost_ModifyPart.Text = selectedPrice.ToString();
                textBoxInventory_ModifyPart.Text = selectedInStock.ToString();
                textBoxMin_ModifyPart.Text = selectedMin.ToString();
                textBoxMax_ModifyPart.Text = selectedMax.ToString();
                textBoxMachineID_ModifyPart.Text = selectedMachineID.ToString();
            }

            else if (part is Outsourced outsourcedPart)
            {
                // Sets the selectedMachineID variable to the Part's Company Name
                selectedCompanyName = outsourcedPart.CompanyName;
                // Ticks the Outsourced radio button
                radioBtnOutsourced_ModifyPart.Enabled = true;
                // Sets the text box values
                textBoxID_ModifyPart.Text = selectedPartID.ToString();
                textBoxName_ModifyPart.Text = selectedName;
                textBoxPriceCost_ModifyPart.Text = selectedPrice.ToString();
                textBoxInventory_ModifyPart.Text = selectedInStock.ToString();
                textBoxMin_ModifyPart.Text = selectedMin.ToString();
                textBoxMax_ModifyPart.Text = selectedMax.ToString();
                textBoxMachineID_ModifyPart.Text = selectedCompanyName.ToString();
            }
        }

        // Handles changing the "Company Name" lable to "Machine" when the proper radio button is clicked
        private void radioBtnInHouse_ModifyPart_CheckedChanged(object sender, EventArgs e)
        {
            labelMachineID_ModifyPart.Text = "Machine ID";
        }

        // Handles changing the "Machine ID" lable to "Company Name" when the proper radio button is clicked
        private void radioBtnOutsourced_ModifyPart_CheckedChanged(object sender, EventArgs e)
        {
            labelMachineID_ModifyPart.Text = "Company Name";
        }

        // Events that change the Text Box colors based on valid and invalid data
        private void textBoxName_ModifyPart_TextChanged(object sender, EventArgs e)
        {
            bool onlyNumbers = textBoxName_ModifyPart.Text.All(chr => !char.IsLetter(chr));

            if (String.IsNullOrEmpty(textBoxName_ModifyPart.Text))
                textBoxName_ModifyPart.BackColor = Color.OrangeRed;
            else if (!onlyNumbers)
                textBoxName_ModifyPart.BackColor = default(Color);
            else if (textBoxName_ModifyPart.Text.Contains(" "))
                textBoxName_ModifyPart.BackColor = default(Color);
            else
                textBoxName_ModifyPart.BackColor = Color.OrangeRed;
        }

        private void textBoxInventory_ModifyPart_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxInventory_ModifyPart.Text, out int parsedValue))
                textBoxInventory_ModifyPart.BackColor = default(Color);
            else
                textBoxInventory_ModifyPart.BackColor = Color.OrangeRed;
        }

        private void textBoxPriceCost_ModifyPart_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxPriceCost_ModifyPart.Text, out double parsedValue))
                textBoxPriceCost_ModifyPart.BackColor = default(Color);
            else
                textBoxPriceCost_ModifyPart.BackColor = Color.OrangeRed;
        }

        private void textBoxMax_ModifyPart_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxMax_ModifyPart.Text, out int parsedValue))
                textBoxMax_ModifyPart.BackColor = default(Color);
            else
                textBoxMax_ModifyPart.BackColor = Color.OrangeRed;
        }

        private void textBoxMin_ModifyPart_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxMin_ModifyPart.Text, out int parsedValue))
                textBoxMin_ModifyPart.BackColor = default(Color);
            else
                textBoxMin_ModifyPart.BackColor = Color.OrangeRed;
        }

        private void textBoxMachineID_ModifyPart_TextChanged(object sender, EventArgs e)
        {
            var currentMachineID = textBoxMachineID_ModifyPart.Text;
            bool isNumber = false;

            if (int.TryParse(currentMachineID, out int parsedMachineID))
                isNumber = true;

            if (isNumber && radioBtnInHouse_ModifyPart.Checked)
            {
                if (int.TryParse(textBoxMachineID_ModifyPart.Text, out int parsedValue))
                    textBoxMachineID_ModifyPart.BackColor = default(Color);
                else
                    textBoxMachineID_ModifyPart.BackColor = Color.OrangeRed;
            }
            else
            {
                bool onlyNumbers = textBoxName_ModifyPart.Text.All(chr => !char.IsLetter(chr));

                if (String.IsNullOrEmpty(textBoxMachineID_ModifyPart.Text))
                    textBoxMachineID_ModifyPart.BackColor = Color.OrangeRed;
                else if (!onlyNumbers)
                    textBoxMachineID_ModifyPart.BackColor = default(Color);
                else if (textBoxMachineID_ModifyPart.Text.Contains(" "))
                    textBoxMachineID_ModifyPart.BackColor = default(Color);
                else
                    textBoxMachineID_ModifyPart.BackColor = Color.OrangeRed;
            }
        }

        // Handles the save button click event
        private void btnSave_ModifyPart_Click(object sender, EventArgs e)
        {
            bool onlyNumbersName = textBoxName_ModifyPart.Text.All(chr => !char.IsLetter(chr));
            bool onlyNumbersMachineID = textBoxMachineID_ModifyPart.Text.All(chr => !char.IsLetter(chr));

            // Checks to ensure text boxes only use valid data types
            if (onlyNumbersName)
            {
                MessageBox.Show("Name must contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxInventory_ModifyPart.Text, out _))
            {
                MessageBox.Show("Inventory can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBoxPriceCost_ModifyPart.Text, out _))
            {
                MessageBox.Show("Price can only contain numbers and decimals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxMax_ModifyPart.Text, out _))
            {
                MessageBox.Show("Max can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxMin_ModifyPart.Text, out _))
            {
                MessageBox.Show("Min can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(textBoxMax_ModifyPart.Text) < int.Parse(textBoxMin_ModifyPart.Text))
            {
                MessageBox.Show("Min cannot be greater than Max.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(textBoxInventory_ModifyPart.Text) < int.Parse(textBoxMin_ModifyPart.Text) ||
                int.Parse(textBoxInventory_ModifyPart.Text) > int.Parse(textBoxMax_ModifyPart.Text))
            {
                MessageBox.Show("Inventory cannot be less than Min or greater than Max.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioBtnInHouse_ModifyPart.Checked == true)
            {
                if (!onlyNumbersMachineID)
                {
                    MessageBox.Show("Machine ID can only contain numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (radioBtnOutsourced_ModifyPart.Checked == true)
            {
                if (onlyNumbersMachineID)
                {
                    MessageBox.Show("Company Name must contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Stores the selected Part's new values
            int currentID = int.Parse(textBoxID_ModifyPart.Text);
            string newName = textBoxName_ModifyPart.Text;
            decimal newPrice = decimal.Parse(textBoxPriceCost_ModifyPart.Text);
            int newInventory = int.Parse(textBoxInventory_ModifyPart.Text);
            int newMax = int.Parse(textBoxMax_ModifyPart.Text);
            int newMin = int.Parse(textBoxMin_ModifyPart.Text);
            int newMachineID;
            string newCompanyName;

            // Finds the selected Part's index position
            int indexPosition = Inventory.GetIndexPositionWithPartID(Inventory.AllParts, currentID);
            // Removes the old Part from the Binding List
            Inventory.AllParts.RemoveAt(currentID);
            // Adds the Part back into the Binding List
            if (radioBtnInHouse_ModifyPart.Checked == true)
            {
                newMachineID = int.Parse(textBoxMachineID_ModifyPart.Text);
                Part updatedPart = new InHouse(currentID, newName, newPrice, newInventory, newMin, newMax, newMachineID);
                Inventory.AllParts.Insert(indexPosition, updatedPart);
            }

            if (radioBtnOutsourced_ModifyPart.Checked == true)
            {
                newCompanyName = textBoxMachineID_ModifyPart.Text;
                Part updatedPart = new Outsourced(currentID, newName, newPrice, newInventory, newMin, newMax, newCompanyName);
                Inventory.AllParts.Insert(indexPosition, updatedPart);
            }

            // Closes the window
            this.Close();
        }

        // Handles the close button click event
        private void btnCancel_ModifyPart_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

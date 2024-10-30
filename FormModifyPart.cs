using System;
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
                radioBtnOutsourced_ModifyPart.Enabled = false;
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
                radioBtnInHouse_ModifyPart.Enabled= false;
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

        // Closes the Modify Part form when the "Close" button is clicked
        private void btnCancel_ModifyPart_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

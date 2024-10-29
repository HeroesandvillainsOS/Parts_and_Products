﻿// This script handles the overall logic for the Main Inventory form.
// Acts as a master class for referencing the Products and Parts related classes, and closing the application.

using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Products_and_Parts
{
    internal class Inventory
    {
        public static BindingList<Product> Products { get; set; } = new BindingList<Product>();
        public static BindingList<Part> AllParts { get; set; } = new BindingList<Part>();

        public static List<int> takenPartIds = new List<int>();

        public static List<int> takenProductIds = new List<int>();

        // Adds test data to the Products & AllParts Binding Lists
        static Inventory()
        {
            // Represents the initial list of Products
            Products.Add(new Product(0, "Acer Laptop", 899.99m, 10, 2, 20));
            Products.Add(new Product(1, "Vizio Television", 999.99m, 8, 1, 10));
            Products.Add(new Product(2, "Apple iPhone 18", 799.99m, 6, 4, 15));

            // Represents the initial list of Parts
            AllParts.Add(new InHouse(0, "Power Supply", 299.99m, 15, 8, 30, 00100));
            AllParts.Add(new InHouse(1, "Battery", 49.99m, 3, 1, 5, 00200));
            AllParts.Add(new Outsourced(2, "Glass Display", 199.99m, 5, 1, 6, "Apple"));
            AllParts.Add(new Outsourced(3, "Wireless Mouse", 79.99m, 5, 2, 8, "Logitech"));
            AllParts.Add(new Outsourced(4, "Charger Cable", 29.99m, 11, 20, 10, "Anker"));
        }

        // Methods related to Products

        public static void OpenAddProductsForm()
        {
            // Keeps a running List of taken productID's every time the Add Products form is open
            for (int i = 0; i < Inventory.Products.Count; i++)
                takenProductIds.Add(i);

            // Opens the Add Products form when the "Add" button is clicked
            FormAddProduct addProductForm = new FormAddProduct();
            addProductForm.Show();
        }

        public static void OpenModifyProductsForm()
        {
            // Opens the Modify Product form when the "Modify" button is clicked
            FormModifyProduct modifyProductForm = new FormModifyProduct();
            modifyProductForm.Show();
        }

        public static void AddProduct(Product product)
        {
            // Adds a new Product item to the Products Binding List,
            // ... which displays the Product on the Inventory form's Product data grid view
            Products.Add(product);
        }

        public static bool RemoveProduct(int productID)
        {
            // Ensures the app fails gracefully in the event an invalid Product (index) is (somehow) selected 
            if (productID >= 0)
                return true;
            else 
                return false;
        }

        public static Product LookupProduct(int productID) { return null; }

        public static void UpdateProduct(int productID, Product product) { }

        // Methods related to Parts

        public static void OpenAddPartsForm()
        {
            // Keeps a running List of taken partID's every time the Add Parts form is open
            for (int i = 0; i < Inventory.AllParts.Count; i++)
                takenPartIds.Add(i);

            // Opens the Add Parts form when the "Add" button is clicked
            FormAddPart addPartForm = new FormAddPart();
            addPartForm.Show();
        }

        public static void OpenModifyPartsForm()
        {
            // Opens the Modify Parts form when the "Modify" button is clicked
            FormModifyPart modifyPartForm = new FormModifyPart();
            modifyPartForm.Show();
        }

        public static void AddPart(Part part)
        {
            // Adds a new part item to the AllParts Binding List,
            // ... which displays the part on the Inventory form's Part data grid view
            Inventory.AllParts.Add(part);
            
        }

        public static bool DeletePart(Part part)
        {
            // THIS WILL BE USED TO CHECK TO SEE IF PART IS ASSOCIATED WITH ANY PRODUCTS
            // IF YES, IT WILL RETURN FALSE AND THE PART CANNOT BE DELETED
            // IF NO, IT WILL RETURN TRUE, ALLOWING THE PART TO BE DELETED
            return true;
        }

        public static Part LookupPart(int partID)
        {
            int foundPartID;
            string foundName;
            decimal foundPrice;
            int foundInStock;
            int foundMin;
            int foundMax;
            int foundMachineID;
            string foundCompanyName;

            foreach(Part part in Inventory.AllParts)
            {
                // Checks to see if the passed Part ID matches a Part in the All Parts List
                if (partID == part.PartID)
                {
                    foundPartID = partID;
                    foundName = part.Name;
                    foundPrice = part.Price;
                    foundInStock = part.InStock;
                    foundMin = part.Min;
                    foundMax = part.Max;

                    // Checks to determine if the part is InHouse or Outsourced

                    if (part is InHouse inHousePart)
                    {
                        foundMachineID = inHousePart.MachineID;
                        Part foundPart = new InHouse(foundPartID, foundName, foundPrice, foundInStock, foundMin, foundMax,
                            foundMachineID);
                        return foundPart;
                    }
                    else if (part is Outsourced outsourcedPart)
                    {
                        foundCompanyName = outsourcedPart.CompanyName;
                        Part foundPart = new Outsourced(foundPartID, foundName, foundPrice, foundInStock, foundMin, foundMax,
                            foundCompanyName);
                        return foundPart;
                    }
                }
            }
            return null;
        }

        public static void UpdatePart(int partID, Part part) { }

        public static void CloseInventoryForm()
        {
            // Closes the program when the "Exit" button is clicked
            Application.Exit();
        }
    }
}

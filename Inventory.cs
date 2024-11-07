// This script handles the overall logic for the Main Inventory form.
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
            Products.Add(new Product(2, "Apple iPhone", 799.99m, 6, 4, 15));

            // Represents the initial list of Parts
            AllParts.Add(new InHouse(0, "Power Supply", 299.99m, 15, 8, 30, 00100));
            AllParts.Add(new InHouse(1, "Battery", 49.99m, 3, 1, 5, 00200));
            AllParts.Add(new Outsourced(2, "Glass Display", 199.99m, 5, 1, 6, "Apple"));
            AllParts.Add(new Outsourced(3, "Wireless Mouse", 79.99m, 5, 2, 8, "Logitech"));
            AllParts.Add(new Outsourced(4, "Charger Cable", 29.99m, 13, 10, 20, "Anker"));

            // Represents the initial list of Associated Parts with Products
            Product.ProductsWithAssociatedParts.Add(new ProductPartAssociation(0, 0));
            Product.ProductsWithAssociatedParts.Add(new ProductPartAssociation(0, 3));

            // Represents the Initial List of Parts that are associated with products
            Product.AssociatedParts.Add(new InHouse(0, "Power Supply", 299.99m, 15, 8, 30, 00100));
            Product.AssociatedParts.Add(new Outsourced(2, "Glass Display", 199.99m, 5, 1, 6, "Apple"));
            Product.AssociatedParts.Add(new Outsourced(3, "Wireless Mouse", 79.99m, 5, 2, 8, "Logitech"));
        }

        // METHODS RELATED TO PRODUCTS

        // Adds a new Product item to the Products Binding List
        public static void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public static bool RemoveProduct(int productID)
        {
            // Ensures the app fails gracefully in the event an invalid Product index is selected 
            if (productID >= 0)
                return true;
            else
                return false;
        }

        // Returns a Product if one is found in the Products Binding List
        public static Product LookupProduct(int productID)
        {
            int foundProductID;
            string foundName;
            decimal foundPrice;
            int foundInStock;
            int foundMin;
            int foundMax;

            foreach (Product product in Inventory.Products)
            {
                // Checks to see if the passed Product ID matches a Product in the Products List
                if (productID == product.ProductID)
                {
                    foundProductID = productID;
                    foundName = product.Name;
                    foundPrice = product.Price;
                    foundInStock = product.InStock;
                    foundMin = product.Min;
                    foundMax = product.Max;
                    Product foundProduct = new Product(foundProductID, foundName, foundPrice, foundInStock, foundMin, foundMax);
                    return foundProduct;
                }
            }
            return null;
        }

        // Saves the Product information to the Inventory.Products Binding List
        public static void UpdateProduct(int productID, Product product)
        {
            Product currentProduct = Inventory.LookupProduct(productID);

            if (currentProduct ==  null)
                MessageBox.Show("No Products with this Product ID could be found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else
            {
                // Deletes the previous reference to the Product in the Inventory.Products Binding List
                foreach (Product individualProduct in Inventory.Products)
                {
                    if (individualProduct.ProductID == productID)
                        Inventory.Products.Remove(individualProduct);
                }

                // Saves the Product's new information to the Inventory.Products Binding List
                Inventory.Products.Add(currentProduct);
            }
        }

        // Returns an index position of a Product when a productID is passed in
        public static int GetIndexPositionWithProductID(BindingList<Product> list, int productID)
        {
            for (int i = 0;  i < list.Count; i++)
            {
                if (list[i].ProductID == productID)
                    return i;
            }
            return -1;
        }

        // METHODS RELATED TO PARTS

        // Adds a new Part item to the AllParts Binding List
        public static void AddPart(Part part)
        {
            Inventory.AllParts.Add(part);
        }

        // Returns true if a Part isn't assoicated with any Products and can safely be deleted 
        public static bool DeletePart(Part part)
        {
            foreach (var productWithPartAssociation in Product.ProductsWithAssociatedParts)
            {
                if (productWithPartAssociation.PartID == part.PartID)
                    return false;
            }
            return true;
        }

        // Returns an InHouse or Outsourced Part if one is found in the AllParts Binding List
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

            foreach (Part part in Inventory.AllParts)
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

        // Saves the Part information to the Inventory.AllParts Binding List
        public static void UpdatePart(int partID, Part part)
        {
            Part currentPart = Inventory.LookupPart(partID);

            if (currentPart == null)
                MessageBox.Show("No Parts with this Part ID could be found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                // Deletes the previous reference to the Part in the Inventory.AllParts Binding List
                foreach (Part individualPart in Inventory.AllParts)
                {
                    if (individualPart.PartID == partID)
                        Inventory.AllParts.Remove(individualPart);
                }

                // Saves the Part's new information to the Inventory.AllParts Binding List
                Inventory.AllParts.Add(currentPart);
            }
        }

        // Returns an index position of a Product when a productID is passed in
        public static int GetIndexPositionWithPartID(BindingList<Part> list, int partID)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].PartID == partID)
                    return i;
            }
            return -1;
        }

        // Closes the program when the "Exit" button is clicked
        public static void CloseInventoryForm()
        {
            Application.Exit();
        }
    }
}

using System.ComponentModel;
using System.Windows.Forms;

namespace Products_and_Parts
{
    internal class Product
    {
        // Maintains a list of every part that is associated with a product
        public static BindingList<Part> AssociatedParts { get; set; } = new BindingList<Part>();

        // Temporarily holds a list of parts to associate with the selected product,
        // ... allowing the user to either "save" them to the "ProductsWithAssociatedParts" Binding List,
        // ... or "cancel" the pairing.
        public static BindingList<Part> TemporaryAssociatedParts { get; set; } = new BindingList<Part>();

        // Represents a master list of ProductID's with their associated parts as a kind of "value key" pairing.
        // A "ProductPartAssociation" item holds two ints in each index, IE. 1,2, which means ProductID 1 is associated with PartID 2.
        // "ProductsWithAssociatedParts" then holds this "value key" reference.
        public static BindingList<ProductPartAssociation> ProductsWithAssociatedParts { get; set; } = new BindingList<ProductPartAssociation>();

        // Acts as a temporary list that displays all parts associated with the Product selected on the Add and Modify Product form
        // Gets reset every time the form is opened, and pulls its data from the "ProductsWtihAssociatedParts" Binding List "value key" pair
        public static BindingList<Part> PartsAssociatedWithThisProduct { get; set; } = new BindingList<Part>();

        public int ProductID { get; set; }  
        public string Name { get; set; }    
        public decimal Price { get; set; }
        public int InStock { get; set; }    
        public int Min { get; set; }
        public int Max { get; set; }

        public Product(int productID, string name, decimal price, int inStock, int min, int max)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        // Adds a Part to the Associated Parts Binding List
        public static void AddAssociatedPart(Part part)
        {
            if (AssociatedParts.Contains(part))
            {
                MessageBox.Show("This Part is already associated with at least one Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
                AssociatedParts.Add(part);
        }

        // Returns true if a Part matching the partID exits in the Associated Parts Binding List
        public static bool RemoveAssociatedPart(int partID)
        {
            foreach (Part associatedPart in AssociatedParts)
            {
                if (associatedPart.PartID == partID)
                    return true;
            }

            MessageBox.Show("No Part is associated with this Part ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Returns a Part if a matching one exists in the Associated Parts Binding List
        public static Part LookupAssociatedPart(int partID)
        {
            foreach (Part associatedPart in AssociatedParts)
            {
                if (associatedPart.PartID == partID)
                {
                    Part returnedPart = Inventory.LookupPart(partID);
                    return returnedPart;
                }
            }
            return null;
        }
    }
}

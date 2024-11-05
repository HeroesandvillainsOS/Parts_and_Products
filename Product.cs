using System.ComponentModel;

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

        // WILL USE TO ADD A PART TO THE ALL ASSOCIATED PARTS BINDING LIST WHEN SAVE BUTTON CLICKED
        public static void AddAssociatedPart(Part part)
        {

        }

        // CAN ALSO USE TO DELETE AN ASSOCIATED PART FROM THE ALL ASSOCIATED PARTS BINDING LIST WHEN SAVE BUTTON CLICKED
        // IF RETURNS TRUE, DELETE PART FROM ALL ASSOCIATED PARTS BINDING LIST. IF FALSE, DON'T DELETE AND DISPLAY MESSAGE.
        public static bool RemoveAssociatedPart(int partID)
        {
            return true;
        }

        // CAN USE TO GET FULL PART DETAILS FROM ALL ASSOCIATED PARTS BINDING LIST BY ENTERING A PART ID
        // IF NULL, MAYBE A MESSAGE DISPLAYS SAYING THE PART IS NOT ASSOCIATED WITH ANY PRODUCTS
        public static Part LookupAssociatedPart(int partID)
        {
            return null;
        }
    }
}

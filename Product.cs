using System.ComponentModel;
using System.Windows.Forms;

namespace Products_and_Parts
{
    internal class Product
    {
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
    }
}

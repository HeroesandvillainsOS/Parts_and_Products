using System.ComponentModel;

namespace Products_and_Parts
{
    internal class Product
    {
        public static BindingList<Part> AssociatedParts { get; set; } = new BindingList<Part>();
        public static BindingList<Part> TemporaryAssociatedParts { get; set; } = new BindingList<Part>();
        public static BindingList<ProductPartAssociation> ProductsWithAssociatedParts { get; set; } = new BindingList<ProductPartAssociation>();
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

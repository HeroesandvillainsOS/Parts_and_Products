using System.ComponentModel;

namespace Products_and_Parts
{
    internal class Product
    {
        public static BindingList<Part> AssociatedParts = new BindingList<Part>();
        public int ProductID { get; set; }  
        public string Name { get; set; }    
        public decimal Price { get; set; }
        public int InStock { get; set; }    
        public int Min { get; set; }
        public int Max { get; set; }

        // A static constructor for a one-time initialization of test data (will only generate once and not on every class instance)

        public Product(int productID, string name, decimal price, int inStock, int min, int max)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public static void AddAssociatedPart(Part part)
        {

        }

        public static bool RemoveAssociatedPart(int partID)
        {
            return true;
        }

        public static Part LookupAssociatedPart(int partID)
        {
            return null;
        }
    }
}

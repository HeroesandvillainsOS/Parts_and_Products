using System.ComponentModel;

namespace Products_and_Parts
{
    internal class Inventory
    {
        public static BindingList<Product> Product { get; set; } = new BindingList<Product>();
        public static BindingList<Part> AllParts { get; set; } = new BindingList<Part>();

        static Inventory()
        {
            Product.Add(new Product(0, "Acer Laptop", 899.99m, 10, 2, 20));
            Product.Add(new Product(1, "Vizio Television", 999.99m, 8, 1, 10));
            Product.Add(new Product(2, "Apple iPhone 18", 799.99m, 6, 4, 15));

            AllParts.Add(new InHouse(0, "Power Supply", 299.99m, 15, 8, 30, 00100));
            AllParts.Add(new InHouse(1, "Battery", 49.99m, 3, 1, 5, 00200));
            AllParts.Add(new Outsourced(2, "Glass Display", 199.99m, 5, 1, 6, "Apple"));
            AllParts.Add(new Outsourced(3, "Wireless Mouse", 79.99m, 5, 2, 8, "Logitech"));
            AllParts.Add(new Outsourced(4, "Charger Cable", 29.99m, 11, 20, 10, "Anker"));
        }

        public static void AddProduct(Product product)
        {

        }

        public static bool RemoveProduct(int productID)
        {
            return true;
        }

        public static Product LookupProduct(int productID)
        {
            return null;
        }

        public static void UpdateProduct(int productID, Product product)
        {

        }

        public static void AddPart(Part part)
        {

        }

        public static bool DeletePart(Part part)
        {
            return true;
        }

        public static Part LookupPart(int partID)
        {
            return null;
        }

        public static void UpdatePart(int partID, Part part)
        {

        }
    }
}

namespace Products_and_Parts
{
    internal class ProductPartAssociation
    {
        public int ProductID { get; set; }
        public int PartID { get; set; }

        public ProductPartAssociation(int productID, int partID)
        {
            ProductID = productID;
            PartID = partID;
        }
    }
}

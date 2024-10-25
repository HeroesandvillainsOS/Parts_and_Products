namespace Products_and_Parts
{
    internal class InHouse : Part
    {
        public int MachineID { get; set; }

        public InHouse(int partID, string name, decimal price, int inStock, int min, int max, int machineID)
            : base(partID, name, price, inStock, min, max)
        {
            MachineID = machineID;
        }
    }

}

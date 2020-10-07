namespace VendingMachineCore.Products
{
    public abstract class Product
    {
        public int Prize { get; protected set; }
        public double Number { get; set; }

        public Product()
        {
            
        }
    }
}
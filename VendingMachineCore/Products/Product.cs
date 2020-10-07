namespace VendingMachineCore.Products
{
    public abstract class Product
    {
        protected int Prize { get; set; }
        public double Number { get; set; }

        public Product()
        {
            
        }
    }
}
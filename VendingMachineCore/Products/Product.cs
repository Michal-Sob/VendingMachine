namespace VendingMachineCore.Products
{
    public abstract class Product
    {
        protected double Prize { get; set; }
        public double Number { get; set; }

        public Product()
        {
            
        }
    }
}
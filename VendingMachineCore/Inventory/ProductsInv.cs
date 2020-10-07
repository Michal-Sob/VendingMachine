using System.Collections.Generic;
using VendingMachineCore.Products;

namespace VendingMachineCore.Inventory
{
    public class ProductsInv
    {
        public Dictionary<Products, int> ProductCount { get; set; }

        public ProductsInv()
        {
            ProductCount = new Dictionary<Products, int>()
            {
                {Products.Cola, 10},
                {Products.Chips, 10},
                {Products.Candy, 10}
            };
        }

        public enum Products
        {
            Cola,
            Chips,
            Candy
        }
    }
}
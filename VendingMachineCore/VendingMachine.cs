using System;
using System.Collections;
using System.Linq;
using VendingMachineCore.Coins;
using VendingMachineCore.Inventory;

namespace VendingMachineCore
{
    public class VendingMachine
    {
        private CoinsInv CoinsInv;
        private ProductsInv ProductsInv;

        public VendingMachine()
        {
            CoinsInv = new CoinsInv();
            ProductsInv = new ProductsInv();
        }

        public Coin InsertCoin(Coin coin)
        {
            if (coin == null)
                Console.WriteLine("No coin with this value");
            if (coin.Mass == 2.5)
            {
                CentError();
                return null;
            }

            if (coin.Mass == 5)
                return new Nickel();
            if (coin.Mass == 2.268)
                return new Dime();
            if (coin.Mass == 5.67)
                return new Quarter();
            
            return null;
        }

        public void DisplayCredit(int credit)
        {
            Console.WriteLine($"your credit is: {credit}¢");
        }

        private void CentError()
        {
            Console.WriteLine("No Cent coin allowed");
        }
    }
}
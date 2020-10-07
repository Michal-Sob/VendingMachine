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
            if (coin.Mass == 2.5) 
                return new Cent();
            if (coin.Mass == 5)
                return new Nickel();
            if (coin.Mass == 2.268)
                return new Dime();
            if (coin.Mass == 5.67)
                return new Quarter();
            else
                return null;
        }
    }
}
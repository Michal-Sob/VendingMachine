using System;
using System.Collections;
using System.Collections.Generic;
using VendingMachineCore.Coins;

namespace VendingMachineCore.Inventory
{
    public class CoinsInv
    {
        public Dictionary<Coins, int> CoinCount { get; set; }

        public CoinsInv()
        {
            CoinCount = new Dictionary<Coins, int>()
            {
                {Coins.Nickel, 10},
                {Coins.Dime, 10},
                {Coins.Quarter, 10}
            };
        }

        public enum Coins
        {
            Cent = 1,
            Nickel = 5,
            Dime = 10,
            Quarter = 25,
        }

        public Coins CoinVerification(int coin)
        {
            return coin switch
            {
                1 => Coins.Cent,
                5 => Coins.Nickel,
                10 => Coins.Dime,
                25 => Coins.Quarter,
                _ => Coins.Cent
            };
        }
    }
}
using System;
using VendingMachineCore.Coins;
using VendingMachineCore.Inventory;

namespace VendingMachineCore
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            VendingMachine vendingMachine = new VendingMachine();

            Console.WriteLine("Type value of a coin (1,5,10,25)");
            var coin = int.Parse(Console.ReadLine());

            vendingMachine.InsertCoin(CoinsMass(coin));
        }

        private static Coin CoinsMass(int coin)
        {
            if (coin == 1) 
                return new Cent();
            if (coin == 5)
                return new Nickel();
            if (coin == 10)
                return new Dime();
            if (coin == 25)
                return new Quarter();
            else
                return null;
        }
    }
}
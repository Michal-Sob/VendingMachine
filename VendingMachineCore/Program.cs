using System;
using VendingMachineCore.Coins;
using VendingMachineCore.Inventory;

namespace VendingMachineCore
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            var credit = InsertCoin(vendingMachine);
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

        private static bool InputValidation(string input)
        {
            if (int.TryParse(input, out var result))
                if (result == 0 || result == 2 || result == 5 || result == 10 || result == 25)
                    return true;
            
            return false;
        }

        private static int InsertCoin(VendingMachine vendingMachine)
        {
            int credit = 0;
            int coin;
            
            do
            {
                Console.WriteLine("Type value of a coin (5,10,25 (0 to accept))");
                var input = Console.ReadLine();

                while (!InputValidation(input))
                {
                    Console.WriteLine("Type value of a coin (5,10,25 (0 to accept))");
                    input = Console.ReadLine();
                }

                coin = int.Parse(input);

                if (coin == 0)
                    break;

                credit += vendingMachine.InsertCoin(CoinsMass(coin)).Value;

                vendingMachine.DisplayCredit(credit);
            } while (coin != 0);

            return credit;
        }
        

    }
}
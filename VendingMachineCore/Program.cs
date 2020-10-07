using System;
using VendingMachineCore.Coins;
using VendingMachineCore.Inventory;
using VendingMachineCore.Products;

namespace VendingMachineCore
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            var credit = 0;
            Product product = null;
            
            while (product == null)
            {
                credit = InsertCoin(vendingMachine);
            
                product = ChooseProduct(vendingMachine, credit);
            }
            
            Console.WriteLine($"{product.GetType().Name} in dispenser");

            var change = vendingMachine.DispenseChange(credit, product);
            
            if (change.Count > 0)
            {
                Console.WriteLine("Your change:");
                foreach (var coin in change)
                {
                    Console.WriteLine(coin);
                }
            }
            
            Console.WriteLine("Thank You");
        }


        private static Coin CoinValue(int coin)
        {
            return coin switch
            {
                1 => new Cent(),
                5 => new Nickel(),
                10 => new Dime(),
                25 => new Quarter(),
                _ => null
            };
        }

        private static bool CoinInputValidation(string input)
        {
            if (int.TryParse(input, out var result))
                if (result == 0 || result == 2 || result == 5 || result == 10 || result == 25)
                    return true;
            
            return false;
        }
        
        private static bool ProductInputValidation(string input)
        {
            if (int.TryParse(input, out var result))
                if (result == 0 || result == 1 || result == 2 || result == 3)
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

                while (!CoinInputValidation(input))
                {
                    Console.WriteLine("Type value of a coin (5,10,25 (0 to accept))");
                    input = Console.ReadLine();
                }

                coin = int.Parse(input);

                if (coin == 0)
                    break;

                credit += vendingMachine.InsertCoin(CoinValue(coin)).Value;

                vendingMachine.DisplayCredit(credit);
            } while (coin != 0);

            return credit;
        }

        private static Product ChooseProduct(VendingMachine vendingMachine, int credit)
        {
            Product product = null;

            while (product == null)
            {
                Console.WriteLine("Cola : 1 ; Chips : 2 ; Candy : 3 ; back : 4");
                var input = Console.ReadLine();

                if (ProductInputValidation(input))
                    product = vendingMachine.DispenseProduct(credit, int.Parse(input));
                else
                    return null;
            }

            return product;
        }

    }
}
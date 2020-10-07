using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VendingMachineCore.Coins;
using VendingMachineCore.Inventory;
using VendingMachineCore.Products;

namespace VendingMachineCore
{
    public class VendingMachine
    {
        private CoinsInv _coinsInv;
        private ProductsInv _productsInv;
       
        public List<Coin> Change { get; private set; }

        public VendingMachine()
        {
            _coinsInv = new CoinsInv();
            _productsInv = new ProductsInv();
            Change = new List<Coin>();
        }

        public Coin InsertCoin(Coin coin)
        {
            if (coin == null)
                Console.WriteLine("No coin with this value");
            
            if (coin.Mass == 2.5)
            {
                CentError();
            }
            
            if (coin.Mass == 5)
            {
                _coinsInv.CoinCount[CoinsInv.Coins.Nickel] += 1;
                return new Nickel();
            }
            
            if (coin.Mass == 2.268)
            {
                _coinsInv.CoinCount[CoinsInv.Coins.Dime] += 1;
                return new Dime();
            }
            
            if (coin.Mass == 5.67)
            {
                _coinsInv.CoinCount[CoinsInv.Coins.Quarter] += 1;
                return new Quarter();
            }

            return null;
        }

        public Product DispenseProduct(int credit, int productNumber)
        {
            Product product;
            bool enoughFunds;
            switch (productNumber)
            {
                case 1:
                    enoughFunds = CreditVerification(credit, product = new Cola());
                    break;
                case 2:
                    enoughFunds = CreditVerification(credit, product = new Chips());
                    break;
                case 3:
                    enoughFunds = CreditVerification(credit, product = new Candy());
                    break;
                default:
                    return null;
            }

            return enoughFunds ? product : null;
        }

        public List<Coin> DispenseChange(int credit, Product product)
        {
            if (credit == product.Prize)
                return Change;
            
            if (credit - product.Prize >= 25)
            {

                    _coinsInv.CoinCount[CoinsInv.Coins.Quarter] -= 1;
                    Change.Add(new Quarter());
                    credit -= 25;

            }
            if (credit - product.Prize <= 10 && credit - product.Prize > 5)
            {
                _coinsInv.CoinCount[CoinsInv.Coins.Dime] -= 1;
                    Change.Add(new Dime());
                    credit -= 10;
            }
            if (credit - product.Prize <= 5)
            {
                _coinsInv.CoinCount[CoinsInv.Coins.Nickel] -= 1;
                    Change.Add(new Nickel());
                    credit -= 5;
            }

            DispenseChange(credit, product);

            return Change;
        }

        private bool CreditVerification(int credit, Product product)
        {
            return credit >= product.Prize;
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
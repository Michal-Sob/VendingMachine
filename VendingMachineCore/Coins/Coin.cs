namespace VendingMachineCore.Coins
{
    public abstract class Coin
    {
        public double Mass { get; protected set; }
        public int Value { get; protected set; }

        protected Coin()
        {

        }
    }
}
namespace BridgelabzCollection.DynamicOnlineMarketplace.Models
{
    public abstract class Product
    {
        public string Name { get; protected set; }
        public double Price { get; private set; }

        protected Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        // Controlled modification (Encapsulation)
        public void UpdatePrice(double newPrice)
        {
            Price = newPrice;
        }

        public abstract void Display();
    }
}

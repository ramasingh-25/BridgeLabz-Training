using System;

namespace BridgelabzCollection.DynamicOnlineMarketplace.Models
{
    public class Product<TCategory> : Product
        where TCategory : ICategory
    {
        public TCategory Category { get; private set; }

        public Product(string name, double price, TCategory category)
            : base(name, price)
        {
            Category = category;
        }

        public override void Display()
        {
            Console.WriteLine(
                $"Product: {Name}, Price: ₹{Price}, Category: {Category.CategoryName}");
        }
    }
}

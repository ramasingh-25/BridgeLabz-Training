using System;
using System.Collections.Generic;
using System.Text;

namespace BridgelabzCollection.SmartWareHouseSystem
{
    class Groceries : WareHouseSystem
    {
        public DateTime ExpiryDate { get; set; }

        public Groceries(string name, double price, DateTime expiry)
            : base(name, price)
        {
            ExpiryDate = expiry;
        }

        public override void Show()
        {
            Console.WriteLine($"Grocery: {Name}, Price: {Price}, Expiry: {ExpiryDate.ToShortDateString()}");
        }
    }
}

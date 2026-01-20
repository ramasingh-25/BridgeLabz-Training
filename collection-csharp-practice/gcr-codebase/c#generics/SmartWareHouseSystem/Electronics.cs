using System;
using System.Collections.Generic;
using System.Text;

namespace BridgelabzCollection.SmartWareHouseSystem
{
     class Electronics : WareHouseSystem
    {
        public int WarrantyYears { get; set; }

        public Electronics(string name, double price, int warranty)
            : base(name, price)
        {
            WarrantyYears = warranty;
        }

        public override void Show()
        {
            Console.WriteLine($"Electronics: {Name}, Price: {Price}, Warranty: {WarrantyYears} years");
        }
    }
}

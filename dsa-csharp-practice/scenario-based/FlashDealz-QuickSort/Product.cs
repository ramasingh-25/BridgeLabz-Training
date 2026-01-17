using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.FlashDealz_QuickSort
{
    public class Product
    {
        public string Name { get; set; }
        public int DiscountPercentage { get; set; }

        public Product(string name, int discount)
        {
            Name = name;
            DiscountPercentage = discount;
        }
    }
}
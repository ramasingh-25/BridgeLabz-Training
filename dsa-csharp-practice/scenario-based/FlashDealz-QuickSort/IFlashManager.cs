using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.FlashDealz_QuickSort
{
    internal interface IFlashManager
    {
        void AddProduct(string name, double discount);
        void SortProducts();
        void DisplayDeals();
    }
}

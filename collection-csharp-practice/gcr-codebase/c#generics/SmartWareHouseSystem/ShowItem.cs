using System;
using System.Collections.Generic;
using System.Text;

namespace BridgelabzCollection.SmartWareHouseSystem
{
    internal class ShowItem
    {
        public static void DisplayWarehouseItems(IReadOnlyList<WareHouseSystem> items)
        {
            foreach (var item in items)
            {
                item.Show();
            }
        }
    }
}

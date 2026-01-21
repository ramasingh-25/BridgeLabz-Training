//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.RealWorldSystemDesign.Shopping_Cart_System
//{
//    internal class ShoppingCart
//    {
//        Dictionary<string, double> cart = new Dictionary<string, double>();
//        List<string> order = new List<string>();

//        public void AddItem(string item, double price)
//        {
//            cart[item] = price;
//            order.Add(item);
//        }

//        public void ShowSortedByPrice()
//        {
//            SortedDictionary<double, string> sorted =
//                new SortedDictionary<double, string>();

//            foreach (var item in cart)
//                sorted[item.Value] = item.Key;

//            foreach (var s in sorted)
//                Console.WriteLine(s.Value + " : " + s.Key);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.ObjectModelling
//{
//    internal class EcommercePlatform
//    {

      
//            class Item
//            {
//                public string ItemTitle { get; set; }
//                public double ItemCost { get; set; }

//                public Item(string title, double cost)
//                {
//                    ItemTitle = title;
//                    ItemCost = cost;
//                }

//                public void PrintItemDetails()
//                {
//                    Console.WriteLine(ItemTitle + " costs ₹" + ItemCost);
//                }
//            }

//            // Purchase class
//            class Purchase
//            {
//                public int PurchaseNumber { get; set; }
//                private List<Item> itemList = new List<Item>();

//                public Purchase(int number)
//                {
//                    PurchaseNumber = number;
//                }

//                public void InsertItem(Item item)
//                {
//                    itemList.Add(item);
//                }

//                public void ShowPurchaseSummary()
//                {
//                    Console.WriteLine("Purchase No: " + PurchaseNumber);
//                    Console.WriteLine("Items bought:");

//                    double grandTotal = 0;

//                    foreach (Item item in itemList)
//                    {
//                        item.PrintItemDetails();
//                        grandTotal += item.ItemCost;
//                    }

//                    Console.WriteLine("Final Bill Amount: ₹" + grandTotal);
//                    Console.WriteLine();
//                }
//            }

//            // Buyer class
//            class Buyer
//            {
//                public string BuyerName { get; set; }

//                public Buyer(string name)
//                {
//                    BuyerName = name;
//                }

//                public void ConfirmPurchase(Purchase purchase)
//                {
//                    Console.WriteLine(BuyerName + " confirmed Purchase No " + purchase.PurchaseNumber);
//                    purchase.ShowPurchaseSummary();
//                }
//            }

//            // MAIN METHOD
//            public static void Main(string[] args)
//            {
//                Item item1 = new Item("Laptop", 85000);
//                Item item2 = new Item("Keyboard", 2500);
//                Item item3 = new Item("Mouse", 1200);

//                Buyer buyer = new Buyer("Ananya");

//                Purchase purchase1 = new Purchase(501);

//                purchase1.InsertItem(item1);
//                purchase1.InsertItem(item2);
//                purchase1.InsertItem(item3);

//                buyer.ConfirmPurchase(purchase1);
//            }
//        }
//    }
    


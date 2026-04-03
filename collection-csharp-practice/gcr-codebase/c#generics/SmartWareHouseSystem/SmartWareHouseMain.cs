using System;
using System.Collections.Generic;
using System.Text;

namespace BridgelabzCollection.SmartWareHouseSystem
{
    internal class SmartWareHouseMain
    {
        public static void Main()
        {
            GenricStorage<Electronics> electronicsStorage = new GenricStorage<Electronics>();
            electronicsStorage.AddItem(new Electronics("Mac", 80000, 1));
            electronicsStorage.AddItem(new Electronics("Mouse", 2000, 2));

            GenricStorage<Groceries> groceryStorage = new GenricStorage<Groceries>();
            groceryStorage.AddItem(new Groceries("Rice", 100, DateTime.Now.AddDays(4)));
            groceryStorage.AddItem(new Groceries("Milk", 500, DateTime.Now.AddDays(6)));


            GenricStorage<Furniture> furnitureStorage = new GenricStorage<Furniture>();
            furnitureStorage.AddItem(new Furniture("Table", 2000, "Wood"));
            furnitureStorage.AddItem(new Furniture("Chair", 2000, "Wood"));


            Console.WriteLine("--Electronics--");
            electronicsStorage.DisplayAllItems();
            Console.WriteLine();

            Console.WriteLine("--Groceries--");
            groceryStorage.DisplayAllItems();
            Console.WriteLine();

            Console.WriteLine("--Furniture--");
            furnitureStorage.DisplayAllItems();
            Console.WriteLine();

            Console.WriteLine("--Using Variance--");
            ShowItem.DisplayWarehouseItems(electronicsStorage.GetAllItems());
        }
    }
}

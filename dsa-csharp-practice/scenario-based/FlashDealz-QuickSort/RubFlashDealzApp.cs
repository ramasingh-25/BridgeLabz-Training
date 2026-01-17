using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.FlashDealz_QuickSort
{
    public class RunFlashDealzApp
    {
        public static void Main(string[] args)
        {
            IFlashManager manager = new FlashManagerImpl();
            bool running = true;

            Console.WriteLine("=== FLASH DEALZ MANAGER ===");

            while (running)
            {
                FlashUtility.ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string name = FlashUtility.GetString("Product Name");
                        double disc = FlashUtility.GetDouble("Discount %");
                        manager.AddProduct(name, disc);
                        break;
                    case "2":
                        manager.SortProducts();
                        break;
                    case "3":
                        manager.DisplayDeals();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
        }
    }
}

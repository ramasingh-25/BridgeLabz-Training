using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzDSA.Scenario_based.FlashDealz_QuickSort
{
    internal class FlashUtility
    {

        public static void ShowMenu()
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Sort by Discount (Quick Sort)");
            Console.WriteLine("3. Show Deals");
            Console.WriteLine("4. Exit");
            Console.Write("Select: ");
        }

        public static string GetString(string prompt)
        {
            Console.Write($"    {prompt}: ");
            return Console.ReadLine();
        }

        public static double GetDouble(string prompt)
        {
            Console.Write($"    {prompt}: ");
            return double.Parse(Console.ReadLine());
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based
//{
//    internal class BusRoute
//    {
       
//            public static void Main(string[] args)
//            {
//                int totalDist = 0;
//                string userChoice = "";

//                Console.WriteLine("Bus Journey Started");

//                while (userChoice != "yes")
//                {
//                    Console.Write("Enter distance to next stop (km): ");
//                    int dist = int.Parse(Console.ReadLine());

//                    totalDist += dist;
//                    Console.WriteLine("Total distance covered: " + totalDist + " km");

//                    Console.Write("Do you want to get off here? (yes/no): ");
//                    userChoice = Console.ReadLine();
//                }

//                Console.WriteLine("You arrived. Final distance: " + totalDist + " km");
//            }
//        }
//    }

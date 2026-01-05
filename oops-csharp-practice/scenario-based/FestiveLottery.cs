//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based
//{
//    internal class FestiveLottery
//    {
        
//            public static void Main(string[] args)
//            {
//                string UserChoice = "yes";

//                while (UserChoice == "yes")
//                {
//                    Console.Write("Enter your ticket number: ");
//                    int num = int.Parse(Console.ReadLine());

//                    if (num <= 0)
//                    {
//                        Console.WriteLine("Invalid ticket number.");
//                        continue;
//                    }

//                    if (num % 7 == 0 && num % 5 == 0)
//                    {
//                        Console.WriteLine("Congratulations! You win a gift.");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Better luck next time.");
//                    }

//                    Console.Write("Any more visitors? (yes/no): ");
//                    UserChoice = Console.ReadLine();
//                }
//            }

//        }
//    }

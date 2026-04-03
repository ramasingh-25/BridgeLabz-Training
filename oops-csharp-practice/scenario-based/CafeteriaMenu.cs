//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based
//{
//    internal class CafeteriaMenu
//    {
        
//            // Stores available food items
//            static string[] foodMenu =
//            {
//            "Chowmein",
//            "Cold Coffee",
//            "Lemon Juice",
//            "Chocolate Ice Cream",
//            "Patties",
//            "Garlic Bread",
//            "Chilli Paneer",
//            "Pasta",
//            "Pizza",
//            "Veg Fried Rice",
            
//        };

//            static void Main()
//            {
//                Console.WriteLine(" Campus Cafeteria Menu\n");

//                //list menu items
//                ShowFoodMenu();

//                Console.Write("\nEnter item number to order: ");
//                int userChoice = Convert.ToInt32(Console.ReadLine());

               
//                string orderedFood = FetchFoodItem(userChoice);

//                if (orderedFood != null)
//                {
//                    Console.WriteLine("\nOrder Confirmed: " + orderedFood);
//                }
//                else
//                {
//                    Console.WriteLine("\nInvalid item number. Please try again.");
//                }
//            }

            
//            static void ShowFoodMenu()
//            {
//                for (int position = 0; position < foodMenu.Length; position++)
//                {
//                    Console.WriteLine(position + " -> " + foodMenu[position]);
//                }
//            }

//            static string FetchFoodItem(int position)
//            {
//                if (position >= 0 && position < foodMenu.Length)
//                {
//                    return foodMenu[position];
//                }
//                return null;
//            }
//        }
//    }

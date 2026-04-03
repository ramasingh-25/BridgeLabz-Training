//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.FoodDeliverySystem
//{
//    internal class OnlineFoodDeliver
//    {
        
//            static void Main()
//            {
//                FoodItem item1 = new VegItem("Hakka Noodle", 100,2);
//                FoodItem item2 = new NonVegItem("Chicken Wings", 250, 1);

//                ViewBill(item1);
//                ViewBill(item2);
//            }

//            static void ViewBill(FoodItem food)
//            {
//                food.GetItemDetails();

//                double total = food.CalculatingTotalPrice();
//                Console.WriteLine("Total Price: " + total);

//                if (food is IDiscountable discount)
//                {
//                    Console.WriteLine(discount.GetDiscountDetails());
//                    Console.WriteLine("Discount Amount: " + discount.ApplyDiscount());
//                }

//                Console.WriteLine("====================================");
//            }
//        }

//    }

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.EcommercePlatformSystem
//{
//    public class ProductProcessor
//    {
//        public void DisplayFinalPrices(Product[] products)
//        {
//            for (int i = 0; i < products.Length; i++)
//            {
//                double tax = 0;

//                if (products[i] is ITaxable taxableProduct)
//                {
//                    tax = taxableProduct.CalculateTax();
//                }

//                double discount = products[i].CalculateDiscount();

//                double finalPrice = products[i].Price + tax - discount;

//                Console.WriteLine("Product name is : " + products[i].Name);
//                Console.WriteLine("Final Price of product : " + finalPrice);

//            }
//        }
//    }
//}

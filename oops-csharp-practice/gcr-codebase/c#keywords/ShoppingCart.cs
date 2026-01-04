//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Sealed
//{

//    class ShoppingCart
//    {
//        static void Main(string[] args)
//        {
//            Product product1 = new Product(101, "Computer", 500000, 3);
//            Product product2 = new Product(102, "KeyBoard", 700, 4);

//            product1.DisplayProductDetails(product1);
//            Console.WriteLine();

//            product2.DisplayProductDetails(product2);
//            Console.WriteLine();

//            Product.UpdateDiscount(15.0);
//            Console.WriteLine();

//            product1.DisplayProductDetails(product1);
//        }
//    }

//    public class Product
//        {
//            public static double Discount = 10.0; // percentage
//            public readonly int ProductID;
//            public string ProductName;
//            public double Price;
//            public int Quantity;

//            public Product(int ProductID, string ProductName, double Price, int Quantity)
//            {
//                this.ProductID = ProductID;
//                this.ProductName = ProductName;
//                this.Price = Price;
//                this.Quantity = Quantity;
//            }
//            public static void UpdateDiscount(double newDiscount)
//            {
//                Discount = newDiscount;
//                Console.WriteLine("Updated Discount: " + Discount + "%");
//            }
//            public void DisplayProductDetails(object product)
//            {
//                if (product is Product)
//                {
//                    Console.WriteLine("Product ID   : " + ProductID);
//                    Console.WriteLine("Product Name : " + ProductName);
//                    Console.WriteLine("Price        : " + Price);
//                    Console.WriteLine("Quantity     : " + Quantity);
//                    Console.WriteLine("Discount     : " + Discount + "%");
//                }
//                else
//                {
//                    Console.WriteLine("Invalid product object");
//                }
//            }
//        }

        
//    }

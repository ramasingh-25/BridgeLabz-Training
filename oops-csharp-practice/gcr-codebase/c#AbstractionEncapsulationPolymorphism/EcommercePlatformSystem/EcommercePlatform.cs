//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.EcommercePlatformSystem
//{
//    public class EcommercePlatform
//    {
//        public static void Main(string[] args)
//        {
//            Product[] products = new Product[3];

//            Electronics p1 = new Electronics();
//            p1.ProductId = 1;
//            p1.Name = "Lenovo";
//            p1.Price = 70000;

//            Clothing p2 = new Clothing();
//            p2.ProductId = 2;
//            p2.Name = "Shirt";
//            p2.Price = 3000;

//            Groceries p3 = new Groceries();
//            p3.ProductId = 3;
//            p3.Name = "Milk";
//            p3.Price = 60;

//            products[0] = p1;
//            products[1] = p2;
//            products[2] = p3;

//            ProductProcessor processor = new ProductProcessor();

//            processor.DisplayFinalPrices(products);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.InstanceVsClass
//{
//    class ProductInventory
//    {

        
//            static void Main(string[] args)
//            {
//                Product product1 = new Product("TV", 50000);
//                product1.ShowProductDetails();
//                Product product2 = new Product("Refridgerator", 160000);
//                product2.ShowProductDetails();
//                Product product3 = new Product("WashingMachine", 20000);
//                Product.ShowTotalProducts();
//            }

//        public class Product
//        {
//            private string productName;
//            private double price;
//            private static int totalProducts = 0;

//            public Product(string name, double amount)
//            {
//                this.productName = name;
//                this.price = amount;
//                totalProducts++;
//            }
//            public void ShowProductDetails()
//            {
//                Console.WriteLine("Product Name : " + productName);
//                Console.WriteLine("Price        : " + price);
//                Console.WriteLine();
//            }
//            public static void ShowTotalProducts()
//            {
//                Console.WriteLine("Total product details" + totalProducts);
//            }
//        }
//    }

//}
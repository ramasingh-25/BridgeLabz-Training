using System;
using System.Collections.Generic;


namespace BridgelabzCollection.DynamicOnlineMarketplace.Menu
{
    public class MarketplaceMenu
    {
        private readonly List<Product> products = new List<Product>();
        private bool running = true;

        public void Start()
        {
            while (running)
            {
                Console.WriteLine("\n===== ONLINE MARKETPLACE =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Apply Discount");
                Console.WriteLine("3. View All Products");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break;

                    case 2:
                        ApplyDiscount();
                        break;

                    case 3:
                        DisplayProducts();
                        break;

                    case 4:
                        running = false;
                        Console.WriteLine("Exiting Marketplace...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        private void AddProduct()
        {
            Console.WriteLine("\nSelect Category:");
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Clothing");
            Console.Write("Choice: ");

            int catChoice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            if (catChoice == 1)
            {
                BookCategory bookCategory = new BookCategory();
                Product<BookCategory> product =
                    new Product<BookCategory>(name, price, bookCategory);
                products.Add(product);
            }
            else if (catChoice == 2)
            {
                ClothingCategory clothingCategory = new ClothingCategory();
                Product<ClothingCategory> product =
                    new Product<ClothingCategory>(name, price, clothingCategory);
                products.Add(product);
            }
            else
            {
                Console.WriteLine("Invalid category!");
            }
        }

        private void ApplyDiscount()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            DisplayProducts();

            Console.Write("Select product number: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.Write("Enter discount percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            if (index >= 0 && index < products.Count)
            {
                DiscountUtility.ApplyDiscount(products[index], discount);
                Console.WriteLine("Discount applied successfully.");
            }
            else
            {
                Console.WriteLine("Invalid product selection.");
            }
        }

        private void DisplayProducts()
        {
            Console.WriteLine();
            Console.WriteLine("----- PRODUCT CATALOG -----");

            if (products.Count == 0)
            {
                Console.WriteLine("No products to display.");
                return;
            }

            int count = 1;
            foreach (var product in products)
            {
                Console.Write(count + ". ");
                product.Display();
                count++;
            }
        }
    }
}

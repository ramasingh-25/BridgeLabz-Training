//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.BookShelf
//{
//    internal class Menu
//    {
//        public static void ShowMenu()
//        {
//            IBookShelf shelf = new BookShelf();
//            while (true)
//            {
//                Console.WriteLine("PRESS 1: For Add Book");
//                Console.WriteLine("PRESS 2: For Remove Book");
//                Console.WriteLine("PRESS 3: For Display Library");
//                Console.WriteLine("PRESS 4 : For Exit");
//                int choice = int.Parse(Console.ReadLine());
//                if (choice == 1)
//                {
//                    Console.Write("Enter Genre: ");
//                    string genre = Console.ReadLine();

//                    Console.Write("Enter Book Name: ");
//                    string book = Console.ReadLine();

//                    shelf.AddBook(genre, book);
//                }
//                else if (choice == 2)
//                {
//                    Console.Write("Enter Genre: ");
//                    string genre = Console.ReadLine();

//                    Console.Write("Enter Book Name: ");
//                    string book = Console.ReadLine();

//                    shelf.RemoveBook(genre, book);
//                }
//                else if (choice == 3)
//                {
//                    shelf.Display();
//                }
//                else if (choice == 4)
//                {
//                    Console.WriteLine("Thank you For Visiting");
//                    return;
//                }
//                else
//                {
//                    Console.WriteLine("Invaid choice");
//                }
//            }
//        }
//    }
//}


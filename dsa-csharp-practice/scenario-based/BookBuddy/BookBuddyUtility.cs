//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.BookBuddy
//{
//    internal class BookBuddyUtility
//    {
//        public static void RunInterface()
//        {
//            // Initialize the Shelf and the Storage Implementation
//            Shelf myShelf = new Shelf();
//            IStorable bookManager = new StoringImplementation();
//            bool isRunning = true;

//            Console.WriteLine("Welcome to BookBuddy!");

//            while (isRunning)
//            {
//                Console.WriteLine("\n---------------------------------");
//                Console.WriteLine("1. Add a Book");
//                Console.WriteLine("2. Sort Books by Name");
//                Console.WriteLine("3. Search by Author");
//                Console.WriteLine("4. View All Books");
//                Console.WriteLine("5. Exit");
//                Console.Write("Select an option: ");

//                string userChoice = Console.ReadLine();

//                switch (userChoice)
//                {
//                    case "1":
//                        Console.WriteLine("\nEnter Book details in format 'Title-Author' (e.g., Hobbit-Tolkien):");
//                        string inputName = Console.ReadLine();

//                        // Basic validation to ensure format is correct for Search functionality
//                        if (!inputName.Contains("-"))
//                        {
//                            Console.WriteLine("Invalid format! You must include a '-' to separate Title and Author.");
//                        }
//                        else
//                        {
//                            Book newBook = new Book(inputName);
//                            bookManager.AddBook(newBook, myShelf);
//                            Console.WriteLine("Book added successfully.");
//                        }
//                        break;

//                    case "2":
//                        Console.WriteLine("\nSorting books...");
//                        try
//                        {
//                            bookManager.SortBooks(myShelf);
//                            Console.WriteLine("Books sorted alphabetically!");
//                            PrintShelf(myShelf);
//                        }
//                        catch (NullReferenceException)
//                        {
//                            Console.WriteLine("Error: The shelf contains empty slots. The current Sort implementation cannot handle nulls.");
//                        }
//                        break;

//                    case "3":
//                        Console.Write("\nEnter Author Name to search: ");
//                        string authorName = Console.ReadLine();
//                        try
//                        {
//                            string result = bookManager.SearchByAuthor(authorName, myShelf);
//                            Console.WriteLine(result);
//                        }
//                        catch (NullReferenceException)
//                        {
//                            Console.WriteLine("Error: Hit a null slot while searching. Please check StoringImpl logic.");
//                        }
//                        break;

//                    case "4":
//                        PrintShelf(myShelf);
//                        break;

//                    case "5":
//                        isRunning = false;
//                        Console.WriteLine("Exiting application.");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid option. Please try again.");
//                        break;
//                }
//            }
//        }

       
//        private static void PrintShelf(Shelf shelf)      // Helper method to display books excluding empty slots
//        {
//            Console.WriteLine("\n--- Current Shelf ---");
//            bool isEmpty = true;
//            for (int i = 0; i < shelf.storage.Length; i++)
//            {
//                if (shelf.storage[i] != null)
//                {
//                    Console.WriteLine($"Slot {i}: {shelf.storage[i].name}");
//                    isEmpty = false;
//                }
//            }
//            if (isEmpty) Console.WriteLine("Shelf is empty.");
//        }
//    }
//}

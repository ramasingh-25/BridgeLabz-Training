//using System;

//namespace Oops.Scenario_Based
//{
//    class DigitalLibraryApp
//    {
//        // Entry point for role selection
//        public static void LaunchSystem(string[,] libraryData)
//        {
//            while (true)
//            {
//                Console.WriteLine("\nCHOOSE USER MODE");
//                Console.WriteLine("1 -> Admin");
//                Console.WriteLine("2 -> Visitor");
//                Console.WriteLine("3 -> Close Application");

//                int userMode = int.Parse(Console.ReadLine());

//                switch (userMode)
//                {
//                    case 1:
//                        AdminSection(libraryData);
//                        break;

//                    case 2:
//                        VisitorSection(libraryData);
//                        break;

//                    case 3:
//                        return;

//                    default:
//                        Console.WriteLine("INVALID INPUT");
//                        break;
//                }
//            }
//        }

//        // Visitor operations
//        public static void VisitorSection(string[,] libraryData)
//        {
//            while (true)
//            {
//                Console.WriteLine("\n1 -> Display Books");
//                Console.WriteLine("2 -> Search Book");
//                Console.WriteLine("3 -> Back");

//                int option = int.Parse(Console.ReadLine());

//                switch (option)
//                {
//                    case 1:
//                        DisplayBooks(libraryData);
//                        break;

//                    case 2:
//                        SearchBookByTitle(libraryData);
//                        break;

//                    case 3:
//                        return;

//                    default:
//                        Console.WriteLine("WRONG CHOICE");
//                        break;
//                }
//            }
//        }

//        // Admin operations
//        public static void AdminSection(string[,] libraryData)
//        {
//            Console.WriteLine("ENTER ADMIN PIN");
//            int pin = int.Parse(Console.ReadLine());

//            if (pin != 5678)
//            {
//                Console.WriteLine("AUTHORIZATION FAILED");
//                return;
//            }

//            while (true)
//            {
//                Console.WriteLine("\n1 -> View Collection");
//                Console.WriteLine("2 -> Edit Book Details");
//                Console.WriteLine("3 -> Change Book Status");
//                Console.WriteLine("4 -> Back");

//                int adminOption = int.Parse(Console.ReadLine());

//                switch (adminOption)
//                {
//                    case 1:
//                        DisplayBooks(libraryData);
//                        break;

//                    case 2:
//                        UpdateBookDetails(libraryData);
//                        break;

//                    case 3:
//                        ModifyAvailability(libraryData);
//                        break;

//                    case 4:
//                        return;

//                    default:
//                        Console.WriteLine("INVALID OPTION");
//                        break;
//                }
//            }
//        }

//        // Show all books
//        static void DisplayBooks(string[,] libraryData)
//        {
//            Console.WriteLine("\n----- BOOK INVENTORY -----");

//            for (int i = 0; i < libraryData.GetLength(0); i++)
//            {
//                Console.WriteLine(
//                    (i + 1) + ". " +
//                    libraryData[i, 0] + " | " +
//                    libraryData[i, 1] + " | " +
//                    libraryData[i, 2]
//                );
//            }
//        }

//        // Edit book title and writer
//        static void UpdateBookDetails(string[,] libraryData)
//        {
//            DisplayBooks(libraryData);

//            Console.WriteLine("ENTER BOOK NUMBER TO UPDATE");
//            int bookIndex = int.Parse(Console.ReadLine()) - 1;

//            if (bookIndex < 0 || bookIndex >= libraryData.GetLength(0))
//            {
//                Console.WriteLine("BOOK DOES NOT EXIST");
//                return;
//            }

//            Console.WriteLine("NEW BOOK TITLE:");
//            libraryData[bookIndex, 0] = Console.ReadLine();

//            Console.WriteLine("NEW AUTHOR NAME:");
//            libraryData[bookIndex, 1] = Console.ReadLine();

//            Console.WriteLine("BOOK DETAILS UPDATED");
//        }

//        // Change availability
//        static void ModifyAvailability(string[,] libraryData)
//        {
//            DisplayBooks(libraryData);

//            Console.WriteLine("SELECT BOOK NUMBER TO CHANGE STATUS");
//            int bookIndex = int.Parse(Console.ReadLine()) - 1;

//            if (bookIndex < 0 || bookIndex >= libraryData.GetLength(0))
//            {
//                Console.WriteLine("INVALID SELECTION");
//                return;
//            }

//            Console.WriteLine("ENTER STATUS (Available / Borrowed)");
//            libraryData[bookIndex, 2] = Console.ReadLine();

//            Console.WriteLine("STATUS CHANGED SUCCESSFULLY");
//        }

//        // Search by title
//        static void SearchBookByTitle(string[,] libraryData)
//        {
//            Console.WriteLine("ENTER BOOK TITLE");
//            string keyword = Console.ReadLine();

//            for (int i = 0; i < libraryData.GetLength(0); i++)
//            {
//                if (libraryData[i, 0].Equals(keyword, StringComparison.OrdinalIgnoreCase))
//                {
//                    Console.WriteLine(
//                        "BOOK FOUND -> " +
//                        libraryData[i, 0] + " | " +
//                        libraryData[i, 1] + " | " +
//                        libraryData[i, 2]
//                    );
//                    return;
//                }
//            }

//            Console.WriteLine("BOOK NOT FOUND");
//        }

//        static void Main(string[] args)
//        {
//            string[,] libraryData =
//            {
//                { "The Monk Who Sold His Ferrari", "Robin Sharma", "Available" },
//                { "Code Complete", "Steve McConnell", "Available" },
//                { "Deep Work", "Cal Newport", "Borrowed" },
//                { "The Psychology of Money", "Morgan Housel", "Available" },
//                { "Zero to One", "Peter Thiel", "Available" }
//            };

//            LaunchSystem(libraryData);
//        }
//    }
//}

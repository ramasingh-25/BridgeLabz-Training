//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.LibraryManagement
//{
//     class LibraryManagementSystem
//    {
//        static void Main()
//        {
//            Console.WriteLine("=== LIBRARY MANAGEMENT SYSTEM ===");
//            Console.WriteLine();

//            // create different library items
//            List<LibraryItem> items = new List<LibraryItem>();
//            items.Add(new Book(1, "Java", "Steve Jobs", 400));
//            items.Add(new Magazine(2, "TechZine", "Editor", "March 2025"));
//            items.Add(new DVD(3, "Practicing OOPs", "Director", 350));

//            Console.WriteLine("--- LIBRARY ITEMS ---");
//            foreach (LibraryItem item in items)
//            {
//                item.GetItemDetails();

//                if (item is IReservable)
//                {
//                    IReservable reservable = (IReservable)item;
//                    bool available = reservable.CheckAvailability();
//                    Console.WriteLine("Available: " + available);

//                    if (available)
//                    {
//                        reservable.ReserveItem("Person1");
//                    }
//                }
//                Console.WriteLine("====================");
//            }

//            Console.ReadKey();
//        }
//    }
//}


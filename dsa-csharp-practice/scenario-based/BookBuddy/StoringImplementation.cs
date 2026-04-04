//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.BookBuddy
//{
//    public class StoringImplementation   : IStorable
//    {
//        public void AddBook(Book book, Shelf shelf)
//        {
//            for (int i = 0; i < shelf.storage.Length; i++)
//            {
//                if (shelf.storage[i] == null)
//                {
//                    shelf.storage[i] = book;
//                    break;
//                }
//                if (i == 99)
//                {
//                    Console.WriteLine("Shelf is full!");
//                }
//            }
//        }

//        public string SearchByAuthor(string authSearch, Shelf shelf)
//        {
//            for (int i = 0; i < shelf.storage.Length; i++)
//            {
//                if (shelf.storage[i].name.Split('-')[1] == authSearch)
//                {
//                    return shelf.storage[i].name + " is found at " + i + " place";
//                }
//            }
//            return "Book not found!";
//        }

//        public void SortBooks(Shelf shelf)
//        {
//            int n = shelf.storage.Length;

//            for (int i = 0; i < n; i++)
//            {
//                for (int j = 0; j < n - i - 1; j++)
//                {
//                    if (shelf.storage[j] != null && shelf.storage[j + 1] != null)
//                    {
//                        if (shelf.storage[j].name.CompareTo(shelf.storage[j + 1].name) > 0)
//                        {
//                            Book temp = shelf.storage[j];
//                            shelf.storage[j] = shelf.storage[j + 1];
//                            shelf.storage[j + 1] = temp;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.BookShelf
//{
//    internal class BookShelf : IBookShelf
//    {
//        private string[] genres;
//        private BookLinkedList[] bookLists;
//        private int count;
//        public BookShelf()
//        {
//            genres = new string[10];
//            bookLists = new BookLinkedList[10];
//            count = 0;
//        }
//        public void AddBook(string genre, string book)
//        {
//            int index = FindGenreIndex(genre);

//            if (index == -1)
//            {
//                genres[count] = genre;
//                bookLists[count] = new BookLinkedList();
//                bookLists[count].Add(book);
//                count++;
//            }
//            else
//            {
//                bookLists[index].Add(book);
//            }
//            Console.WriteLine("Book added successfully.");
//        }
//        public void RemoveBook(string genre, string book)
//        {
//            int index = FindGenreIndex(genre);

//            if (index == -1)
//            {
//                Console.WriteLine("Genre not found.");
//                return;
//            }

//            bookLists[index].Remove(book);
//            Console.WriteLine("Book removed.");
//        }
//        public void Display()
//        {
//            for (int i = 0; i < count; i++)
//            {
//                Console.WriteLine("Genre " + genres[i]);
//                bookLists[i].Display();
//            }
//        }
//        private int FindGenreIndex(string genre)
//        {
//            for (int i = 0; i < count; i++)
//            {
//                if (genres[i] == genre)
//                    return i;
//            }
//            return -1;
//        }
//    }
//}


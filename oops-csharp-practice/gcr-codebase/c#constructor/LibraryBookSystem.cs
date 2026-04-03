//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Constructor
//{
//    internal class LibraryBookSystem
//    {

//        public string title;
//        public string author;
//        public double price;
//        public bool IsBookAvailable;

//        public LibraryBookSystem(string Title, string Author, double Price)   //param constructor
//        {
//            this.title = Title;
//            this.author = Author;
//            this.price = Price;
//            this.IsBookAvailable = true;
//        }


       
//        public void BorrowingBook()    //borrowing book
//        {
//            if (IsBookAvailable)
//            {
//                IsBookAvailable = false;
//                Console.WriteLine("You have successfully borrowed the book: " + title);
//            }
//            else
//            {
//                Console.WriteLine("Sorry, this book is not available ,kindly check other");
//            }
//        }

//        public static void Main(string[] args) //main method
//        {
//            LibraryBookSystem book1 = new LibraryBookSystem("The Alchemist", "Paulo Coelho", 399);

//            book1.BorrowingBook();

//            book1.BorrowingBook();


//        }
//    }
//}

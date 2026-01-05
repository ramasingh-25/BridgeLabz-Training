//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.ObjectModelling
//{
//     class Aggregation
//    {

//        public static void Main(String[] args)
//        {

//            Book b1 = new Book("Chemistry", "Rama");
//            Book b2 = new Book("Physics", "Chitra");


//            Library l1 = new Library("National Library");
//            Library l2 = new Library("State Library");


//            l1.AddBook(b1);
//            l1.AddBook(b2);

//            l2.AddBook(b2);


//            l1.ShowBooks();
//            l2.ShowBooks();
//        }
//        class Book
//    {
//        public string Title;
//        public string Author;

       
//        public Book(string enterTitle, string enterAuthor)   //parameterized
//        {
//            this.Title = enterTitle;
//            this.Author = enterAuthor;
//        }
//    }

//    // Library class 
//    class Library
//    {
//        public string LibraryName;
//        public List<Book> Books;

//        //constructor
//        public Library(string libraryName)
//        {
//            this.LibraryName = libraryName;
//            this.Books = new List<Book>();
//        }

//        public void AddBook(Book book)
//        {
//            Books.Add(book);
//        }

//        public void ShowBooks()
//        {
//            Console.WriteLine("Library: " + LibraryName);

//            foreach (Book book in Books)
//            {
//                Console.WriteLine(book.Title + " by " + book.Author);
//            }

//            Console.WriteLine();
//        }
//    }

    
        
//    }

//}

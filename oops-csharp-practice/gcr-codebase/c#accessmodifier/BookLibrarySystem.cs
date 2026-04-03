//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.AccessModifier
//{
//     class BookLibrarySystem
//    {
//        //main method
//        static void Main(string[] args)
//        {

//            EBook eBook1 = new EBook("The Discovery Of India", "J.L Nehru", "123-67895");

//            eBook1.DisplayDetails();

//            Console.WriteLine("ISBN from Main : " + eBook1.iSBN);
//        }
//    }
//    public class Book
//    {
//        public string iSBN;
//        protected string Title;
//        private string author;

//        public Book(string title, string author, string iSBN)
//        {
//            this.Title = title;
//            this.author = author;
//            this.iSBN = iSBN;
//        }
//        public string ShowAuthor()
//        {
//            return author;
//        }
//        public void SetAuthor(string authorName)
//        {
//            author = authorName;
//        }

//    }
//    public class EBook : Book
//    {
//        public EBook(string title, string author, string iSBN) : base(title, author, iSBN) { }

//        public void DisplayDetails()
//        {
//            Console.WriteLine("Displaying the details");
//            Console.WriteLine("ISBN : " + iSBN);
//            Console.WriteLine("Title : " + Title);
//            Console.WriteLine("Author : " + ShowAuthor());
//        }
//    }
//}

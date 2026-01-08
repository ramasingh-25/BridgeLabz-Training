//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.LibraryManagement
//{
//    abstract class LibraryItem
//    {
//        private int itemId;
//        private string title;
//        private string author;
//        private string borrowerData;

//        public int ItemId { get { return itemId; } set { itemId = value; } }
//        public string Title { get { return title; } set { title = value; } }
//        public string Author { get { return author; } set { author = value; } }
//        protected string BorrowerData { get { return borrowerData; } set { borrowerData = value; } }

//        public LibraryItem(int id, string itemTitle, string itemAuthor)
//        {
//            itemId = id;
//            title = itemTitle;
//            author = itemAuthor;
//            borrowerData = "";
//        }

//        // must be implemented by child classes
//        public abstract int GetLoanDuration();

//        public void GetItemDetails()
//        {
//            Console.WriteLine("ID: " + itemId + " | " + title + " by " + author);
//            Console.WriteLine("Loan Duration: " + GetLoanDuration() + " days");
//        }
//    }
//}
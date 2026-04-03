//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.LibraryManagement
//{
//    class Book : LibraryItem, IReservable
//    {
//        private int pages;
//        private bool isAvailable;

//        public int Pages { get { return pages; } set { pages = value; } }

//        public Book(int id, string title, string author, int pageCount) : base(id, title, author)
//        {
//            pages = pageCount;
//            isAvailable = true;
//        }

//        public override int GetLoanDuration()
//        {
//            return 21; 
//        }

//        public void ReserveItem(string borrowerName)
//        {
//            if (isAvailable)
//            {
//                isAvailable = false;
//                BorrowerData = borrowerName;
//                Console.WriteLine("Book reserved for " + borrowerName);
//            }
//            else
//            {
//                Console.WriteLine("Book already reserved");
//            }
//        }

//        public bool CheckAvailability()
//        {
//            return isAvailable;
//        }
//    }
//}
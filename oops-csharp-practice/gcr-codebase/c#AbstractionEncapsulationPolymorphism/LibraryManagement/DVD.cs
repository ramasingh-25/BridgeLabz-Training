//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.LibraryManagement
//{
    
//        class DVD : LibraryItem, IReservable
//        {
//            private int duration;
//            private bool isAvailable;

//            public int Duration { get { return duration; } set { duration = value; } }

//            public DVD(int id, string title, string director, int minutes) : base(id, title, director)
//            {
//                duration = minutes;
//                isAvailable = true;
//            }

//            public override int GetLoanDuration()
//            {
//                return 3; // 3 days for DVDs
//            }

//            public void ReserveItem(string borrowerName)
//            {
//                if (isAvailable)
//                {
//                    isAvailable = false;
//                    BorrowerData = borrowerName;
//                    Console.WriteLine("DVD reserved for " + borrowerName);
//                }
//                else
//                {
//                    Console.WriteLine("DVD already reserved");
//                }
//            }

//            public bool CheckAvailability()
//            {
//                return isAvailable;
//            }
//        }
//    }


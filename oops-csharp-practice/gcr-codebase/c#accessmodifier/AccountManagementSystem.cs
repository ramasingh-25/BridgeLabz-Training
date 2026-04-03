//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.AccessModifier
//{
//    class AccountManagementSystem
//    {
//        public int accountNumber;        // public
//        protected string accountHolder;  // protected
//        private double balance;          // private

//        // Set balance
//        public void SetBalance(double b)
//        {
//            balance = b;
//        }

//        // Get balance
//        public double GetBalance()
//        {
//            return balance;

//        }
//    }
//    class SavingsAccount : AccountManagementSystem
//    {
//        public void ShowDetails()
//        {
//            accountNumber = 124567891;         
//            accountHolder = "Rama";  

//            Console.WriteLine(accountNumber);
//            Console.WriteLine(accountHolder);
//        }
       
//            static void Main()
//            {
//                SavingsAccount s = new SavingsAccount();

//                s.ShowDetails();
//                s.SetBalance(5000);

//                Console.WriteLine("Balance: " + s.GetBalance());
//            }
//        }

//    }




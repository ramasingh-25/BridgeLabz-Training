//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.BankAccountSystem
//{
//    public abstract class BankingAccount
//    {
//        private long accountNumber;
//        private string holderName;
//        protected double balance { get; set; }

//        protected BankingAccount(long accountNumber, string holderName, double balance)
//        {
//            this.accountNumber = accountNumber;
//            this.holderName = holderName;
//            this.balance = balance;
//        }

//        public void Deposit(double amount)
//        {
//            if (amount > 0)
//            {
//                balance += amount;
//                Console.WriteLine("Amount deposited successfully");
//            }
//            else { Console.WriteLine("Invalid amount"); }

//        }
//        public void Withdraw(double amount)
//        {
//            if (amount > 0 && amount <= balance)
//            {
//                balance -= amount;
//                Console.WriteLine("Amount withdrawn successfully");
//            }
//            else
//            {
//                Console.WriteLine("Enter valid amount");
//            }
//        }
//        public double GetBalance()
//        {
//            return balance;
//        }

//        public abstract double CalculateInterest();
//    }
//}

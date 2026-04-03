//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops
//{
//    internal class BankAccSystem
//    {

//        public static string bankName = "Secure Bank";
//        private static int totalAccounts = 0;
//        public readonly long AccountNumber;
//        public string AccountHolderName;

//        public BankAccSystem(string AccountHolderName, long AccountNumber)
//        {
//            this.AccountHolderName = AccountHolderName;
//            this.AccountNumber = AccountNumber;
//            totalAccounts++;
//        }
//        public static int GetTotalAccounts()
//        {
//            return totalAccounts;
//        }
//        public void DisplayAccountDetails(object account)
//        {
//            if (account is BankAccSystem)
//            {
//                Console.WriteLine("Bank Name        : " + bankName);
//                Console.WriteLine("Account Holder   : " + AccountHolderName);
//                Console.WriteLine("Account Number   : " + AccountNumber);
//            }
//            else
//            {
//                Console.WriteLine("Invalid account object");
//            }
//        }
//    }

//    class BankAccountSystem
//    {
//        static void Main(string[] args)
//        {
//            BankAccSystem account1 = new BankAccSystem("Chitra", 1221);
//            BankAccSystem account2 = new BankAccSystem("Aman", 1111);

//            account1.DisplayAccountDetails(account1);
//            Console.WriteLine();

//            account2.DisplayAccountDetails(account2);
//            Console.WriteLine();

//            Console.WriteLine("Total Accounts: " + BankAccSystem.GetTotalAccounts());

//        }
//    }
//}

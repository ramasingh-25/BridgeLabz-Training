//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.OopsAssignment.BankAccountSystem
//{
//    public class BankingSystem
//    {
//        static void Main(string[] args)
//        {
//            BankingAccount[] accounts = new BankingAccount[1];

//            for (int i = 0; i < accounts.Length; i++)
//            {
//                Console.WriteLine("Enter account number : ");
//                long accountNumber = Convert.ToInt64(Console.ReadLine());
//                Console.WriteLine("Enter Name ");
//                string name = Console.ReadLine();
//                Console.WriteLine("Enter balance : ");
//                double balance = Convert.ToDouble(Console.ReadLine());
//                accounts[i] = new SavingsAccount(accountNumber, name, balance);
//            }



//            foreach (BankingAccount account in accounts)
//            {
//                Console.WriteLine("Balance: " + account.GetBalance());
//                Console.WriteLine("Interest: " + account.CalculateInterest());

//                if (account is ILoanable loanAccount)
//                {
//                    loanAccount.ApplyForLoan();
//                    Console.WriteLine("Loan Eligible: " +
//                        loanAccount.CalculateLoanEligibility(110000));
//                }
//            }
//        }
//    }
//}

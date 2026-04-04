//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.LoanApprovalAutomation
//{
//    class Menu
//    {
//        public void Start()
//        {
//            while (true)
//            {

//                Console.Write("Enter applicant name: ");
//                string name = Console.ReadLine();
//                Console.Write("Enter credit score: ");
//                int score = int.Parse(Console.ReadLine());
//                Console.Write("Enter monthly income: ");
//                double income = double.Parse(Console.ReadLine());
//                Console.Write("Enter loan amount: ");
//                double amount = double.Parse(Console.ReadLine());
//                Console.Write("Enter loan duration (months): ");
//                int months = int.Parse(Console.ReadLine());
//                Applicant user = new Applicant(name, score, income, amount);
//                Console.WriteLine();
//                Console.WriteLine("PRESS 1: Personal Loan");
//                Console.WriteLine("PRESS 2: Home Loan");
//                Console.WriteLine("PRESS 3: Auto Loan");

//                int choice = int.Parse(Console.ReadLine());
//                LoanApplication loan;
//                if (choice == 1) loan = new PersonalLoan(user, months);
//                else if (choice == 2) loan = new HomeLoan(user, months);
//                else if (choice == 3) loan = new AutoLoan(user, months);
//                else return; ;
//                Console.WriteLine();
//                if (loan.ApproveLoan())
//                {
//                    Console.WriteLine("Loan Approved");
//                    Console.WriteLine("Monthly EMI: " +
//                    Math.Round(loan.CalculateEMI(), 2));
//                }
//                else
//                {
//                    Console.WriteLine("Loan Rejected");
//                }
//                Console.WriteLine("PRESS 1 :FOR CONTINUE");
//                Console.WriteLine("PRESS 2 : FOR EXIT");
//                int ch = int.Parse(Console.ReadLine());
//                if (ch == 2) return;
//            }
//        }
//    }
//}

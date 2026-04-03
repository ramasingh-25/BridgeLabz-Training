//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.ScenarioBased
//{
//    class BankAccountManager
//    {


//        // --------- Static data for single customer ---------
//        static long accId;
//        static string holder;
//        static double totalAmt;
//        static int secretCode;
//        static bool isAccountReady = false;
//        static bool isPinReady = false;

//        // Role selection screen
//        static void StartPortal()
//        {
//            while (true)
//            {
//                Console.WriteLine();
//                Console.WriteLine("=== DIGITAL BANK PORTAL ===");

//                Console.WriteLine("SELECT ACCESS TYPE:");
//                Console.WriteLine("ENTER 1 : CUSTOMER LOGIN");
//                Console.WriteLine("ENTER 2 : ADMIN LOGIN");
//                Console.WriteLine("ENTER 3 : CLOSE APPLICATION");

//                int option = int.Parse(Console.ReadLine());

//                switch (option)
//                {
//                    case 1:
//                        CustomerPanel();
//                        break;
//                    case 2:
//                        AdminAccess();
//                        break;
//                    case 3:
//                        Console.WriteLine("SESSION CLOSED SUCCESSFULLY");
//                        break;
//                }
//            }
//        }

//        // ---------------- ADMIN SECTION ----------------
//        static void AdminAccess()
//        {
//            int adminKey = 4004;
//            Console.WriteLine("ENTER ADMIN SECURITY CODE");
//            int enteredKey = int.Parse(Console.ReadLine());

//            if (enteredKey != adminKey)
//            {
//                Console.WriteLine("ACCESS DENIED");
//                return;
//            }

//            while (true)
//            {
//                Console.WriteLine();
//                Console.WriteLine("=== ADMIN DASHBOARD ===");
//                Console.WriteLine("1 : OPEN NEW ACCOUNT");
//                Console.WriteLine("2 : SHOW ACCOUNT INFO");
//                Console.WriteLine("3 : REMOVE ACCOUNT");
//                Console.WriteLine("4 : RETURN TO MAIN MENU");

//                int select = int.Parse(Console.ReadLine());

//                switch (select)
//                {
//                    case 1:
//                        OpenNewAccount();
//                        break;
//                    case 2:
//                        DisplayAccount();
//                        break;
//                    case 3:
//                        CloseAccount();
//                        break;
//                    case 4:
//                        return;
//                }
//            }
//        }

//        // Create account
//        static void OpenNewAccount()
//        {
//            Random rnd = new Random();
//            accId = rnd.NextInt64(1000000000L, 10000000000L);

//            Console.WriteLine("GENERATED ACCOUNT ID : " + accId);
//            Console.WriteLine("ENTER CUSTOMER NAME");
//            holder = Console.ReadLine();

//            Console.WriteLine("ENTER STARTING AMOUNT");
//            totalAmt = double.Parse(Console.ReadLine());

//            isAccountReady = true;
//            Console.WriteLine("ACCOUNT SUCCESSFULLY OPENED");
//        }

//        // Show account info
//        static void DisplayAccount()
//        {
//            if (!isAccountReady)
//            {
//                Console.WriteLine("NO RECORD FOUND. CREATE ACCOUNT FIRST.");
//                return;
//            }

//            Console.WriteLine("ACCOUNT ID      : " + accId);
//            Console.WriteLine("CUSTOMER NAME  : " + holder);
//            Console.WriteLine("CURRENT FUNDS  : " + totalAmt);
//        }

//        // Delete account
//        static void CloseAccount()
//        {
//            if (!isAccountReady)
//            {
//                Console.WriteLine("NO ACTIVE ACCOUNT AVAILABLE");
//                return;
//            }

//            accId = 0;
//            holder = null;
//            totalAmt = 0;
//            secretCode = 0;
//            isAccountReady = false;
//            isPinReady = false;

//            Console.WriteLine("ACCOUNT HAS BEEN TERMINATED");
//        }

//        // ---------------- CUSTOMER SECTION ----------------
//        static void CustomerPanel()
//        {
//            if (!isAccountReady)
//            {
//                Console.WriteLine("ACCOUNT DOES NOT EXIST");
//                return;
//            }

//            if (!isPnReady)
//            {
//                Console.WriteLine("SECURITY PIN NOT SET. PLEASE SET PIN FIRST");
//                SetupPin();
//                return;
//            }

//            Console.WriteLine("CUSTOMER ACCESS GRANTED");

//            while (true)
//            {
//                Console.WriteLine();
//                Console.WriteLine("1 : ADD MONEY");
//                Console.WriteLine("2 : REMOVE MONEY");
//                Console.WriteLine("3 : VIEW BALANCE");
//                Console.WriteLine("4 : EXIT TO MAIN MENU");

//                int choice = int.Parse(Console.ReadLine());

//                Console.WriteLine("ENTER YOUR SECURITY PIN");
//                int verifyPin = int.Parse(Console.ReadLine());

//                if (verifyPin != secretCode)
//                {
//                    Console.WriteLine("INVALID PIN ENTERED");
//                    return;
//                }

//                if (choice == 1) AddFunds();
//                else if (choice == 2) RemoveFunds();
//                else if (choice == 3) ShowBalance();
//                else if (choice == 4) return;
//                else Console.WriteLine("OPTION NOT RECOGNIZED");
//            }
//        }

//        // Create PIN
//        static void SetuPin()
//        {
//            Console.WriteLine("SET A 4 DIGIT SECURITY PIN");
//            secretCode = int.Parse(Console.ReadLine());
//            isPinReady = true;
//            Console.WriteLine("PIN SET SUCCESSFULLY");
//        }

//        // Deposit
//        static void AddFunds()
//        {
//            Console.WriteLine("ENTER AMOUNT TO ADD");
//            double cash = double.Parse(Console.ReadLine());

//            if (cash < 0)
//                Console.WriteLine("AMOUNT NOT ACCEPTABLE");
//            else
//                totalAmt += cash;
//        }

//        // Withdraw
//        static void RemoveFunds()
//        {
//            Console.WriteLine("ENTER AMOUNT TO WITHDRAW");
//            double cash = double.Parse(Console.ReadLine());

//            if (cash < 0)
//            {
//                Console.WriteLine("INVALID VALUE");
//            }
//            else if (cash > totalAmt)
//            {
//                Console.WriteLine("BALANCE TOO LOW");
//            }
//            else
//            {
//                totalAmt -= cash;
//                Console.WriteLine("PLEASE COLLECT YOUR CASH");
//            }
//        }

//        // Balance check
//        static void ShowBalance()
//        {
//            Console.WriteLine("AVAILABLE BALANCE : " + totalAmt);
//        }

//        static void Main(string[] args)
//        {
//            StartPortal();
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.ATM_Dispenser_Logic
//{
//    class Menu
//    {
//        public void ShowMenu()
//    {
//        while (true)
//        {


//            Console.WriteLine("Enter amount u want to get cash");
//            int amount = int.Parse(Console.ReadLine());
//            Console.WriteLine("---- ATM MENU ----");
//            Console.WriteLine("PRESS 1: Normal ATM");
//            Console.WriteLine("PRESS 2: ATM without ₹500");
//            Console.WriteLine("PRESS 3: Fallback ATM");
//            Console.Write("PRESS 4: EXIT ");

//            int choice = Convert.ToInt32(Console.ReadLine());
//            if (choice == 4) return;
//            if (choice > 4 || choice < 1)
//            {
//                Console.WriteLine("Invalid Operation");
//                continue;
//            }


//            ATM atm = choice == 1 ? new NormalATM() : choice == 2 ? new No500ATM() : choice == 3 ? new FallbackATM() : null;
//            if (atm != null) atm.Dispense(amount);
//            else
//                Console.WriteLine("Invalid choice");
//        }
//    }
//}
//}

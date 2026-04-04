//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Scenario_based.ATM_Dispenser_Logic
//{
 
    
//        abstract class ATM : IDispenser
//        {
//            protected int[] notes;
//            public ATM(int[] notes)
//            {
//                this.notes = notes;
//            }


//            public void Dispense(int amount)
//            {
//                int remaining = amount;

//                foreach (int note in notes)
//                {
//                    int count = remaining / note;


//                    if (count > 0)
//                    {
//                        Console.WriteLine("₹" + note + " x " + count);
//                        remaining %= note;


//                    }
//                }
//                if (remaining > 0)
//                {


//                    Console.WriteLine("Remaining amount not dispensed: ₹" + remaining);


//                }
//            }
//        }
//    }

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based.CallLogTracking
//{
//    internal class CallLogTracking
//    {
//            static void Main()
//            {
//                CustomerCallLogManager manager = new CustomerCallLogManager(5);

//                manager.AddCallLog(new CustomerCallLog("9789005661", "Out of Covrage", DateTime.Now.AddHours(-2)));
//                manager.AddCallLog(new CustomerCallLog("9792875109", "Network Coverage", DateTime.Now.AddHours(-1)));
//                manager.AddCallLog(new CustomerCallLog("9555454446", "SIM not found", DateTime.Now));

//                manager.SearchByKeyword("Billing");

//                manager.FilterByTime(DateTime.Now.AddHours(-3), DateTime.Now);
//            }
//        }

//    }

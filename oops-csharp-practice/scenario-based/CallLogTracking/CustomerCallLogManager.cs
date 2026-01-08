//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based.CallLogTracking
//{
//    internal class CustomerCallLogManager
//    {
        
//        private CustomerCallLog[] logs;
//        private int count;

//        public CustomerCallLogManager(int size)
//        {
//            logs = new CustomerCallLog[size];
//            count = 0;
//        }

//        // Add call log
//        public void AddCallLog(CustomerCallLog log)
//        {
//            if (count < logs.Length)
//            {
//                logs[count] = log;
//                count++;
//                Console.WriteLine("Call log added successfully.");
//            }
//            else
//            {
//                Console.WriteLine("Call log storage full.");
//            }
//        }

//        // Search by keyword in message
//        public void SearchByKeyword(string keyword)
//        {
//            Console.WriteLine($"\nLogs containing keyword: {keyword}");
//            for (int i = 0; i < count; i++)
//            {
//                if (logs[i].Message.Contains(keyword))
//                {
//                    logs[i].ShowLog();
//                }
//            }
//        }

//        // Filter logs by time range
//        public void FilterByTime(DateTime start, DateTime end)
//        {
//            Console.WriteLine("\nLogs between given time range:");
//            for (int i = 0; i < count; i++)
//            {
//                if (logs[i].TimeStamp >= start && logs[i].TimeStamp <= end)
//                {
//                    logs[i].ShowLog();
//                }
//            }
//        }
//    }

//}

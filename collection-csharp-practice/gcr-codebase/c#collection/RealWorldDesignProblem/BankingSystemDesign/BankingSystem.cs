//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.RealWorldSystemDesign.BankingSystemDesign
//{
//    internal class BankingSystem
//    {
//        Dictionary<int, double> accounts = new Dictionary<int, double>();
//        Queue<int> withdrawalQueue = new Queue<int>();

//        public void AddAccount(int accNo, double balance)
//        {
//            accounts[accNo] = balance;
//        }

//        public void RequestWithdrawal(int accNo)
//        {
//            withdrawalQueue.Enqueue(accNo);
//        }

//        public void ProcessWithdrawals()
//        {
//            while (withdrawalQueue.Count > 0)
//            {
//                int acc = withdrawalQueue.Dequeue();
//                Console.WriteLine("Processing withdrawal for account " + acc);
//            }
//        }

//        public void SortByBalance()
//        {
//            SortedDictionary<double, int> sorted =
//                new SortedDictionary<double, int>();

//            foreach (var acc in accounts)
//                sorted[acc.Value] = acc.Key;

//            foreach (var s in sorted)
//                Console.WriteLine(s.Value + " -> " + s.Key);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.RealWorldSystemDesign.Insurance_Policy_Management
//{
//    internal class Insurance
//    {
//        HashSet<Policy> uniquePolicies = new HashSet<Policy>();
//        List<Policy> insertionOrder = new List<Policy>();
//        SortedSet<Policy> sortedByExpiry =
//            new SortedSet<Policy>(Comparer<Policy>.Create(
//                (a, b) => a.ExpiryDate.CompareTo(b.ExpiryDate)));

//        public void AddPolicy(Policy policy)
//        {
//            if (uniquePolicies.Add(policy))
//            {
//                insertionOrder.Add(policy);
//                sortedByExpiry.Add(policy);
//            }
//        }

//        public void PoliciesExpiringSoon()
//        {
//            DateTime limit = DateTime.Now.AddDays(30);
//            foreach (var p in sortedByExpiry)
//            {
//                if (p.ExpiryDate <= limit)
//                    Console.WriteLine(p.PolicyNumber);
//            }
//        }

//        public void PoliciesByCoverage(string type)
//        {
//            foreach (var p in uniquePolicies.Where(p => p.CoverageType == type))
//                Console.WriteLine(p.PolicyNumber);
//        }
//    }
//}

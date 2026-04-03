//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.RealWorldSystemDesign.Voting_System_Design
//{
//    internal class VotingSystem
//    {
//        Dictionary<string, int> votes = new Dictionary<string, int>();
//        List<string> voteOrder = new List<string>();

//        public void CastVote(string candidate)
//        {
//            voteOrder.Add(candidate);

//            if (votes.ContainsKey(candidate))
//                votes[candidate]++;
//            else
//                votes[candidate] = 1;
//        }

//        public void DisplayResultsSorted()
//        {
//            SortedDictionary<string, int> sorted =
//                new SortedDictionary<string, int>(votes);

//            foreach (var v in sorted)
//                Console.WriteLine(v.Key + " : " + v.Value);
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.List
//{
//    internal class ElementFreq
//    {
//        static void Main()
//        {
//            List<string> fruits = new List<string>
//        { "apple", "banana", "apple", "orange" };

//            Dictionary<string, int> frequency = new Dictionary<string, int>();

//            foreach (string item in fruits)
//            {
//                if (frequency.ContainsKey(item))
//                    frequency[item]++;
//                else
//                    frequency[item] = 1;
//            }

//            foreach (var pair in frequency)
//                Console.WriteLine(pair.Key + " : " + pair.Value);
//        }
//    }
//}

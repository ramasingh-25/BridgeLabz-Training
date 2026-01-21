//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.Map
//{
//    class InvertaMap
//    {
//        static void Main()
//        {
//            Dictionary<string, int> originalMap = new Dictionary<string, int>()
//        {
//            { "A", 1 },
//            { "B", 2 },
//            { "C", 1 }
//        };

//            Dictionary<int, List<string>> invertedMap =
//                new Dictionary<int, List<string>>();

//            foreach (var pair in originalMap)
//            {
//                if (!invertedMap.ContainsKey(pair.Value))
//                {
//                    invertedMap[pair.Value] = new List<string>();
//                }

//                invertedMap[pair.Value].Add(pair.Key);
//            }

//            Console.WriteLine("Inverted Map:");
//            foreach (var pair in invertedMap)
//            {
//                Console.Write(pair.Key + " = ");
//                Console.WriteLine(string.Join(", ", pair.Value));
//            }
//        }
//    }
//}
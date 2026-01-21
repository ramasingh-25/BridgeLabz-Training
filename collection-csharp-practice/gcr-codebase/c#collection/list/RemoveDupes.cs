//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.List
//{
//    internal class RemoveDupes
//    {
//        static void Main()
//        {
//            List<int> numbers = new List<int> { 3, 1, 2, 2, 3, 4 };
//            HashSet<int> seen = new HashSet<int>();
//            List<int> result = new List<int>();

//            foreach (int num in numbers)
//            {
//                if (!seen.Contains(num))
//                {
//                    seen.Add(num);
//                    result.Add(num);
//                }
//            }

//            Console.WriteLine(string.Join(", ", result));
//        }
//    }
//}

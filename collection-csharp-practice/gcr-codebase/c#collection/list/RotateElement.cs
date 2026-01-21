//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.List
//{
//    internal class RotateElement
//    {
//        static void RotateList(List<int> list, int k)
//        {
//            k = k % list.Count;
//            List<int> rotated = new List<int>();

//            for (int i = k; i < list.Count; i++)
//                rotated.Add(list[i]);

//            for (int i = 0; i < k; i++)
//                rotated.Add(list[i]);

//            list.Clear();
//            list.AddRange(rotated);
//        }

//        static void Main()
//        {
//            List<int> nums = new List<int> { 10, 20, 30, 40, 50 };
//            RotateList(nums, 2);

//            Console.WriteLine(string.Join(", ", nums));
//        }
//    }
//}

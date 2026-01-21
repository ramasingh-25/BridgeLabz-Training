//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.List
//{
//    internal class RevList
//    {
//        static void ReverseList(List<int> list)
//        {
//            int start = 0;
//            int end = list.Count - 1;

//            while (start < end)
//            {
//                int temp = list[start];
//                list[start] = list[end];
//                list[end] = temp;

//                start++;
//                end--;
//            }
//        }

//        static void Main()
//        {
//            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
//            ReverseList(numbers);

//            Console.WriteLine(string.Join(", ", numbers));
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.Queue
//{
//    internal class BinaryNumber
//    {
//        static void GenerateBinaryNumbers(int n)
//        {
//            Queue<string> queue = new Queue<string>();
//            queue.Enqueue("1");

//            for (int i = 0; i < n; i++)
//            {
//                string current = queue.Dequeue();
//                Console.Write(current + " ");

//                queue.Enqueue(current + "0");
//                queue.Enqueue(current + "1");
//            }
//        }

//        static void Main()
//        {
//            int n = 5;
//            GenerateBinaryNumbers(n);
//        }
//    }
//}

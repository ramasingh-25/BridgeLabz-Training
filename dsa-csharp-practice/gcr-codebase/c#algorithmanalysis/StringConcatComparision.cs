//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;

//namespace BridgeLabzDSA.AlgoAnalysis
//{
//    internal class StringConcatComparision
//    {
//        public static void Main(string[] args)
//        {
//            int iterations = 10000;
//            string[] names = { "chitra","khushi","swati"};

//            Stopwatch sw = Stopwatch.StartNew();
//            string s = "";
//            for (int i = 0; i < iterations; i++)
//            {
//                s += names[i % 3];
//            }
//            sw.Stop();
//            Console.WriteLine($"String Concatenation Time: {sw.Elapsed.TotalMilliseconds} ms");

//            sw.Restart();
//            StringBuilder sb = new StringBuilder();
//            for (int i = 0; i < iterations; i++)
//            {
//                sb.Append(names[i % 3]);
//            }
//            sw.Stop();
//            Console.WriteLine($"StringBuilder Time: {sw.Elapsed.TotalMilliseconds} ms");
//        }
//    }
//}

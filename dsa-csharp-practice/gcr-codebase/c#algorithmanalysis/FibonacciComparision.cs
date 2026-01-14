//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;

//namespace BridgeLabzDSA.AlgoAnalysis
//{
//    internal class FibonacciComparision
//    {
//        public static void Main(string[] args)
//        {
//            int number = 40;

//            Stopwatch sw = Stopwatch.StartNew();
//            long recResult = FibonacciRecursive(number);
//            sw.Stop();
//            Console.WriteLine($"Recursive Time (N={number}): {sw.Elapsed.TotalMilliseconds} ms");

//            sw.Restart();
//            long iterResult = FibonacciIterative(number);
//            sw.Stop();
//            Console.WriteLine($"Iterative Time (N={number}): {sw.Elapsed.TotalMilliseconds} ms");
//        }

//        public static long FibonacciRecursive(int number)
//        {
//            if (number <= 1) return number;
//            return FibonacciRecursive(number - 1) + FibonacciRecursive(number - 2);
//        }

//        public static long FibonacciIterative(int number)
//        {
//            if (number <= 1) return number;
//            long num1 = 0, num2 = 1, sum;
//            for (int i = 2; i <= number; i++)
//            {
//                sum = num1 + num2;
//                num1 = num2;
//                num2 = sum;
//            }
//            return num2;
//        }
//    }
//}


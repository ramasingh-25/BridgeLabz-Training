//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;

//namespace BridgeLabzDSA.AlgoAnalysis
//{
//    internal class SearchComparision
//    {
       
//            public static void Main(string[] args)
//            {
//                int sizelimit = 1000000;
//                int[] data = new int[sizelimit];
//                for (int i = 0; i < sizelimit; i++)
//                {
//                    data[i] = i;
//                }

//                int target = sizelimit - 1;

//                Stopwatch sw = Stopwatch.StartNew();
//                bool foundLinear = false;
//                for (int i = 0; i < data.Length; i++)
//                {
//                    if (data[i] == target)
//                    {
//                        foundLinear = true;
//                        break;
//                    }
//                }
//                sw.Stop();
//                Console.WriteLine($"Linear Search Time: {sw.Elapsed.TotalMilliseconds} ms");

//                Array.Sort(data);
//                sw.Restart();
//                int low = 0, high = data.Length - 1;
//                bool foundBinary = false;
//                while (low <= high)
//                {
//                    int mid = low + (high - low) / 2;
//                    if (data[mid] == target)
//                    {
//                        foundBinary = true;
//                        break;
//                    }
//                    if (data[mid] < target) low = mid + 1;
//                    else high = mid - 1;
//                }

//                sw.Stop();
//                Console.WriteLine($"Binary Search Time: {sw.Elapsed.TotalMilliseconds} ms");

//            }
//        }
//    }


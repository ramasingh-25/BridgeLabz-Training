//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Searching
//{
//    internal class FindPeekElement
//    {
//        static void Main()
//        {
//            int[] arr = { 2, 5, 4, 60, 7, 3, 8, 46 };


//            int peakIndex = FindPeakElement(arr);


//            Console.WriteLine("Peak element index: " + peakIndex);
//            Console.WriteLine("Peak element value: " + arr[peakIndex]);

//        }

//        static int FindPeakElement(int[] arr)
//        {
//            int low = 0;
//            int high = arr.Length - 1;

//            while (low < high)
//            {
//                int mid = low + (high - low) / 2;

//                if (arr[mid] < arr[mid + 1])
//                {
                    
//                    low = mid + 1;
//                }
//                else
//                {
                    
//                    high = mid;
//                }
//            }

//            return low; 
//        }
//    }
//}


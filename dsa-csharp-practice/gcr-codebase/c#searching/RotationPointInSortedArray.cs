//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Searching
//{
//    internal class RotationPointInSortedArray
//    {
//        static void Main()
//        {
//            int[] arr = { 9,8,5,4,7,3,1 };

//            int findIndex = FindRotationPoint(arr);

//            Console.WriteLine("Index of smallest element: " + findIndex);
//            Console.WriteLine("Smallest element: " + arr[findIndex]);
//        }

//        static int FindRotationPoint(int[] arr)
//        {
//            int low = 0;
//            int high = arr.Length - 1;

//            while (low < high)
//            {

//                int mid = low + (high - low) / 2;


//                if (arr[mid] > arr[high])
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

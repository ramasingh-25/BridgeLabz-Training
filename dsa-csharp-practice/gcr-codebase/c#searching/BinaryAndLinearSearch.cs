//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Searching
//{
//    internal class BinaryAndLinearSearch
//    {
       
//            public static void Main(string[] args)
//            {
//                int[] array = { -2,1,5,7,9,10};

//                int target = 7;

//                int Findmissing = FirstMissingPositive(array);

//                Console.WriteLine("First Missing Positive Integer: " + Findmissing);

//                Array.Sort(array);

//                int index = BinarySearch(array, target);

//                Console.WriteLine("Index of target element: " + index);
//            }



//           //method to find missingh positive number
//            static int FirstMissingPositive(int[] array)
//            {
//                int num = array.Length;
//                bool[] visited = new bool[num + 1];

//                for (int i = 0; i < num; i++)
//                {
//                    if (array[i] > 0 && array[i] <= num)
//                    {
//                        visited[array[i]] = true;
//                    }
//                }

//                for (int i = 1; i <= num; i++)
//                {
//                    if (!visited[i])
//                        return i;
//                }

//                return num + 1;
//            }



//            //Binary search
//            static int BinarySearch(int[] arr, int target)
//            {
//                int low = 0, high = arr.Length - 1;

//                while (low <= high)
//                {
//                    int mid = low + (high - low) / 2;

//                    if (arr[mid] == target)
//                        return mid;
//                    else if (arr[mid] < target)
//                        low = mid + 1;
//                    else
//                        high = mid - 1;
//                }

//                return -1;
//            }
//        }
//    }

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Searching
//{
//    internal class FirstAndLastOccurence
//    {
        
//            public static void Main(string[] args)
//            {
//                int[] arr = { 13,13,18,19,20,40,55 };
//                int target = 13;

//                int firstOcc = FindFirstOcc(arr, target);
//                int lastOcc = FindLastOcc(arr, target);

//                Console.WriteLine("First Occurrence Index is : " + firstOcc);
//                Console.WriteLine("Last Occurrence Index is  : " + lastOcc);
//            }

            
//            static int FindFirstOcc(int[] array, int target)
//            {
//                int low = 0, high = array.Length - 1;
//                int result = -1;

//                while (low <= high)
//                {
//                    int mid = low + (high - low) / 2;

//                    if (array[mid] == target)
//                    {
//                        result = mid;
//                        high = mid - 1;
//                    }
//                    else if (array[mid] < target)
//                    {
//                        low = mid + 1;
//                    }
//                    else
//                    {
//                        high = mid - 1;
//                    }
//                }

//                return result;
//            }


           
//            static int FindLastOcc(int[] array, int target)
//            {
//                int low = 0, high = array.Length - 1;
//                int result = -1;

//                while (low <= high)
//                {
//                    int mid = low + (high - low) / 2;

//                    if (array[mid] == target)
//                    {
//                        result = mid;
//                        low = mid + 1;
//                    }
//                    else if (array[mid] < target)
//                    {
//                        low = mid + 1;
//                    }
//                    else
//                    {
//                        high = mid - 1;
//                    }
//                }

//                return result;
//            }
//        }
//    }

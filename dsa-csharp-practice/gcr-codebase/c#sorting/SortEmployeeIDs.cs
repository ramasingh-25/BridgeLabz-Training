//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Sorting
//{
//    internal class SortEmployeeIDs
//    {
        
//        static void Main(string[] args)
//        {
//            int[] employeeIds = { 99, 105, 172, 48, 124, 102, 111, 67, 131, 89 };

//            Console.WriteLine("Before sorting:");
//            PrintArray(employeeIds);

//            InsertionSort(employeeIds);

//            Console.WriteLine("\nAfter sorting (ascending):");

//            PrintArray(employeeIds);
//        }

//        static void InsertionSort(int[] arr)
//        {
//            int n = arr.Length;

            
//            for (int i = 1; i < n; i++)
//            {
//                int current = arr[i];           
//                int j = i - 1;

//                while (j >= 0 && arr[j] > current)
//                {
//                    arr[j + 1] = arr[j];
//                    j--;
//                }

//                arr[j + 1] = current;
//            }
//        }

//        static void PrintArray(int[] arr)
//        {
//            Console.WriteLine(string.Join(" ", arr));
//        }
//    }
//}

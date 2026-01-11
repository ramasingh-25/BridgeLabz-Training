//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Sorting
//{
//    internal class SortJobApplicants
//    {
       
//        static void Main(string[] args)
//        {
            
//            int[] salaries = { 10, 9, 6, 16, 12, 12, 17, 8, 14, 13, 20, 11 };

//            Console.WriteLine("Before sorting:");
//            PrintArray(salaries);

//            HeapSort(salaries);

//            Console.WriteLine("\nAfter sorting (ascending):");
//            PrintArray(salaries);
//        }

//        static void HeapSort(int[] arr)
//        {
//            int n = arr.Length;

           
//            for (int i = n / 2 - 1; i >= 0; i--)
//            {
//                Heapify(arr, n, i);
//            }

            
//            for (int i = n - 1; i > 0; i--)
//            {
//                Swap(arr, 0, i);

//                Heapify(arr, i, 0);
//            }
//        }

//        static void Heapify(int[] arr, int n, int i)
//        {
//            int largest = i;          
//            int left = 2 * i + 1;     
//            int right = 2 * i + 2;    

            
//            if (left < n && arr[left] > arr[largest])
//                largest = left;

           
//            if (right < n && arr[right] > arr[largest])
//                largest = right;

           
//            if (largest != i)
//            {
//                Swap(arr, i, largest);

                
//                Heapify(arr, n, largest);
//            }
//        }

//        static void Swap(int[] arr, int i, int j)
//        {
//            //tuple swap
//            (arr[i], arr[j]) = (arr[j], arr[i]); 
//        }

//        static void PrintArray(int[] arr)
//        {
//            Console.WriteLine(string.Join(" ", arr));
//        }
//    }
//}
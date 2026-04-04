//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Sorting
//{
//    internal class QuickSortProductPrices
//    {
//        public static void Main(string[] args)
//        {
//            int[] prices = { 1999, 399, 799, 499, 1000, 999 };

//            Console.WriteLine("Product Prices Before Sorting:");
//            PrintArray(prices);

//            QuickSorting(prices, 0, prices.Length - 1);

//            Console.WriteLine("Product Prices After Sorting:");
//            PrintArray(prices);
//        }


//        static void QuickSorting(int[] arr, int low, int high)
//        {
//            if (low < high)
//            {
//                int pivotIndex = Partition(arr, low, high);


//                QuickSorting(arr, low, pivotIndex - 1);
//                QuickSorting(arr, pivotIndex + 1, high);
//            }
//        }




//        static int Partition(int[] arr, int low, int high)
//        {
//            //last element is pivot element
//            int pivot = arr[high];   
//            int i = low - 1;

//            for (int j = low; j < high; j++)
//            {
//                if (arr[j] < pivot)
//                {
//                    i++;


//                    int temp = arr[i];
//                    arr[i] = arr[j];
//                    arr[j] = temp;
//                }
//            }

//            //swapping
//            int tempPivot = arr[i + 1];
//            arr[i + 1] = arr[high];
//            arr[high] = tempPivot;

//            return i + 1;
//        }



//        static void PrintArray(int[] arr)
//        {
//            for (int i = 0; i < arr.Length; i++)
//            {
//                Console.Write(arr[i] + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}
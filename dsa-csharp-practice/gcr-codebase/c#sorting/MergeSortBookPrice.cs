//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Sorting
//{
//     class MergeSortBookPrice
//    {
//        static void Main(string[] args)
//        {

//            double[] bookPrices = { 399.99, 499.50, 799.00, 299.99, 649.50, 499.00, 2399.99, 449.00, 659.50, 239.99 };


//            Console.WriteLine("Before sorting:");

//            PrintArray(bookPrices);


//            MergeSort(bookPrices, 0, bookPrices.Length - 1);

//            Console.WriteLine("\nAfter sorting (ascending):");
//            PrintArray(bookPrices);
//        }

//        static void MergeSort(double[] arr, int left, int right)
//        {
//            if (left >= right)
//                return;

//            int mid = left + (right - left) / 2;

//            // Sort first and second halves
//            MergeSort(arr, left, mid);
//            MergeSort(arr, mid + 1, right);

//            // Merge the sorted halves
//            Merge(arr, left, mid, right);
//        }

//        static void Merge(double[] arr, int left, int mid, int right)
//        {
            
//            int n1 = mid - left + 1;
//            int n2 = right - mid;

            
//            double[] leftArr = new double[n1];
//            double[] rightArr = new double[n2];

            
//            for (int i = 0; i < n1; i++)
//                leftArr[i] = arr[left + i];
//            for (int j = 0; j < n2; j++)
//                rightArr[j] = arr[mid + 1 + j];

//            int iLeft = 0;    
//            int jRight = 0;

//            // Initial index of merged subarray
//            int k = left;    

//            while (iLeft < n1 && jRight < n2)
//            {
//                if (leftArr[iLeft] <= rightArr[jRight])
//                {
//                    arr[k] = leftArr[iLeft];
//                    iLeft++;
//                }
//                else
//                {
//                    arr[k] = rightArr[jRight];
//                    jRight++;
//                }
//                k++;
//            }

//            while (iLeft < n1)
//            {
//                arr[k] = leftArr[iLeft];
//                iLeft++;
//                k++;
//            }

//            while (jRight < n2)
//            {
//                arr[k] = rightArr[jRight];
//                jRight++;
//                k++;
//            }
//        }

//        static void PrintArray(double[] arr)
//        {
//            Console.WriteLine(string.Join("  ", arr));
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Sorting
//{
//     class SortingStudentMarks
//    {
//       //main method
//        static void Main(string[] args)
//        {

//            //scores array to sort 
//            int[] score = { 87, 88, 78, 65, 77, 94, 83, 60, 66, 84 };

//            Console.WriteLine("Before sorting:");
//            PrintArray(score);

//            BubbleSort(score);

//            Console.WriteLine("\nAfter sorting (ascending):");
//            PrintArray(score);
//        }
//        //by bubble sort
//        static void BubbleSort(int[] array)
//        {
//            int n = array.Length;

//            for (int i = 0; i < n - 1; i++)
//            {
//                for (int j = 0; j < n - i - 1; j++)
//                {
//                    if (array[j] > array[j + 1])
//                    {
//                        // Swap
//                        int temp = array[j];
//                        array[j] = array[j + 1];
//                        array[j + 1] = temp;
//                    }
//                }
//            }
//        }

//        static void PrintArray(int[] array)
//        {
//            Console.WriteLine(string.Join(" ", array));
//        }
//    }
//}
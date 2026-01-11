//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Sorting
//{
//     class SelectionSortExamScores
//    {


//        public static void Main(string[] args)
//        {
//            int[] marks = { 83, 65, 87, 77, 98, 58 };

//            Console.WriteLine("Exam Scores Before Sorting:");
//            PrintArray(marks);

//            SelectionSort(marks);

//            Console.WriteLine("Exam Scores After Sorting:");
//            PrintArray(marks);


//        }





//        static void SelectionSort(int[] array)
//        {
//            int n = array.Length;

//            for (int i = 0; i < n - 1; i++)
//            {
//                int minIndex = i;


//                for (int j = i + 1; j < n; j++)
//                {
//                    if (array[j] < array[minIndex])
//                    {
//                        minIndex = j;
//                    }
//                }


//                int temp = array[minIndex];
//                array[minIndex] = array[i];
//                array[i] = temp;
//            }
//        }



//        //method to print array


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

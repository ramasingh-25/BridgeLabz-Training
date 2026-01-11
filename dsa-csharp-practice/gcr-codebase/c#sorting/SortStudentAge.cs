//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Sorting
//{
//    public class SortStudenrAge
//    {
        
//        static void Main(string[] args)
//        {
//            //array to store the age of students
//            int[] ages = { 16, 11, 13, 14, 12, 17, 15, 12, 18, 16, 10, 13, 17 };

//            Console.WriteLine("Original ages: ");

//            Array(ages);


//            int[] sortedAges = CountingSortAges(ages);


//            Console.WriteLine("\nSorted ages: ");
//            Array(sortedAges);

//        }

//        static int[] CountingSortAges(int[] ages)
//        {
            
//            const int MIN_AGE = 10;
//            const int MAX_AGE = 18;
//            int range = MAX_AGE - MIN_AGE + 1; 


//            int[] count = new int[range];

           
//            foreach (int age in ages)
//            {
//                count[age - MIN_AGE]++;
//            }

          
//            for (int i = 1; i < range; i++)
//            {
//                count[i] += count[i - 1];
//            }

//            int[] output = new int[ages.Length];

//            for (int i = ages.Length - 1; i >= 0; i--)
//            {
//                int age = ages[i];
//                int index = age - MIN_AGE;

//                output[count[index] - 1] = age;

//                count[index]--;
//            }

//            return output;
//        }

//        static void Array(int[] arr)
//        {
//            Console.WriteLine(string.Join(" ", arr));
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.ExceptionHandling
//{
//    internal class HandlingMultipleException
//    {
//        public static void Main(string[] args)
//        {
//            try
//            {
//                // Initialize array 
//                int[] arr = { 50, 60, 70, 80, 90 };

//                Console.Write("Enter index: ");
//                int ind = Convert.ToInt32(Console.ReadLine());

//                Console.WriteLine("Value at index " + ind + ": " + arr[ind]);
//            }



//            catch (IndexOutOfRangeException)
//            {
//                Console.WriteLine("Invalid index!");
//            }



//            catch (NullReferenceException)
//            {
//                Console.WriteLine("Array is not initialized!");
//            }
//        }
//    }
//}

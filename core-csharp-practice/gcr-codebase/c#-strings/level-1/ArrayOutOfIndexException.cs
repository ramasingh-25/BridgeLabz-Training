//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//   class ArrayOutOfIndexException
    
//        {
//            public static void DemonstrateArrayIndexOutOfRange()
//            {
//                int[] arr = { 10, 20, 30, 40, 50 };

               
//                Console.WriteLine("Element at index 10: " + arr[7]);
//            }

          

//            public static void HandleArrayIndexOutOfRange()
//            {


//                try
//                {
//                    DemonstrateArrayIndexOutOfRange();
//                }
//                catch (IndexOutOfRangeException ex)
//                {

//                    Console.WriteLine("Exception Caught: IndexOutOfRangeException");
//                    Console.WriteLine("Message: " + ex.Message);
//                }
//            }

//            static void Main(string[] args)
//            {

//                HandleArrayIndexOutOfRange();
//                Console.WriteLine("\nProgram execution continues safely.");


//            }
//        }
//    }


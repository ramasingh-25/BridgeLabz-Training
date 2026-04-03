//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//    class IndexOutOfRange

//    {
//        public static void DemonstrateIndexOutOfRange()
//        {
//            string text = "RamaSingh";

           
//            Console.WriteLine("Character at index 20: " + text[20]);    // Invalid index access
//        }

        
//        public static void HandleIndexOutOfRange()  // Method that handles the exception
//        {
//            try
//            {
//                DemonstrateIndexOutOfRange();
//            }
//            catch (IndexOutOfRangeException ex)
//            {
//                Console.WriteLine("Exception Caught: IndexOutOfRangeException");
//                Console.WriteLine("Message: " + ex.Message);
//            }
//        }

//        //main method
//        static void Main(string[] args)
//        {
//            HandleIndexOutOfRange();
//            Console.WriteLine("\nProgram execution continues safely.");
//        }
//    }
//}




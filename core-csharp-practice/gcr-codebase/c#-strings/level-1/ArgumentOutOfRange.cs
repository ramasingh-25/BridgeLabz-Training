//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//    class ArgumentOutOfRange
    
//        {
//            public static void DemonstrateArgumentOutOfRange()
//            {
//                string text = "RamaSingh";

//                int startIndex = 6;
//                int endIndex = 3;

               
//                string result = text.Substring(startIndex, endIndex - startIndex + 1);

//                Console.WriteLine(result);
//            }

            
//            public static void HandleArgumentOutOfRange()
//            {
//                try
//                {

//                    DemonstrateArgumentOutOfRange();


//                }
//                catch (ArgumentOutOfRangeException ex)
//                {

//                    Console.WriteLine("Exception Caught: ArgumentOutOfRangeException");
//                    Console.WriteLine("Message: " + ex.Message);


//                }
//            }

//            static void Main(string[] args)
//            {

//                HandleArgumentOutOfRange();
//                Console.WriteLine("\nProgram execution continues safely.");


//            }
//        }
//    }




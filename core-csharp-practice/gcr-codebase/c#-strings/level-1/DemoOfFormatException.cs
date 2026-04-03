//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//   class DemoOfFormatException
//    {
       
//            public static void DemonstrateFormatException()
//            {
//                string input = "ABC123"; 
              
               
//                int number = int.Parse(input);

//                Console.WriteLine("Converted number: " + number);
//            }

//            //method to demonstrate
//            public static void HandleFormatException()
//            {
//                try
//                {
//                    DemonstrateFormatException();
//                }
//                catch (FormatException ex)
//                {
//                    Console.WriteLine("Exception Caught: FormatException");
//                    Console.WriteLine("Message: " + ex.Message);
//                }
//            }

//            static void Main(string[] args)
//            {
//                HandleFormatException();
//                Console.WriteLine("\nProgram execution continues safely.");
//            }
//        }
//    }


//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//    class ReturningAllChar
    
//        {
//        //method to return all characters
//            public static char[] GetCharacters(string input)
//            {
//                char[] result = new char[input.Length];
//                for (int i = 0; i < input.Length; i++)
//                {
//                    result[i] = input[i];
//                }
//                return result;
//            }
//        //main method 
//            static void Main(string[] args)
//            {
//            //taking inputs
//                Console.Write("Enter the string");
//                string input = Console.ReadLine();

//                char[] customResult = GetCharacters(input);

//                char[] builtinMethod = input.ToCharArray();

//                Console.WriteLine("\nCharacters using custom method:");
//                foreach (char c in customResult)
//                {
//                    Console.Write(c + " ");
//                }

//                Console.WriteLine("\n\nCharacters using ToCharArray():");
//                foreach (char c in builtinMethod)
//                {
//                    Console.Write(c + " ");
//                }


//            }
//        }
//    }


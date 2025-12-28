//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//    class ConvertingToUpperCase
//    {
//        //method converting to upper case
//             static string ConvertUsingAscii(string input)
//            {

//                StringBuilder result = new StringBuilder();



//                for (int i = 0; i < input.Length; i++)
//                {


//                    char ch = input[i];

//                    // ASCII logic: a-z → A-Z
//                    if (ch >= 'a' && ch <= 'z')
//                    {
//                        ch = (char)(ch - 32);
//                    }


//                    result.Append(ch);
//                }

//                return result.ToString();

//            }

//            static void Main()
//            {
//                Console.Write("Enter the text: ");
//                string input = Console.ReadLine();

//                string customUpper = ConvertUsingAscii(input);

//                string builtInUpper = input.ToUpper();

//                Console.WriteLine("\nResults:");

//                Console.WriteLine("Using ASCII logic : " + customUpper);

//                Console.WriteLine("Using ToUpper()  : " + builtInUpper);

//            }

//        }

//    }


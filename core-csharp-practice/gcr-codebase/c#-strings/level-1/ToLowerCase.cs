//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//   class ToLowerCase
    
//    {
        
//          static string ConvertUsingAscii(string input)
//            {
//                StringBuilder result = new StringBuilder();

//                for (int i = 0; i < input.Length; i++)
//                {
//                    char ch = input[i];

//                    // ASCII logic: A-Z → a-z
//                    if (ch >= 'A' && ch <= 'Z')
//                    {
//                        ch = (char)(ch + 32);

//                    }

//                    result.Append(ch);

//                }

//                return result.ToString();
//            }

//            static void Main()
//            {

//                Console.Write("Enter the text: ");


//                string input = Console.ReadLine();

//                string customLower = ConvertUsingAscii(input);

//                string builtInLower = input.ToLower();

//                Console.WriteLine("\nResults:");


//                Console.WriteLine("Using ASCII logic : " + customLower);


//                Console.WriteLine("Using ToLower()  : " + builtInLower);
//            }
//        }
//    }



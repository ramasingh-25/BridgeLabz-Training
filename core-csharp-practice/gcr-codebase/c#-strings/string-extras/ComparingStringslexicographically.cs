//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//   class ComparingStringslexicographically
   
//        {
//            static void Main(String[] args)
//            {
//                Console.Write("Enter first string");
//                string str1 = Console.ReadLine();
//                Console.Write("Enter second string ");
//                string str2 = Console.ReadLine();
//                int len = str1.Length < str2.Length ? str1.Length : str2.Length;
//                int res = 0;
//                for (int i = 0; i < len; i++)
//                {
//                    if (str1[i] != str2[i])
//                    {
//                        res = str1[i] - str2[i];
//                        break;
//                    }
//                }

//                if (res == 0)
//                    res = str1.Length - str2.Length;

//                if (res < 0)
//                    Console.WriteLine("String 1 come before String 2");
//                else if (res > 0)
//                    Console.WriteLine("String 2 come before String 1");
//                else
//                    Console.WriteLine("Both strings are equal");
//            }
//        }
//    }



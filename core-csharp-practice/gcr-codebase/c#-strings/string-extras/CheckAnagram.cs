//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//    class CheckAnagram
//    {
//        static void Main()
//        {
//            Console.Write("Enter first string");
//            //converting string to lowercase
//            string str1 = Console.ReadLine().ToLower();
//            Console.Write("Enter second string");
//            //converting string to uppercase
//            string str2 = Console.ReadLine().ToLower();
//            bool res = true;
//            for (int i = 0; i < str1.Length; i++)
//            {
//                if (!(str2.Contains(str1[i].ToString()) && str1.Contains(str2[i].ToString())))
//                {
//                    res = false;
//                    break;
//                }
//            }

//            if (res && str1.Length == str2.Length)
//                Console.WriteLine("Strings are Anagrams");
//            else
//                Console.WriteLine("string is not Anagrams");
//        }
//    }
//}


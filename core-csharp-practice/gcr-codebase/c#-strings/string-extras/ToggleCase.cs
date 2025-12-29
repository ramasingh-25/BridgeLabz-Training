//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//    class ToggleCase
//    {
//        static void Main(String[] args)
//        {
//            Console.WriteLine("Enter a string");
//            string str = Console.ReadLine();//taking input string

//            string res = "";

//            for (int i = 0; i < str.Length; i++)
//            {
//                char c = str[i];
//                if (c >= 'a' && c <= 'z') res += (char)(c - 32);
//                else if (c >= 'A' && c <= 'Z') res += (char)(c + 32);
//                else res += c;

//            }

//            Console.WriteLine(res);

//        }
//    }
//}
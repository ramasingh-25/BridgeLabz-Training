//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Built_in
//{
//    class CheckPalindrome
//    {
//        //method to check given string is palindrome

//        static bool Palindrome(string str)
//        {
            
//            char[] arr = str.ToLower().ToCharArray();
//            //reversing a array

//            Array.Reverse(arr);

//            return str.ToLower() == new string(arr);
//        }
//        //main method
//        static void Main()
//        {

//            Console.Write("Enter a string: ");
//            //taking a string
//            string input = Console.ReadLine();

//            bool res = Palindrome(input);
//            if (res)
//                Console.WriteLine("Palindrome");
//            else
//                Console.WriteLine("Not a Palindrome");

//        }
//    }
//}

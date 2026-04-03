//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
// public class LongestWord
    
//        {
//        //main method
//            static void Main(String[] args)
//            {
//                Console.WriteLine("Enter  a sentence");
//                string str = Console.ReadLine();
//                string word = "";
//                string longest = "";
//                for (int i = 0; i < str.Length; i++)
//                {
//                    if (str[i] != ' ')
//                    {
//                        word += str[i];
//                    }
//                    else
//                    {
//                        if (word.Length > longest.Length) longest = word;
//                        word = "";
//                    }
//                }
//                if (word.Length > longest.Length) longest = word;
//                Console.WriteLine("longest word =" + longest);
//                Console.WriteLine("its length =" + longest.Length);

//            }
//        }
//    }
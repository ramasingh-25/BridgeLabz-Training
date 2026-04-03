//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//class VowelsAndConsonants
//    {
//        public static void Main(String[] args)
//        {
//            Console.WriteLine("Enter a string");
//            //converting input to lowercase
//            string s = Console.ReadLine().ToLower(); 

//            int vowels = 0;
//            int cons = 0;
//            for (int i = 0; i < s.Length; i++)
//            {
//                char c = s[i];
//                if (c >= 'a' && c <= 'z')
//                {
//                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') vowels++;
//                    else cons++;

//                }
//            }
//            Console.WriteLine("Vowels " + vowels);
//            Console.WriteLine("Consonants " + cons);
//        }
//    }
//}

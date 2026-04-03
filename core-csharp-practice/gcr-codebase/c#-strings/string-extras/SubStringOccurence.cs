//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//   class SubStringOccurence
//    {
//        public static void Main(String[] args)
//        {
//            Console.Write("Enter a string ");
//            string str = Console.ReadLine();//taking string
//            Console.Write("Enter substring ");
//            string substr = Console.ReadLine();
//            int count = 0;
//            int i = 0;
//            //iterating to get substring
//            while (str.IndexOf(substr, i) != -1)
//            {
//                i = str.IndexOf(substr, i);
//                count++;
//                i = i + substr.Length;
//            }

//            Console.WriteLine("Occurrences: " + count);
//        }
//    }
//}

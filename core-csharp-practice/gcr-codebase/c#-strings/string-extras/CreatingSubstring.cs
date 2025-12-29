//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//     class CreatingSubstring
    
//        {
//            public static string MakingSubstring(string mainString, int firstIndex, int endIndex)
//            {
//                string result = "";

//                for (int i = firstIndex; i <= endIndex; i++)
//                {


//                    result += mainString[i];


//                }
//                return result;

//            }
//            static void Main(string[] args)
//            {
//                Console.Write("Enter the string :");
//                string mainString = Console.ReadLine();

//                Console.WriteLine("Enter the first and last index to create the substring");

//                Console.Write("first index :");

//                int firstIndex = Convert.ToInt32(Console.ReadLine());

//                Console.Write("end index :");
//                int endIndex = Convert.ToInt32(Console.ReadLine());

//                string custom =  MakingSubstring(mainString, firstIndex, endIndex);

//                string built_in = mainString.Substring(firstIndex, endIndex - firstIndex + 1);

//                Console.WriteLine("Results");

//                Console.WriteLine("Substring created using custom method " + custom);
//                Console.WriteLine("substring using built in method " + built_in);



//            }
//        }
//    }



//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//     class MostFrequency
//    {
        
//            public static void Main(String[] args)
//            {
//                Console.Write("Enter a string: ");
//                string str = Console.ReadLine();
//                char maximum = str[0];
//                int max = 0;

//                for (int i = 0; i < str.Length; i++)
//                {
//                    int count = 0;
//                    for (int j = 0; j < str.Length; j++)
//                    {
//                        if (str[i] == str[j])
//                            count++;
//                    }
//                    if (count > max)
//                    {
//                        max = count;
//                        maximum = str[i];
//                    }
//                }
//                Console.WriteLine("Most Frequent Character " + maximum);
//            }
//        }
//    }


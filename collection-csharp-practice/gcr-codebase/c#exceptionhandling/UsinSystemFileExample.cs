//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.ExceptionHandling
//{
//    internal class UsinSystemFileExample
//    {
//        public static void Main(string[] args)
//        {
//            try
//            {
//                using (StreamReader reader = new StreamReader("info.txt"))
//                {
//                    string firstLine = reader.ReadLine();

//                    Console.WriteLine(firstLine);
//                }
//            }
//            catch (IOException)
//            {
//                Console.WriteLine("Error reading file");
//            }
//        }
//    }
//}

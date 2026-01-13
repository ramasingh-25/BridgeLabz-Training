//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Text;

//namespace BridgeLabzDSA.Stringbulider
//{
//    internal class StringBuilderPerformance
//    {
       
//       public static void Main()

//        {

//            int iterations = 10000;

//            Stopwatch sw1 = Stopwatch.StartNew();
//            string str = "";

//            for (int i = 0; i < iterations; i++)
//            {
//                str += "Hello";
//            }

//            sw1.Stop();
//            Console.WriteLine("String Time: " + sw1.ElapsedMilliseconds + " ms");

            
//            Stopwatch sw2 = Stopwatch.StartNew();
//            StringBuilder sb = new StringBuilder();

//            for (int i = 0; i < iterations; i++)
//            {

//                sb.Append("Hello");
//            }

//            sw2.Stop();
//            Console.WriteLine("StringBuilder Time: " + sw2.ElapsedMilliseconds + " ms");
//        }
//    }



//}


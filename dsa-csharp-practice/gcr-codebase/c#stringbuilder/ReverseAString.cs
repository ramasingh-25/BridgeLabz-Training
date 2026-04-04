//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Stringbulider
//{
//    internal class ReverseAString
//    {
//        public static void Main(string[] args)
//        {
//            string str = "Rama";

//            StringBuilder sb = new StringBuilder(str);

            

//            int l = 0;


//            int r = sb.Length - 1;


//            while (l < r)
//            {

//                char temp = sb[l];

//                sb[l] = sb[r];

//                sb[r] = temp;

//                l++;

//                r--;
//            }

//            Console.WriteLine("Reversed String is: " + sb.ToString());
//        }
//    }
//}

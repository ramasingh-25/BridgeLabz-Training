//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Built_in
//{
//   class LcmGcd
//    {
//        static void Main(String[] args)
//        {
//            //taking a input from user

//            Console.Write("Enter first number ");
//            int a = int.Parse(Console.ReadLine());
//            Console.Write("Enter second number ");
//            int b = int.Parse(Console.ReadLine());
//            Console.WriteLine("GCD: " + GCD(a, b));
//            Console.WriteLine("LCM: " + LCM(a, b));

//        }
//        static int GCD(int a, int b)

//        {
//            while (b != 0)
//            {
//                int temp = b;
//                b = a % b;
//                a = temp;
//            }
//            return a;
//        }
//        static int LCM(int a, int b)
//        {
//            return (a * b) / GCD(a, b);
//        }

        
//    }
//}

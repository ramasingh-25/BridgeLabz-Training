//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Built_in
//{
//  class CheckPrime
//    {
        
//        static void Main()
//        {
//            Console.Write("Enter a number: ");
//            int n = int.Parse(Console.ReadLine());
//            if (IsPrime(n))
//                Console.WriteLine("Prime Number");
//            else
//                Console.WriteLine("Not a Prime Number");
//        }
//        static bool IsPrime(int n)
//        {
//            if (n <= 1) return false;

//            for (int i = 2; i <= n / 2; i++)
//            {
//                if (n % i == 0)
//                    return false;
//            }
//            return true;
//        }

//    }
//}

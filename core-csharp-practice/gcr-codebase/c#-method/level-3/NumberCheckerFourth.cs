//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//     class NumberCheckerFourth
    
//        {

//        // method 
//        static bool IsPrime(int n)
//        {
//            if (n <= 1) return false;
//            for (int i = 2; i <= n / 2; i++)
//            {
//                if (n % i == 0) return false;
//            }
//            return true;
//        }

//        static bool IsNeon(int n)
//        {
//            int square = n * n;
//            int sum = 0;
//            while (square > 0)
//            {
//                sum += square % 10;
//                square /= 10;
//            }
//            return sum == n;
//        }

//        static bool IsSpy(int n)
//        {
//            int sum = 0;
//            int product = 1;
//            int temp = n;
//            while (temp > 0)
//            {
//                int digit = temp % 10;
//                sum += digit;
//                product *= digit;
//                temp /= 10;
//            }
//            return sum == product;
//        }

//        static bool IsAutomorphic(int n)
//        {


//            int square = n * n;
            
//            string sqStr = square.ToString();   // Check if square ends with n
//            string nStr = n.ToString();
//            return sqStr.EndsWith(nStr);


//        }

//        static bool IsBuzz(int n)
//        {
//            return (n % 7 == 0 || n % 10 == 7);
//        }
//        public static void Main(string[] args)
//            {
//                Console.Write("Enter a number: ");
//                int number = int.Parse(Console.ReadLine());



//                if (IsPrime(number)) Console.WriteLine("Is Prime: Yes");
//                else Console.WriteLine("Is Prime: No");

//                if (IsNeon(number)) Console.WriteLine("Is Neon: Yes");
//                else Console.WriteLine("Is Neon: No");

//                if (IsSpy(number)) Console.WriteLine("Is Spy: Yes");
//                else Console.WriteLine("Is Spy: No");

//                if (IsAutomorphic(number)) Console.WriteLine("Is Automorphic: Yes");
//                else Console.WriteLine("Is Automorphic: No");

//                if (IsBuzz(number)) Console.WriteLine("Is Buzz: Yes");
//                else Console.WriteLine("Is Buzz: No");


//            }

            
//        }
//    }



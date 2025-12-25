//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{

//     class ComparingNaturalNumbers
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("Enter a natural number: ");
//            int n = Convert.ToInt32(Console.ReadLine());


//            if (n < 0)
//            {
//                Console.WriteLine("Please enter a valid natural number.");
//                return;
//            }

//            int recursiveSum = SumUsingRecursion(n);
//            int formulaSum = SumUsingFormula(n);

//            Console.WriteLine("Sum using recursion: " + recursiveSum);
//            Console.WriteLine("Sum using formula: " + formulaSum);

            
//            if (recursiveSum == formulaSum)
//            {
//                Console.WriteLine("Both results are correct and equal.");
//            }
//            else
//            {
//                Console.WriteLine("Results are not equal.");
//            }
//        }
       
//        public static int SumUsingRecursion(int n)     // calculate sum using recursion
//        {
//            if (n == 0)
//                return 0;

//            return n + SumUsingRecursion(n - 1);
//        }

            
//            public static int SumUsingFormula(int n)   // calculate sum using formula
//        {
//                return (n * (n + 1)) / 2;
//            }

           
//        }
//    }


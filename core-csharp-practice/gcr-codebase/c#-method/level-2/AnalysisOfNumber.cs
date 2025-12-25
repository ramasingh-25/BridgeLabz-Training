//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//   class AnalysisOfNumber
//    {
//        static void Main(string[] args)
//        {
//            int[] numbers = new int[5];


//            for (int i = 0; i < numbers.Length; i++)
//            {
//                Console.Write("Enter number " + (i + 1) + ": ");
//                numbers[i] = Convert.ToInt32(Console.ReadLine());
//            }

//            Console.WriteLine();

            
//            for (int i = 0; i < numbers.Length; i++)
//            {
//                if (IsPositive(numbers[i]))
//                {
//                    if (IsEven(numbers[i]))
//                    {
//                        Console.WriteLine(numbers[i] + " is Positive and Even");
//                    }
//                    else
//                    {
//                        Console.WriteLine(numbers[i] + " is Positive and Odd");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine(numbers[i] + " is Negative");
//                }
//            }

//            Console.WriteLine();

//            // Comparing first and last elements
//            int comparisonResult = Compare(numbers[0], numbers[numbers.Length - 1]);

//            if (comparisonResult == 1)
//            {
//                Console.WriteLine("First element is greater than the last element");
//            }
//            else if (comparisonResult == 0)
//            {
//                Console.WriteLine("First and last elements are equal");
//            }
//            else
//            {
//                Console.WriteLine("First element is less than the last element");
//            }
//        }

//        public static bool IsPositive(int number)
//        {
//            return number >= 0;
//        }

//            public static bool IsEven(int number)
//            {
//                return number % 2 == 0;
//            }

//            public static int Compare(int number1, int number2)
//            {
//                if (number1 > number2)
//                    return 1;
//                else if (number1 == number2)
//                    return 0;
//                else
//                    return -1;
//            }

           
//        }
//    }



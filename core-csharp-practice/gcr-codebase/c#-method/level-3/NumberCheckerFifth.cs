//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//    class NumberCheckerFifth
//    {
//        static int[] GetFactors(int n)
//        {
//            int count = 0;
//            for (int i = 1; i <= n; i++)
//            {
//                if (n % i == 0) count++;
//            }

//            int[] arr = new int[count];
//            int index = 0;

//            for (int i = 1; i <= n; i++)
//            {
//                if (n % i == 0)
//                {
//                    arr[index] = i;
//                    index++;
//                }
//            }
//            return arr;
//        }

//        static int GetGreatestFactor(int[] factors)
//        {
//            int max = factors[0];
//            for (int i = 1; i < factors.Length; i++)
//            {
//                if (factors[i] > max) max = factors[i];
//            }
//            return max;
//        }

//        static int GetSumFactors(int[] factors)
//        {
//            int sum = 0;
//            for (int i = 0; i < factors.Length; i++)
//            {
//                sum += factors[i];
//            }
//            return sum;
//        }

//        static long GetProductFactors(int[] factors)
//        {
//            long prod = 1;
//            for (int i = 0; i < factors.Length; i++)
//            {
//                prod *= factors[i];
//            }
//            return prod;
//        }

//        static double GetCubeProduct(int[] factors)
//        {
//            double prod = 1;
//            for (int i = 0; i < factors.Length; i++)
//            {
//                prod *= Math.Pow(factors[i], 3);
//            }
//            return prod;
//        }

//        static bool IsPerfect(int n)
//        {
//            int sum = 0;

//            for (int i = 1; i < n; i++)
//            {
//                if (n % i == 0)
//                {
//                    sum += i;
//                }
//            }
//            return sum == n;
//        }
//        public static void Main(string[] args)
//            {
//                Console.Write("Enter a number: ");
//                int number = int.Parse(Console.ReadLine());

//                int[] factors = GetFactors(number);

//                Console.Write("Factors: ");
//                for (int i = 0; i < factors.Length; i++) Console.Write(factors[i] + " ");
//                Console.WriteLine();

//                Console.WriteLine("Greatest Factor: " + GetGreatestFactor(factors));
//                Console.WriteLine("Sum of Factors: " + GetSumFactors(factors));
//                Console.WriteLine("Product of Factors: " + GetProductFactors(factors));
//                Console.WriteLine("Product of Cube of Factors: " + GetCubeProduct(factors));

//                if (IsPerfect(number))
//                    Console.WriteLine(number + " is a Perfect Number.");
//                else
//                    Console.WriteLine(number + " is NOT a Perfect Number.");
//            }

            
//        }
//    }



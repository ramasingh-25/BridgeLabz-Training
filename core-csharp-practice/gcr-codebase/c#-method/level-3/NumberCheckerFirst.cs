//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//     class NumberCheckerFirst
//    {
//            static bool IsDuckNumber(int[] digits)
//            {

//                //iterating for loop to find digit length

//                for (int i = 0; i < digits.Length; i++)
//                {
//                    if (digits[i] == 0) return true;
//                }
//                return false;
//            }

               

//            static bool IsArmstrong(int originalNum, int[] digits)
//            {   
//                double sum = 0;
//                int power = digits.Length;
//                for (int i = 0; i < digits.Length; i++)
//                {
//                    sum = sum + Math.Pow(digits[i], power);
//                }
//                return sum == originalNum;
//            }
//        //method to find largest and second largest


//            static void FindLargestAndSecondLargest(int[] digits)
//            {
//                int max = Int32.MinValue;
//                int secondMax = Int32.MinValue;

//                for (int i = 0; i < digits.Length; i++)
//                {
//                    if (digits[i] > max)
//                    {
//                        secondMax = max;
//                        max = digits[i];
//                    }
//                    else if (digits[i] > secondMax && digits[i] != max)
//                    {
//                        secondMax = digits[i];
//                    }
//                }
//                Console.WriteLine("Largest Digit: " + max);


//                Console.WriteLine("Second Largest Digit: " + secondMax);


//            }

//            static void FindSmallestAndSecondSmallest(int[] digits)
//            {
//                int min = Int32.MaxValue;
//                int secondMin = Int32.MaxValue;

//                for (int i = 0; i < digits.Length; i++)
//                {
//                    if (digits[i] < min)
//                    {
//                        secondMin = min;
//                        min = digits[i];
//                    }
//                    else if (digits[i] < secondMin && digits[i] != min)
//                    {
//                        secondMin = digits[i];
//                    }
//                }
//                Console.WriteLine("Smallest Digit: " + min);
//                Console.WriteLine("Second Smallest Digit: " + secondMin);
//            }
//        public static void Main(string[] args)
//        {
//            Console.Write("Enter a number: ");
//            int number = int.Parse(Console.ReadLine());

//            int count = DigitCount(number);
//            int[] digits = DigitsArray(number, count);

//            if (IsDuckNumber(digits))
//                Console.WriteLine("It is a Duck Number.");
//            else
//                Console.WriteLine("It is not a Duck Number.");

//            if (IsArmstrong(number, digits))
//                Console.WriteLine("It is an Armstrong Number.");
//            else
//                Console.WriteLine("It is not an Armstrong Number.");

//            FindLargestAndSecondLargest(digits);
//            FindSmallestAndSecondSmallest(digits);
//        }

//        static int DigitCount(int n)
//        {
//            int count = 0;
//            int temp = n;
//            while (temp > 0)
//            {
//                temp = temp / 10;
//                count++;
//            }
//            return count;
//        }

//        static int[] DigitsArray(int n, int count)
//        {
//            int[] arr = new int[count];
//            int temp = n;
//            for (int i = count - 1; i >= 0; i--)
//            {
//                arr[i] = temp % 10;
//                temp = temp / 10;
//            }
//            return arr;
//        }

//    }
//    }




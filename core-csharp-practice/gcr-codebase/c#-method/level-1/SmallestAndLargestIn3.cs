//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//    class SmallestAndLargestIn3
//    {

//        public static int[] FindSmallestAndLargest(int number1, int number2, int number3)
//        {
//            int smallest = number1;
//            int largest = number1;

//            if (number2 < smallest)
//                smallest = number2;

//            if (number3 < smallest)
//                smallest = number3;

//            if (number2 > largest)
//                largest = number2;

//            if (number3 > largest)
//                largest = number3;

//            return new int[] { smallest, largest };

//        }

    

//    static void Main(string[] args)
//        {

//            //taking inputs from user 


//            Console.Write("Enter first number: ");
//            int num1 = int.Parse(Console.ReadLine());

//            Console.Write("Enter second number: ");
//            int num2 = int.Parse(Console.ReadLine());

//            Console.Write("Enter third number: ");
//            int num3 = int.Parse(Console.ReadLine());

//            int[] result = FindSmallestAndLargest(num1, num2, num3);

//            Console.WriteLine("Smallest number :" + result[0]);
//            Console.WriteLine("Largest number :" +result[1]);
//        }
//    }
//}

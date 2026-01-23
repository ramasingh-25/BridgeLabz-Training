//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.Exception
//{
//    internal class NestedTryCatch
//    {
//        static void Main(string[] args)
//        {
//            int[] numbers = { 10, 20, 30, 40, 50 };

//            try
//            {
//                Console.Write("Enter array index: ");
//                int index = Convert.ToInt32(Console.ReadLine());

//                try
//                {
//                    Console.Write("Enter divisor: ");
//                    int divisor = Convert.ToInt32(Console.ReadLine());

//                    int result = numbers[index] / divisor;
//                    Console.WriteLine("Result: " + result);
//                }
//                catch (DivideByZeroException)
//                {
//                    Console.WriteLine("Cannot divide by zero!");
//                }
//            }
//            catch (IndexOutOfRangeException)
//            {
//                Console.WriteLine("Invalid array index!");
//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("Please enter valid integers.");
//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.Exception
//{
//    internal class HandlingDivisionAndInputErrors
//    {
//        public static void Main(string[] args)
//        {
//            try
//            {
//                Console.Write("Enter first number: ");
//                int n1 = int.Parse(Console.ReadLine());

//                Console.Write("Enter second number: ");
//                int n2 = int.Parse(Console.ReadLine());

//                int result = n1 / n2;
//                Console.WriteLine("Result: " + result);
//            }


//            catch (DivideByZeroException)
//            {
//                Console.WriteLine("Cannot divide by zero");
//            }



//            catch (FormatException)
//            {
//                Console.WriteLine("Please enter valid numeric values");
//            }


//        }
//    }
//}

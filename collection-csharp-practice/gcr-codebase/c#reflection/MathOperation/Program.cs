//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

//namespace Project5.Reflection.MathOperation
//{
//    internal class Program
//    {
       
//        static void Main()
//        {
//            MathOperation math = new MathOperation();
//            Type type = typeof(MathOperation);

//            Console.Write("Enter method name (Add / Subtract / Multiply): ");
//            string methodName = Console.ReadLine();

//            Console.Write("Enter first number: ");
//            int a = int.Parse(Console.ReadLine());

//            Console.Write("Enter second number: ");
//            int b = int.Parse(Console.ReadLine());

//            // Get method dynamically
//            MethodInfo method = type.GetMethod(methodName);

//            if (method == null)
//            {
//                Console.WriteLine("Invalid method name!");
//                return;
//            }

//            // Invoke method dynamically
//            object result = method.Invoke(math, new object[] { a, b });

//            Console.WriteLine($"Result: {result}");
//        }
//    }

//}

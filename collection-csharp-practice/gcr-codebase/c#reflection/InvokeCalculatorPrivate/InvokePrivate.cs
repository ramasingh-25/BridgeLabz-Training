//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Text;

//namespace Project5.Reflection.InvokeCalculatorPrivate
//{
//    internal class InvokePrivate
//    {
        
//        static void Main()
//        {
//            Calculator calculator = new Calculator();

//            // Get type information
//            Type type = typeof(Calculator);

//            // Get private method 'Multiply'
//            MethodInfo multiplyMethod = type.GetMethod(
//                "Multiply",
//                BindingFlags.NonPublic | BindingFlags.Instance
//            );

//            // Invoke private method
//            object result = multiplyMethod.Invoke(
//                calculator,
//                new object[] { 5, 4 }
//            );

//            Console.WriteLine("Result of Multiply (via Reflection): " + result);
//        }
//    }

//}


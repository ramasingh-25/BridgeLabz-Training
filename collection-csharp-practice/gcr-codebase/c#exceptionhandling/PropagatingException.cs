//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.Exception
//{
//    internal class PropagatingException
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                Method2();
//            }
//            catch (ArithmeticException)
//            {
//                Console.WriteLine("Handled exception in Main");
//            }
//        }

//        static void Method2()
//        {
//            Method1(); // No try-catch here → exception propagates
//        }

//        static void Method1()
//        {
//            int result = 10 / 0; // Throws ArithmeticException
//            Console.WriteLine(result);
//        }
//    }
//}

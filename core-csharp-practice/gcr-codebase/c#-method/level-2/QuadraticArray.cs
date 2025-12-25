//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//    internal class QuadraticArray
    
//        {
//        static void Main(string[] args)
//        {
//            Console.Write("Enter value of a: ");
//            double a = Convert.ToDouble(Console.ReadLine());

//            Console.Write("Enter value of b: ");
//            double b = Convert.ToDouble(Console.ReadLine());

//            Console.Write("Enter value of c: ");
//            double c = Convert.ToDouble(Console.ReadLine());

//            double[] roots = FindRoots(a, b, c);

//            if (roots.Length == 0)
//            {
//                Console.WriteLine("No real roots exist.");
//            }
//            else if (roots.Length == 1)
//            {
//                Console.WriteLine("Only one root exists: " + roots[0]);
//            }
//            else
//            {
//                Console.WriteLine("Root 1: " + roots[0]);
//                Console.WriteLine("Root 2: " + roots[1]);
//            }
//        }
//        // find roots of quadratic equation
//        public static double[] FindRoots(double a, double b, double c)
//            {
//                // Calculate discriminant (delta)
//                double delta = Math.Pow(b, 2) - 4 * a * c;

//                // If delta is negative → no real roots
//                if (delta < 0)
//                {
//                    return new double[0]; // empty array
//                }

//                // If delta is zero → one root
//                if (delta == 0)
//                {
//                    double root = -b / (2 * a);
//                    return new double[] { root };
//                }
//                double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
//                double root2 = (-b - Math.Sqrt(delta)) / (2 * a);

//                return new double[] { root1, root2 };
//            }

            
//        }
//    }



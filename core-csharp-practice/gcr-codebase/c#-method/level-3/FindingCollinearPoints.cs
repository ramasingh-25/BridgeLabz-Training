//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//    class CollinearPoints
//    {


//        static bool CheckCollinearBySlope(double x1, double y1, double x2, double y2, double x3, double y3)
//        {
//            double slopeAB = (y2 - y1) / (x2 - x1);// Calculate slope AB = (y2 - y1) / (x2 - x1)

//            double slopeBC = (y3 - y2) / (x3 - x2);// Calculate slope BC = (y3 - y2) / (x3 - x2)

//            double slopeAC = (y3 - y1) / (x3 - x1);// Calculate slope AC = (y3 - y1) / (x3 - x1)


//            Console.WriteLine("Slope AB: {0:F2}", slopeAB);// Display the slopes
//            Console.WriteLine("Slope BC: {0:F2}", slopeBC);
//            Console.WriteLine("Slope AC: {0:F2}", slopeAC);


//            double tolerance = 0.0001;
//            bool ab_bc_equal = Math.Abs(slopeAB - slopeBC) < tolerance;
//            bool bc_ac_equal = Math.Abs(slopeBC - slopeAC) < tolerance;
//            bool ab_ac_equal = Math.Abs(slopeAB - slopeAC) < tolerance;

//            return ab_bc_equal && bc_ac_equal && ab_ac_equal;
//        }


//        static bool CheckCollinearByArea(double x1, double y1, double x2, double y2, double x3, double y3)
//        {


//            double area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));  // area = 0.5 * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2))


//            Console.WriteLine("Area of triangle: {0:F4}", area);  // Display the area



//            double tolerance = 0.0001;
//            return Math.Abs(area) < tolerance;
//        }

//        static void Main()
//        {


//            // Taking 3 inputs from user

//            Console.WriteLine("Enter coordinates for Point A:");
//            Console.Write("Enter x1: ");
//            double x1 = double.Parse(Console.ReadLine());

//            Console.Write("Enter y1: ");
//            double y1 = double.Parse(Console.ReadLine());

//            Console.WriteLine("\nEnter coordinates for Point B:");
//            Console.Write("Enter x2: ");
//            double x2 = double.Parse(Console.ReadLine());

//            Console.Write("Enter y2: ");
//            double y2 = double.Parse(Console.ReadLine());

//            Console.WriteLine("\nEnter coordinates for Point C:");
//            Console.Write("Enter x3: ");
//            double x3 = double.Parse(Console.ReadLine());

//            Console.Write("Enter y3: ");
//            double y3 = double.Parse(Console.ReadLine());

            
//            Console.WriteLine("\n--- Checking Collinearity ---");  // Display the points

//            Console.WriteLine("Point A: ({0}, {1})", x1, y1);
//            Console.WriteLine("Point B: ({0}, {1})", x2, y2);
//            Console.WriteLine("Point C: ({0}, {1})", x3, y3);


//            bool isSlopeCollinear = CheckCollinearBySlope(x1, y1, x2, y2, x3, y3);
//            Console.WriteLine("\n--- Method 1: Slope Formula ---");
//            if (isSlopeCollinear)
//            {
//                Console.WriteLine("The points A, B, and C are COLLINEAR (using slope method)");
//            }
//            else
//            {
//                Console.WriteLine("The points A, B, and C are NOT COLLINEAR (using slope method)");
//            }


//            bool isAreaCollinear = CheckCollinearByArea(x1, y1, x2, y2, x3, y3);
//            Console.WriteLine("\n--- Method 2: Area of Triangle Formula ---");
//            if (isAreaCollinear)
//            {
//                Console.WriteLine("The points A, B, and C are COLLINEAR (using area method)");
//            }
//            else
//            {
//                Console.WriteLine("The points A, B, and C are NOT COLLINEAR (using area method)");

//            }
//        }
//    }
//}


    


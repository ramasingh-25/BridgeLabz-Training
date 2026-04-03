//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//  class ConvertingUnits
    
//    {
//        public class UnitConvertor
//        {
            
//            public static double ConvertYardsToFeet(double yards)   // a. Convert yards to feet
//            {
//                double yards2feet = 3;
//                return yards * yards2feet;
//            }

            
//            public static double ConvertFeetToYards(double feet)   // b. Convert feet to yards
//            {
//                double feet2yards = 0.333333;
//                return feet * feet2yards;
//            }

            
//            public static double ConvertMetersToInches(double meters)// c. Convert meters to inches
//            {
//                double meters2inches = 39.3701;
//                return meters * meters2inches;
//            }

            
//            public static double ConvertInchesToMeters(double inches)   // d. Convert inches to meters
//            {
//                double inches2meters = 0.0254;
//                return inches * inches2meters;
//            }

//            public static double ConvertInchesToCentimeters(double inches)
//            // e. Convert inches to centimeters
//            {
//                double inches2cm = 2.54;
//                return inches * inches2cm;
//            }

//            // Main method
//            static void Main(string[] args)
//            {



//                //taking inputs from user
//                Console.Write("Enter value in yards: ");
//                double yards = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Yards to Feet: " + ConvertYardsToFeet(yards));

//                Console.Write("Enter value in feet: ");
//                double feet = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Feet to Yards: " + ConvertFeetToYards(feet));

//                Console.Write("Enter value in meters: ");
//                double meters = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Meters to Inches: " + ConvertMetersToInches(meters));

//                Console.Write("Enter value in inches: ");
//                double inches = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Inches to Meters: " + ConvertInchesToMeters(inches));
//                Console.WriteLine("Inches to Centimeters: " + ConvertInchesToCentimeters(inches));
//            }
//        }
//    }

//}


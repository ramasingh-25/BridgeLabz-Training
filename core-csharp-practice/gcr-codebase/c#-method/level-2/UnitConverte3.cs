//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//    class UnitConverte3
//    { 
        
           
//            public static double ConvertFarhenheitToCelsius(double farhenheit)
//            {
//                double farhenheit2celsius = (farhenheit - 32) * 5 / 9;
//                return farhenheit2celsius;
//            }

            
//            public static double ConvertCelsiusToFarhenheit(double celsius)
//            {
//                double celsius2farhenheit = (celsius * 9 / 5) + 32;
//                return celsius2farhenheit;
//            }

            
//            public static double ConvertPoundsToKilograms(double pounds)
//            {
//                double pounds2kilograms = 0.453592;
//                return pounds * pounds2kilograms;
//            }

//            public static double ConvertKilogramsToPounds(double kilograms)
//            {
//                double kilograms2pounds = 2.20462;
//                return kilograms * kilograms2pounds;
//            }

            
//            public static double ConvertGallonsToLiters(double gallons)
//            {
//                double gallons2liters = 3.78541;
//                return gallons * gallons2liters;
//            }

           
//            public static double ConvertLitersToGallons(double liters)
//            {
//                double liters2gallons = 0.264172;
//                return liters * liters2gallons;
//            }

//            static void Main(string[] args)
//            {

//            //taking inputs
//                Console.Write("Enter temperature in Fahrenheit: ");
//                double f = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Fahrenheit to Celsius: " + ConvertFarhenheitToCelsius(f));

//                Console.Write("Enter temperature in Celsius: ");
//                double c = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Celsius to Fahrenheit: " + ConvertCelsiusToFarhenheit(c));

//                Console.Write("Enter weight in pounds: ");
//                double pounds = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Pounds to Kilograms: " + ConvertPoundsToKilograms(pounds));

//                Console.Write("Enter weight in kilograms: ");
//                double kg = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Kilograms to Pounds: " + ConvertKilogramsToPounds(kg));

//                Console.Write("Enter volume in gallons: ");
//                double gallons = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Gallons to Liters: " + ConvertGallonsToLiters(gallons));

//                Console.Write("Enter volume in liters: ");
//                double liters = Convert.ToDouble(Console.ReadLine());
//                Console.WriteLine("Liters to Gallons: " + ConvertLitersToGallons(liters));
//            }
//        }
//    }



//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//     class NumberOfRounds
//    {


//         static void Main(string[] args)
//        {

            
//            Console.WriteLine("Enter first side");  //taking inputs of 3 sides from user
//            double side1 = Convert.ToDouble(Console.ReadLine());

//            Console.WriteLine("Enter second side");
//            double side2 = Convert.ToDouble(Console.ReadLine());

//            Console.WriteLine("Enter third side");

//            double side3 = Convert.ToDouble(Console.ReadLine());


//            double rounds = CalculateNoofRounds(side1, side2, side3);  



//            Console.WriteLine($"The athlete needs to complete {rounds} rounds to finish a 5 km run.");


//        }

//        static double CalculateNoofRounds(double s1, double s2, double s3)
//        {


//            double perimeter = s1 + s2 + s3;


//            // 5 km in meters

//            double GivenDistance = 5000;        
//            return GivenDistance / perimeter;



//        }
//    }
//}
    

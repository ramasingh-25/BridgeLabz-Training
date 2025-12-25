//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//     class DistributionOfChoclate
//    {

//        public static void Main(string[] args)
//        {

//            Console.WriteLine("Enter No of Choclate");

//            int numberOfChoclate = int.Parse(Console.ReadLine());    //input number of child


//            Console.WriteLine("Enter No of Childern");

//            int numberOfChildren = int.Parse(Console.ReadLine());

//            int[] result = chocolatecalculation(numberOfChoclate, numberOfChildren);

//            Console.WriteLine("Each child will get " + result[0] + " chocolates");   //printing the values
//            Console.WriteLine("Remaining chocolates = " + result[1]);

//}

//        public static int[] chocolatecalculation(int number, int divisor)
//        {
            
//            int q = number / divisor;   // Chocolates per child

            
//            int r = number % divisor;  //calculate remaining chocolates


//            return new int[] { q, r };
//        }
//    }
//}
    

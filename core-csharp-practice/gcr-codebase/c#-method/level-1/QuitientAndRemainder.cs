//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//   class QuitientAndRemainder
//    {


//       //main method
//        public static void Main(string[] args)


//        {
//            //taking input from user

//            Console.WriteLine("Enter number");
//            int num = Convert.ToInt32(Console.ReadLine());

//            Console.WriteLine("Enter Divisor");
//            int divsior = Convert.ToInt32(Console.ReadLine());

//            int[] result = FindQuotientReminder(num, divsior);

//            Console.WriteLine("Quotient = " + result[0]);
//            Console.WriteLine("Remainder = " + result[1]);


//        }
//        // method to calculate qutient and remainder
//        static int[] FindQuotientReminder(int n, int d)
//        {
//            int quotient = n / d;
//            int remainder = n % d;

//            return new int[] { quotient, remainder };


//        }
//    }
//}
    

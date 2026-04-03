//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Project1.array
//{
//    public class YoungestAndTallestFriend
//    {
//        public static void Main(string[] args)
//        {
//            //Three Friends
//            string[] Friends = { "Amar", "Akbar", "Anthony" };
//            for (int i = 0; i < Friends.Length; i++)
//            {
//                Console.WriteLine(Friends[i]);
//            }

//            //age array
//            int[] age = new int[3];

//            //height array
//            double[] height = new double[3];

//            //taking input 
//            for (int i = 0; i < Friends.Length; i++)
//            {

//                Console.Write($"Enter detail of {Friends[i]}");

//                Console.Write("\nEnter age");
//                age[i] = Convert.ToInt32(Console.ReadLine());

//                Console.Write("\nEnter height");
//                height[i] = Convert.ToDouble(Console.ReadLine());


//            }


//            int YoungestIndex = 0;
//            int TallestIndex = 0;

//            for (int i = 1; i < 3; i++)
//            {
//                if (age[i] < age[YoungestIndex])
//                    YoungestIndex = i;

//                if (height[i] > height[TallestIndex])
//                    TallestIndex = i;
//            }
//            Console.WriteLine("Youngest Friend  is: " + Friends[YoungestIndex]);
//            Console.WriteLine("Tallest Friend  is: " + Friends[TallestIndex]);



//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//    class FootBallTeam
//    {
        
           

//            static double Mean(int sum, int count)
//            {
//                return (double)sum / count;
//            }


//        static int Sum(int[] arr)
//        {
//            int sum = 0;
//            for (int i = 0; i < arr.Length; i++)
//            {
//                sum = sum + arr[i];
//            }
//            return sum;


//        }


//        static int Shortest(int[] arr)
//            {
//                int min = arr[0];
//                for (int i = 1; i < arr.Length; i++)
//                {
//                    if (arr[i] < min)
//                    {
//                        min = arr[i];
//                    }
//                }
//                return min;

//            }

//            static int Tallest(int[] arr)
//            {
//                int max = arr[0];
//                for (int i = 1; i < arr.Length; i++)
//                {
//                    if (arr[i] > max)
//                    {
//                        max = arr[i];
//                    }
//                }
//                return max;
//            }
//        public static void Main(string[] args)
//        {
//            int[] heights = new int[11];


//            Random rand = new Random();


//            Console.WriteLine("Generating heights for 11 players...");
//            for (int i = 0; i < heights.Length; i++)
//            {
//                heights[i] = rand.Next(150, 251);


//                Console.Write(heights[i] + " ");
//            }
//            Console.WriteLine();

//            int sum = Sum(heights);
//            double mean = Mean(sum, heights.Length);
//            int shortest = Shortest(heights);
//            int tallest = Tallest(heights);

//            Console.WriteLine("Sum of heights: " + sum);
//            Console.WriteLine("Mean height: " + mean);
//            Console.WriteLine("Shortest player: " + shortest);
//            Console.WriteLine("Tallest player: " + tallest);
//        }

//    }
//}



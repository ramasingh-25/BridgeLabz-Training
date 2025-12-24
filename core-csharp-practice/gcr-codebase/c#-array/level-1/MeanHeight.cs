using System;

namespace project1.array
{
    public class MeanHeight
    {

        public static void Main()

        {
            // initializing height array
            double[] height = new double[11];
            double sum = 0.0;

            for (int i = 0; i < height.Length; i++)
            {
                Console.Write("Enter height " + (i + 1) + ": ");
                height[i] = Convert.ToDouble(Console.ReadLine());  //taking inputs from user
            }
            // iterating 
            for (int i = 0; i < height.Length; i++)
            {
                sum += height[i];
            }

            double mean = sum / height.Length;
            //printing the value
            Console.WriteLine("Mean height of the football team is: " + mean);
        }
    }
}
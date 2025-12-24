using System;
using System.Collections.Generic;
using System.Text;

namespace project1.array
{
    public class TwoDArray
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of rows :");

            //taking input from user

            int rows = int.Parse(Console.ReadLine());

            Console.Write("Enter number of columns :");

            int columns = int.Parse(Console.ReadLine());


            //storing Two Dimensional array


            int[,] array_two_d = new int[rows, columns];
            Console.WriteLine("Enter the elements of 2D array :");

            //iterating

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array_two_d[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            int[] array_one_d = new int[rows * columns];
            //initializing index

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array_one_d[index] = array_two_d[i, j];
                    index++;
                }
            }
            //storing value
            for (int i = 0; i < array_one_d.Length; i++)
            {
                Console.WriteLine(array_one_d[i] + " ");
            }


        }
    }
}

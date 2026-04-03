using System;
using System.Collections.Generic;
using System.Text;

namespace project1.array
{
      class OddEvenArray
    {
        static void Main(string[] args)
        {

            // Taking input from user

            Console.Write("Enter a natural number: ");

            int number = int.Parse(Console.ReadLine());

            // checking number is zero
            if (number <= 0)
            {

                Console.WriteLine("Error: Please enter a natural number.");
                return;


            }


            
            int size = number / 2 + 1;     // Create arrays with given size


            int[] odd = new int[size];

            int[] even = new int[size];

            // Index variables
            int oddIndex = 0;
            int evenIndex = 0;

            // Loop from 1 to number
            for (int i = 1; i <= number; i++)
            {
                if (i % 2 == 0)
                {
                    even[evenIndex] = i;
                    evenIndex++;
                }
                else
                {
                    odd[oddIndex] = i;
                    oddIndex++;
                }
            }

            //it will print odd number


            Console.WriteLine("\nOdd Numbers:");
            for (int i = 0; i < oddIndex; i++)
            {
                Console.Write(odd[i] + " ");
            }

            //it will print even number

            Console.WriteLine("\n\nEven Numbers:");
            for (int i = 0; i < evenIndex; i++)
            {
                Console.Write(even[i] + " ");
            }
        }

    }
}

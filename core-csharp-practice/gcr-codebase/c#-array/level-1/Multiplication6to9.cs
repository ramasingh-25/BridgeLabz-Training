using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace project1.array
{

     class Multiplication6to9
    {

        static void Main()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());  //taking user input

            int[] multiplication = new int[4];

//  Initializing index variable
            int ind = 0;

            for (int i = 6; i <= 9; i++)
            {
                multiplication[ind] = number * i;
                ind++;
                 
            }

            
            Console.WriteLine("Multiplication Table:");

            
          // printing six to nine 
            ind= 0;
            for (int i = 6; i <= 9; i++)
            {

                Console.WriteLine(number + " * " + i + " = " + multiplication[ind]);
                ind++;
            }
        }
    }

}


using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Project1.array
{
     class LargestAndSecondLargest
    {
        static void Main()
        {
            Console.WriteLine("Enter the size of the array");

            int n = int.Parse(Console.ReadLine());   //taking input from user
            int[] arr = new int[n];

            Console.WriteLine("Enter the digits");



            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            
            int largest = arr[0];
            int secondLargest = arr[1];
            //condition for largest and second largest
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > largest)
                {
                    secondLargest = largest;
                    largest = arr[i];
                }
                else if (arr[i] > secondLargest && arr[i] != largest)
                {
                    secondLargest = arr[i];
                }
            }


            
            Console.WriteLine("The largest is " + largest);   //largest

            
            Console.WriteLine("The second largest is " + secondLargest);    //secondLargest







        }
    }
}



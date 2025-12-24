
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Project1.array
{


    public class LargestAndSecondLargestTwo
    {


        static void Main()
        {
            Console.Write("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int maxDigit = 10;
            int[] arr = new int[maxDigit];
            int index = 0;

            //by two pointer

            while (number != 0)
            {
                if (index == maxDigit)
                {
                    maxDigit = maxDigit + 10;

                    int[] temp = new int[maxDigit];




                    for (int i = 0; i < arr.Length; i++)
                    {
                        temp[i] = arr[i];
                    }
                    //assigning new array


                    arr = temp; 
                }

                arr[index] = number % 10;



                number = number / 10;

                index++;



            }


            int largest = arr[0];
            int secondLargest = arr[1];
//iterating over the for loop for largest and second largest

            for (int i = 1; i < maxDigit; i++)
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


           
            Console.WriteLine("The largest is " + largest);    //largest

            
            Console.WriteLine("The second largest is " + secondLargest);    // secondLargest



        }
    }
}

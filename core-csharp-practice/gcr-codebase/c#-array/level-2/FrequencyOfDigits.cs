using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.array
{
    public class FrequencyOfDigits
    {

        public static void Main(string[] args)


        {
            Console.Write("Enter a number: ");


            string n = Console.ReadLine();    //Taking inputs from user

            // Convert input to integer to remove any leading zeros
            int number = Convert.ToInt32(n);

            // Count digits in the number
            int temp = number;
            int count = 0;

            while (temp > 0)
            {
                count++;
                temp /= 10;
            }


            int[] digits = new int[count];
            temp = number;

            for (int i = count - 1; i >= 0; i--)
            {
                digits[i] = temp % 10;
                temp /= 10;
            }

            int[] frequency = new int[10];

            // Count frequency
            foreach (int digit in digits)
            {
                frequency[digit]++;
            }


            Console.WriteLine("\nDigit Frequencies:");
            for (int i = 0; i < 10; i++)
            {
                if (frequency[i] > 0)
                {
                    Console.WriteLine($"Digit {i}: {frequency[i]} time(s)");
                }
            }
        }
    }
}


using System;

namespace project1.array;

public class StoringSum
{
    static void Main(string[] args)
    {
        double[] numbers = new double[10];
        double total = 0.0;
        int index = 0;


        while (true)
        {
            Console.Write("Enter a number: ");
            double input = Convert.ToDouble(Console.ReadLine());

            if (input <= 0)
            {
                break;
            }

            if (index == 10)
            {
                break;
            }

            numbers[index] = input;
            index++;
        }

        Console.WriteLine("Stored Numbers:");
        for (int i = 0; i < index; i++)
        {
            Console.WriteLine(numbers[i]);
            total += numbers[i];
        }


        Console.WriteLine("Sum of all numbers: " + total);
    }
}

using System;

public class DivisibleByFive
{
   public  static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
		
		
// if condition for divisibility of five

        if (num % 5 == 0)
        {
            Console.WriteLine("Is the number " + num + " divisible by 5? Yes");
        }
        else
        {
            Console.WriteLine("Is the number " + num + " divisible by 5? No");
        }
    }
}
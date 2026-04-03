using System;

public class PositiveNegativeZero
{
	
   public static void Main()
   
    {
	
	
	 //taking inputs from user
	
	
        Console.Write("Enter a number ");
        int number = int.Parse(Console.ReadLine());
		
		
		
		
// condition to check number is positive or negative


        if (number > 0)
        {
            Console.WriteLine("positive");
        }
        else if (number < 0)
        {
            Console.WriteLine("negative");
        }
        else
        {
            Console.WriteLine("zero");
        }
		
		
    }
}
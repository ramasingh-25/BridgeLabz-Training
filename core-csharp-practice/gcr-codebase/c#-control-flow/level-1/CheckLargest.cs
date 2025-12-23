using System;

public class CheckLargest

{
   public static void Main()
	
    {
		
		//taking three inputs from user

		
        Console.Write("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine());
		
       
        Console.Write("Enter second number: ");
        int num2 = int.Parse(Console.ReadLine());
		

        Console.Write("Enter third number: ");
        int num3 = int.Parse(Console.ReadLine());

// comparing between three numbers
        bool firstLargest = (num1 > num2 && num1 > num3);
        bool secondLargest = (num2 > num1 && num2 > num3);
        bool thirdLargest = (num3 > num1 && num3 > num2);
		
		
   // printing output
   
   
        Console.WriteLine("Is the first number the largest? " + firstLargest);
        Console.WriteLine("Is the second number the largest? " + secondLargest);
        Console.WriteLine("Is the third number the largest? " + thirdLargest);
    }
}
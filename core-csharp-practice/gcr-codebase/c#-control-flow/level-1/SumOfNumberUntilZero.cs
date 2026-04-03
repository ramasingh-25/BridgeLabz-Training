using System;

class SumOfNumberUntilZero
{


    static void Main()
	
	
    {
        double total = 0.0;
        double value;
		

        Console.Write("Enter a number press 0 to stop the the program ");
        value = Convert.ToDouble(Console.ReadLine()); //enter a number 
		
		

        while (value != 0)
		
		
        {
            total = total + value;

            Console.Write("Enter a number (0 to stop): ");
            value = Convert.ToDouble(Console.ReadLine()); //keep einput the numbers until 0
        }

        Console.WriteLine("The total is " + total); //result
    }
}
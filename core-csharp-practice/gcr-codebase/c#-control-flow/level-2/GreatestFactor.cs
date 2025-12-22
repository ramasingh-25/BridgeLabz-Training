using System;

class GreatestFactor
{


    static void Main()
    {
	
	
        // input user
		
		
        Console.Write("Enter a number: ");
		
		
        int number = int.Parse(Console.ReadLine());
		

        int greatestFactor = 1;  // initialize with 1

       // for loop
	   
        for (int i = number - 1; i >= 1; i--)
        {
            
			
			
            if (number % i == 0)
            {
			
			
			
                greatestFactor = i;
                break;   // break the loop
            }
        }

        Console.WriteLine("The greatest factor is: " + greatestFactor);
    }
}
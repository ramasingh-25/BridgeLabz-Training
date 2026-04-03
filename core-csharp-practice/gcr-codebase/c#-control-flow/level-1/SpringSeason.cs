using System;

public class SpringSeason
{


   public static void Main(String[] args)
    {
	
	
	// taking inputs from user 
	
	
		Console.WriteLine("Enter month and day");
		
		
        int month = int.Parse(Console.ReadLine());
        int day = int.Parse(Console.ReadLine());
		
		
       //Spring Season is from March 20 to June 20
	   

        if ((month == 3 && day >= 20) ||(month == 4) ||(month == 5) ||(month == 6 && day <= 20))
        {
            Console.WriteLine("Its a Spring Season");
        }
        else
        {
		
            Console.WriteLine("Not a Spring Season");
			
			
        }
    }
}
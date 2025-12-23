using System;

public class HarshadNumber
{
    public static void Main()
    {
	
	
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        
		// intializing variable sum with 0
        int sum = 0;
 
        int orgnum = number;
        
     
        while (number != 0)
        {           
            sum = sum + (number % 10);
            number = number / 10;
        }
        
        if (orgnum % sum == 0)
		
		
        {

		
            Console.WriteLine(orgnum + " is a Harshad Number");
			
			
        }
        else
        {
		
		
            Console.WriteLine(orgnum + " is not a Harshad Number");
        }
        
        Console.ReadLine();
    }
}
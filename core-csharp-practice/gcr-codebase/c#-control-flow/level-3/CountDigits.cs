using System;

public class CountDigits
{
    public static void Main()
    {
       
        Console.Write("Enter a number: ");
		
		
        int number = int.Parse(Console.ReadLine());
        
        
        int count = 0;
		
        //if the number is not equal to zero then it will enter in while loop
        while (number != 0)
        {
            
            number = number / 10;
            
            
            count++;
        }
        
        Console.WriteLine("Number of digits: " + count);
        
        Console.ReadLine();
    }
}
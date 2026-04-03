using System;

public class CounterForLoop
{
    public static void Main()
    {
	
	
	//taking user input
	
	
	
        Console.Write("Enter countdown number");
        int number = int.Parse(Console.ReadLine());
		
		

        for (int i = number; i >= 1; i--)
        {
            Console.WriteLine(i);
        }
    }
}
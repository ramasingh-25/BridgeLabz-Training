using System;

public class SumOfNumber
{
    static void Main(String []args)
	
    {
        double tot = 0.0;
        double value;
		
//taking input from user

        Console.Write("Enter a number press 0 to stop the the program ");
        value = Convert.ToDouble(Console.ReadLine());


//checkin codition to break the statement
        while (true)
        {
			if(value<=0) break;
            tot= tot + value;

            Console.Write("Enter a number (0 to stop): ");
            value = Convert.ToDouble(Console.ReadLine());
			
        }

        Console.WriteLine("The total is " + tot);
    }
}
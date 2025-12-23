using System;

 class AbundantNumberCheck
{
    static void Main()
    {
        Console.WriteLine("Enter the number:");
		
		
        string input = Console.ReadLine();
		
		
        int num = int.Parse(input);
		
		
		//initializing sum variable with zero
		
		
        int sum = 0;
		
		
    //for loop from 1 to num
	
	
	
        for (int i = 1; i < num; i++)
        {
            if (num % i == 0)
            {
                sum += i;
            }
        }
//if condition 
        if (sum > num)
        {
            Console.WriteLine("Abundant Number");
        }
        else
        {
            Console.WriteLine("Not an Abundant Number");
        }
    }
}
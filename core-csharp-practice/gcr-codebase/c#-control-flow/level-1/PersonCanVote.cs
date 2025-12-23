using System;

public class PersonCanVote
{
   public static void Main()
    {
	
	//taking inputs from user
	
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
		
		
    // condition that personis eligible to vote
	
	
        if (age >= 18)
        {
		
		
            Console.WriteLine("The person's age is " + age + " and can vote.");
        }
		
		
        else
        {
            Console.WriteLine("The person's age is " + age + " and cannot vote.");
        }
    }

}

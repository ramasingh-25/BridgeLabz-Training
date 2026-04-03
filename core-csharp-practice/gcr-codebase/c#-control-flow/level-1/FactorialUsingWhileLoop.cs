using System;

public class FactorialUsingWhileLoop{


    public static void Main(){
	
        Console.Write("Enter a number: ");
		
        int num = Convert.ToInt32(Console.ReadLine());
		
		
		
        // Check for positive integer
        if (num <= 0){
		
		
            Console.WriteLine("Please enter a positive integer");
			
            return;
        }
        long factorial = 1;
        int i = 1;
        while (i <= num){
            factorial = factorial * i;
            i++;
        }
        Console.WriteLine("The factorial of " + num + " is " + factorial);
    }
}

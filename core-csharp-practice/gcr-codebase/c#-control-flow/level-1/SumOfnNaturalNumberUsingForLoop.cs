using System;

public class SumOfnNaturalNumberUsingForLoop
{
    public static void Main()
    {
	
	//taking input from user
	
	
        Console.Write("Enter a number ");
		
		
        int num = int.Parse(Console.ReadLine());


        if (num > 0){
			
            int total = 0;
           

            for(int i=1;i <= num;i++)
            {
                total = total+ i;
                
            }
			
			
			//calculating sum of n natural numbers

             
            int sumByFormula = num * (num + 1) / 2;

            Console.WriteLine("Sum using while loop: " + total);
			
			
            Console.WriteLine("Sum using formula: " + sumByFormula);
        
        
            if (total== sumByFormula)
            {
                Console.WriteLine("Both results are correct and equal.");
            }
            else
            {
                Console.WriteLine("Results are not equal.");
            }
        }
        else
        {
            Console.WriteLine("The number " + num + " is not a natural number.");
        }
    }
}
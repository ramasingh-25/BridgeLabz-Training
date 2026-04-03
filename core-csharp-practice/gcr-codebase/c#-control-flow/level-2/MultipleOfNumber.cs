using System;

class MultipleOfNumber


{
    static void Main(String[] args)
    {
	
	
	// taking input from user
        Console.Write("Enter a number: ");
		
		
		
         int number = int.Parse(Console.ReadLine());

      

        // loop start from 100 to 1
		
		// multiple of a number below 100
		
		for (int i = 100; i >= 1; i--)
        {
            
			//if remainder is zero then it is the factor of number
			
			
			if (i % number  == 0)
            {
			
                Console.WriteLine(i);
            }
        }
    }
}
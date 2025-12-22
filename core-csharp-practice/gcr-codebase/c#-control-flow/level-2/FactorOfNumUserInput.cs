using System;

class FactorOfNumUserInput


{
    static void Main(String[] args)
    {
        Console.Write("Enter a number: ");
		
		
		
         int number = int.Parse(Console.ReadLine());

      

        // loop start from 1 to input number
		
		for (int i = 1; i < number; i++)
        {
            
			//if remainder is zero then it is the factor of number
			
			
			if (number % i == 0)
            {
			
                Console.WriteLine(i);
            }
        }
    }
}

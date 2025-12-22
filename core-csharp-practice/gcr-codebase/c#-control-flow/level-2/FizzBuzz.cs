using System;
 
    class FizzBuzz {
	
	
       static void Main() {
        
        Console.Write("Enter the number");
		
		
        int number=Convert.ToInt32(Console.ReadLine());

        
		
		
        if (number <= 0) {    // Check if the number is positive
		
		
            Console.WriteLine("The number must be a positive integer.");
			
			
        }



        // FizzBuzz logic
		
		
        for (int i = 1; i <= number; i++) {
		
            if (i % 3 == 0 && i % 5 == 0) {
			
                Console.WriteLine("FizzBuzz");
            }
			
			
			else if (i % 3 == 0) {
			
                Console.WriteLine("Fizz");
				
				
            }
			
			else if (i % 5 == 0) {
			
              Console.WriteLine("Buzz");
			  
			  
            }
        }


    }
}
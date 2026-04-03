using System;

   public class PowerOfNumber{
   
   
   
         public static void Main(){
		 
		 
            int number = 5;    //integer input


            int power = 3;   // integer input
			
			
            int result = 1;
			
			// loop from 1 to power
			
		
            for (int i =1;i<=power;i++){

             // calculating result
   
   
             result = result*number;
  }
  
  
           Console.WriteLine("Result: " + result);
  
     }
}
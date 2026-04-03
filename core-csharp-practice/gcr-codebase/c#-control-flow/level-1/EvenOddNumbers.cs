using System;
public class EvenOddNumbers{


   public static void Main(string[] args){
	
	
        Console.Write("Enter a number: ");
		
		
        int num = int.Parse(Console.ReadLine());
		
		
        // Check whether the given numvber isnumber
		
		
        if (num <= 0){
            Console.WriteLine("Please enter a natural number");
            return;
        }
        for (int i = 1; i <= num; i++){
            if (i % 2 == 0){
			
			
                Console.WriteLine(i + " is an even number");
            }
			
			
            else{
			
                Console.WriteLine(i + " is an odd number");
            }
        }
    }
}

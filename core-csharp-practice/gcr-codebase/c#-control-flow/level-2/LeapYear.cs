using System;


   class LeapYear {
     static void Main() {
		
	    //taking inputs from user
		
		
        Console.Write("Enter a Year");
		
		
        int year=  int.Parse(Console.ReadLine());

        if(year > 1582){
		
		
		
            
			if(year%4==0 && year%100!=0){   		//A year is a leap year if: It is divisible by 4 and But years not divisible by 100

                
				Console.WriteLine("Leap year");
				
            }
			
			
			else if(year%400==0){
                Console.WriteLine("leap year");
            }
			
			
			else{
             Console.WriteLine("not a leap year");
            }
			
        }
        
    }
}
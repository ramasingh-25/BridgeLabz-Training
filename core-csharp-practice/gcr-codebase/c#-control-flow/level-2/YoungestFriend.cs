using System;


  class YoungestFriend {
  
 
     static void Main(String[] args) {
	 
	 
	

        Console.WriteLine("Enter age of amar:");   // taking inputs of 3 age
        int age1 = Convert.ToInt32(Console.ReadLine());
		
        Console.WriteLine("Enter age of akbar:");
        int age2 = Convert.ToInt32(Console.ReadLine());
		
		
		
        Console.WriteLine("Enter age of anthony:");
		
        int age3 = Convert.ToInt32(Console.ReadLine());



        Console.WriteLine("Enter height of amar:");       // taking the height of 3 friend
        float height1 = Convert.ToSingle(Console.ReadLine());
		
		
		
        Console.WriteLine("Enter height of akbar:");
        float height2 = Convert.ToSingle(Console.ReadLine());
		
		
		
        Console.WriteLine("Enter height of anthony:");
        float height3 = Convert.ToSingle(Console.ReadLine());



        if(age1 < age2 && age1 < age3){
            Console.WriteLine("Youngest Friend is amar");   //comparing age
        }
		
		
		
	    if(age2 < age1 && age2 < age3){
            Console.WriteLine("Youngest Friend is akbar");
			
			
        }
		
		if(age3 < age1 && age3 < age2){
            Console.WriteLine("Youngest Friend is anthony");
        }
		
		

       if(height1 > height2 && height1 > height3){      //comparing Heights
            Console.WriteLine("Tallest Friend is amar");
        }
		
	   else if(height2 > height1 && height2 > height3){
            Console.WriteLine("Tallest Friend is akbar");
        }
		
		else if(height3 > height1 && height3 > height1){
            Console.WriteLine("Tallest Friend is anthony");
        }
		
		
        
    }
}
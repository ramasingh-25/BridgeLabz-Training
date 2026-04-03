using System;

   class SimpleInterest{
   
      static void Main(string[] args){
   
   
   
   // taking inputs from user
        Console.Write("Enter Principal amount ");
        double p = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rate of Interest ");
		
		
		
        double r = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time in years ");
        double t = Convert.ToDouble(Console.ReadLine());


        
		//Simple Interest = (Principal * Rate * Time) / 100  
		
		
        double simpleInterest = (p * r * t) / 100;   //calculating Simple Interest 



        Console.WriteLine("The Simple Interest is " + simpleInterest +    " for Principal " + p +
            ", Rate of Interest " + r +  " and Time " + t  );
    }
}
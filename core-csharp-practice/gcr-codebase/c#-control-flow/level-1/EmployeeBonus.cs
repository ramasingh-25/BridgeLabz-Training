using System;

public class EmployeeBonus{


	public static void Main(){
	
	
		Console.Write("Enter employee salary");
		
		
		//taking input
		
		
		int salary = Convert.ToInt32(Console.ReadLine());
		
		
		Console.Write("Enter years of service");
		
		int yearsOfService = Convert.ToInt32(Console.ReadLine());
		
		// initializing variable bonus 
		
		double bonus =0;
		
		// Zara decided to give a bonus of 5% to employees whose year of service is more than 5 years
		
		if(yearsOfService > 5){
		
			bonus = salary * 0.05;
			
		}
		
		Console.WriteLine("The bonus amount is :" + bonus);
	}
}	
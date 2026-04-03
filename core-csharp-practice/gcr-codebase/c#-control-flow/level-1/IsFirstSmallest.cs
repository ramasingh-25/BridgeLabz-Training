using System;
class IsFirstSmallest{
	static void Main(String []args){
	
	//Taking inputs from user
	
	
		Console.WriteLine("Enter three number"); 
		
		int number1=int.Parse(Console.ReadLine());
		int number2=int.Parse(Console.ReadLine());
		int number3=int.Parse(Console.ReadLine());
		
		// if condition to find largest
		
		
		if(number1<number2&&number1<number3)
		
		{
		
	
		Console.WriteLine(" Is the first number the smallest? Yes");}
		else
		{			
		
		
	Console.WriteLine(" Is the first number the smallest? No");
	
	
		}
		
		
	}
}
using System;


public class MultiplicationTableOfNumber{


	public static void Main(String[] args){
	
		Console.Write("Enter the number");
		
		//taking input from user
		
		
		int number = int.Parse(Console.ReadLine());
		for(int i=6; i<=9;i++){
		
		
			Console.WriteLine(number + " * " + i + " = " +(number * i));
			
			
		}
	}
	
}
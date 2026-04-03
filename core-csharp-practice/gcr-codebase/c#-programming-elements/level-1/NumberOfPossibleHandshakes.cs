using System;

public class NumberOfPossibleHandshakes
{
	static void Main()
	{
	
	//Taking input from User
	
		Console.WriteLine("Enter Number of Students : ");
		int numberOfStudents = Convert.ToInt32(Console.ReadLine());
		
		
		
		//calculating No. of Handshakes
		
		int numberOfHandshakes = (numberOfStudents * (numberOfStudents - 1))/2;
		

		Console.WriteLine("Maximum number of possible handshakes among "+numberOfStudents+" students are "+ numberOfHandshakes);
	}

}
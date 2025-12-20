using System;


public class PerimeterOfSquare
{
	public static void Main()
	{
	
		Console.Write("Enter the side of square :");   

	    int perimeter = Convert.ToInt32(Console.ReadLine());  //taking inputs from user
	    int side  = perimeter/4;     // perimeter = side*4
	    
		
		
		Console.WriteLine("The length of  the side is "+ side + " whose perimeter is "+perimeter);
		
		
	
	}
}
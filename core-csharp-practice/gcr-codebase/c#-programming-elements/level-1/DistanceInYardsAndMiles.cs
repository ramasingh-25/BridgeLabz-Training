using System;

public class DistanceInYardsAndMiles
{
	public static void Main()  
	{
		
		Console.Write("Enter distance in feet :");

		int distanceFeet = Convert.ToInt32(Console.ReadLine());  //taking inputs from user
		
		
		//3feet =1yards
		
		int distanceYards = distanceFeet / 3;   // calculating distance in feet
		int distanceMiles = distanceYards / 1760;   // calculating distance in miles
		
		Console.WriteLine("Distance in feet is "+distanceFeet+" so distance in yard is "+ distanceYards+ " and distance in miles is " + distanceMiles);
	
	}
}
using System;

  class AthleteRoundsTriangularPark{
  
    static void Main(string[] args)  {
	
	   Console.Write("Enter side 1 in meters ");
       double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 2 in meters ");
        double  side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 3 in meters ");
        double side3 = Convert.ToDouble(Console.ReadLine());
		
		
		double perimeter=side1+side2+side3;   //Perimeter of Triangle
		
		double totalDistance=5000; // 5 km = 5000 meters
		
		
       double noOfrounds = totalDistance / perimeter;   		// Number of rounds

	   
	     Console.WriteLine( "The total number of rounds the athlete will run is " +
            noOfrounds + " to complete 5 km"  );
	   
	   
		
	
	
	
	
	
	}}
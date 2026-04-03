using System;
public class AreaOfTriangle{


	public static void Main(String []args){
	
	
		Console.WriteLine("Enter the value of base of triangle"); 
		
		//input the base of trangle
		double baseOf=double.Parse(Console.ReadLine()); 
		
		
		Console.WriteLine("Enter the value of height of triangle");
		
		 //input the height of triangle
		double hei=double.Parse(Console.ReadLine());
		
		//area of trangle is 1/2*base *height 
		
		
		double sqInch= 0.5*baseOf*hei; 
		
		
		double sqcenti=sqInch*6.4516; //1 sqinch=6.4516 sqcenti
		
		
		Console.WriteLine("Area of triangle in square inches is "+sqInch+" and in square centimeters is "+sqcenti);
		
		
	}
}
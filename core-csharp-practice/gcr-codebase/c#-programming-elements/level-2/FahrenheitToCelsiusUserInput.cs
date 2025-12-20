using System;

class FahrenheitToCelsiusUserInput {

	public static void Main(String[] args) {
	
	
	 Console.Write("Enter Temperature in Fahrenheit ");  //Creating  a variable and take the user's input.
	  
	  double farh=Convert.ToDouble(Console.ReadLine());	
	  
	//Use the formula: Fahrenheit to Celsius: (°F − 32) x 5/9 = °C
	  double cel = (farh-32)* 5.0/9.0;
		 
      Console.WriteLine("The " + farh + " Fahrenheit is " + cel + "  celsius");
		
		

	}

}
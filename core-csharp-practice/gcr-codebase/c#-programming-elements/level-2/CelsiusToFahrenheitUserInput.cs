using System;

   class CelsiusToFahrenheitUserInput {

	 static void Main(String[] args) {
	
	//Create a celsius variable and take the temperature as user input.
	
	  Console.Write("Enter Temperature in celsius ");
	  
	  
	  
	  double cel=Convert.ToDouble(Console.ReadLine());	
	  
	//Use the formula: Celsius to Fahrenheit: (°C × 9/5) + 32 = °F	

	
	  double farh= (cel*9.0/5) + 32;
	  
	  
      Console.WriteLine("The " + cel + " Celsius is " + farh + "  Fahrenheit");
		

	}

}

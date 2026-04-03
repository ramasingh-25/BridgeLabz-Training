using System;
  
     class DoubleOperation{
  
      static void Main(string[] args){
  
  //taking  inputs  from users
  
      Console.Write("Enter First Number ");
	  
	  double a=Convert.ToDouble(Console.ReadLine());
	  
	  Console.Write("Enter Second Number ");
	  
	  double b=Convert.ToDouble(Console.ReadLine());
	  
	  Console.Write("Enter Third Number ");
	  
	  double c=Convert.ToDouble(Console.ReadLine());
	  
	  
	  double operation2  = x * y + z;
	  
	  double operation3  =  z + x / y;
	  
	  double operation4  =  x % y + z;
	  
	  Console.WriteLine("The results of Double Operations are " + operation1 + "," + operation2 + "," + operation3 + " and " + operation4 );
	  
  }
  }
using System;
  
 class IntOperation{
  
  static void Main(string[] args){
  
  //take 3 number from users
  
  
      Console.Write("Enter First Number ");
	  
	  int a=Convert.ToInt32(Console.ReadLine());
	  
	  Console.Write("Enter Second Number ");
	  
	  int b=Convert.ToInt32(Console.ReadLine());
	  
	  Console.Write("Enter Third Number ");
	  
	  int c=Convert.ToInt32(Console.ReadLine());
	  
	  int operation1=a + b * c;
	  
	  int operation2=a * b + c;
	  
	  int operation3=c + a / b;
	  
	  int operation4=a % b + c;
	  
	  Console.WriteLine("The results of Int Operations are " + operation1 + "," + operation2 + "," 
	  + operation3 + " and " + operation4 );
  
  }
 }
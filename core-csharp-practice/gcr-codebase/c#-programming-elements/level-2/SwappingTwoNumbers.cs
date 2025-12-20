using System;
  
   class SwappingTwoNumbers{
  
    static void Main(string[] args){
  
  
    Console.Write("Enter First Number ");     //Create a variable n1 and n2 and take user input.
  
    int n1=Convert.ToInt32(Console.ReadLine());
  
    Console.Write("Enter Second Number ");
	
	int n2=Convert.ToInt32(Console.ReadLine());
	
	
	   int temp = n1;     //Swap n1 and n2 and print the swapped output.
        n1 = n2;
        n2 = temp;
		
		Console.WriteLine("The swapped numbers are " + n1 + " and " + n2);
		
  }
  }
using System;
  class QuotientAndReminderOfTwoNumber{
  
  static void Main(string[] args){
  
  //In this we find  Quotient and Remainder of Two Number by taking input from users
  
  
    Console.Write("Enter First Number ");
  
    int n1=Convert.ToInt32(Console.ReadLine());
  
    Console.Write("Enter Second Number ");
	
	int n2=Convert.ToInt32(Console.ReadLine());
	
	double QuotientOfTwonumber= n1/n2;
	
	double RemindertOfTwonumber= n1%n2;
	
	Console.WriteLine("The Quotient is " + QuotientOfTwonumber + " and Remainder is " 
	
	+ RemindertOfTwonumber + " of two numbers " + n1 + "and" + n2);
  }
  }
  
using System;

  class TotalIncomePerson{
  
   static void Main(string[] args) {
  
  
  
  //Create a variable named salary and take user input.
  Console.Write("Enter salary: ");
  
  double salaryperson = Convert.ToDouble(Console.ReadLine());
  
  Console.Write("Enter bonus: ");           //Create another variable bonus and take user input.

  
  double bonusperson = double.Parse(Console.ReadLine());
  
  double incomperson=salaryperson+bonusperson; //calculate the totle salary by add both salary and bonus
  
  Console.WriteLine("The salary is INR " + salaryperson + " and bonus is INR " + 
  bonusperson + " Hence Total Income is INR " + incomperson);
  
  }
  }
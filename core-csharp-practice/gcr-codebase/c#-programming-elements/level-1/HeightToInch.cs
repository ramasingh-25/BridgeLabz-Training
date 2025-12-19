using System;
  
  public class HeightToInch{
  public static void Main(String[] args){
  
  //taking input from user
  
  Console.Write("Enter Height in cm ");
  
  double HeightinCm=Convert.ToDouble(Console.ReadLine());
  
   //1 foot = 12 inches and 1 inch = 2.54 cm
   
   
   double totalInches = HeightinCm / 2.54;
   
   
   
    double foot = totalInches / 12;
    double inches = totalInches % 12;
	
	Console.WriteLine("Your Height in cm is " + HeightinCm + "while in feet is " + foot + " and inches is " + inches);
  
  
  }
  
  
  }
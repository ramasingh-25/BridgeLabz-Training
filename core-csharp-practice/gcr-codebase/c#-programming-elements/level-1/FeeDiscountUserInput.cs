using System;
  
  public class FeeDiscountUserInput{
  public static void Main(string[] args){
  //Taking user Input
  Console.Write("Enter fees: ");
  double fees=Convert.ToDouble(Console.ReadLine());
  
  
  Console.Write("Enter DiscountPercent: ");
  double DiscountPercent=Convert.ToDouble(Console.ReadLine());;
  
  //Calculating Discounted Amount
  
  double DiscountAmount= (fees*DiscountPercent)/100;
  double DiscountPrice= fees-DiscountAmount;
  
  Console.WriteLine("The discount amount is INR " + DiscountAmount + 
  "and final discounted fee is INR " + DiscountPrice);
  
  
  
  
  }
  

  }
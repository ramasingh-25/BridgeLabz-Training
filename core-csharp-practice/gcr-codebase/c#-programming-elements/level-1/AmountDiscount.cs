using System;
  
  public class AmountDiscount{
  public static void Main(string[] args){
  
  
  double fees=125000;
  double DiscountPercentage=10;
  
  
  double DiscountAmount= (fees*DiscountPercentage)/100;
  double DiscountPrice= fees-DiscountAmount;
  
  Console.WriteLine("The discount amount is INR " + DiscountAmount + 
  "and final discounted fee is INR " + DiscountPrice);
  
  
  
  
  }
  

  }
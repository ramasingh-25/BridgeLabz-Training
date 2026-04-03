using System;
  
  public class CostpriceSellingprice{
  public static void Main(string[] args){
  
  
  int CostP=129;
  int SellingP=191;
  
  long profit=SellingP-CostP;
  
  double profitPercentage= (profit/CostP)*100;
  
        
		
		Console.WriteLine(
            "The Cost Price is INR " + CostP + " and Selling Price is INR " + SellingP +
            "\nThe Profit is INR " + profit + " and the Profit Percentage is " + profitPercentage + "%");
       
  
  
  
  }
  
  
  
  }
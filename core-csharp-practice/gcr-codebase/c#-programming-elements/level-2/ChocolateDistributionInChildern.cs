using System;

  public class ChocolateDistributionInChildern{
  
  
  static void Main(string[] args) {
 
        Console.Write("Enter number of chocolates: ");         //Get an integer value from the user for numberOfChocolates and numberOfChildren.

        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of children: ");
        int  numberOfChildren = Convert.ToInt32(Console.ReadLine());

       
        int chocolatesEach = numberOfChocolates / numberOfChildren;  // calculations
        int  remainingChocolates = numberOfChocolates % numberOfChildren;

        Console.WriteLine("The number of chocolates each child gets is " +    chocolatesEach +
		" and the number of remaining chocolates is " + remainingChocolates );
    }
}
using System;

public class TotalPrice
{
	public static void Main(String[] args)
	{
	
	//Taking inputs from user
		Console.WriteLine("Enter unit price of an item :");
		int unitPrice = int.Parse(Console.ReadLine());

		Console.WriteLine("Enter the quantity to be bought :");
		int quantity = int.Parse(Console.ReadLine());
		int totalPrice = unitPrice * quantity;  // calculating the total price that we need to calculate

		Console.WriteLine("The total price is INR "+ totalPrice+" if the quantity "+ quantity +" and unit price is INR "+ unitPrice );		
	}
}
using System;

class BasicCalc
{
    static void Main()
    {
        double num1;
        double num2;
        //Taking Input From User
        Console.Write("Enter first no: ");
        num1 = Convert.ToDouble(Console.ReadLine());
        
        
        Console.Write("Enter second no: ");
        num2 = Convert.ToDouble(Console.ReadLine());
        
        //Performing Arithmatic Operation
        double add = num1 + num2;
        double sub = num1 - num2;
        double mul = num1 * num2;
        double div = num1 / num2;
		
		
        // Printing output for Calc
		
        Console.WriteLine("The addition, subtraction, multiplication and division value of 2 numbers " 
                          + num1 + " and " + num2 + " is " 
                          + add + ", " + sub + ", " 
                          + mul + ", and " + div);
    }
}
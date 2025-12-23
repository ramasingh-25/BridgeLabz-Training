using System;

 class SwitchCalculator
{
      static void Main()
    {
	
	//taking inputs from user
	
	
        Console.WriteLine("Enter first number:");
		
		
        double first = double.Parse(Console.ReadLine());
		
		

        Console.WriteLine("Enter second number:");
        double second = double.Parse(Console.ReadLine());
		
		

        Console.WriteLine("Enter operator (+, -, *, /):");
        string op = Console.ReadLine();
		
		// initializing variable result

        double result = 0;
        bool isValid = true;


//switch statement to perform operation

        switch (op)
        {
            case "+":
                result = first + second;
                break;
            case "-":
                result = first - second;
                break;
            case "*":
                result = first * second;
                break;
            case "/":
                result = first / second;
                break;
            default:
                Console.WriteLine("Invalid Operator");
                isValid = false;
                break;
        }
//condition
        if (isValid)
        {
		
		
            Console.WriteLine("Result: " + result);
        }
    }
}
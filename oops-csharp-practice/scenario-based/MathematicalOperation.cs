//using System;

//namespace project1.ScenarioBased
//{
//    class MathematicalOperation
//    {
//        // Calculates the factorial of a given non-negative number
//        public static int CalculateFactorial(int number)
//        {
//            if (number < 0)
//                throw new ArgumentException("Factorial cannot be calculated for negative numbers.");

//            int factorialResult = 1;

//            // Multiply numbers from 1 up to the given number
//            for (int counter = 1; counter <= number; counter++)
//            {
//                factorialResult *= counter;
//            }

//            return factorialResult;
//        }

//        // Checks whether the given number is a prime number
//        public static bool CheckPrime(int number)
//        {
//            if (number <= 1)
//                return false;

//            // Check divisibility up to square root of the number
//            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
//            {
//                if (number % divisor == 0)
//                    return false;
//            }

//            return true;
//        }

//        // Returns the Greatest Common Divisor (GCD) of two integers
//        public static int CalculateGCD(int firstNumber, int secondNumber)
//        {
//            firstNumber = Math.Abs(firstNumber);
//            secondNumber = Math.Abs(secondNumber);

//            // Apply Euclidean Algorithm
//            while (secondNumber != 0)
//            {
//                int remainder = firstNumber % secondNumber;
//                firstNumber = secondNumber;
//                secondNumber = remainder;
//            }

//            return firstNumber;
//        }

//        // Finds the Fibonacci number at the given position
//        public static long GetFibonacciAtPosition(int index)
//        {
//            if (index < 0)
//                throw new ArgumentException("Fibonacci position must be zero or greater.");

//            if (index == 0) return 0;
//            if (index == 1) return 1;

//            long previousValue = 0;
//            long currentValue = 1;

//            // Generate Fibonacci sequence up to the given index
//            for (int step = 2; step <= index; step++)
//            {
//                long nextValue = previousValue + currentValue;
//                previousValue = currentValue;
//                currentValue = nextValue;
//            }

//            return currentValue;
//        }
//    }

//    class ExecutionPoint
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine($"Factorial of 5: {MathematicalOperation.CalculateFactorial(5)}");
//            Console.WriteLine($"Is 7 a Prime Number?: {MathematicalOperation.CheckPrime(7)}");
//            Console.WriteLine($"GCD of 48 and 18: {MathematicalOperation.CalculateGCD(48, 18)}");
//            Console.WriteLine($"Fibonacci number at position 6: {MathematicalOperation.GetFibonacciAtPosition(6)}");
//        }
//    }
//}

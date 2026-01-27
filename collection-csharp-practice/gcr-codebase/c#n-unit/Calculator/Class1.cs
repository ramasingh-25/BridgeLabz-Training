using System;

namespace Calculator
{
    // Custom exception for divide by zero
    public class DivideByZeroCustomException : Exception
    {
        public DivideByZeroCustomException(string message) : base(message)
        {
        }
    }

    // Calculator class with basic operations
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroCustomException("Division by zero is not allowed");

            return a / b;
        }
    }
}

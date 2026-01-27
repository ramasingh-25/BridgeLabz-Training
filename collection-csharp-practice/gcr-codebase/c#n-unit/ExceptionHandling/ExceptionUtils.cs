using System;

namespace Calculator
{
    // Class to demonstrate exception handling
    public class ExceptionUtils
    {
        // Divide method that throws exception if b is zero
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new ArithmeticException("Cannot divide by zero");
            }

            return a / b;
        }
    }
}

    


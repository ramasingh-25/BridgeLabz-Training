using System;

namespace Calculator
{
    public class StringUtils
    {
        // Reverse a string
        public string Reverse(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        // Check palindrome
        public bool IsPalindrome(string str)
        {
            return str.Equals(Reverse(str), StringComparison.OrdinalIgnoreCase);
        }

        // Convert to uppercase
        public string ToUpperCase(string str)
        {
            return str.ToUpper();
        }
    }
}

using System.Text.RegularExpressions;

namespace Calculator
{
    // Validates password strength
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            if (password == null)
                return false;

            // At least 8 characters
            if (password.Length < 8)
                return false;

            // At least one uppercase letter
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // At least one digit
            if (!Regex.IsMatch(password, "[0-9]"))
                return false;

            return true;
        }
    }
}

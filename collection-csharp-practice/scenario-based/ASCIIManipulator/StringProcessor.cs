// using System;

// public class StringProcessor : IStringProcessor
// {
//     public bool IsValidInput(string input)
//     {
//         if (input == null || input.Length < 6)
//             return false;
        
//         foreach (char c in input)
//         {
//             if (!char.IsLetter(c))
//                 return false;
//         }
        
//         return true;
//     }
    
//     public string CleanseAndInvert(string input)
//     {
//         if (!IsValidInput(input))
//             return "";
        
//         string lowercase = input.ToLower();
//         string filtered = "";
        
//         foreach (char c in lowercase)
//         {
//             if (c % 2 != 0)
//                 filtered += c;
//         }
        
//         char[] reversed = filtered.ToCharArray();
//         Array.Reverse(reversed);
        
//         string result = "";
//         for (int i = 0; i < reversed.Length; i++)
//         {
//             if (i % 2 == 0)
//                 result += char.ToUpper(reversed[i]);
//             else
//                 result += reversed[i];
//         }
        
//         return result;
//     }
// }
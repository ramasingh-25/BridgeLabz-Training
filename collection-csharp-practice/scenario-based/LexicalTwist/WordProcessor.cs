// using System;
// using System.Linq;

// public class WordProcessor : IWordProcessor
// {
//     private readonly char[] vowels = { 'A', 'E', 'I', 'O', 'U' };
    
//     public bool IsValidWord(string word)
//     {
//         return !word.Contains(' ');
//     }
    
//     public bool IsReversed(string firstWord, string secondWord)
//     {
//         return string.Equals(firstWord, new string(secondWord.Reverse().ToArray()), StringComparison.OrdinalIgnoreCase);
//     }
    
//     public string ProcessReversedWords(string firstWord)
//     {
//         string reversed = new string(firstWord.Reverse().ToArray()).ToLower();
//         string result = "";
        
//         foreach (char c in reversed)
//         {
//             if ("aeiou".Contains(c))
//                 result += '@';
//             else
//                 result += c;
//         }
        
//         return result;
//     }
    
//     public string ProcessNonReversedWords(string firstWord, string secondWord)
//     {
//         string combined = (firstWord + secondWord).ToUpper();
//         int vowelCount = 0;
//         int consonantCount = 0;
        
//         foreach (char c in combined)
//         {
//             if (char.IsLetter(c))
//             {
//                 if (vowels.Contains(c))
//                     vowelCount++;
//                 else
//                     consonantCount++;
//             }
//         }
        
//         if (vowelCount == consonantCount)
//             return "Vowels and consonants are equal";
        
//         if (vowelCount > consonantCount)
//         {
//             string uniqueVowels = "";
//             foreach (char c in combined)
//             {
//                 if (vowels.Contains(c) && !uniqueVowels.Contains(c))
//                 {
//                     uniqueVowels += c;
//                     if (uniqueVowels.Length == 2) break;
//                 }
//             }
//             return uniqueVowels;
//         }
//         else
//         {
//             string uniqueConsonants = "";
//             foreach (char c in combined)
//             {
//                 if (char.IsLetter(c) && !vowels.Contains(c) && !uniqueConsonants.Contains(c))
//                 {
//                     uniqueConsonants += c;
//                     if (uniqueConsonants.Length == 2) break;
//                 }
//             }
//             return uniqueConsonants;
//         }
//     }
// }
// using System;

// public class Menu
// {
//     private IWordProcessor wordProcessor;
    
//     public Menu(IWordProcessor wordProcessor)
//     {
//         this.wordProcessor = wordProcessor;
//     }
    
//     public void Run()
//     {
//         Console.WriteLine("Enter the first word");
//         string firstWord = Console.ReadLine();
        
//         if (!wordProcessor.IsValidWord(firstWord))
//         {
//             Console.WriteLine($"{firstWord} is an invalid word");
//             return;
//         }
        
//         Console.WriteLine("Enter the second word");
//         string secondWord = Console.ReadLine();
        
//         if (!wordProcessor.IsValidWord(secondWord))
//         {
//             Console.WriteLine($"{secondWord} is an invalid word");
//             return;
//         }
        
//         if (wordProcessor.IsReversed(firstWord, secondWord))
//         {
//             string result = wordProcessor.ProcessReversedWords(firstWord);
//             Console.WriteLine(result);
//         }
//         else
//         {
//             string result = wordProcessor.ProcessNonReversedWords(firstWord, secondWord);
//             Console.WriteLine(result);
//         }
//     }
// }
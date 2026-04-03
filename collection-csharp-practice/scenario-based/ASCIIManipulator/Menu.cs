// using System;

// public class Menu
// {
//     private IStringProcessor stringProcessor;
    
//     public Menu(IStringProcessor stringProcessor)
//     {
//         this.stringProcessor = stringProcessor;
//     }
    
//     public void Run()
//     {
//         Console.WriteLine("Enter the word");
//         string input = Console.ReadLine();
        
//         string result = stringProcessor.CleanseAndInvert(input);
        
//         if (result == "")
//             Console.WriteLine("Invalid Input");
//         else
//             Console.WriteLine($"The generated key is - {result}");
//     }
// }
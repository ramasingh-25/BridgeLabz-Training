//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.ScenarioBased
//{
//    class TextCorrecting
//    {

//        public static String OneSpaceAfterPunctuation(String sentence)
//        {
//            StringBuilder updatedSentence = new StringBuilder();

//            for (int i = 0; i < sentence.Length; i++)
//            {
//                if (sentence[i] == ',' || sentence[i] == ':' || sentence[i] == ';' || sentence[i] == '?' || sentence[i] == '.' || sentence[i] == '!')
//                {
//                    updatedSentence.Append(sentence[i]);
//                    updatedSentence.Append(" ");

//                }
//                else
//                {

//                    updatedSentence.Append(sentence[i]);

//                }
//            }

//            return updatedSentence.ToString();
//        }

//        public static String Capitalizing(String sentence)
//        {
//            StringBuilder updatedSentence = new StringBuilder();

//            for (int i = 0; i < sentence.Length; i++)
//            {
//                if (i < sentence.Length - 2)
//                {
//                    if (sentence[i] == '.' || sentence[i] == '?' || sentence[i] == '!')
//                    {
//                        updatedSentence.Append(sentence[i]);
//                        updatedSentence.Append(sentence[i + 1]);
//                        updatedSentence.Append(char.ToUpper(sentence[i + 2]));
//                        i = i + 2;
//                    }
//                    else
//                    {
//                        updatedSentence.Append(sentence[i]);
//                    }
//                }
//                else
//                {
//                    updatedSentence.Append(sentence[i]);
//                }
//            }

//            return updatedSentence.ToString();
//        }

//        public static String RemoveDoubleSpaces(String sentence)
//        {
//            StringBuilder updatedSentence = new StringBuilder();

//            for (int i = 0; i < sentence.Length; i++)
//            {
//                if (i < sentence.Length - 1)
//                {
//                    if (sentence[i] == ' ' && sentence[i + 1] == ' ')
//                    {

//                    }
//                    else
//                    {
//                        updatedSentence.Append(sentence[i]);
//                    }
//                }
//                else
//                {
//                    updatedSentence.Append(sentence[i]);
//                }
//            }

//            return updatedSentence.ToString();
//        }

//        public static void Run()
//        {

//            Console.WriteLine("  Simple Text Editor Tool ");


//            Console.Write("Please enter text: ");
//            String userInput = Console.ReadLine();

//            bool Running = true;

//            while (Running)
//            {

//                Console.WriteLine($"CURRENT TEXT: {userInput}");

//                Console.WriteLine("1. Add Space After Punctuation");
//                Console.WriteLine("2. Capitalize Sentences");
//                Console.WriteLine("3. Remove Extra Spaces");
//                Console.WriteLine("4. Apply All Changes");
//                Console.WriteLine("5. Reset Text");
//                Console.WriteLine("6. Exit");

//                Console.Write("Select an option (1-6): ");

//                String selection = Console.ReadLine();

//                switch (selection)
//                {
//                    case "1":
//                        userInput = OneSpaceAfterPunctuation(userInput);
//                        Console.WriteLine(" > Punctuation spacing updated.");
//                        break;
//                    case "2":

//                        userInput = Capitalizing(userInput);
//                        Console.WriteLine(" > Capitalization updated.");
//                        break;

//                    case "3":
//                        userInput = RemoveDoubleSpaces(userInput);

//                        Console.WriteLine(" > Double spaces removed.");

//                        break;
//                    case "4":
//                        userInput = OneSpaceAfterPunctuation(userInput);
//                        userInput = Capitalizing(userInput);
//                        userInput = RemoveDoubleSpaces(userInput);
//                        Console.WriteLine(" > All formatting applied.");
//                        break;
//                    case "5":
//                        Console.Write("Enter new text: ");
//                        userInput = Console.ReadLine();
//                        break;
//                    case "6":
//                        Running = false;
//                        Console.WriteLine("Goodbye!");

//                        break;
//                    default:
//                        Console.WriteLine("Invalid selection. Try again.");
//                        break;
//                }
//            }
//        }

//        public static void Main(String[] args)
//        {

//            Run();

//        }
//    }
//}


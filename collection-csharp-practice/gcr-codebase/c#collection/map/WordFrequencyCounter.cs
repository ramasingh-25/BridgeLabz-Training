//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.Map
//{
//    class WordFrequencyCounter
//    {
//        static void Main()
//        {
//            string text = "Hello world, hello Java!";

//            // Convert to lowercase and remove punctuation
//            text = text.ToLower();
//            char[] separators = { ' ', ',', '!', '.', '?' };
//            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

//            Dictionary<string, int> wordCount = new Dictionary<string, int>();

//            foreach (string word in words)
//            {
//                if (wordCount.ContainsKey(word))
//                    wordCount[word]++;
//                else
//                    wordCount[word] = 1;
//            }

//            Console.WriteLine("Word Frequency:");
//            foreach (var pair in wordCount)
//            {
//                Console.WriteLine(pair.Key + " : " + pair.Value);
//            }
//        }
//    }
//    }

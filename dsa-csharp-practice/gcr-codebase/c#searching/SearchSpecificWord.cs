//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzDSA.Searching
//{

//    internal class SearchSpecificWord
//    {
//         static void Main(String[] args)
//        {
//            string[] sentences =
//            {
//            "hiii I am Rama ",
//            "I am a BridgeLabz trainee",
//            "I have studied in gla university",
//            "I am a passionate Software Enggineer"
//        };

//            string wordToSearch = "currently";

//            bool getword = false;

//            for (int i = 0; i < sentences.Length; i++)
//            {
//                if (sentences[i].ToLower().Contains(wordToSearch.ToLower()))
//                {
//                    Console.WriteLine("Word found:");

//                    Console.WriteLine(sentences[i]);
//                    getword = true;

//                    break;
//                }
//            }

//            if (!getword)
//            {
//                Console.WriteLine("No sentence contains this word:- " + wordToSearch);
//            }

//        }
//    }
//}


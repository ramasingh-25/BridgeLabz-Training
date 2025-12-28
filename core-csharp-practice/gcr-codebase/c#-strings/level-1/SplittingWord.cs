//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Strings
//{
//    class SplittingWord
   
//        {
//        //method to find lenght word
//            static int FindLength(string word)
//            {
//                int length = 0;

//                foreach (char ch in word)
//                {
//                    length++;
//                }

//                return length;
//            }

//            //splitting word 
//            static string[,] GetWordsAndLengths(string sentence)
//            {
//                List<string> words = new List<string>();
//                string word = "";

//                for (int i = 0; i < sentence.Length; i++)
//                {
//                    if (sentence[i] != ' ')
//                    {
//                        word += sentence[i];
//                    }
//                    else
//                    {
//                        if (word != "")
//                        {
//                            words.Add(word);
//                            word = "";
//                        }
//                    }
//                }

               

//                if (word != "")
//                {
//                    words.Add(word);
//                }

//                string[,] result = new string[words.Count, 2];

//                for (int i = 0; i < words.Count; i++)
//                {
//                    result[i, 0] = words[i];
//                    result[i, 1] = FindLength(words[i]).ToString();
//                }

//                return result;


//            }

//            static void Main(string[] args)
//            {
//                Console.Write("Enter a sentence: ");
//                string sentence = Console.ReadLine();

//                string[,] data = GetWordsAndLengths(sentence);

//                Console.WriteLine("\nWord\tLength");

//                for (int i = 0; i < data.GetLength(0); i++)
//                {
//                    Console.WriteLine(data[i, 0] + "\t" + data[i, 1]);


//                }
//            }
//        }
//    }


//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.Built_in
//{
//    class NumberGuessingGame

//    {
       
//          static void Main()
//            {
//                int low = 1, high = 100;
//                string feedback = "";

//                Console.WriteLine("Think of a number between 1 and 100.");

//                while (feedback != "correct")
//                {
//                    int guess = GenerateGuess(low, high);
//                    Console.WriteLine("Computer guesses: " + guess);

//                    feedback = GetFeedback();

//                    if (feedback == "high") high = guess - 1;
//                    else if (feedback == "low") low = guess + 1;
//                }

//                Console.WriteLine("Number guessed correctly!");
//            }
//        static int GenerateGuess(int low, int high)
//        {
//            return (low + high) / 2;
//        }

//        static string GetFeedback()
//        {
//            Console.Write("Is the guess high, low, or correct? ");
//            return Console.ReadLine().ToLower();
//        }

//    }

//    }
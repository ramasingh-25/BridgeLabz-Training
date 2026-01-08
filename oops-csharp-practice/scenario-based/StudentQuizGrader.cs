//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Oops.Scenario_Based
//{
//    public class StudentQuizGrader
//    {
        
//            static int CalculateScore(string[] correct, string[] student)
//            {
//                int score = 0;
//                for (int i = 0; i < correct.Length; i++)
//                {
//                    if (correct[i].Equals(student[i], StringComparison.OrdinalIgnoreCase))
//                    {
//                        Console.WriteLine("Question " + (i + 1) + ": correct");
//                        score++;
//                    }
//                    else
//                    {
//                        Console.WriteLine("Question " + (i + 1) + ": incorrect");
//                    }
//                }
//                return score;
//            }
//            static void Main()
//            {
//                string[] correctanswer = { "A", "D", "B", "D", "A", "B", "D", "A", "B", "C" };
//                string[] studentanswer = { "A", "C", "D", "D", "D", "A", "D", "D", "A", "C" };

//                int score = CalculateScore(correctanswer, studentanswer);
//                double prcnt = (double)score / correctanswer.Length * 100;
//                Console.WriteLine("Score: " + score + "/" + (correctanswer.Length));
//                Console.WriteLine($"Percentage: {prcnt:F2}%");
//                Console.WriteLine((score >= 5) ? "Result : Pass" : "Result : Fail");
//            }
//        }
//    }

//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.ScenarioBased.ExamProctor
//{
//    class ExamMenu
//    {
//        ExamUtility exam = new ExamUtility();

//        public void Start()
//        {
//            int choice = 0;

//            while (choice != 5)
//            {
//                Console.WriteLine("1. Visit Question");
//                Console.WriteLine("2. Answer Question");
//                Console.WriteLine("3. Show Last Visited");
//                Console.WriteLine("4. Submit Exam");
//                Console.WriteLine("5. Exit");

//                choice = int.Parse(Console.ReadLine());

//                if (choice == 1)
//                {
//                    Console.Write("Question ID ");
//                    exam.VisitQuestion(int.Parse(Console.ReadLine()));
//                }
//                else if (choice == 2)
//                {
//                    Console.Write("Question ID: ");
//                    int qid = int.Parse(Console.ReadLine());
//                    Console.Write("Answer (A/B/C/D): ");
//                    exam.AnswerQuestion(qid, Console.ReadLine());
//                }
//                else if (choice == 3)
//                {
//                    exam.ShowLastVisited();
//                }
//                else if (choice == 4)
//                {
//                    exam.SubmitExam();
//                    choice = 5;
//                }
//            }
//        }
//    }
//}
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgelabzCollection.ScenarioBased.ExamProctor
//{
//    class ExamUtility : IExamProctor
//    {
//        private QuestionStack navigation;
//        private CustomHashMap correctAnswers;
//        private CustomHashMap studentAnswers;

//        public ExamUtility()
//        {
//            navigation = new QuestionStack(20);
//            correctAnswers = new CustomHashMap(10);
//            studentAnswers = new CustomHashMap(10);

//            LoadExamPaper();
//        }

//        // predefined MCQ answers
//        private void LoadExamPaper()
//        {
//            correctAnswers.Put(1, "B");
//            correctAnswers.Put(2, "C");
//            correctAnswers.Put(3, "A");
//            correctAnswers.Put(4, "D");
//        }

//        public void VisitQuestion(int qid)
//        {
//            navigation.Push(qid);
//            Console.WriteLine("Visited Question " + qid);
//        }

//        public void AnswerQuestion(int qid, string answer)
//        {
//            if (correctAnswers.Get(qid) != null)
//            {
//                studentAnswers.Put(qid, answer);
//                Console.WriteLine("Answer saved.");
//            }
//            else
//            {
//                Console.WriteLine("Invalid Question ID.");
//            }
//        }

//        public void ShowLastVisited()
//        {
//            int last = navigation.Peek();
//            if (last == -1)
//                Console.WriteLine("No question visited.");
//            else
//                Console.WriteLine("Last visited question: " + last);
//        }

//        public void SubmitExam()
//        {
//            int score = CalculateScore();
//            Console.WriteLine("Exam Submitted.");
//            Console.WriteLine("Final Score: " + score);
//        }

//        // scoring function
//        private int CalculateScore()
//        {
//            int score = 0;

//            for (int i = 0; i < studentAnswers.Size(); i++)
//            {
//                int qid = studentAnswers.GetKeyAt(i);
//                if (studentAnswers.Get(qid) == correctAnswers.Get(qid))
//                {
//                    score++;
//                }
//            }
//            return score;
//        }
//    }
//}

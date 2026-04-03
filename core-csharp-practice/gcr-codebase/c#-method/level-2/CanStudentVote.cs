//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Project1.methods
//{
//    public class CanStudentVote
//    {
//        // check whether a student can vote
//        public static bool StudentVoteChecker(int a)
//        {

//            if (a < 0)
//            {
//                return false;
//            }

//            // Check voting eligibility
//            if (a >= 18)
//            {
//                return true;
//            }

//            return false;
//        }

//        static void Main(string[] args)
//        {
//            int[] age = new int[10];

//            for (int i = 0; i < age.Length; i++)
//            {
//                Console.Write("Enter age of student " + (i + 1) + ": ");
//                age[i] = Convert.ToInt32(Console.ReadLine());

//                bool canVote = StudentVoteChecker(age[i]);

//                if (canVote)
//                {
//                    Console.WriteLine("Student " + (i + 1) + " is eligible to vote.");
//                }
//                else
//                {
//                    Console.WriteLine("Student " + (i + 1) + " is NOT eligible to vote.");
//                }
//            }
//        }
//    }
//}
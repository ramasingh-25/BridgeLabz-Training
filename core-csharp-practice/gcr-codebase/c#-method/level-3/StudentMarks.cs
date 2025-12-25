//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace project1.methods
//{
//     class StudentMarks
    
//        {
//         static double[,] CalculateTotalAveragePercentage(int[,] scores, int numberOfStudents)


//            {


//                double[,] calculations = new double[numberOfStudents, 3];

//                for (int i = 0; i < numberOfStudents; i++)
//                {
//                    int physics = scores[i, 0];
//                    int chemistry = scores[i, 1];
//                    int math = scores[i, 2];
//                    double total = physics + chemistry + math;
//                    double average = total / 3.0;
//                    double percentage = (total / 300.0) * 100.0;
//                    calculations[i, 0] = Math.Round(total, 2);
//                    calculations[i, 1] = Math.Round(average, 2);
//                    calculations[i, 2] = Math.Round(percentage, 2);
//                }

//                return calculations;
//            }

//            static void DisplayScorecard(int numberOfStudents, int[,] scores, double[,] calculations)
//            {
//                Console.WriteLine();
//                Console.WriteLine("");
//                Console.WriteLine();

                
//                Console.WriteLine("Student\tPhysics\tChemistry\tMath\tTotal\tAverage\tPercentage");   // Print table header
//            Console.WriteLine("");

                
//                for (int i = 0; i < numberOfStudents; i++)  // Print each student's data
//            {
//                    int studentNumber = i + 1;
//                    int physics = scores[i, 0];
//                    int chemistry = scores[i, 1];
//                    int math = scores[i, 2];
//                    double total = calculations[i, 0];
//                    double average = calculations[i, 1];
//                    double percentage = calculations[i, 2];

//                    Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t{4}\t{5}\t{6}%",
//                        studentNumber, physics, chemistry, math, total, average, percentage);
//                }

//                Console.WriteLine("");
//            }
//        static void Main()
//        {
//            Console.WriteLine("");
//            Console.WriteLine();


//            Console.Write("Enter the number of students: "); 
//            int numberOfStudents = int.Parse(Console.ReadLine());


//            int[,] scores = GenerateScores(numberOfStudents);


//            double[,] calculations = CalculateTotalAveragePercentage(scores, numberOfStudents);


//            DisplayScorecard(numberOfStudents, scores, calculations);
//        }

//        static int[,] GenerateScores(int numberOfStudents)
//        {
//            int[,] scores = new int[numberOfStudents, 3];
//            Random random = new Random();

//            for (int i = 0; i < numberOfStudents; i++)
//            {
//                scores[i, 0] = random.Next(10, 100); 
//                scores[i, 1] = random.Next(10, 100);
//                scores[i, 2] = random.Next(10, 100); 
//            }

//            return scores;
//        }

//    }

//}


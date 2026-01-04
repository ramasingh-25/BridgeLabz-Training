using System;
using System.Collections.Generic;
using System.Text;

namespace project1.ScenarioBased
{
   class StudentMarksAnalyzer
   
        {
            static void ResultChecker(double[] marks)
            {

                while (true)
                {
                //menu-driven program

                    Console.WriteLine("SELECT AN OPTION");
                    Console.WriteLine("1. CALCULATE CLASS AVERAGE");
                    Console.WriteLine("2. DISPLAY HIGHEST AND LOWEST MARKS");
                    Console.WriteLine("3. SHOW STUDENTS SCORING ABOVE AVERAGE");
                    Console.WriteLine("4. VALIDATE INVALID MARKS");
                    Console.WriteLine("5. EXIT PROGRAM");

                    int choice = int.Parse(Console.ReadLine());

                //switch to perform selected operation

                    switch (choice)
                    {
                        case 1:

                            Console.WriteLine("Average of the class is " + AverageMarks(marks));
                            break;

                        case 2:
                            HighestAndLowest(marks);
                            break;

                        case 3:
                            AboveAverage(marks);
                            break;

                        case 4:
                        //handle with invalid options
                        CheckInvalidMarks(marks);
                            break;

                        case 5:
                            return;

                        default:
                        
                            Console.WriteLine("INVALID OPERATION");
                            break;
                    }
                }
            }
        //calculationg average marks of students
            public static double AverageMarks(double[] marks)
            {
                double total = 0.0;
                for (int i = 0; i < marks.Length; i++)
                {
                    total += marks[i];
                }
                return total / marks.Length;
            }
        //calculating highest and lowest
            public static void HighestAndLowest(double[] marks)
            {
                double max = 0.0;
                double min = double.MaxValue;

                for (int i = 0; i < marks.Length; i++)
                {
                    if (marks[i] > max) max = marks[i];
                    if (marks[i] < min) min = marks[i];
                }

                Console.WriteLine("Higest score is " + max + " Lowest Score is " + min);
            }
        //calculating above average marks
            public static void AboveAverage(double[] marks)
            {
                double avg = AverageMarks(marks);

                for (int i = 0; i < marks.Length; i++)
                {
                    if (marks[i] > avg)
                    {
                        Console.WriteLine(
                            "The student " + (i + 1) +
                            " got his score " + marks[i] +
                            " is higher than average (" + avg + ")"
                        );
                    }
                }
            }
        //checking invalid marks

            static void CheckInvalidMarks(double[] marks)
            {
                int limit = 0;

                for (int i = 0; i < marks.Length; i++)
                {
                    if (!(marks[i] >= limit))
                    {
                        Console.WriteLine(
                            "You input invalid marks of this student " +
                            (i + 1) +
                            " Input marks greater than or equal to 0"
                        );
                    }
                }
            }
        //main method
            static void Main(String[] args)
            {
            //taking input marks

                Console.WriteLine("Enter the number of students");
                int count = Convert.ToInt32(Console.ReadLine());

            //array to score student marks
                double[] marks = new double[count];

                Console.WriteLine("Enter the test scores of students");
                for (int i = 0; i < count; i++)
                {
                    marks[i] = double.Parse(Console.ReadLine());
                }

                ResultChecker(marks);
            }
        }
    }

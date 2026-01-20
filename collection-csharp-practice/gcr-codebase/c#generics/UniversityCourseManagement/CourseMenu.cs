using System;

namespace BridgelabzCollection.UniversityCourseManagement
{
    public class CourseMenu
    {
        public static void Start()
        {
            Course<ExamCourse> exam = new Course<ExamCourse>();
            Course<AssignmentCourse> assign = new Course<AssignmentCourse>();

            exam.Add(CourseUtility.GetExamCourse());
            assign.Add(CourseUtility.GetAssignCourse());

            Console.WriteLine("\n--- Exam Courses ---");
            exam.Show();

            Console.WriteLine("\n--- Assignment Courses ---");
            assign.Show();
        }
    }
}

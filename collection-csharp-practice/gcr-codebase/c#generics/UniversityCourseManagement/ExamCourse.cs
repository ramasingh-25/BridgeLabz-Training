using System;

namespace BridgelabzCollection.UniversityCourseManagement
{
    public class ExamCourse : CourseType
    {
        public int marks;

        public ExamCourse(string title, int credit, int marks)
            : base(title, credit)
        {
            this.marks = marks;
        }

        public override void Evaluate()
        {
            Console.WriteLine($"Exam Course: {title}, Marks: {marks}");
        }
    }
}

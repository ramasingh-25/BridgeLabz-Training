using System;

namespace BridgelabzCollection.UniversityCourseManagement
{
    public class AssignmentCourse : CourseType
    {
        public int score;

        public AssignmentCourse(string title, int credit, int score)
            : base(title, credit)
        {
            this.score = score;
        }

        public override void Evaluate()
        {
            Console.WriteLine($"Assignment Course: {title}, Score: {score}");
        }
    }
}

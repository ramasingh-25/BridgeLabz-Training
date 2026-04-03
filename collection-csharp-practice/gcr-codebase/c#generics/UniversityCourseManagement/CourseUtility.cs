using System;

namespace BridgelabzCollection.UniversityCourseManagement
{
    public class CourseUtility
    {
        public static ExamCourse GetExamCourse()
        {
            return new ExamCourse("Maths", 4, 85);
        }

        public static AssignmentCourse GetAssignCourse()
        {
            return new AssignmentCourse("Software Engg", 3, 90);
        }
    }
}

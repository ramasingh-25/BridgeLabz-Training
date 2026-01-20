using System;

namespace BridgelabzCollection.UniversityCourseManagement
{
    public interface ICourse<T> where T : CourseType
    {
        void Add(T course);
        void Show();
    }
}

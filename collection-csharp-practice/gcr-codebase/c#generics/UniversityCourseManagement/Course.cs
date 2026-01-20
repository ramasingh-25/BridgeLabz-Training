using System;
using System.Collections.Generic;

namespace BridgelabzCollection.UniversityCourseManagement
{
    public class Course<T> : ICourse<T> where T : CourseType
    {
        private List<T> list = new List<T>();

        public void Add(T course)
        {
            list.Add(course);
        }

        public void Show()
        {
            foreach (var c in list)
            {
                c.Evaluate();
            }
        }
    }
}

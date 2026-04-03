using System;
using System.Collections.Generic;

namespace BridgelabzCollection.AIResumeScreening
{
    public class Resume<T> where T : JobRole
    {
        private List<T> list = new List<T>();
        public void Add(T role)
        {
            list.Add(role);
        }
        public void Process()
        {
            foreach (var r in list)
            {
                r.Check();
            }
        }
    }
}

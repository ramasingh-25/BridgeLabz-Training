using System;

namespace BridgelabzCollection.AIResumeScreening
{
    public class ResumeUtility
    {
        public static void AddRole<T>(Resume<T> res, T role)
            where T : JobRole
        {
            res.Add(role);
        }
    }
}

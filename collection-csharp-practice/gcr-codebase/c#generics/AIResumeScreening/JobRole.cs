using System;

namespace BridgelabzCollection.AIResumeScreening
{
    public abstract class JobRole
    {
        public string name;
        public int exp;
        public JobRole(string name, int exp)
        {
            this.name = name;
            this.exp = exp;
        }
        public abstract void Check();
    }
}

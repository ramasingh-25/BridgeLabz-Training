using System;

namespace BridgelabzCollection.AIResumeScreening
{
    public class DataScientist : JobRole
    {
        public DataScientist(string name, int exp) : base(name, exp) { }
        public override void Check()
        {
            Console.WriteLine($"Data Scientist: {name}, Exp: {exp} yrs");
        }
    }
}

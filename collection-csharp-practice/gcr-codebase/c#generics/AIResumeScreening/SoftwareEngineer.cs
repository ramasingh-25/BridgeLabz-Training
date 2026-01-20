using System;

namespace BridgelabzCollection.AIResumeScreening
{
    public class SoftwareEngineer : JobRole
    {
        public SoftwareEngineer(string name, int exp)
            : base(name, exp)
        {
        }

        public override void Check()
        {
            Console.WriteLine($"Software Engineer: {name}, Exp: {exp} yrs");
        }
    }
}

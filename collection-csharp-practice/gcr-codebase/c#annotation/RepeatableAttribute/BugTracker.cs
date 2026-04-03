using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.RepeatableAttribute
{
    public class BugTracker
    {
        [BugReport("Null reference issue")]

        [BugReport("Performance problem on large input")]
        public void ProcessData()
        {
            Console.WriteLine("Processing data...");
        }
    }
}

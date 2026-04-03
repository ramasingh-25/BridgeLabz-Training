using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectFive.Annotation.RepeatableAttribute
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            Type type = typeof(BugTracker);
            MethodInfo method = type.GetMethod("ProcessData");

            object[] attributes =
                method.GetCustomAttributes(typeof(BugReportAttribute), false);

            foreach (BugReportAttribute bug in attributes)
            {
                Console.WriteLine("Bug: " + bug.Description);
            }
        }
    }
}

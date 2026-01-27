using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.CustomAttribute
{
    public class TaskManager
    {
        [TaskInfo("High", "Rishita")]
        public void CompleteTask()
        {
            Console.WriteLine("Task completed");
        }
    }
}

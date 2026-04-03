using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.TodoAttribute
{
   
        [AttributeUsage(AttributeTargets.Method)]
        class TodoAttribute : Attribute
        {
            public string Task { get; set; }
            public string AssignedTo { get; set; }
            public string Priority { get; set; }

            public TodoAttribute(string task, string assignedTo)
            {
                Task = task;
                AssignedTo = assignedTo;
                Priority = "MEDIUM";   // default value
            }
        }
}

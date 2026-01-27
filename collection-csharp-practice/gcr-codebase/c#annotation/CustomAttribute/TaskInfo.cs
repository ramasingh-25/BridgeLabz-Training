using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.CustomAttribute
{
        [AttributeUsage(AttributeTargets.Method)]
        class TaskInfo : Attribute
        {
            public string Priority { get; set; }
            public string AssignedTo { get; set; }

            public TaskInfo(string priority, string assignedTo)
            {
                Priority = priority;
                AssignedTo = assignedTo;
            }

        }
    }


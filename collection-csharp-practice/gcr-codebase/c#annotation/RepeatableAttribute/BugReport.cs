using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.RepeatableAttribute
{
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        class BugReportAttribute : Attribute
        {
            public string Description { get; set; }

            public BugReportAttribute(string description)
            {
                Description = description;
            }
        }
    }


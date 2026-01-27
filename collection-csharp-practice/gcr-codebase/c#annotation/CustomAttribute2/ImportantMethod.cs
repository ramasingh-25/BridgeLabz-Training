using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.CustomAttribute2
{

        [AttributeUsage(AttributeTargets.Method)]
        class ImportantMethod : Attribute
        {
            public string Level { get; set; }

            public ImportantMethod(string level = "HIGH")
            {
                Level = level;
            }
        }
    }


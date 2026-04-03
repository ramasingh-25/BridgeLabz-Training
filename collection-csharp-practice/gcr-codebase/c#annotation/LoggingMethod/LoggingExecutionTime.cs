using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.LoggingMethod
{
  
        [AttributeUsage(AttributeTargets.Method)]
        class LoggingExecutionTime : Attribute
        {
            
        }
    }


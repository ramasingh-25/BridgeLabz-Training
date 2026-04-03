using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.MaxLengthAttribute
{
  
        [AttributeUsage(AttributeTargets.Field)]
        class MaxLength : Attribute
        {
            public int Value { get; }

            public MaxLength(int value)
            {
                Value = value;
            }
        }
}

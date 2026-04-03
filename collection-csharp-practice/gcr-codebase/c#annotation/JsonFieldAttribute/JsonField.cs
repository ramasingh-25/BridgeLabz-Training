using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.JsonFieldAttribute
{
    
        [AttributeUsage(AttributeTargets.Field)]
        class JsonField : Attribute
        {
            public string Name { get; set; }
        }
    }


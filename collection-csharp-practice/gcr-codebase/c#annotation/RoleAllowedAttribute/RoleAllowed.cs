using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.RoleAllowedAttribute
{
 

        [AttributeUsage(AttributeTargets.Method)]
        class RoleAllowed : Attribute
        {
            public string Role { get; }

            public RoleAllowed(string role)
            {
                Role = role;
            }

        }
    }

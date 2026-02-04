using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabz.Collections.Senario.HealthCheckProApp
{

    [AttributeUsage(AttributeTargets.Method)]
    class PublicAPIAttribute : Attribute
    {
        public string Description;

        public PublicAPIAttribute(string description)
        {
            Description = description;
        }
    }

    // Attribute for authentication
    [AttributeUsage(AttributeTargets.Method)]
    class RequiresAuthAttribute : Attribute
    {
        public string Role;

        public RequiresAuthAttribute(string role)
        {
            Role = role;
        }
    }

    // Controller class
    class LabTestController
    {
        [PublicAPI("Get all lab tests")]
        public void GetAllTests()
        {
        }

        [PublicAPI("Book lab test")]
        [RequiresAuth("Doctor")]
        public void BookTest()
        {
        }

        public void InternalMethod()
        {
        }
    }

}

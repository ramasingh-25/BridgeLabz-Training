using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.TodoAttribute
{
    public class ProjectTask
    {

        [Todo("Implement login feature", "Rishita", Priority = "HIGH")]
        public void Login()
        {
            
        }

        [Todo("Add error handling", "Rama")]
        public void ErrorHandling()
        {
            
        }

        [Todo("Optimize database queries", "Neha", Priority = "LOW")]
        public void OptimizeDB()
        {
            
        }
    }
}

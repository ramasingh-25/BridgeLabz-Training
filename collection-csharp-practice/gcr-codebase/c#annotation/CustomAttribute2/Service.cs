using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.CustomAttribute2
{
    public class Service
    {
        [ImportantMethod]   
        public void ProcessPayment()
        {
            Console.WriteLine("Processing payment");
        }

        [ImportantMethod("LOW")]
        public void LogActivity()
        {
            Console.WriteLine("Logging activity");
        }

        public void HelperMethod()
        {
            Console.WriteLine("Helper method");
        }
    }
}

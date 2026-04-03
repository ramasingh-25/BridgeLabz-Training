using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFive.Annotation.LoggingMethod
{
    public class Worker
    {

        [LoggingExecutionTime]
        public void FastMethod()
        {
            Thread.Sleep(300);
        }

        [LoggingExecutionTime]
        public void SlowMethod()
        {
            Thread.Sleep(1000); 
        }

        public void NormalMethod()
        {
            Thread.Sleep(200);
        }
    }
}

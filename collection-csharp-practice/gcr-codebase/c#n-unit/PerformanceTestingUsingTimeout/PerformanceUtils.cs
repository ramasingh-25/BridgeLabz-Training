using System.Threading;

namespace Calculator
{
    // Class to simulate long running task
    public class PerformanceUtils
    {
        // Sleeps for 3 seconds
        public string LongRunningTask()
        {
            Thread.Sleep(3000); // 3 seconds
            return "Completed";
        }
    }
}

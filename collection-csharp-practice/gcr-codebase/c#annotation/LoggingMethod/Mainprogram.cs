using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ProjectFive.Annotation.LoggingMethod
{
    public class Mainprogram
    {
        public static void Main(string[] args)
        {
            Worker worker = new Worker();
            Type type = typeof(Worker);

            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
               
                if (Attribute.IsDefined(method, typeof(LoggingExecutionTime)))
                {
                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    method.Invoke(worker, null);
                    sw.Stop();

                    Console.WriteLine(
                        $"Method: {method.Name}, Execution Time: {sw.ElapsedMilliseconds} ms");
                }
            }
        }
    }
}
